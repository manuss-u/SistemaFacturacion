using System;
using System.Collections.Generic;
using Microsoft.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDatos
{
    public class DALConexion
    {
        private SqlConnection Conexion = new SqlConnection("Server=DESKTOP-627OEER;Database=BDSistemaFacturacion;User Id=UserdbMS;Password=0123456789;TrustServerCertificate=True");

        public SqlConnection OpenConnection()
        {
            if(Conexion.State == System.Data.ConnectionState.Closed)
            {
                Conexion.Open();
            }
            return Conexion;
        }
        public SqlConnection CloseConnection()
        {
            if(Conexion.State == System.Data.ConnectionState.Open)
            {
                Conexion.Close();
            }
            return Conexion;
        }
    }
}
