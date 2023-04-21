using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VentaVideojuegos
{
    public class OrdenCompraDTO
    {
        public int ID { get; set; }

        public DateTime FechaOrden { get; set; }

        public int IdCliente { get; set; }

        public double Total { get; set; }

        public double TotalDolares { get; set; }

        public double SubTotal { get; set; }

        public List<DetalleOrden> listaDetalles { get; set; } = new List<DetalleOrden>();


    }
}
