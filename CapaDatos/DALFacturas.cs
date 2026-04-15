using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;

namespace CapaDatos
{
    public class DALFacturas
    {
        private readonly DALConexion conexion = new DALConexion();

        public DataTable ObtenerProductoPorId(int idProducto)
        {
            DataTable dt = new DataTable();

            string query = @"
                SELECT IdProducto, NombreProducto, PrecioVenta, Stock
                FROM Productos
                WHERE IdProducto = @IdProducto;";

            SqlCommand cmd = new SqlCommand(query, conexion.OpenConnection());
            cmd.Parameters.AddWithValue("@IdProducto", idProducto);

            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);

            conexion.CloseConnection();
            return dt;
        }

        public string GenerarNumeroFactura()
        {
            string numeroFactura = "FAC-000001";

            string query = @"
                SELECT ISNULL(MAX(IdFactura), 0) + 1
                FROM Facturas;";

            SqlCommand cmd = new SqlCommand(query, conexion.OpenConnection());
            object resultado = cmd.ExecuteScalar();
            conexion.CloseConnection();

            int siguiente = Convert.ToInt32(resultado);
            numeroFactura = "FAC-" + siguiente.ToString("000000");

            return numeroFactura;
        }

        public void GuardarFactura(
            string numeroFactura,
            int idCliente,
            int idEmpleado,
            DateTime fechaRegistro,
            string estadoFactura,
            decimal descuento,
            decimal iva,
            decimal totalFactura,
            List<DetalleFacturaItem> detalles)
        {
            if (detalles == null || detalles.Count == 0)
                throw new Exception("La factura debe tener al menos un producto en el detalle.");

            SqlConnection con = conexion.OpenConnection();
            SqlTransaction transaccion = con.BeginTransaction();

            try
            {
                decimal subtotalFactura = 0;

                foreach (DetalleFacturaItem item in detalles)
                {
                    subtotalFactura += item.Subtotal;
                }

                string queryFactura = @"
                    INSERT INTO Facturas
                    (NumeroFactura, IdCliente, IdEmpleado, FechaRegistro, EstadoFactura, Subtotal, Descuento, Iva, TotalFactura)
                    VALUES
                    (@NumeroFactura, @IdCliente, @IdEmpleado, @FechaRegistro, @EstadoFactura, @Subtotal, @Descuento, @Iva, @TotalFactura);

                    SELECT SCOPE_IDENTITY();";

                SqlCommand cmdFactura = new SqlCommand(queryFactura, con, transaccion);
                cmdFactura.Parameters.AddWithValue("@NumeroFactura", numeroFactura);
                cmdFactura.Parameters.AddWithValue("@IdCliente", idCliente);
                cmdFactura.Parameters.AddWithValue("@IdEmpleado", idEmpleado);
                cmdFactura.Parameters.AddWithValue("@FechaRegistro", fechaRegistro.Date);
                cmdFactura.Parameters.AddWithValue("@EstadoFactura", estadoFactura);
                cmdFactura.Parameters.AddWithValue("@Subtotal", subtotalFactura);
                cmdFactura.Parameters.AddWithValue("@Descuento", descuento);
                cmdFactura.Parameters.AddWithValue("@Iva", iva);
                cmdFactura.Parameters.AddWithValue("@TotalFactura", totalFactura);

                int idFactura = Convert.ToInt32(cmdFactura.ExecuteScalar());

                foreach (DetalleFacturaItem item in detalles)
                {
                    string queryStock = @"
                        SELECT Stock
                        FROM Productos
                        WHERE IdProducto = @IdProducto;";

                    SqlCommand cmdStock = new SqlCommand(queryStock, con, transaccion);
                    cmdStock.Parameters.AddWithValue("@IdProducto", item.IdProducto);

                    object stockResult = cmdStock.ExecuteScalar();

                    if (stockResult == null || stockResult == DBNull.Value)
                        throw new Exception($"El producto con ID {item.IdProducto} no existe.");

                    int stockActual = Convert.ToInt32(stockResult);

                    if (item.Cantidad > stockActual)
                        throw new Exception($"No hay stock suficiente para el producto con ID {item.IdProducto}.");

                    string queryDetalle = @"
                        INSERT INTO DetalleFacturas
                        (IdFactura, IdProducto, Cantidad, PrecioUnitario, Subtotal)
                        VALUES
                        (@IdFactura, @IdProducto, @Cantidad, @PrecioUnitario, @Subtotal);";

                    SqlCommand cmdDetalle = new SqlCommand(queryDetalle, con, transaccion);
                    cmdDetalle.Parameters.AddWithValue("@IdFactura", idFactura);
                    cmdDetalle.Parameters.AddWithValue("@IdProducto", item.IdProducto);
                    cmdDetalle.Parameters.AddWithValue("@Cantidad", item.Cantidad);
                    cmdDetalle.Parameters.AddWithValue("@PrecioUnitario", item.PrecioUnitario);
                    cmdDetalle.Parameters.AddWithValue("@Subtotal", item.Subtotal);
                    cmdDetalle.ExecuteNonQuery();

                    string queryActualizarStock = @"
                        UPDATE Productos
                        SET Stock = Stock - @Cantidad
                        WHERE IdProducto = @IdProducto;";

                    SqlCommand cmdActualizarStock = new SqlCommand(queryActualizarStock, con, transaccion);
                    cmdActualizarStock.Parameters.AddWithValue("@Cantidad", item.Cantidad);
                    cmdActualizarStock.Parameters.AddWithValue("@IdProducto", item.IdProducto);
                    cmdActualizarStock.ExecuteNonQuery();
                }

                transaccion.Commit();
            }
            catch
            {
                transaccion.Rollback();
                throw;
            }
            finally
            {
                conexion.CloseConnection();
            }
        }
    }

    public class DetalleFacturaItem
    {
        public int IdProducto { get; set; }
        public string NombreProducto { get; set; } = string.Empty;
        public int Cantidad { get; set; }
        public decimal PrecioUnitario { get; set; }
        public decimal Subtotal { get; set; }
    }
}