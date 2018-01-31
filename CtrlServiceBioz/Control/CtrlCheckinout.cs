using EntServiceBioz.Entidad;
using PerServiceBioz.Persistencia;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CtrlServiceBioz.Control
{
    public class CtrlCheckinout
    {
        PerCkeckinout percheckinout = new PerCkeckinout();
        public bool Insertar(Checkinout Entidad)
        {
            return percheckinout.Insert(Entidad);
        }
    }
}
