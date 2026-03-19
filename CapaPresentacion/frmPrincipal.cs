using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PantallasSistemaFacturacion
{
    public partial class frmPrincipal : Form
    {
        public frmPrincipal()
        {
            InitializeComponent();
        }
        private void frmPrincipal_Load(object sender, EventArgs e)
        {

        }


        private void AbrirPanel(Form formulario)
        {
            pnlContenedor.Controls.Clear();

            formulario.TopLevel = false;
            formulario.FormBorderStyle = FormBorderStyle.None;
            formulario.Dock = DockStyle.Fill;

            pnlContenedor.Controls.Add(formulario);
            formulario.Show();
        }

        private void clientesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AbrirPanel(new frmClientes());
        }

        private void categoríasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AbrirPanel(new frmListaCategoriasProductos());
        }

        private void facturasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AbrirPanel(new frmFacturas());
        }

        private void informesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AbrirPanel(new frmInformes());
        }

        private void empleadosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AbrirPanel(new frmListaEmpleados());
        }

        private void rolesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AbrirPanel(new frmRoles());
        }

        private void seguridadToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            AbrirPanel(new frmSeguridad());
        }

        private void ayudaToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            AbrirPanel(new frmAyuda());
        }

        private void acercaDeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AbrirPanel(new frmAcercaDe());
        }

        private void salirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void productosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AbrirPanel(new frmListaProductos());
        }
    }
}
