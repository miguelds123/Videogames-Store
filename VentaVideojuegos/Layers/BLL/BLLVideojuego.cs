using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VentaVideojuegos
{
    class BLLVideojuego
    {
        public void BorradoLogico(int pID)
        {
            DALVideojuego _DALVideojuego= new DALVideojuego();

            _DALVideojuego.BorradoLogico(pID);
        }

        public void DeleteVideojuego(double pId)
        {
            DALVideojuego _DALVideojuego = new DALVideojuego();

            _DALVideojuego.DeleteVideojuego(pId);
        }

        public List<Videojuego> GetAllVideojuego()
        {
            DALVideojuego _DALVideojuego = new DALVideojuego();

            return _DALVideojuego.GetAllVideojuego();
        }

        public Videojuego GetVideojuegoById(double pId)
        {
            DALVideojuego _DALVideojuego = new DALVideojuego();

            return _DALVideojuego.GetVideojuegoById(pId);
        }

        public void SaveVideojuego(Videojuego pVideojuego)
        {
            DALVideojuego _DALVideojuego = new DALVideojuego();

            _DALVideojuego.SaveVideojuego(pVideojuego);
        }

        public void UpdateVideojuego(Videojuego pVideojuego)
        {
            DALVideojuego _DALVideojuego = new DALVideojuego();

            _DALVideojuego.UpdateVideojuego(pVideojuego);
        }
    }
}
