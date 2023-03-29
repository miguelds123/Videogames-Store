using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VentaVideojuegos
{
    class BLLTelefono : IBLLTelefono
    {
        public bool DeleteTelefono(string pId, string pTelefono)
        {
            IDALTelefono _DALTelefono= new DALTelefono();

            return _DALTelefono.DeleteTelefono(pId, pTelefono);
        }

        public List<Telefono> GetAllTelefono()
        {
            IDALTelefono _DALTelefono = new DALTelefono();

            return _DALTelefono.GetAllTelefono();
        }

        public List<Telefono> GetTelefonoByFilter(string pNumeroTelefono)
        {
            IDALTelefono _DALTelefono = new DALTelefono();

            return _DALTelefono.GetTelefonoByFilter(pNumeroTelefono);
        }

        public List<Telefono> GetTelefonoByIdCliente(string pId)
        {
            IDALTelefono _DALTelefono = new DALTelefono();

            return _DALTelefono.GetTelefonoByIdCliente(pId);
        }

        public List<Telefono> SaveTelefono(Telefono pTelefono)
        {
            IDALTelefono _DALTelefono = new DALTelefono();

            return _DALTelefono.SaveTelefono(pTelefono);
        }

        public List<Telefono> UpdateTelefono(Telefono pTelefono, string pTelefonoViejo, string pIdClienteViejo)
        {
            IDALTelefono _DALTelefono = new DALTelefono();

            return _DALTelefono.UpdateTelefono(pTelefono, pTelefonoViejo, pIdClienteViejo);
        }
    }
}
