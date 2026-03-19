using CapaDatos;
using System;
using System.Windows.Forms;
using CapaNegocio;


namespace PantallasSistemaFacturacion
{
    public partial class frmListaEmpleados : Form
    {
<<<<<<< HEAD
        private readonly NEmpleados nEmpleados = new NEmpleados();
=======
        private readonly DALEmpleados dalEmpleados = new DALEmpleados();
>>>>>>> f9ccecfcae657d7b8908920b3870b398ff8df57d

        public frmListaEmpleados()
        {
            InitializeComponent();
            this.Load += frmListaEmpleados_Load;
            btnBuscar.Click += btnBuscar_Click;
            btnEliminar.Click += btnEliminar_Click;
        }

        private void frmListaEmpleados_Load(object? sender, EventArgs e)
        {
            CargarEmpleados();
        }

        private void CargarEmpleados()
        {
            try
            {
                dgvEmpleados.DataSource = nEmpleados.ListarEmpleados();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar empleados: {ex.Message}",
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnBuscar_Click(object? sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(txtBuscar.Text))
                    dgvEmpleados.DataSource = nEmpleados.ListarEmpleados();
                else
                    dgvEmpleados.DataSource = nEmpleados.BuscarEmpleados(txtBuscar.Text.Trim());
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al buscar empleados: {ex.Message}",
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void frmListaEmpleados_Load(object? sender, EventArgs e)
        {
            CargarEmpleados();
        }

        private void CargarEmpleados()
        {
            try
            {
                dgvEmpleados.DataSource = dalEmpleados.ListarEmpleados();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar empleados: {ex.Message}",
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnBuscar_Click(object? sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(txtBuscar.Text))
                    dgvEmpleados.DataSource = dalEmpleados.ListarEmpleados();
                else
                    dgvEmpleados.DataSource = dalEmpleados.BuscarEmpleados(txtBuscar.Text.Trim());
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al buscar: {ex.Message}",
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            using (var f = new frmEmpleados())
            {
                if (f.ShowDialog() == DialogResult.OK)
                    CargarEmpleados();
            }
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (dgvEmpleados.SelectedRows.Count == 0)
            {
                MessageBox.Show("Seleccione un empleado de la lista para editar.",
                    "Sin selección", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

<<<<<<< HEAD
            int idEmpleado = Convert.ToInt32(dgvEmpleados.SelectedRows[0].Cells["IdEmpleado"].Value);

            using (var f = new frmEmpleados(idEmpleado))
=======
            int id = Convert.ToInt32(dgvEmpleados.SelectedRows[0].Cells["IdEmpleado"].Value);
            using (var f = new frmEmpleados(id))
>>>>>>> f9ccecfcae657d7b8908920b3870b398ff8df57d
            {
                if (f.ShowDialog() == DialogResult.OK)
                    CargarEmpleados();
            }
        }

        private void btnEliminar_Click(object? sender, EventArgs e)
        {
            if (dgvEmpleados.SelectedRows.Count == 0)
            {
<<<<<<< HEAD
                MessageBox.Show("Seleccione un empleado de la lista para eliminar.",
=======
                MessageBox.Show("Seleccione un empleado de la lista para eliminarlo.",
>>>>>>> f9ccecfcae657d7b8908920b3870b398ff8df57d
                    "Sin selección", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

<<<<<<< HEAD
            DialogResult confirmar = MessageBox.Show("¿Está seguro de eliminar este empleado?",
                "Confirmar eliminación", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (confirmar != DialogResult.Yes)
                return;

            try
            {
                int idEmpleado = Convert.ToInt32(dgvEmpleados.SelectedRows[0].Cells["IdEmpleado"].Value);
                nEmpleados.EliminarEmpleado(idEmpleado);
=======
            var confirmar = MessageBox.Show(
                "¿Está seguro de que desea eliminar este empleado?",
                "Confirmar eliminación", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (confirmar != DialogResult.Yes) return;

            try
            {
                int id = Convert.ToInt32(dgvEmpleados.SelectedRows[0].Cells["IdEmpleado"].Value);
                dalEmpleados.EliminarEmpleado(id);
>>>>>>> f9ccecfcae657d7b8908920b3870b398ff8df57d
                CargarEmpleados();
            }
            catch (Exception ex)
            {
<<<<<<< HEAD
                MessageBox.Show($"Error al eliminar empleado: {ex.Message}",
=======
                MessageBox.Show($"Error al eliminar: {ex.Message}",
>>>>>>> f9ccecfcae657d7b8908920b3870b398ff8df57d
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
<<<<<<< HEAD
            Close();
=======
            this.Close();
>>>>>>> f9ccecfcae657d7b8908920b3870b398ff8df57d
        }
    }
}
