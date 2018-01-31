
using EntServiceBioz.Entidad;
using PerServiceBioz.Persistencia;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CtrlServiceBioz.Control
{
    public class CtrlEmpleadoHuella
    {
        PerEmpleadoHuella PerEmpleadoHuella;

        public List<EmpleadoHuella> Lista;

        public CtrlEmpleadoHuella()
        {
            PerEmpleadoHuella = new PerEmpleadoHuella();
        }
        public List<EmpleadoHuella> ObtenerTodos()
        {
            return (List<EmpleadoHuella>)new PerEmpleadoHuella().ObtenerTodos();
        }
        public EmpleadoHuella Obtener(int Id_Empleado_Huella)
        {
            return (EmpleadoHuella)new PerEmpleadoHuella().Obtener(Id_Empleado_Huella);
        }

        public bool Insertar(EmpleadoHuella Entidad)
        {
            return PerEmpleadoHuella.Insert(Entidad);
        }

        public bool Actualizar(EmpleadoHuella Entidad)
        {
            return PerEmpleadoHuella.Update(Entidad);
        }

        public bool Eliminar(int Id_Empleado_Huella)
        {
            return PerEmpleadoHuella.Eliminar(Id_Empleado_Huella);
        }
    }
}
