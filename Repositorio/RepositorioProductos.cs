using project2.Clases;
using project2.Interfaz;
using System;
using System.Collections.Generic;
using System.Text;
using MySql.Data.MySqlClient;

//agregar vender 
namespace project2.Repositorio

{
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
        public void Vender(Producto producto)
        {
            using (MySqlConnection conn = new MySqlConnection(connStr))
            {
                string query = "INSERT INTO ventas (Nombre, Precio) VALUES (@nombre, @precio)";
                using (MySqlCommand comm = new MySqlCommand(query, conn))
                {
                    comm.Parameters.AddWithValue("@nombre", producto.Nombre);
                    comm.Parameters.AddWithValue("@precio", producto.Precio);
                    try
                    {
                        conn.Open();
                        comm.ExecuteNonQuery();
                        Console.WriteLine("Producto vendido");
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("Error: " + ex.Message);
                    }
                }
            }
        }
    }
}

