using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VentaVideojuegos.Layers.BLL
{
    class BLLReservacion : IBLLReservacion
    {
        public bool DeleteReservacion(string pId)
        {
            IDALReservacion _DALReservacion = new DALReservacion();

            return _DALReservacion.DeleteReservacion(pId);
        }

        public List<Reservacion> GetAllReservacion()
        {
            IDALReservacion _DALReservacion = new DALReservacion();

            return _DALReservacion.GetAllReservacion();
        }

        public Reservacion GetReservacionById(string pId)
        {
            IDALReservacion _DALReservacion = new DALReservacion();

            return _DALReservacion.GetReservacionById(pId);
        }

        public List<Reservacion> GetReservacionByIdCliente(string pId)
        {
            IDALReservacion _DALReservacion = new DALReservacion();

            return _DALReservacion.GetReservacionByIdCliente(pId);
        }

        public Reservacion SaveReservacion(Reservacion pReservacion)
        {
            IDALReservacion _DALReservacion = new DALReservacion();

            return _DALReservacion.SaveReservacion(pReservacion);
        }

        public Reservacion UpdateReservacion(Reservacion pReservacion)
        {
            IDALReservacion _DALReservacion = new DALReservacion();

            return _DALReservacion.UpdateReservacion(pReservacion);
        }
    }
}
