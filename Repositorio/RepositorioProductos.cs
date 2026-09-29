using project2.Clases;
using project2.Interfaz;
using System;
using System.Collections.Generic;
using System.Text;
using MySql.Data.MySqlClient;
using System.Reflection.Metadata.Ecma335;

//agregar vender 
namespace project2.Repositorio

{
    //siempre marca error el repocitory
    internal class RepositorioProductos : Irepocitory<Producto>

    {
        private string connStr = "Server=localhost;Port=3307;Database=project2_db;Uid=root;Password=19503236;";
        //actualizar
        public void Actualizar(Producto producto)
        {
            using (MySqlConnection conn = new MySqlConnection(connStr))
            {
                string query = "UPDATE productos SET Nombre = @nombre, Precio = @precio WHERE ID = @id";
                using (MySqlCommand comm = new MySqlCommand(query, conn))
                {
                    comm.Parameters.AddWithValue("@nombre", producto.Nombre);
                    comm.Parameters.AddWithValue("@precio", producto.Precio);
                    comm.Parameters.AddWithValue("@id", producto.ID);
                    try
                    {
                        conn.Open();
                        comm.ExecuteNonQuery();
                        Console.WriteLine("Producto actualizado");
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("Error: " + ex.Message);
                    }
                }
            }
            //Console.WriteLine("Producto actualizado: ");
        }
        //borrar
        public void Borrar(Producto producto)
        {
            using (MySqlConnection conn = new MySqlConnection(connStr))
            {
                string query = "DELETE FROM productos WHERE ID = @id";
                using (MySqlCommand comm = new MySqlCommand(query, conn))
                {
                    comm.Parameters.AddWithValue("@id", producto.ID);
                    try
                    {
                        conn.Open();
                        comm.ExecuteNonQuery();
                        Console.WriteLine("Producto eliminado");
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("Error: " + ex.Message);
                    }
                }
            }
            //Console.WriteLine("Producto eliminado: " );
        }
        //buscar
        public List<Producto> Buscar(string nombre)
        {
            List<Producto> productos = new List<Producto>();
            using (MySqlConnection conn = new MySqlConnection(connStr))
            {
                string query = "SELECT * FROM productos WHERE Nombre LIKE @nombre";
                using (MySqlCommand comm = new MySqlCommand(query, conn))
                {
                    comm.Parameters.AddWithValue("@nombre", "%" + nombre + "%");
                    try
                    {
                        conn.Open();
                        using (MySqlDataReader reader = comm.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                Producto producto = new Producto();
                                producto.ID = reader.GetInt32("ID");
                                producto.Nombre = reader.GetString("Nombre");
                                producto.Precio = reader.GetDecimal("Precio");
                                productos.Add(producto);
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("Error: " + ex.Message);
                    }
                }
            }
            //throw new NotImplementedException();
            return productos;
        }
        //lista
        public List<Producto> Lista()
        {
            List<Producto> productos = new List<Producto>();
            using (MySqlConnection conn = new MySqlConnection(connStr))
            {
                string query = "SELECT * FROM productos";
                using (MySqlCommand comm = new MySqlCommand(query, conn))
                {
                    try
                    {
                        conn.Open();
                        using (MySqlDataReader reader = comm.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                Producto producto = new Producto();
                                producto.ID = reader.GetInt32("ID");
                                producto.Nombre = reader.GetString("Nombre");
                                producto.Precio = reader.GetDecimal("Precio");
                                productos.Add(producto);
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("Error: " + ex.Message);
                    }
                }
            }
            return productos;
        }
        //registro
        public void Registro(Producto producto)
        {
            using (MySqlConnection conn = new MySqlConnection(connStr))
            {
                string query = "INSERT INTO productos (Nombre, Precio) VALUES (@nombre, @precio)";
                using (MySqlCommand comm = new MySqlCommand(query, conn))
                {
                    comm.Parameters.AddWithValue("@nombre", producto.Nombre);
                    comm.Parameters.AddWithValue("@precio", producto.Precio);
                    try
                    {
                        conn.Open();
                        comm.ExecuteNonQuery();
                        Console.WriteLine("Producto registrado");
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("Error: " + ex.Message);
                    }
                }
            }
        }
        public Producto ObtenerProducto(int id)
        {
            Producto producto = null;

            using (MySqlConnection conn = new MySqlConnection(connStr))
            {
                string query = "SELECT ID, Nombre, Precio FROM productos WHERE ID = @id";

                using (MySqlCommand comm = new MySqlCommand(query, conn))
                {
                    comm.Parameters.AddWithValue("@id", id);

                    try
                    {
                        conn.Open();

                        using (MySqlDataReader reader = comm.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                producto = new Producto
                                {
                                    ID = reader.GetInt32("ID"),
                                    Nombre = reader.GetString("Nombre"),
                                    Precio = reader.GetDecimal("Precio")
                                };
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("Error al consultar producto: " + ex.Message);
                    }
                }
            }

            return producto;
        }
        

        public void Vender(int idProducto, int cantidad, decimal subtotal)
        {
            using (MySqlConnection conn = new MySqlConnection(connStr))
            {

                string query = "INSERT INTO ventas (ProductoID, Cantidad, Total, Fecha) VALUES (@idProducto, @cantidad, @subtotal, @fecha)";

                using (MySqlCommand comm = new MySqlCommand(query, conn))
                {
                    comm.Parameters.AddWithValue("@idProducto", idProducto);
                    comm.Parameters.AddWithValue("@cantidad", cantidad);
                    comm.Parameters.AddWithValue("@subtotal", subtotal);
                    comm.Parameters.AddWithValue("@fecha", DateTime.Now);

                    try
                    {
                        conn.Open();
                        comm.ExecuteNonQuery();
                        Console.WriteLine("Venta registrada en MySQL con éxito.");
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("Error al guardar venta: " + ex.Message);
                    }
                }
            }
        }
        public void HistorialVentas()
        {
            using (MySqlConnection conn = new MySqlConnection(connStr))
            {
                // Realizamos un JOIN para mostrar el nombre del producto vendido
                string query = @"SELECT v.ID, p.Nombre, v.Cantidad, v.Total, v.Fecha 
                        FROM ventas v 
                        INNER JOIN productos p ON v.ProductoID = p.ID";

                using (MySqlCommand comm = new MySqlCommand(query, conn))
                {
                    try
                    {
                        conn.Open();
                        using (MySqlDataReader reader = comm.ExecuteReader())
                        {
                            Console.WriteLine("\n=== HISTORIAL DE VENTAS ===");
                            while (reader.Read())
                            {
                                Console.WriteLine($"ID Venta: {reader["ID"]} | Producto: {reader["Nombre"]} | Cantidad: {reader["Cantidad"]} | Total: ${reader["Total"]} | Fecha: {reader["Fecha"]}");
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("Error al cargar historial: " + ex.Message);
                    }
                }
            }
        }
    }

}

