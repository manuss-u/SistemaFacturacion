using CapaDatos;
using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.Windows.Forms;

namespace PantallasSistemaFacturacion
{
    public partial class frmFacturas : Form
    {
        private readonly DALFacturas dalFacturas = new DALFacturas();

        public frmFacturas()
        {
            InitializeComponent();

            this.Load += frmFacturas_Load;
            btnGuardar.Click += btnGuardar_Click;

            dgvDetalleFactura.CellEndEdit += dgvDetalleFactura_CellEndEdit;
            dgvDetalleFactura.RowsRemoved += dgvDetalleFactura_RowsRemoved;
            dgvDetalleFactura.UserDeletedRow += dgvDetalleFactura_UserDeletedRow;

            txtDescuento.TextChanged += txtDescuento_TextChanged;
            txtIva.TextChanged += txtIva_TextChanged;
        }

        private void frmFacturas_Load(object? sender, EventArgs e)
        {
            ConfigurarFormulario();
            ConfigurarGrid();
            LimpiarFormulario();
        }

        private void ConfigurarFormulario()
        {
            cmbEstadoFactura.Items.Clear();
            cmbEstadoFactura.Items.Add("Pendiente");
            cmbEstadoFactura.Items.Add("Pagada");
            cmbEstadoFactura.Items.Add("Anulada");
            cmbEstadoFactura.SelectedIndex = 0;

            dtpFechaRegistro.Value = DateTime.Today;

            txtTotal.ReadOnly = true;
        }

        private void ConfigurarGrid()
        {
            dgvDetalleFactura.Columns.Clear();
            dgvDetalleFactura.AutoGenerateColumns = false;
            dgvDetalleFactura.AllowUserToAddRows = true;
            dgvDetalleFactura.AllowUserToDeleteRows = true;

            DataGridViewTextBoxColumn colIdProducto = new DataGridViewTextBoxColumn();
            colIdProducto.Name = "IdProducto";
            colIdProducto.HeaderText = "IdProducto";
            colIdProducto.Width = 90;

            DataGridViewTextBoxColumn colProducto = new DataGridViewTextBoxColumn();
            colProducto.Name = "Producto";
            colProducto.HeaderText = "Producto";
            colProducto.Width = 220;
            colProducto.ReadOnly = true;

            DataGridViewTextBoxColumn colCantidad = new DataGridViewTextBoxColumn();
            colCantidad.Name = "Cantidad";
            colCantidad.HeaderText = "Cantidad";
            colCantidad.Width = 90;

            DataGridViewTextBoxColumn colPrecio = new DataGridViewTextBoxColumn();
            colPrecio.Name = "PrecioUnitario";
            colPrecio.HeaderText = "Precio Unitario";
            colPrecio.Width = 120;

            DataGridViewTextBoxColumn colSubtotal = new DataGridViewTextBoxColumn();
            colSubtotal.Name = "Subtotal";
            colSubtotal.HeaderText = "Subtotal";
            colSubtotal.Width = 120;
            colSubtotal.ReadOnly = true;

            dgvDetalleFactura.Columns.Add(colIdProducto);
            dgvDetalleFactura.Columns.Add(colProducto);
            dgvDetalleFactura.Columns.Add(colCantidad);
            dgvDetalleFactura.Columns.Add(colPrecio);
            dgvDetalleFactura.Columns.Add(colSubtotal);
        }

        private void LimpiarFormulario()
        {
            txtFactura.Text = dalFacturas.GenerarNumeroFactura();
            txtCliente.Clear();
            txtEmpleado.Clear();
            txtDescuento.Text = "0";
            txtIva.Text = "0";
            txtTotal.Text = "0.00";
            dtpFechaRegistro.Value = DateTime.Today;
            cmbEstadoFactura.SelectedIndex = 0;

            dgvDetalleFactura.Rows.Clear();
        }

        private void dgvDetalleFactura_CellEndEdit(object? sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
                return;

            DataGridViewRow fila = dgvDetalleFactura.Rows[e.RowIndex];

            if (fila.IsNewRow)
                return;

            if (dgvDetalleFactura.Columns[e.ColumnIndex].Name == "IdProducto")
            {
                CargarProductoEnFila(fila);
            }

            if (dgvDetalleFactura.Columns[e.ColumnIndex].Name == "Cantidad" ||
                dgvDetalleFactura.Columns[e.ColumnIndex].Name == "PrecioUnitario")
            {
                CalcularSubtotalFila(fila);
            }

            RecalcularTotalFactura();
        }

