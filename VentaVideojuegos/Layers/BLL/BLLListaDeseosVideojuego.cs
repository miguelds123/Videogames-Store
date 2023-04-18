using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VentaVideojuegos.Layers.BLL
{
    class BLLListaDeseosVideojuego
    {
        public void DeleteListaDeseosVideojuego(string pIdCliente, string pIdProducto)
        {
            DALListaDeseosVideojuegos _DALListaDeseosVideojuego= new DALListaDeseosVideojuegos();

            _DALListaDeseosVideojuego.DeleteListaDeseosVideojuego(pIdCliente, pIdProducto);
        }

        public List<ListaDeseos> GetAllListaDeseosVideojuego()
        {
            DALListaDeseosVideojuegos _DALListaDeseosVideojuego = new DALListaDeseosVideojuegos();

            return _DALListaDeseosVideojuego.GetAllListaDeseosVideojuego();
        }

        public ListaDeseos GetListaDeseosVideojuego(string pIdCliente, string pIdProducto)
        {
            DALListaDeseosVideojuegos _DALListaDeseosVideojuego = new DALListaDeseosVideojuegos();

            return _DALListaDeseosVideojuego.GetListaDeseosVideojuego(pIdCliente, pIdProducto);
        }

        public List<ListaDeseos> GetListaDeseosVideojuegoByIdCliente(string pId)
        {
            DALListaDeseosVideojuegos _DALListaDeseosVideojuego = new DALListaDeseosVideojuegos();

            return _DALListaDeseosVideojuego.GetListaDeseosVideojuegoByIdCliente(pId);
        }

        public List<ListaDeseos> GetListaDeseosVideojuegoByIdProducto(string pId)
        {
            DALListaDeseosVideojuegos _DALListaDeseosVideojuego = new DALListaDeseosVideojuegos();

            return _DALListaDeseosVideojuego.GetListaDeseosVideojuegoByIdProducto(pId);
        }

        public void SaveListaDeseosVideojuegos(ListaDeseos pListaDeseos)
        {
            DALListaDeseosVideojuegos _DALListaDeseosVideojuego = new DALListaDeseosVideojuegos();

            _DALListaDeseosVideojuego.SaveListaDeseosVideojuegos(pListaDeseos);
        }

        public void UpdateListaDeseosVideojuego(ListaDeseos pListaDeseos)
        {
            DALListaDeseosVideojuegos _DALListaDeseosVideojuego = new DALListaDeseosVideojuegos();

            _DALListaDeseosVideojuego.UpdateListaDeseosVideojuego(pListaDeseos);
        }
    }
}
