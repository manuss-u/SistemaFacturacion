using CapaDatos;
using System;
using System.Data;
using System.Windows.Forms;
using CapaNegocio;

namespace PantallasSistemaFacturacion
{
    public partial class frmEmpleados : Form
    {
<<<<<<< HEAD
        private readonly NEmpleados nEmpleados = new NEmpleados();
=======
        private readonly DALEmpleados dalEmpleados = new DALEmpleados();
>>>>>>> f9ccecfcae657d7b8908920b3870b398ff8df57d
        private int _idEmpleado = 0;

        public frmEmpleados()
        {
            InitializeComponent();
            this.Load += frmEmpleados_Load;
<<<<<<< HEAD
            txtGuardar.Click += btnGuardar_Click;
            ConfigurarFormulario();
        }
          
=======
        }

>>>>>>> f9ccecfcae657d7b8908920b3870b398ff8df57d
        public frmEmpleados(int idEmpleado) : this()
        {
            _idEmpleado = idEmpleado;
        }

<<<<<<< HEAD
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
=======
        private void frmEmpleados_Load(object? sender, EventArgs e)
        {
            CargarRoles();
            if (_idEmpleado > 0)
>>>>>>> f9ccecfcae657d7b8908920b3870b398ff8df57d
            {
                lblTitulo.Text = "Editar Empleado";
                txtGuardar.Text = "Actualizar";
                CargarEmpleado();
            }
<<<<<<< HEAD
=======
            else
            {
                lblTitulo.Text = "Nuevo Empleado";
                txtGuardar.Text = "Guardar";
            }
>>>>>>> f9ccecfcae657d7b8908920b3870b398ff8df57d
        }

        private void CargarRoles()
        {
            try
            {
<<<<<<< HEAD
                DataTable dt = nEmpleados.ListarRoles();
                AutoCompleteStringCollection roles = new AutoCompleteStringCollection();

                foreach (DataRow row in dt.Rows)
                {
                    string nombreRol = row["NombreRol"]?.ToString() ?? string.Empty;
                    if (!string.IsNullOrWhiteSpace(nombreRol))
                        roles.Add(nombreRol);
                }

                txtRol.AutoCompleteCustomSource = roles;
=======
                DataTable dt = dalEmpleados.ListarRoles();
                cmbRol.DataSource    = dt;
                cmbRol.DisplayMember = "NombreRol";
                cmbRol.ValueMember   = "IdRol";
                cmbRol.SelectedIndex = -1;
>>>>>>> f9ccecfcae657d7b8908920b3870b398ff8df57d
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
<<<<<<< HEAD
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
=======
                DataTable dt = dalEmpleados.ObtenerEmpleadoPorId(_idEmpleado);
                if (dt.Rows.Count == 0) return;

                DataRow row = dt.Rows[0];
                txtNombreEmpleado.Text = row["Nombre"].ToString();
                txtDocumento.Text      = row["Documento"].ToString();
                txtDireccion.Text      = row["Direccion"].ToString();
                txtTelefono.Text       = row["Telefono"].ToString();
                txtEmail.Text          = row["Email"].ToString();
                cmbRol.SelectedValue   = row["IdRol"];
                txtDetalles.Text       = row["Detalles"].ToString();

                if (row["FechaIngreso"] != DBNull.Value)
                    dtpFechaIngreso.Value = Convert.ToDateTime(row["FechaIngreso"]);

                if (row["FechaRetiro"] != DBNull.Value)
                {
                    dtpFechaRetiro.Checked = true;
                    dtpFechaRetiro.Value   = Convert.ToDateTime(row["FechaRetiro"]);
                }
                else
                {
                    dtpFechaRetiro.Checked = false;
>>>>>>> f9ccecfcae657d7b8908920b3870b398ff8df57d
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar empleado: {ex.Message}",
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

<<<<<<< HEAD
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
=======
        private void txtGuardar_Click(object sender, EventArgs e)
        {
            if (!Validaciones.ValidarCamposRequeridos(
                (txtNombreEmpleado, "Nombre Empleado"),
                (txtDocumento,      "Documento"))) return;

            if (!Validaciones.EsEmailValido(txtEmail, "Email", false)) return;
            if (!Validaciones.ComboBoxSeleccionado(cmbRol, "Rol")) return;

            try
            {
                string    nombre       = txtNombreEmpleado.Text.Trim();
                string    documento    = txtDocumento.Text.Trim();
                string    direccion    = txtDireccion.Text.Trim();
                string    telefono     = txtTelefono.Text.Trim();
                string    email        = txtEmail.Text.Trim();
                int       idRol        = Convert.ToInt32(cmbRol.SelectedValue);
                DateTime  fechaIngreso = dtpFechaIngreso.Value.Date;
                DateTime? fechaRetiro  = dtpFechaRetiro.Checked ? dtpFechaRetiro.Value.Date : (DateTime?)null;
                string    detalles     = txtDetalles.Text.Trim();

                if (_idEmpleado == 0)
                    dalEmpleados.InsertarEmpleado(nombre, documento, direccion, telefono,
                        email, idRol, fechaIngreso, fechaRetiro, detalles);
                else
                    dalEmpleados.ActualizarEmpleado(_idEmpleado, nombre, documento, direccion,
                        telefono, email, idRol, fechaIngreso, fechaRetiro, detalles);

                MessageBox.Show(
                    _idEmpleado == 0 ? "Empleado creado correctamente." : "Empleado actualizado correctamente.",
                    "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);

                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al guardar: {ex.Message}",
>>>>>>> f9ccecfcae657d7b8908920b3870b398ff8df57d
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
