using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VentaVideojuegos
{
    interface IBLLReservacion
    {
        Reservacion GetReservacionById(string pId);
        List<Reservacion> GetReservacionByIdCliente(string pId);
        List<Reservacion> GetAllReservacion();
        void SaveReservacion(Reservacion pReservacion);
        void UpdateReservacion(Reservacion pReservacion);
        void DeleteReservacion(string pId);
    }
}
