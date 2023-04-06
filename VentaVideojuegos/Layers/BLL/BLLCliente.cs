using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VentaVideojuegos.Interfaces;

namespace VentaVideojuegos
{
    class BLLCliente : IBLLCliente
    {
        public void BorradoLogico(string pId)
        {
            IDALCliente _DALCliente = new DALCliente();

            _DALCliente.BorradoLogico(pId);
        }

        public void DeleteCliente(string pId)
        {
            IDALCliente _DALCliente= new DALCliente();

            _DALCliente.DeleteCliente(pId);
        }

        public List<Cliente> GetAllCliente()
        {
            IDALCliente _DALCliente = new DALCliente();

            return _DALCliente.GetAllCliente();
        }

        public List<Cliente> GetClienteByFilter(string pDescripcion)
        {
            IDALCliente _DALCliente = new DALCliente();

            return _DALCliente.GetClienteByFilter(pDescripcion);
        }

        public Cliente GetClienteById(string pId)
        {
            IDALCliente _DALCliente = new DALCliente();

            return _DALCliente.GetClienteById(pId);
        }

        public void SaveCliente(Cliente pCliente)
        {
            IDALCliente _DALCliente = new DALCliente();

            _DALCliente.SaveCliente(pCliente);
        }

        public void UpdateCliente(Cliente pCliente)
        {
            IDALCliente _DALCliente = new DALCliente();

            _DALCliente.UpdateCliente(pCliente);
        }
    }
}
