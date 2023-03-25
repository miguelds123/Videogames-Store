using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VentaVideojuegos
{
    interface IDALProducto
    {
        Producto GetProductoById(double pId);
        List<Producto> GetAllProducto();
        List<Producto> GetProductoByFilter(string pDescripcion);
        Producto SaveProducto(Producto pProducto);
        Producto UpdateProducto(Producto pProducto);
        bool DeleteProducto(double pId);
    }
}
