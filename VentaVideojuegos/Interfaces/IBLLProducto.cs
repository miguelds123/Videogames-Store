using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VentaVideojuegos
{
    interface IBLLProducto
    {
        Producto GetProductoById(double pId);
        List<Producto> GetAllProducto();
        List<Producto> GetProductoByFilter(string pDescripcion);
        void SaveProducto(Producto pProducto);
        void UpdateProducto(Producto pProducto);
        void DeleteProducto(double pId);
        Producto AvabilityStock(double pId, double pCantidadSolicitada);

    }
}
