using System;
using System.Collections.Generic;
using System.Text;

namespace project2.Clases
{
    public class Venta
    { //5 propiedades
        public string CodigoVenta { get; set; } //codigo de venta       
        public List<VentaProductos> productos { get; set; } //lista de productos
        public DateTime Fecha { get; set; }//fecha de venta
        public Empleado Empleado { get; set; }//empleado que realizo la venta
        public decimal Total { get; set; } //total de la venta

        public Venta()
        {
            productos = new List<VentaProductos>();
            Total = 0;
            Fecha = DateTime.Now;
        }
        public void AgregarProducto(Producto producto, int cantidad)
        {
            decimal totalProducto = producto.Precio * cantidad;
            VentaProductos productoVendido = new VentaProductos
            {
                producto = producto,
                cantidad = cantidad,
                total = totalProducto

            };

            productos.Add(productoVendido);
            Total += totalProducto;
        }

    }
}
