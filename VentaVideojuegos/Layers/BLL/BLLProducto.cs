using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VentaVideojuegos
{
    class BLLProducto : IBLLProducto
    {
        public Producto AvabilityStock(double pId, double pCantidadSolicitada)
        {
            IDALProducto _DALProducto= new DALProducto();
            Producto producto= _DALProducto.GetProductoById(pId);

            if (producto.CantidadInventario < pCantidadSolicitada)
            {
                throw new Exception($"No hay cantidad suficiente en inventario para el producto {producto.ID} {producto.Descripcion}, cantidad disponible: {producto.CantidadInventario}");
            }
            else
            {
                return producto;
            }
        }

        public bool DeleteProducto(double pId)
        {
            IDALProducto _DALProducto= new DALProducto();

            return _DALProducto.DeleteProducto(pId);
        }

        public List<Producto> GetAllProducto()
        {
            IDALProducto _DALProducto = new DALProducto();

            return _DALProducto.GetAllProducto();
        }

        public List<Producto> GetProductoByFilter(string pDescripcion)
        {
            IDALProducto _DALProducto = new DALProducto();

            return _DALProducto.GetProductoByFilter(pDescripcion);
        }

        public Producto GetProductoById(double pId)
        {
            IDALProducto _DALProducto = new DALProducto();

            return _DALProducto.GetProductoById(pId);
        }

        public Producto SaveProducto(Producto pProducto)
        {
            IDALProducto _DALProducto = new DALProducto();

            return _DALProducto.SaveProducto(pProducto);
        }

        public Producto UpdateProducto(Producto pProducto)
        {
            IDALProducto _DALProducto = new DALProducto();

            return _DALProducto.UpdateProducto(pProducto);
        }
    }
}
