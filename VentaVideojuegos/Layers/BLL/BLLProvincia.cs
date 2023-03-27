using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VentaVideojuegos.Interfaces;

namespace VentaVideojuegos.Layers.DAL
{
    class BLLProvincia : IBLLProvincia
    {
        public List<Provincia> GetAllProvincia()
        {
            IDALProvincia _DALProvincia=  new DALProvincia();

            return _DALProvincia.GetAllProvincia();
        }
    }
}
