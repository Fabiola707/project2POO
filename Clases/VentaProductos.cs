using System;
using System.Collections.Generic;
using System.Text;

namespace project2.Clases
{
    internal class VentaProductos
    {//3 propiedades
        public int ProductoId { get; set; }
        public float NombreProducto { get; set; }
        public int Cantidad { get; set; }
        public decimal PrecioUnitario { get; set; }
        public decimal Subtotal { get; set; }
        
    }
}
