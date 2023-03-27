using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VentaVideojuegos.Layers.DAL;
using VentaVideojuegos.Layers.Entities;

namespace VentaVideojuegos
{
    class BLLCanton : IBLLCanton
    {
        public List<Canton> GetAllCanton()
        {
            IDALCanton _DALCanton= new DALCanton();

            return _DALCanton.GetAllCanton();
        }
    }
}
