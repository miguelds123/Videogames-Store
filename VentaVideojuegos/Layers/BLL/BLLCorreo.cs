using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VentaVideojuegos
{
    class BLLCorreo : IBLLCorreo
    {
        public void DeleteCorreo(string pId, string pCorreo)
        {
            IDALCorreo _DALCorreo= new DALCorreo();

            _DALCorreo.DeleteCorreo(pId, pCorreo);
        }

        public List<Correo> GetAllCorreo()
        {
            IDALCorreo _DALCorreo = new DALCorreo();

            return _DALCorreo.GetAllCorreo();
        }

        public List<Correo> GetCorreoByFilter(string pCorreo)
        {
            IDALCorreo _DALCorreo = new DALCorreo();

            return _DALCorreo.GetCorreoByFilter(pCorreo);
        }

        public List<Correo> GetCorreoByIdCliente(string pId)
        {
            IDALCorreo _DALCorreo = new DALCorreo();

            return _DALCorreo.GetCorreoByIdCliente(pId);
        }

        public void SaveCorreo(Correo correo)
        {
            IDALCorreo _DALCorreo = new DALCorreo();

            _DALCorreo.SaveCorreo(correo);
        }

        public void UpdateCorreo(Correo correo, string pCorreoViejo, string pIdClienteViejo)
        {
            IDALCorreo _DALCorreo = new DALCorreo();

            _DALCorreo.UpdateCorreo(correo, pCorreoViejo, pIdClienteViejo);
        }
    }
}
