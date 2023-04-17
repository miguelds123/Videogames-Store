using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VentaVideojuegos
{
    class BLLReservacionVideojuego
    {
        public void DeleteReservacionVideojuego(string pId)
        {
            DALReservacionVideojuego _DALReservacionVideojuego = new DALReservacionVideojuego();

            _DALReservacionVideojuego.DeleteReservacionVideojuego(pId);
        }

        public List<Reservacion> GetAllReservacionVideojuego()
        {
            DALReservacionVideojuego _DALReservacionVideojuego = new DALReservacionVideojuego();

            return _DALReservacionVideojuego.GetAllReservacionVideojuego();
        }

        public Reservacion GetReservacionVideojuegoById(string pId)
        {
            DALReservacionVideojuego _DALReservacionVideojuego = new DALReservacionVideojuego();

            return _DALReservacionVideojuego.GetReservacionVideojuegoById(pId);
        }

        public List<Reservacion> GetReservacionVideojuegoByIdCliente(string pId)
        {
            DALReservacionVideojuego _DALReservacionVideojuego = new DALReservacionVideojuego();

            return _DALReservacionVideojuego.GetReservacionVideojuegoByIdCliente(pId);
        }

        public void SaveReservacion(Reservacion pReservacion)
        {
            DALReservacionVideojuego _DALReservacionVideojuego = new DALReservacionVideojuego();

            _DALReservacionVideojuego.SaveReservacion(pReservacion);
        }

        public void UpdateReservacion(Reservacion pReservacion)
        {
            DALReservacionVideojuego _DALReservacionVideojuego = new DALReservacionVideojuego();

            _DALReservacionVideojuego.UpdateReservacion(pReservacion);
        }

        public int GetCurrentNumeroReservacion()
        {
            DALReservacionVideojuego _DALReservacionVideojuego = new DALReservacionVideojuego();

            return _DALReservacionVideojuego.GetCurrentNumeroReservacion();
        }

        public int GetNextNumeroReservacion()
        {
            DALReservacionVideojuego _DALReservacionVideojuego = new DALReservacionVideojuego();

            return _DALReservacionVideojuego.GetNextNumeroReservacion();
        }
    }
}
