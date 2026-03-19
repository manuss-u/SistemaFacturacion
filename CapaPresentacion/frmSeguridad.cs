using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CapaDatos;

namespace PantallasSistemaFacturacion
{
    public partial class frmSeguridad : Form
    {
        private readonly DALSeguridad dalSeguridad = new DALSeguridad();

        public frmSeguridad()
        {
            InitializeComponent();
            this.Load += frmSeguridad_Load;
            txtGuardar.Click += btnActualizarSeguridad_Click;
            cmbEmpleado.SelectedIndexChanged += cmbEmpleado_SelectedIndexChanged;
        }

        private void frmSeguridad_Load(object? sender, EventArgs e)
        {
            CargarUsuarios();
        }

        private void CargarUsuarios()
        {
            try
            {
                DataTable dt = dalSeguridad.ListarUsuariosSistema();
                cmbEmpleado.DataSource = dt;
                cmbEmpleado.DisplayMember = "Usuario";
                cmbEmpleado.ValueMember = "IdUsuario";
                cmbEmpleado.SelectedIndex = -1;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar usuarios: {ex.Message}",
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void cmbEmpleado_SelectedIndexChanged(object? sender, EventArgs e)
        {
            if (cmbEmpleado.SelectedIndex < 0) return;

            DataRowView row = (DataRowView)cmbEmpleado.SelectedItem!;
            txtUsuario.Text = row["Usuario"].ToString();
            txtClave.Text = string.Empty;

            Validaciones.LimpiarError(txtUsuario);
            Validaciones.LimpiarError(txtClave);
        }

        private void btnActualizarSeguridad_Click(object? sender, EventArgs e)
        {
            if (!Validaciones.ComboBoxSeleccionado(cmbEmpleado, "Usuario del sistema")) return;
            if (!Validaciones.ValidarCamposRequeridos((txtUsuario, "Nombre de usuario"))) return;
            if (!Validaciones.EsClaveValida(txtClave, 6)) return;

            try
            {
                int idUsuario = Convert.ToInt32(cmbEmpleado.SelectedValue);
                dalSeguridad.ActualizarUsuario(idUsuario, txtUsuario.Text.Trim(), txtClave.Text);

                MessageBox.Show("Usuario actualizado correctamente.",
                    "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);

                txtClave.Clear();
                CargarUsuarios();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al actualizar: {ex.Message}",
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtUsuario_TextChanged(object sender, EventArgs e)
        {
            Validaciones.LimpiarError(txtUsuario);
        }

        private void txtClave_TextChanged(object sender, EventArgs e)
        {
            Validaciones.LimpiarError(txtClave);
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtGuardar_Click(object sender, EventArgs e)
        {

        }

        private void frmSeguridad_Load_1(object sender, EventArgs e)
        {

        }
    }
}
