using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VentaVideojuegos
{
    interface IDALReservacion
    {
        Reservacion GetReservacionById(string pId);
        List<Reservacion> GetReservacionByIdCliente(string pId);
        List<Reservacion> GetAllReservacion();
        Reservacion SaveReservacion(Reservacion pReservacion);
        Reservacion UpdateReservacion(Reservacion pReservacion);
        bool DeleteReservacion(string pId);
    }
}
