using System;
using System.Data;
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
        }

        public frmEmpleados(int idEmpleado) : this()
        {
            _idEmpleado = idEmpleado;
        }

        private void frmEmpleados_Load(object? sender, EventArgs e)
        {
            ConfigurarFormulario();
            CargarRoles();

            if (_idEmpleado > 0)
            {
                lblTitulo.Text = "Editar Empleado";
                txtGuardar.Text = "Actualizar";
                CargarEmpleado();
            }
            else
            {
                lblTitulo.Text = "Nuevo Empleado";
                txtGuardar.Text = "Guardar";
            }
        }

        private void ConfigurarFormulario()
        {
            dtpFechaIngreso.Value = DateTime.Today;
            dtpFechaRetiro.Value = DateTime.Today;
            dtpFechaRetiro.ShowCheckBox = true;
            dtpFechaRetiro.Checked = false;
        }

        private void CargarRoles()
        {
            try
            {
                DataTable dt = nEmpleados.ListarRoles();
                cmbRol.DataSource = dt;
                cmbRol.DisplayMember = "NombreRol";
                cmbRol.ValueMember = "IdRol";
                cmbRol.SelectedIndex = -1;
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
                txtDetalles.Text = row["Detalles"]?.ToString() ?? string.Empty;

                if (row["IdRol"] != DBNull.Value)
                    cmbRol.SelectedValue = row["IdRol"];

                if (row["FechaIngreso"] != DBNull.Value)
                    dtpFechaIngreso.Value = Convert.ToDateTime(row["FechaIngreso"]);

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

        private void txtGuardar_Click(object sender, EventArgs e)
        {
            if (!Validaciones.ValidarCamposRequeridos(
                (txtNombreEmpleado, "Nombre Empleado"),
                (txtDocumento, "Documento")))
                return;

            if (!Validaciones.EsEmailValido(txtEmail, "Email", false))
                return;

            if (!Validaciones.ComboBoxSeleccionado(cmbRol, "Rol"))
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
                string rol = cmbRol.Text.Trim();
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
            Close();
        }
    }
}