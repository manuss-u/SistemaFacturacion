using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CapaNegocio;

namespace PantallasSistemaFacturacion
{
    public partial class frmEmpleados : Form
    {
        private readonly NEmpleados nEmpleados = new NEmpleados();
        private int _idEmpleado = 0;

        public frmEmpleados()
        {
            InitializeComponent();
            this.Load += frmEmpleados_Load;
            txtGuardar.Click += btnGuardar_Click;
            ConfigurarFormulario();
        }
          
        public frmEmpleados(int idEmpleado) : this()
        {
            _idEmpleado = idEmpleado;
        }

        private void ConfigurarFormulario()
        {
            dtpFechaIngreso.Value = DateTime.Today;
            dtpFechaRetiro.Value = DateTime.Today;
            dtpFechaRetiro.ShowCheckBox = true;
            dtpFechaRetiro.Checked = false;

            txtRol.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            txtRol.AutoCompleteSource = AutoCompleteSource.CustomSource;
        }

        private void frmEmpleados_Load(object? sender, EventArgs e)
        {
            CargarRoles();

            if (_idEmpleado == 0)
            {
                lblTitulo.Text = "Nuevo Empleado";
                txtGuardar.Text = "Guardar";
            }
            else
            {
                lblTitulo.Text = "Editar Empleado";
                txtGuardar.Text = "Actualizar";
                CargarEmpleado();
            }
        }

        private void CargarRoles()
        {
            try
            {
                DataTable dt = nEmpleados.ListarRoles();
                AutoCompleteStringCollection roles = new AutoCompleteStringCollection();

                foreach (DataRow row in dt.Rows)
                {
                    string nombreRol = row["NombreRol"]?.ToString() ?? string.Empty;
                    if (!string.IsNullOrWhiteSpace(nombreRol))
                        roles.Add(nombreRol);
                }

                txtRol.AutoCompleteCustomSource = roles;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar roles: {ex.Message}",
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CargarEmpleado()
        {
            try
            {
                DataTable dt = nEmpleados.ObtenerEmpleadoPorId(_idEmpleado);
                if (dt.Rows.Count == 0) return;

                DataRow row = dt.Rows[0];
                txtNombreEmpleado.Text = row["Nombre"]?.ToString() ?? string.Empty;
                txtDocumento.Text = row["Documento"]?.ToString() ?? string.Empty;
                txtDireccion.Text = row["Direccion"]?.ToString() ?? string.Empty;
                txtTelefono.Text = row["Telefono"]?.ToString() ?? string.Empty;
                txtEmail.Text = row["Email"]?.ToString() ?? string.Empty;
                txtRol.Text = row["Rol"]?.ToString() ?? string.Empty;
                txtDetalles.Text = row["Detalles"]?.ToString() ?? string.Empty;

                if (DateTime.TryParse(row["FechaIngreso"]?.ToString(), out DateTime fechaIngreso))
                    dtpFechaIngreso.Value = fechaIngreso;

                if (row["FechaRetiro"] == DBNull.Value || string.IsNullOrWhiteSpace(row["FechaRetiro"]?.ToString()))
                {
                    dtpFechaRetiro.Checked = false;
                }
                else
                {
                    dtpFechaRetiro.Checked = true;
                    dtpFechaRetiro.Value = Convert.ToDateTime(row["FechaRetiro"]);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar empleado: {ex.Message}",
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnGuardar_Click(object? sender, EventArgs e)
        {
            if (!Validaciones.ValidarCamposRequeridos((txtNombreEmpleado, "Nombre Empleado")))
                return;

            if (!Validaciones.EsEmailValido(txtEmail, "Email"))
                return;

            DateTime fechaIngreso = dtpFechaIngreso.Value.Date;
            DateTime? fechaRetiro = dtpFechaRetiro.Checked ? dtpFechaRetiro.Value.Date : null;

            if (fechaRetiro.HasValue && fechaRetiro.Value < fechaIngreso)
            {
                MessageBox.Show("La fecha de retiro no puede ser menor que la fecha de ingreso.",
                    "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                string nombre = txtNombreEmpleado.Text.Trim();
                string documento = txtDocumento.Text.Trim();
                string direccion = txtDireccion.Text.Trim();
                string telefono = txtTelefono.Text.Trim();
                string email = txtEmail.Text.Trim();
                string rol = txtRol.Text.Trim();
                string detalles = txtDetalles.Text.Trim();

                if (_idEmpleado == 0)
                {
                    nEmpleados.InsertarEmpleado(nombre, documento, direccion, telefono, email, rol, fechaIngreso, fechaRetiro, detalles);
                    MessageBox.Show("Empleado guardado correctamente.",
                        "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    nEmpleados.ActualizarEmpleado(_idEmpleado, nombre, documento, direccion, telefono, email, rol, fechaIngreso, fechaRetiro, detalles);
                    MessageBox.Show("Empleado actualizado correctamente.",
                        "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                DialogResult = DialogResult.OK;
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al guardar empleado: {ex.Message}",
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
