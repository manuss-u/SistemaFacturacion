using CapaDatos;
using System.Data;

namespace CapaNegocio
{
    public class NEmpleados
    {
        private readonly DALEmpleados dalEmpleados = new DALEmpleados();

        public DataTable ListarEmpleados()
        {
            return dalEmpleados.ListarEmpleados();
        }

        public DataTable BuscarEmpleados(string criterio)
        {
            return dalEmpleados.BuscarEmpleados(criterio);
        }

        public DataTable ObtenerEmpleadoPorId(int idEmpleado)
        {
            return dalEmpleados.ObtenerEmpleadoPorId(idEmpleado);
        }

        public void InsertarEmpleado(string nombre, string documento, string direccion, string telefono,
            string email, string nombreRol, DateTime fechaIngreso, DateTime? fechaRetiro, string detalles)
        {
            dalEmpleados.InsertarEmpleado(nombre, documento, direccion, telefono, email, nombreRol, fechaIngreso, fechaRetiro, detalles);
        }

        public void ActualizarEmpleado(int idEmpleado, string nombre, string documento, string direccion, string telefono,
            string email, string nombreRol, DateTime fechaIngreso, DateTime? fechaRetiro, string detalles)
        {
            dalEmpleados.ActualizarEmpleado(idEmpleado, nombre, documento, direccion, telefono, email, nombreRol, fechaIngreso, fechaRetiro, detalles);
        }

        public void EliminarEmpleado(int idEmpleado)
        {
            dalEmpleados.EliminarEmpleado(idEmpleado);
        }

        public DataTable ListarRoles()
        {
            return dalEmpleados.ListarRoles();
        }
    }
}

