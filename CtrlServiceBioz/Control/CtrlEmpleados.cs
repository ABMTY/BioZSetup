using EntServiceBioz.Entidad;
using PerServiceBioz.Persistencia;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CtrlServiceBioz.Control
{
    public class CtrlEmpleados
    {
        PerEmpleados PerEmpleados;

        public List<EntEmpleado> Lista;

        public CtrlEmpleados()
        {
            PerEmpleados = new PerEmpleados();
        }
        public List<EntEmpleado> ObtenerTodos()
        {
            return (List<EntEmpleado>)new PerEmpleados().ObtenerTodos();
        }

        public EntEmpleado ObtenerEmpleadoporenrollnumber(int enrollnumber)
        {            
            return (EntEmpleado)new PerEmpleados().ObtenerEmpleadoporenrollnumber(enrollnumber);
        }

        public List<EntEmpleado> ObtenerPorEmpresa(int id_empresa)
        {
            return (List<EntEmpleado>)new PerEmpleados().ObtenerPorEmpresa(id_empresa);
        }

        public EntEmpleado Obtener(int Id_RolesVista)
        {
            return (EntEmpleado)new PerEmpleados().Obtener(Id_RolesVista);
        }


        public bool Insertar(EntEmpleado Entidad)
        {
            return PerEmpleados.Insert(Entidad);
        }

        public bool Actualizar(EntEmpleado Entidad)
        {
            return PerEmpleados.Update(Entidad);
        }

        public bool Eliminar(int Id_Rol_Vista)
        {
            return PerEmpleados.Eliminar(Id_Rol_Vista);
        }
    }
}
