using System;
using System.Collections.Generic;
using System.Text;

namespace project2.Clases
{
    public class Venta
    { //5 propiedades
        public int Id { get; set; }//*****
        public string CodigoVenta { get; set; } //codigo de venta       
        
        public DateTime Fecha { get; set; }//fecha de venta*****
        public Empleado Empleado { get; set; }//empleado que realizo la venta
        public decimal Total { get; set; } //total de la venta******
        public List<VentaProductos> Detalles { get; set; } = new List<VentaProductos>//lista de productos ERROR EN DETALLES


        /*Para mysql, una tabla tal que así
         * VENTAS (es id de aqui es el id cuenta en la siguiente tabla)
         * id--empleado--fecha--total
         *   |          |      |     |
         * ---------------------------
         *   |          |      |     |
         * ---------------------------
         *   
         * VENTA PRODUCTOS
         * id--id cuenta--id producto--precio--cantidad--total
         *   |           |            |       |         |      |
         * -----------------------------------------------------
         *   |           |            |       |         |      |
         * -----------------------------------------------------*/
        public Venta()
        {
            NombreProducto = new List<VentaProductos>();//ERROR
            Total = 0;
            Fecha = DateTime.Now;
        }
        public void AgregarProducto(Producto producto, int cantidad)
        {
            decimal totalProducto = producto.Precio * cantidad;
            VentaProductos productoVendido = new VentaProductos
            {
                ProductoId = productoId,//ERROR 
                Cantidad = cantidad,
                Subtotal = totalProducto

            };

            Producto.Add(productoVendido);//ERROR
            Total += totalProducto;
        }

    }
}
