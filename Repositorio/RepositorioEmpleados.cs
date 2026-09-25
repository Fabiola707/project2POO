using System;
using project2.Clases;
using project2.Interfaz;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Collections.Generic;
using MySql.Data.MySqlClient;

namespace project2.Repositorio
{
    internal class RepositorioEmpleados : Irepocitory<Empleado>
    {

        private string connStr = "Server=localhost;Port=3307;Database=project2_db;Uid=root;Password=19503236;";
        //"Server=localhost;Port=3307;Database=Localhost instance MySQL801;Uid=root;Password=19503236;";

        public void Registro(Empleado empleado)
        {
            using (MySqlConnection conn = new MySqlConnection(connStr))
            {
                string query = "INSERT INTO empleados (Nombre, Salario, Edad) VALUES (@nombre, @salario, @edad)";
                using (MySqlCommand comm = new MySqlCommand(query, conn))
                {
                    comm.Parameters.AddWithValue("@codigo", empleado.Codigo);
                    comm.Parameters.AddWithValue("@nombre", empleado.Nombre);
                    comm.Parameters.AddWithValue("@salario", empleado.Salario);
                    comm.Parameters.AddWithValue("@edad", empleado.Edad);
                    try
                    {
                        conn.Open();
                        comm.ExecuteNonQuery();
                        Console.WriteLine("Empleado registrado");
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("Error: " + ex.Message);
                    }
                }
            }
            
        }
        //actualizar empleado
        public void Actualizar(Empleado empleado)
        {
            using (MySqlConnection conn = new MySqlConnection(connStr))
            {
                MySqlCommand comm = new MySqlCommand("UPDATE empleados SET nombre=@nombre, salario=@salario, edad=@edad WHERE ID=@id", conn);
                comm.Parameters.AddWithValue("@codigo", empleado.Codigo);
                comm.Parameters.AddWithValue("@nombre", empleado.Nombre);
                comm.Parameters.AddWithValue("@salario", empleado.Salario);
                comm.Parameters.AddWithValue("@edad", empleado.Edad);
                comm.Parameters.AddWithValue("@id", empleado.ID);

                try
                {
                    conn.Open();
                    int filas = comm.ExecuteNonQuery();
                    if (filas > 0)
                    {
                        Console.WriteLine("Empleado actualizado correctamente.");
                    }
                    else
                    {
                        Console.WriteLine("No se encontró el empleado con ID: " + empleado.ID);
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
                finally
                {
                    conn.Close();
                }
            }
        }
        //borrar
        public void Borrar(Empleado empleado)
        {
            using (MySqlConnection conn = new MySqlConnection(connStr))
            {
                MySqlCommand comm = new MySqlCommand("DELETE FROM empleados WHERE ID=@id", conn);
                comm.Parameters.AddWithValue("@id", empleado.ID);
                try
                {
                    conn.Open();
                    int filas = comm.ExecuteNonQuery();
                    if (filas > 0)
                    {
                        Console.WriteLine("Empleado eliminado correctamente.");
                    }
                    else
                    {
                        Console.WriteLine("No se encontró el empleado con ID: " + empleado.ID);
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
                finally
                {
                    conn.Close();
                }
            }
            Console.WriteLine("Empleado eliminado.");
        }
        //lista
        public List<Empleado> Lista()
        {
            List<Empleado> empleados = new List<Empleado>();

            using (MySqlConnection conn = new MySqlConnection(connStr))
            {
                string query = "SELECT * FROM empleados";

                using (MySqlCommand comm = new MySqlCommand(query, conn))
                {
                        try
                    {
                        conn.Open();
                        using (MySqlDataReader dr = comm.ExecuteReader())
                            while (dr.Read())
                            {
                                Empleado empleado = new Empleado();
                                empleado.ID = Convert.ToInt32(dr["ID"]);
                                empleado.Codigo = Convert.ToInt32(dr["Codigo"]);
                                empleado.Nombre = dr["Nombre"].ToString();    
                                empleado.Edad = Convert.ToInt32(dr["Edad"]);
                                empleado.Salario = Convert.ToDecimal(dr["Salario"]);

                                empleados.Add(empleado);
                            }
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("Error: " + ex.Message);
                    }
                }
            }

            return empleados;
        }
        //buscar
        public List<Empleado> Buscar(string nombre)
        {
            List<Empleado> empleados = new List<Empleado>();
            using (MySqlConnection conn = new MySqlConnection(connStr))
            {
                string query = "SELECT id, codigo, nombre * FROM empleados WHERE Nombre LIKE @criterio OR codigo LIKE @criterio";
                using (MySqlCommand comm = new MySqlCommand(query, conn))
                {
                    comm.Parameters.AddWithValue("@nombre", "%" + nombre + "%");
                    try
                    {
                        conn.Open();
                        using (MySqlDataReader dr = comm.ExecuteReader())
                            while (dr.Read())
                            {
                                Empleado empleado = new Empleado();
                                empleado.Nombre = dr["Nombre"].ToString();
                                empleado.ID = Convert.ToInt32(dr["ID"]);
                                empleado.Codigo = Convert.ToInt32(dr["Codigo"]);
                               // empleado.Edad = Convert.ToInt32(dr["Edad"]);
                                //empleado.Salario = Convert.ToDecimal(dr["Salario"]);
                                empleados.Add(empleado);
                            }
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("Error: " + ex.Message);
                    }
                }
            }
            return empleados;
        }
        //codigo de empleado para ingresar
        public bool ValidarCodigo(int codigo)
        {
            using (MySqlConnection conn = new MySqlConnection(connStr))
            {
                string query = "SELECT COUNT(*) FROM empleados WHERE Codigo = @codigo";
                using (MySqlCommand comm = new MySqlCommand(query, conn))
                {
                    comm.Parameters.AddWithValue("@codigo", codigo);
                    try
                    {
                        conn.Open();
                        int count = Convert.ToInt32(comm.ExecuteScalar());
                        return count > 0; // Retorna true si el código existe, false si no
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("Error: " + ex.Message);
                        return false;
                    }
                }
            }
        }
    }
}
