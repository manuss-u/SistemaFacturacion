<<<<<<< HEAD
﻿using Microsoft.Data.SqlClient;
=======
using Microsoft.Data.SqlClient;
using System;
>>>>>>> f9ccecfcae657d7b8908920b3870b398ff8df57d
using System.Data;

namespace CapaDatos
{
    public class DALEmpleados
    {
<<<<<<< HEAD
        private readonly DALConexion conexion = new DALConexion();
        public DataTable ListarEmpleados()
        {
            DataTable dt = new DataTable();
            string query = @"
                SELECT e.IdEmpleado,
                       e.Nombre,
                       e.Documento,
                       e.Direccion,
                       e.Telefono,
                       e.Email,
                       ISNULL(r.NombreRol, '') AS Rol,
                       e.FechaIngreso,
                       e.FechaRetiro,
                       e.Detalles
                FROM Empleados e
                LEFT JOIN Roles r ON e.IdRol = r.IdRol
                ORDER BY e.Nombre;";

            SqlCommand cmd = new SqlCommand(query, conexion.OpenConnection());
=======
        private DALConexion conexion = new DALConexion();

        public DataTable ListarEmpleados()
        {
            DataTable dt = new DataTable();
            SqlCommand cmd = new SqlCommand("sp_ListarEmpleados", conexion.OpenConnection());
            cmd.CommandType = CommandType.StoredProcedure;
>>>>>>> f9ccecfcae657d7b8908920b3870b398ff8df57d
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            conexion.CloseConnection();
            return dt;
        }
<<<<<<< HEAD
        public DataTable BuscarEmpleados(string criterio)
        {
            DataTable dt = new DataTable();
            string query = @"
                SELECT e.IdEmpleado,
                       e.Nombre,
                       e.Documento,
                       e.Direccion,
                       e.Telefono,
                       e.Email,
                       ISNULL(r.NombreRol, '') AS Rol,
                       e.FechaIngreso,
                       e.FechaRetiro,
                       e.Detalles
                FROM Empleados e
                LEFT JOIN Roles r ON e.IdRol = r.IdRol
                WHERE e.Nombre LIKE '%' + @Criterio + '%'
                   OR ISNULL(e.Documento, '') LIKE '%' + @Criterio + '%'
                ORDER BY e.Nombre;";

            SqlCommand cmd = new SqlCommand(query, conexion.OpenConnection());
=======

        public DataTable BuscarEmpleados(string criterio)
        {
            DataTable dt = new DataTable();
            SqlCommand cmd = new SqlCommand("sp_BuscarEmpleados", conexion.OpenConnection());
            cmd.CommandType = CommandType.StoredProcedure;
>>>>>>> f9ccecfcae657d7b8908920b3870b398ff8df57d
            cmd.Parameters.AddWithValue("@Criterio", criterio);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            conexion.CloseConnection();
            return dt;
        }
<<<<<<< HEAD
        public DataTable ObtenerEmpleadoPorId(int idEmpleado)
        {
            DataTable dt = new DataTable();
            string query = @"
                SELECT e.IdEmpleado,
                       e.Nombre,
                       e.Documento,
                       e.Direccion,
                       e.Telefono,
                       e.Email,
                       ISNULL(r.NombreRol, '') AS Rol,
                       e.FechaIngreso,
                       e.FechaRetiro,
                       e.Detalles
                FROM Empleados e
                LEFT JOIN Roles r ON e.IdRol = r.IdRol
                WHERE e.IdEmpleado = @IdEmpleado;";

            SqlCommand cmd = new SqlCommand(query, conexion.OpenConnection());
=======

        public DataTable ObtenerEmpleadoPorId(int idEmpleado)
        {
            DataTable dt = new DataTable();
            SqlCommand cmd = new SqlCommand("sp_ObtenerEmpleadoPorId", conexion.OpenConnection());
            cmd.CommandType = CommandType.StoredProcedure;
>>>>>>> f9ccecfcae657d7b8908920b3870b398ff8df57d
            cmd.Parameters.AddWithValue("@IdEmpleado", idEmpleado);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            conexion.CloseConnection();
            return dt;
        }
<<<<<<< HEAD
        public void InsertarEmpleado(string nombre, string documento, string direccion, string telefono,
            string email, string nombreRol, DateTime fechaIngreso, DateTime? fechaRetiro, string detalles)
        {
            int? idRol = ObtenerIdRolPorNombre(nombreRol);

            string query = @"
                INSERT INTO Empleados
                (Nombre, Documento, Direccion, Telefono, Email, IdRol, FechaIngreso, FechaRetiro, Detalles)
                VALUES
                (@Nombre, @Documento, @Direccion, @Telefono, @Email, @IdRol, @FechaIngreso, @FechaRetiro, @Detalles);";

            SqlCommand cmd = new SqlCommand(query, conexion.OpenConnection());
            cmd.Parameters.AddWithValue("@Nombre", nombre);
            cmd.Parameters.AddWithValue("@Documento", string.IsNullOrWhiteSpace(documento) ? (object)DBNull.Value : documento);
            cmd.Parameters.AddWithValue("@Direccion", string.IsNullOrWhiteSpace(direccion) ? (object)DBNull.Value : direccion);
            cmd.Parameters.AddWithValue("@Telefono", string.IsNullOrWhiteSpace(telefono) ? (object)DBNull.Value : telefono);
            cmd.Parameters.AddWithValue("@Email", string.IsNullOrWhiteSpace(email) ? (object)DBNull.Value : email);
            cmd.Parameters.AddWithValue("@IdRol", idRol.HasValue ? (object)idRol.Value : DBNull.Value);
            cmd.Parameters.AddWithValue("@FechaIngreso", fechaIngreso.Date);
            cmd.Parameters.AddWithValue("@FechaRetiro", fechaRetiro.HasValue ? (object)fechaRetiro.Value.Date : DBNull.Value);
            cmd.Parameters.AddWithValue("@Detalles", string.IsNullOrWhiteSpace(detalles) ? (object)DBNull.Value : detalles);
            cmd.ExecuteNonQuery();
            conexion.CloseConnection();
        }
        public void ActualizarEmpleado(int idEmpleado, string nombre, string documento, string direccion, string telefono,
            string email, string nombreRol, DateTime fechaIngreso, DateTime? fechaRetiro, string detalles)
        {
            int? idRol = ObtenerIdRolPorNombre(nombreRol);

            string query = @"
                UPDATE Empleados
                SET Nombre = @Nombre,
                    Documento = @Documento,
                    Direccion = @Direccion,
                    Telefono = @Telefono,
                    Email = @Email,
                    IdRol = @IdRol,
                    FechaIngreso = @FechaIngreso,
                    FechaRetiro = @FechaRetiro,
                    Detalles = @Detalles
                WHERE IdEmpleado = @IdEmpleado;";

            SqlCommand cmd = new SqlCommand(query, conexion.OpenConnection());
            cmd.Parameters.AddWithValue("@IdEmpleado", idEmpleado);
            cmd.Parameters.AddWithValue("@Nombre", nombre);
            cmd.Parameters.AddWithValue("@Documento", string.IsNullOrWhiteSpace(documento) ? (object)DBNull.Value : documento);
            cmd.Parameters.AddWithValue("@Direccion", string.IsNullOrWhiteSpace(direccion) ? (object)DBNull.Value : direccion);
            cmd.Parameters.AddWithValue("@Telefono", string.IsNullOrWhiteSpace(telefono) ? (object)DBNull.Value : telefono);
            cmd.Parameters.AddWithValue("@Email", string.IsNullOrWhiteSpace(email) ? (object)DBNull.Value : email);
            cmd.Parameters.AddWithValue("@IdRol", idRol.HasValue ? (object)idRol.Value : DBNull.Value);
            cmd.Parameters.AddWithValue("@FechaIngreso", fechaIngreso.Date);
            cmd.Parameters.AddWithValue("@FechaRetiro", fechaRetiro.HasValue ? (object)fechaRetiro.Value.Date : DBNull.Value);
            cmd.Parameters.AddWithValue("@Detalles", string.IsNullOrWhiteSpace(detalles) ? (object)DBNull.Value : detalles);
            cmd.ExecuteNonQuery();
            conexion.CloseConnection();
        }
        public void EliminarEmpleado(int idEmpleado)
        {
            string query = @"
                DELETE FROM Usuarios WHERE IdEmpleado = @IdEmpleado;
                DELETE FROM Empleados WHERE IdEmpleado = @IdEmpleado;";

            SqlCommand cmd = new SqlCommand(query, conexion.OpenConnection());
=======

        public void InsertarEmpleado(string nombre, string documento, string direccion,
            string telefono, string email, int idRol,
            DateTime fechaIngreso, DateTime? fechaRetiro, string detalles)
        {
            SqlCommand cmd = new SqlCommand("sp_InsertarEmpleado", conexion.OpenConnection());
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Nombre",       nombre);
            cmd.Parameters.AddWithValue("@Documento",    documento);
            cmd.Parameters.AddWithValue("@Direccion",    direccion);
            cmd.Parameters.AddWithValue("@Telefono",     telefono);
            cmd.Parameters.AddWithValue("@Email",        email);
            cmd.Parameters.AddWithValue("@IdRol",        idRol);
            cmd.Parameters.AddWithValue("@FechaIngreso", fechaIngreso);
            cmd.Parameters.AddWithValue("@FechaRetiro",  (object?)fechaRetiro ?? DBNull.Value);
            cmd.Parameters.AddWithValue("@Detalles",     string.IsNullOrWhiteSpace(detalles) ? DBNull.Value : (object)detalles);
            cmd.ExecuteNonQuery();
            conexion.CloseConnection();
        }

        public void ActualizarEmpleado(int idEmpleado, string nombre, string documento,
            string direccion, string telefono, string email, int idRol,
            DateTime fechaIngreso, DateTime? fechaRetiro, string detalles)
        {
            SqlCommand cmd = new SqlCommand("sp_ActualizarEmpleado", conexion.OpenConnection());
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@IdEmpleado",   idEmpleado);
            cmd.Parameters.AddWithValue("@Nombre",       nombre);
            cmd.Parameters.AddWithValue("@Documento",    documento);
            cmd.Parameters.AddWithValue("@Direccion",    direccion);
            cmd.Parameters.AddWithValue("@Telefono",     telefono);
            cmd.Parameters.AddWithValue("@Email",        email);
            cmd.Parameters.AddWithValue("@IdRol",        idRol);
            cmd.Parameters.AddWithValue("@FechaIngreso", fechaIngreso);
            cmd.Parameters.AddWithValue("@FechaRetiro",  (object?)fechaRetiro ?? DBNull.Value);
            cmd.Parameters.AddWithValue("@Detalles",     string.IsNullOrWhiteSpace(detalles) ? DBNull.Value : (object)detalles);
            cmd.ExecuteNonQuery();
            conexion.CloseConnection();
        }

        public void EliminarEmpleado(int idEmpleado)
        {
            SqlCommand cmd = new SqlCommand("sp_EliminarEmpleado", conexion.OpenConnection());
            cmd.CommandType = CommandType.StoredProcedure;
>>>>>>> f9ccecfcae657d7b8908920b3870b398ff8df57d
            cmd.Parameters.AddWithValue("@IdEmpleado", idEmpleado);
            cmd.ExecuteNonQuery();
            conexion.CloseConnection();
        }

        public DataTable ListarRoles()
        {
            DataTable dt = new DataTable();
<<<<<<< HEAD
            SqlCommand cmd = new SqlCommand("SELECT IdRol, NombreRol FROM Roles ORDER BY NombreRol", conexion.OpenConnection());
=======
            SqlCommand cmd = new SqlCommand("sp_ListarRoles", conexion.OpenConnection());
            cmd.CommandType = CommandType.StoredProcedure;
>>>>>>> f9ccecfcae657d7b8908920b3870b398ff8df57d
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            conexion.CloseConnection();
            return dt;
        }
<<<<<<< HEAD
        private int? ObtenerIdRolPorNombre(string nombreRol)
        {
            if (string.IsNullOrWhiteSpace(nombreRol))
                return null;

            SqlCommand cmd = new SqlCommand("SELECT IdRol FROM Roles WHERE NombreRol = @NombreRol", conexion.OpenConnection());
            cmd.Parameters.AddWithValue("@NombreRol", nombreRol.Trim());
            object? resultado = cmd.ExecuteScalar();
            conexion.CloseConnection();

            if (resultado == null || resultado == DBNull.Value)
                throw new Exception("El rol escrito no existe. Escriba un rol válido, por ejemplo: Administrador, Empleado, Vendedor o Supervisor.");

            return Convert.ToInt32(resultado);
        }
=======
>>>>>>> f9ccecfcae657d7b8908920b3870b398ff8df57d
    }
}
