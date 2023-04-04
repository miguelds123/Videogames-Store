using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VentaVideojuegos
{
    class BLLListaDeseos : IBLLListaDeseos
    {
        public void DeleteListaDeseos(string pIdCliente, string pIdProducto)
        {
            IDAListaDeseos _DALListaDeseos = new DALListaDeseos();

            _DALListaDeseos.DeleteListaDeseos(pIdCliente, pIdProducto);
        }

        public List<ListaDeseos> GetAllListaDeseos()
        {
            IDAListaDeseos _DALListaDeseos = new DALListaDeseos();

            return _DALListaDeseos.GetAllListaDeseos();
        }

        public ListaDeseos GetListaDeseos(string pIdCliente, string pIdProducto)
        {
            IDAListaDeseos _DALListaDeseos = new DALListaDeseos();

            return _DALListaDeseos.GetListaDeseos(pIdCliente, pIdProducto);
        }

        public List<ListaDeseos> GetListaDeseosByIdCliente(string pId)
        {
            IDAListaDeseos _DALListaDeseos = new DALListaDeseos();

            return _DALListaDeseos.GetListaDeseosByIdCliente(pId);
        }

        public List<ListaDeseos> GetListaDeseosByIdProducto(string pId)
        {
            IDAListaDeseos _DALListaDeseos = new DALListaDeseos();

            return _DALListaDeseos.GetListaDeseosByIdProducto(pId);
        }

        public void SaveListaDeseos(ListaDeseos pListaDeseos)
        {
            IDAListaDeseos _DALListaDeseos = new DALListaDeseos();

            _DALListaDeseos.SaveListaDeseos(pListaDeseos);
        }

        public void UpdateListaDeseos(ListaDeseos pListaDeseos)
        {
            IDAListaDeseos _DALListaDeseos = new DALListaDeseos();

            _DALListaDeseos.UpdateListaDeseos(pListaDeseos);
        }
    }
}
