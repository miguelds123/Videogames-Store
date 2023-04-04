using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VentaVideojuegos.Layers.BLL
{
    class BLLReservacion : IBLLReservacion
    {
        public void DeleteReservacion(string pId)
        {
            IDALReservacion _DALReservacion = new DALReservacion();

            _DALReservacion.DeleteReservacion(pId);
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

        public void SaveReservacion(Reservacion pReservacion)
        {
            IDALReservacion _DALReservacion = new DALReservacion();

            _DALReservacion.SaveReservacion(pReservacion);
        }

        public void UpdateReservacion(Reservacion pReservacion)
        {
            IDALReservacion _DALReservacion = new DALReservacion();

            _DALReservacion.UpdateReservacion(pReservacion);
        }
    }
}