        private void CargarProductoEnFila(DataGridViewRow fila)
        {
            try
            {
                if (fila.Cells["IdProducto"].Value == null)
                    return;

                string textoId = fila.Cells["IdProducto"].Value.ToString()!.Trim();

                if (string.IsNullOrWhiteSpace(textoId))
                    return;

                if (!int.TryParse(textoId, out int idProducto))
                {
                    MessageBox.Show("El IdProducto debe ser numérico.",
                        "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    fila.Cells["IdProducto"].Value = null;
                    fila.Cells["Producto"].Value = null;
                    fila.Cells["PrecioUnitario"].Value = null;
                    fila.Cells["Subtotal"].Value = null;
                    return;
                }

                DataTable dt = dalFacturas.ObtenerProductoPorId(idProducto);

                if (dt.Rows.Count == 0)
                {
                    MessageBox.Show("El producto no existe.",
                        "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    fila.Cells["Producto"].Value = null;
                    fila.Cells["PrecioUnitario"].Value = null;
                    fila.Cells["Subtotal"].Value = null;
                    return;
                }

                DataRow row = dt.Rows[0];

                fila.Cells["Producto"].Value = row["NombreProducto"].ToString();

                if (fila.Cells["PrecioUnitario"].Value == null ||
                    string.IsNullOrWhiteSpace(fila.Cells["PrecioUnitario"].Value.ToString()))
                {
                    fila.Cells["PrecioUnitario"].Value = Convert.ToDecimal(row["PrecioVenta"]).ToString("0.00");
                }

                CalcularSubtotalFila(fila);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar producto: {ex.Message}",
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CalcularSubtotalFila(DataGridViewRow fila)
        {
            try
            {
                if (fila.IsNewRow)
                    return;

                int cantidad = 0;
                decimal precioUnitario = 0;

                if (fila.Cells["Cantidad"].Value != null)
                    int.TryParse(fila.Cells["Cantidad"].Value.ToString(), out cantidad);

                if (fila.Cells["PrecioUnitario"].Value != null)
                    decimal.TryParse(fila.Cells["PrecioUnitario"].Value.ToString(), NumberStyles.Any, CultureInfo.InvariantCulture, out precioUnitario);

                decimal subtotal = cantidad * precioUnitario;
                fila.Cells["Subtotal"].Value = subtotal.ToString("0.00");
            }
            catch
            {
                fila.Cells["Subtotal"].Value = "0.00";
            }
        }

        private void RecalcularTotalFactura()
        {
            decimal subtotalDetalle = 0;

            foreach (DataGridViewRow fila in dgvDetalleFactura.Rows)
            {
                if (fila.IsNewRow)
                    continue;

                if (fila.Cells["Subtotal"].Value != null &&
                    decimal.TryParse(fila.Cells["Subtotal"].Value.ToString(), NumberStyles.Any, CultureInfo.InvariantCulture, out decimal subtotalFila))
                {
                    subtotalDetalle += subtotalFila;
                }
            }

            decimal descuento = 0;
            decimal iva = 0;

            decimal.TryParse(txtDescuento.Text.Trim(), NumberStyles.Any, CultureInfo.InvariantCulture, out descuento);
            decimal.TryParse(txtIva.Text.Trim(), NumberStyles.Any, CultureInfo.InvariantCulture, out iva);

            decimal total = subtotalDetalle - descuento + iva;

            if (total < 0)
                total = 0;

            txtTotal.Text = total.ToString("0.00");
        }

        private List<DetalleFacturaItem> ObtenerDetallesDesdeGrid()
        {
            List<DetalleFacturaItem> detalles = new List<DetalleFacturaItem>();

            foreach (DataGridViewRow fila in dgvDetalleFactura.Rows)
            {
                if (fila.IsNewRow)
                    continue;

                string idTexto = fila.Cells["IdProducto"].Value?.ToString() ?? "";
                string nombre = fila.Cells["Producto"].Value?.ToString() ?? "";
                string cantidadTexto = fila.Cells["Cantidad"].Value?.ToString() ?? "";
                string precioTexto = fila.Cells["PrecioUnitario"].Value?.ToString() ?? "";
                string subtotalTexto = fila.Cells["Subtotal"].Value?.ToString() ?? "";

                if (string.IsNullOrWhiteSpace(idTexto) &&
                    string.IsNullOrWhiteSpace(nombre) &&
                    string.IsNullOrWhiteSpace(cantidadTexto) &&
                    string.IsNullOrWhiteSpace(precioTexto))
                {
                    continue;
                }

                if (!int.TryParse(idTexto, out int idProducto))
                    throw new Exception("Hay una fila con IdProducto inválido.");

                if (!int.TryParse(cantidadTexto, out int cantidad) || cantidad <= 0)
                    throw new Exception($"La cantidad del producto {idProducto} debe ser mayor que 0.");

                if (!decimal.TryParse(precioTexto, NumberStyles.Any, CultureInfo.InvariantCulture, out decimal precioUnitario) || precioUnitario < 0)
                    throw new Exception($"El precio unitario del producto {idProducto} es inválido.");

                decimal subtotal = cantidad * precioUnitario;

                if (decimal.TryParse(subtotalTexto, NumberStyles.Any, CultureInfo.InvariantCulture, out decimal subtotalGrid))
                    subtotal = subtotalGrid;

                detalles.Add(new DetalleFacturaItem
                {
                    IdProducto = idProducto,
                    NombreProducto = nombre,
                    Cantidad = cantidad,
                    PrecioUnitario = precioUnitario,
                    Subtotal = subtotal
                });
            }

            return detalles;
        }

        private void btnGuardar_Click(object? sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(txtFactura.Text))
                {
                    MessageBox.Show("Debe ingresar el número de factura.",
                        "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (!int.TryParse(txtCliente.Text.Trim(), out int idCliente))
                {
                    MessageBox.Show("El campo Cliente debe contener el ID del cliente.",
                        "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (!int.TryParse(txtEmpleado.Text.Trim(), out int idEmpleado))
                {
                    MessageBox.Show("El campo Empleado debe contener el ID del empleado.",
                        "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (cmbEstadoFactura.SelectedIndex < 0)
                {
                    MessageBox.Show("Debe seleccionar el estado de la factura.",
                        "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                decimal descuento = 0;
                decimal iva = 0;
                decimal total = 0;

                decimal.TryParse(txtDescuento.Text.Trim(), NumberStyles.Any, CultureInfo.InvariantCulture, out descuento);
                decimal.TryParse(txtIva.Text.Trim(), NumberStyles.Any, CultureInfo.InvariantCulture, out iva);
                decimal.TryParse(txtTotal.Text.Trim(), NumberStyles.Any, CultureInfo.InvariantCulture, out total);

                List<DetalleFacturaItem> detalles = ObtenerDetallesDesdeGrid();

                if (detalles.Count == 0)
                {
                    MessageBox.Show("Debe agregar al menos un producto en el detalle.",
                        "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                dalFacturas.GuardarFactura(
                    txtFactura.Text.Trim(),
                    idCliente,
                    idEmpleado,
                    dtpFechaRegistro.Value,
                    cmbEstadoFactura.Text,
                    descuento,
                    iva,
                    total,
                    detalles);

                MessageBox.Show("Factura guardada correctamente.",
                    "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);

                LimpiarFormulario();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al guardar factura: {ex.Message}",
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtDescuento_TextChanged(object? sender, EventArgs e)
        {
            RecalcularTotalFactura();
        }

        private void txtIva_TextChanged(object? sender, EventArgs e)
        {
            RecalcularTotalFactura();
        }

        private void dgvDetalleFactura_RowsRemoved(object? sender, DataGridViewRowsRemovedEventArgs e)
        {
            RecalcularTotalFactura();
        }

        private void dgvDetalleFactura_UserDeletedRow(object? sender, DataGridViewRowEventArgs e)
        {
            RecalcularTotalFactura();
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void label1_Click(object sender, EventArgs e) { }
        private void panel1_Paint(object sender, PaintEventArgs e) { }
        private void label3_Click(object sender, EventArgs e) { }
        private void label7_Click(object sender, EventArgs e) { }
        private void txtStock_TextChanged(object sender, EventArgs e) { }
        private void textBox1_TextChanged(object sender, EventArgs e) { }
    }
}