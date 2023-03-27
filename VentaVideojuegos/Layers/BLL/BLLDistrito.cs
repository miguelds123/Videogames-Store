using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VentaVideojuegos.Interfaces;
using VentaVideojuegos.Layers.Entities;

namespace VentaVideojuegos
{
    class BLLDistrito : IBLLDistrito
    {
        public List<Distrito> GetAllDistrito()
        {
            IDALDistrito _DALDistrito= new DALDistrito();

            return _DALDistrito.GetAllCanton();
        }
    }
}
