using EntServiceBioz.Entidad;
using IBM.Data.Informix;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PerServiceBioz.Persistencia
{
    public class PerCkeckinout : Persistencia
    {
        public bool Insert(Checkinout entidad)
        {
            bool respuesta = false;
            try
            {                
                AbrirConexion();
                var sql = "insert into asistencia (id_empleado,date,hour,checkinout,device,id_sucursal,enrollnumber) values (?,?,?,?,?,?,NULL);";

                using (var cmd = new IfxCommand(sql, Conexion))
                {
                    cmd.Parameters.Add(new IfxParameter()).Value = entidad.id_empleado;
                    cmd.Parameters.Add(new IfxParameter()).Value = entidad.pFecha;
                    cmd.Parameters.Add(new IfxParameter()).Value = entidad.pHora;
                    cmd.Parameters.Add(new IfxParameter()).Value = entidad.Ckecked;
                    cmd.Parameters.Add(new IfxParameter()).Value = entidad.Device;
                    cmd.Parameters.Add(new IfxParameter()).Value = entidad.id_sucursal;                     

                    cmd.ExecuteNonQuery();
                }
                respuesta = true;

            }

            catch (InvalidCastException ex)
            {
                ApplicationException excepcion = new ApplicationException("Se genero un error con el siguiente mensaje: " + ex.Message, ex);
                excepcion.Source = "Insert Checkinout";
                throw excepcion;
            }
            catch (Exception ex)
            {
                ApplicationException excepcion = new ApplicationException("Se genero un error de aplicación con el siguiente mensaje: " + ex.Message, ex);
                excepcion.Source = "Insert Checkinout";
                throw excepcion;
            }
            finally
            {
                CerrarConexion();
            }
            return respuesta;

        }
    }
}
