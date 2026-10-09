using Google.Protobuf.WellKnownTypes;
using MySql.Data.MySqlClient;
using Core;
using Core.Clases;
using Core.Repositorio;
using project2.Clases;
using MySql;


//mysql contraseña 19503236
//en agregar referencia y selecciona core
///agregar un proyecto de windows form
namespace project2 //ERRORR blyat
{
    class Program
    {
        static void Main(string[] args)
        {
            // antes
            RepositorioEmpleados repoEmpleados = new RepositorioEmpleados(); //error blyat
            RepositorioProductos repoProductos = new RepositorioProductos();
            RepositorioVentas repoVentas = new RepositorioVentas();

            // después (usar la cadena de conexión que ya tenga tu proyecto)
            string conn = Utils.connString;
            RepositorioEmpleados repoEmpleados = new RepositorioEmpleados(conn);
            RepositorioProductos repoProductos = new RepositorioProductos(conn);
            RepositorioVentas repoVentas = new RepositorioVentas(conn);
            Empleado empleado = new Empleado();
            Producto producto = new Producto();

            bool codigoValidos = false;
            //paso 1 validar por codigo de empleado

            while (!codigoValidos)
            {
                Console.Clear();
                Console.WriteLine("SISTEMA DE ACCESO");
                Console.WriteLine("Ingrese el código del empleado:");

                string inputCodigo = Console.ReadLine();
                if (int.TryParse(inputCodigo, out int codigo))
                {
                    if (repoEmpleados.ValidarCodigo(codigo))
                    {
                        codigoValidos = true;
                        Console.WriteLine("Acceso concedido. Presione una tecla para continuar.");
                        Console.ReadKey();
                    }
                    else
                    {
                        Console.WriteLine("Código inválido. presiona enter para intenta nuevamente.");
                        Console.ReadKey();
                    }
                }

                else
                {
                    Console.WriteLine("Entrada no válida. presione enter para intentar nuevamente.");
                    Console.ReadKey();
                }
            }
            //paso 2 mostrar menu de opciones
            bool salir = false;
            while (!salir)
            {
                Console.Clear();

                Console.WriteLine("Menu:\n");
                Console.WriteLine("1- Empleados\n");
                Console.WriteLine("2- Productos\n");
                Console.WriteLine("3- Tienda\n");
                Console.WriteLine("4- Salir\n");
                string opcionM = Console.ReadLine();
                if (opcionM == "4")
                {
                    salir = true;
                    continue;
                }
                switch (opcionM)
                {
                    case "1": //empleados
                    case "2": //productos
                        Console.WriteLine("\nMovimiento que desea realizar:\n");
                        Console.WriteLine("1- Registrar\n");
                        Console.WriteLine("2- Actualizar\n");
                        Console.WriteLine("3- Borrar\n");
                        Console.WriteLine("4- Lista\n");
                        string opcionA = Console.ReadLine().ToUpper();

                        if (opcionM == "1")
                        {
                            Empleado empleado = new Empleado();
                            switch (opcionA)
                            {
                                // Registrar 
                                case "1":
                                    Console.Write("Ingrese el código del empleado: ");
                                    empleado.Codigo = Convert.ToInt32(Console.ReadLine());
                                    Console.Write("Nombre del empleado: ");
                                    empleado.Nombre = Console.ReadLine();
                                    Console.Write("Salario del empleado: ");
                                    empleado.Salario = Convert.ToDecimal(Console.ReadLine());
                                    Console.Write("Edad del empleado: ");
                                    empleado.Edad = Convert.ToInt32(Console.ReadLine());

                                    repoEmpleados.Registro(empleado);
                                    Console.WriteLine("Empleado registrado con éxito.");
                                    break;
                                // Actualizar 
                                case "2":
                                    Console.Write("Ingrese el ID del empleado: ");
                                    empleado.Id = Convert.ToInt32(Console.ReadLine());
                                    Console.Write("Ingrese el nuevo código: ");
                                    empleado.Codigo = Convert.ToInt32(Console.ReadLine());
                                    Console.Write("Ingrese nuevo nombre: ");
                                    empleado.Nombre = Console.ReadLine();
                                    Console.Write("Ingrese nuevo salario: ");
                                    empleado.Salario = Convert.ToDecimal(Console.ReadLine());
                                    Console.Write("Ingrese nueva edad: ");
                                    empleado.Edad = Convert.ToInt32(Console.ReadLine());

                                    repoEmpleados.Actualizar(empleado);
                                    Console.WriteLine("Empleado actualizado.");
                                    break;

                                // Borrar 
                                case "3":
                                    Console.Write("Ingrese el ID del empleado a borrar: ");
                                    empleado.Id = Convert.ToInt32(Console.ReadLine());
                                    repoEmpleados.Borrar(empleado);
                                    Console.WriteLine("Empleado borrado.");
                                    break;

                                // Lista
                                case "4":
                                    List<Empleado> listaEmpleados = repoEmpleados.Lista();//lista de empleados
                                    Console.WriteLine("\n--- Lista de Empleados ---");
                                    foreach (Empleado emp in listaEmpleados)
                                    {
                                        Console.WriteLine($"ID: {emp.Id} | Código: {emp.Codigo} | Nombre: {emp.Nombre} | Edad: {emp.Edad} | Salario: ${emp.Salario:F2}");
                                    }
                                    break;

                                default:
                                    Console.WriteLine("Opción no válida.");
                                    break;
                            }
                        }
                        else if (opcionM == "2")
                        {
                            Producto producto = new Producto();//nuevo objeto producto
                            switch (opcionA)
                            {
                                case "1"://registrar
                                    Console.Write("Nombre del producto: ");
                                    producto.Nombre = Console.ReadLine();
                                    Console.Write("Precio del producto: ");
                                    producto.Precio = Convert.ToDecimal(Console.ReadLine());

                                    repoProductos.Registro(producto);
                                    Console.WriteLine("Producto registrado con exito");
                                    break;
;//==========================================================================================================================
 //hasta aqui tenia pequeños errores
 //==========================================================================================================================
                                case "2"://actualizar
                                    Console.Write("Ingrese el ID del producto: ");
                                    producto.Id = Convert.ToInt32(Console.ReadLine());
                                    Console.Write("Ingrese nuevo nombre: ");
                                    producto.Nombre = Console.ReadLine();
                                    Console.Write("Ingrese nuevo precio: ");
                                    producto.Precio = Convert.ToDecimal(Console.ReadLine());

                                    repoProductos.Actualizar(producto);
                                    Console.WriteLine("Producto actualizado.");
                                    break;

                                case "3"://borrar
                                    Console.Write("Ingrese el ID del producto a eliminar: ");
                                    producto.Id = Convert.ToInt32(Console.ReadLine());
                                    repoProductos.Borrar(producto);
                                    Console.WriteLine("Producto eliminado.");
                                    break;
                                case "4"://lista
                                    List<Producto> listaProductos = repoProductos.Lista();
                                    Console.WriteLine("\n--- Lista de Productos ---");
                                    foreach (Producto prod in listaProductos)
                                    {
                                        Console.WriteLine($"ID: {prod.Id} | Nombre: {prod.Nombre} | Precio: ${prod.Precio:F2}");
                                    }
                                    break;

                                default:
                                    Console.WriteLine("Opción no válida.");
                                    break;
                            }
                        }
                        break;
                        //==========================================================================================================================
                                case "3": // TIENDA / REGISTRO DE VENTA
                                    Venta venta = new Venta
                                {
                                    Total = 0,
                                    Fecha = DateTime.Now,
                                    producto = new List<VentaProductos>()
                        };

                        bool agregarMas = true;

                        while (agregarMas)
                        {
                            Console.Clear();
                            Console.WriteLine("     REGISTRO DE VENTA      ");
                            Console.Write("Ingrese el código del producto: ");//pedir el codigo del producto

                            if (int.TryParse(Console.ReadLine(), out int idProducto))
                            {
                                Producto prodInfo = repoProductos.GetById(idProducto);
                                if (prodInfo != null)
                                {
                                    Console.Write($"ingrese la cantidad de'{prodInfo.Nombre}': ");//pedir la cantidad de producto
                                    if (int.TryParse(Console.ReadLine(), out int cant))
                                    {
                                        decimal subtotal = prodInfo.Precio * cant;
                                        VentaProductos item = new VentaProductos
                                        {
                                            IdProducto = prodInfo.Id,
                                            NombreProducto = prodInfo.Nombre,
                                            PrecioUnitario = prodInfo.Precio,
                                            Cantidad = cant,
                                            Subtotal = subtotal
                                        };

                                        venta.producto.Add(item);
                                        venta.Total += subtotal;
                                        Console.WriteLine("--> Producto agregado");//agregar el producto a la venta
                                    }
                                    else
                                    {
                                        Console.WriteLine("Cantidad no válida");
                                    }
                                }
                                else
                                {
                                    Console.WriteLine("El producto no existe");
                                }
                            }
                            else
                            {
                                Console.WriteLine("Código no válido.");
                            }

                            Console.Write("\n¿Desea agregar otro producto? (S/N): ");
                            string resp = Console.ReadLine().ToUpper();
                            if (resp != "S")
                            {
                                agregarMas = false;
                            }
                        }
                        /*Lo que queremos que se muestre en pantalla
                         * ---------------------Ticket------------------------
                         * producto----precio unitario----cantidad----subtotal
                         * Peras-------35.00--------------4-----------150.00 *
                         * Queso-------120.00-------------1-----------120.00 *
                         * Total--------------------------------------270.00 *
                         * ---------------------------------------------------
                         */
                        //ticket salida
                        Console.Clear();
                        Console.WriteLine("**********************TICKET***********************");
                        Console.WriteLine($"{"Producto",-18} {"P.Unit",-10} {"Cant",-6} {"Subtotal",-8}");
                        Console.WriteLine("***************************************************");

                        foreach (VentaProductos prod in venta.producto)
                        {
                            Console.WriteLine($"{prod.NombreProducto,-18} ${prod.PrecioUnitario,-9:F2} {prod.Cantidad,-6} ${prod.Subtotal,-8:F2}");
                        }//formato tabulado para alinear nombre, cantidad y total de cada item

                        Console.WriteLine("***************************************");
                        Console.WriteLine($"TOTAL: ${venta.Total:F2}");
                        Console.WriteLine("***************************************");

                        // Registro en la base de datos
                        repoVentas.RegistrarVenta(venta);
                        break;
                }

                Console.WriteLine("\nPresione cualquier tecla");
                Console.ReadKey();
            }
        }
        //,mysql 
        /*VENTAS(es id de aqui es el id cuenta en la siguiente tabla)
                 * id--empleado--fecha--total
                 *   |          |      |     |
                 *---------------------------
                 *   |          |      |     |
                 *---------------------------
                 *
                 *VENTA PRODUCTOS
                 * id--id cuenta--id producto--precio--cantidad--total
                 *   |           |            |       |         |      |
                 * -----------------------------------------------------
                 *   |           |            |       |         |      |
                 * -----------------------------------------------------*/

        public static string ObtenerCodigoConsecutivoVenta()
        {
            string prefijoFecha = DateTime.Now.ToString("yyyyMMdd");//2026 07 15 + numero de venta
            string consulta = "SELECT COUNT(*) + 1 FROM ventas WHERE DATE(fecha) = CURDATE()";
            int consecutivo = 1;

            using (MySqlConnection conn = new MySqlConnection(Utils.connString))
            {
                MySqlCommand comm = new MySqlCommand(consulta, conn);
                try
                {
                    conn.Open();
                    object res = comm.ExecuteScalar();
                    if (res != null && res != DBNull.Value)
                    {
                        consecutivo = Convert.ToInt32(res);
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error al consultar MySQL: {ex.Message}");
                }
            }

            return $"{prefijoFecha}-{consecutivo:D4}";
        }
    }
}