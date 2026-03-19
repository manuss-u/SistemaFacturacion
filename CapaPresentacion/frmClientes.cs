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
    public partial class frmClientes : Form
    {
        private readonly DALClientes dalClientes = new DALClientes();

        public frmClientes()
        {
            InitializeComponent();
            this.Load += frmClientes_Load;
            btnBuscar.Click += btnBuscar_Click;
            btnEliminar.Click += btnEliminar_Click;
            btnActualizar.Click += btnActualizar_Click;
        }

        private void frmClientes_Load(object? sender, EventArgs e)
        {
            CargarClientes();
        }

        private void CargarClientes()
        {
            try
            {
                dgvClientes.DataSource = dalClientes.ListarClientes();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar clientes: {ex.Message}",
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnBuscar_Click(object? sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(txtBuscar.Text))
                    dgvClientes.DataSource = dalClientes.ListarClientes();
                else
                    dgvClientes.DataSource = dalClientes.BuscarClientes(txtBuscar.Text.Trim());
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al buscar: {ex.Message}",
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnActualizar_Click(object? sender, EventArgs e)
        {
            txtBuscar.Clear();
            CargarClientes();
        }

        private void btnEliminar_Click(object? sender, EventArgs e)
        {
            if (dgvClientes.SelectedRows.Count == 0)
            {
                MessageBox.Show("Seleccione un cliente de la lista para eliminarlo.",
                    "Sin selección", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var confirmar = MessageBox.Show("¿Está seguro de que desea eliminar este cliente?",
                "Confirmar eliminación", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (confirmar != DialogResult.Yes) return;

            try
            {
                int id = Convert.ToInt32(dgvClientes.SelectedRows[0].Cells["IdCliente"].Value);
                dalClientes.EliminarCliente(id);
                CargarClientes();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al eliminar: {ex.Message}",
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (dgvClientes.SelectedRows.Count == 0)
            {
                MessageBox.Show("Seleccione un cliente de la lista para editar.",
                    "Sin selección", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int id = Convert.ToInt32(dgvClientes.SelectedRows[0].Cells["IdCliente"].Value);
            using (var f = new frmClientesEditar(id))
            {
                if (f.ShowDialog() == DialogResult.OK)
                    CargarClientes();
            }
        }

        private void btnNuevo_Click_1(object sender, EventArgs e)
        {
            using (var f = new frmClientesEditar())
            {
                if (f.ShowDialog() == DialogResult.OK)
                    CargarClientes();
            }
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void label1_Click(object sender, EventArgs e) { }
        private void button1_Click(object sender, EventArgs e) { }

        private void btnBuscar_Click_1(object sender, EventArgs e)
        {

        }
    }
}
