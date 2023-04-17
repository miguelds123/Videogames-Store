using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VentaVideojuegos.Layers.DAL;

namespace VentaVideojuegos
{
    class BLLFacturaVideojuego
    {
        public int GetCurrentNumeroFactura()
        {
            DALFacturaVideojuego _DALFacturaVideojuego= new DALFacturaVideojuego();

            return _DALFacturaVideojuego.GetCurrentNumeroFactura();
        }

        public int GetNextNumeroFactura()
        {
            DALFacturaVideojuego _DALFacturaVideojuego = new DALFacturaVideojuego();

            return _DALFacturaVideojuego.GetNextNumeroFactura();
        }

        public void SaveFactura(OrdenCompraDTO pOrdenCompraDTO)
        {
            DALFacturaVideojuego _DALFacturaVideojuego = new DALFacturaVideojuego();

            _DALFacturaVideojuego.SaveFactura(pOrdenCompraDTO);
        }

        private OrdenCompraDTO GetFactura(double pNumeroFactura)
        {
            DALFacturaVideojuego _DALFacturaVideojuego = new DALFacturaVideojuego();

            return _DALFacturaVideojuego.GetFactura(pNumeroFactura);
        }
    }
}
