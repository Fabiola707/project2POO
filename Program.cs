using project2.Clases;
using project2.Repositorio;

RepositorioEmpleados repoEmpleados = new RepositorioEmpleados();
bool codigoValidos = false;

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
Console.WriteLine("Menu:\n");
Console.WriteLine("1- Empleados\n");
Console.WriteLine("2- Productos\n");
Console.WriteLine("3- Tienda\n");

//agregar  venta e historial
string opcionM = Console.ReadLine();

Console.WriteLine("\nMovimiento que desea realizar:\n");
Console.WriteLine("1- Registrar\n");
Console.WriteLine("2- Actualizar\n");
Console.WriteLine("3- Borrar\n");
Console.WriteLine("4- Lista\n");


string opcionA = Console.ReadLine().ToUpper();

switch (opcionM)
{
    case "1": //empleados

       //RepositorioEmpleados repositorioEmpleados = new RepositorioEmpleados();
        Empleado empleado = new Empleado();

        switch (opcionA)
        {
            case "1": //registro
                Console.WriteLine("Ingrese el código del empleado:");
                empleado.Codigo = Convert.ToInt32(Console.ReadLine());

                Console.WriteLine("Nombre del empleado:");
                empleado.Nombre = Console.ReadLine();

                Console.WriteLine("Salario del empleado:");
                empleado.Salario = Convert.ToDecimal(Console.ReadLine());

                Console.WriteLine("Edad del empleado:");
                empleado.Edad = Convert.ToInt32(Console.ReadLine());

                Console.WriteLine("ID del empleado:");
                empleado.ID = Convert.ToInt32(Console.ReadLine());

                repoEmpleados.Registro(empleado);

                break;

            case "2": //actualizar

                Console.WriteLine("Ingrese el ID del empleado:");
                empleado.ID = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Ingrese el código del empleado:");
                empleado.Codigo = Convert.ToInt32(Console.ReadLine());

                Console.WriteLine("Ingrese nuevo nombre:");
                empleado.Nombre = Console.ReadLine();

                Console.WriteLine("Ingrese nuevo salario:");
                empleado.Salario = Convert.ToDecimal(Console.ReadLine());

                Console.WriteLine("Ingrese nueva edad:");
                empleado.Edad = Convert.ToInt32(Console.ReadLine());

                repoEmpleados.Actualizar(empleado);

                break;

            case "3": //borrar

                Console.WriteLine("Ingrese el ID del empleado:");

                empleado.ID = Convert.ToInt32(Console.ReadLine());

                repoEmpleados.Borrar(empleado);

                break;

            case "4": //Lista

                List<Empleado> listaEmpleados = repoEmpleados.Lista();
                Console.WriteLine("\nLista de empleados:\n");
                foreach (Empleado emp in listaEmpleados)
                {
                    Console.WriteLine(
                        $"ID: {emp.ID}\n Codigo: {emp.Codigo}\n Nombre: {emp.Nombre}\n Edad: {emp.Edad}\n Salario: {emp.Salario}\n"
                    );
                }

                break;
            default:
                Console.WriteLine("Opcion no valida.");
                break;
        }

        break;
//no se porquee sale error en caso 2, checar eso
    case "2": //productos
        RepositorioProductos repoProductos = new RepositorioProductos();
        Producto producto = new Producto();
        switch (opcionA)
        {
            case "1": //registro
                Console.WriteLine("Nombre del producto:");
                producto.Nombre = Console.ReadLine();

                Console.WriteLine("Precio del producto:");
                producto.Precio = Convert.ToDecimal(Console.ReadLine());
                Console.WriteLine("ID del producto:");
                producto.ID = Convert.ToInt32(Console.ReadLine());
                repoProductos.Registro(producto);

                break;

            case "2": //actualizar
                Console.WriteLine("Ingrese el ID del producto:");
                producto.ID = Convert.ToInt32(Console.ReadLine());

                Console.WriteLine("Ingrese nuevo nombre:");
                producto.Nombre = Console.ReadLine();

                Console.WriteLine("Ingrese nuevo precio:");
                producto.Precio = Convert.ToDecimal(Console.ReadLine());
                repoProductos.Actualizar(producto);

                break;

            case "3": //borrar
                Console.WriteLine("Ingrese el ID del producto:");
                producto.ID = Convert.ToInt32(Console.ReadLine());

                repoProductos.Borrar(producto);

                break;

            case "4": //Lista
                List<Producto> listaProductos = repoProductos.Lista();

                Console.WriteLine("\nLista de productos:\n");

                foreach (Producto prod in listaProductos)
                {
                    Console.WriteLine(
                        $"ID: {prod.ID}\n Nombre: {prod.Nombre}\n Precio: {prod.Precio}\n"
                    );
                }
                break;            
    default:
        Console.WriteLine("Opcion no valida.");
        break;
}
    case "3": //tienda
        Console.WriteLine("Modulo de tienda");
        Console.WriteLine("que movimiento desea realizar:\n");
        Console.WriteLine("1- Registrar venta\n");
        Console.WriteLine("2- Historial de ventas\n");
        string opcionT = Console.ReadLine().ToUpper();

        switch (opcionT)
        {
            case "1": //registrar venta
                RepositorioProductos repoProductosTienda = new RepositorioProductos();
                
                /*venta.CodigoVenta = DateTime.Now.ToString("yyyyMMddHHmmss");
                venta.Fecha = DateTime.Now;
                venta.Empleado = usuario;agregar*/
                Venta venta = new Venta();
                venta.Total = 0;
                venta.Fecha = DateTime.Now;                
                //doble error por la misma variable
                List<VentaProductos> ListaProductosVenta = new List<VentaProductos>();
                bool agregarMas = true;

                while (agregarMas)
                {
                    Console.Clear();
                    Console.WriteLine("Registro de venta");
                    Console.WriteLine("Ingrese el codigo del producto:");//pedir el codigo del producto
                    if (!int.TryParse(Console.ReadLine(),out int idProducto))
                    {
                        Console.WriteLine("codigo no valido");
                        Console.ReadKey();
                        continue;
                    }
                    //error por algo no sé que es, era el punto y coma 
                    //pedir la cantidad de producto
                    Console.WriteLine("ingrese cantidad ");
                }
                /*Console.WriteLine("Ingrese el codigo del producto:");
                int codigoProducto = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Ingrese la cantidad del producto:");
                int cantidad = Convert.ToInt32(Console.ReadLine()); */

                /*Lo que queremos que se muestre en pantalla
                 * ---------------------Ticket------------------------
                 * producto----precio unitario----cantidad----subtotal
                 * Peras-------35.00--------------4-----------150.00 *
                 * Queso-------120.00-------------1-----------120.00 *
                 * Total--------------------------------------270.00 *
                 * ---------------------------------------------------
                 */

                Console.WriteLine("Cobrando...");
                Console.WriteLine("producto--------cantidad--------total");

                foreach (VentaProductos prod in venta.productos)
                {
                    // Formato tabulado para alinear nombre, cantidad y total de cada item
                    Console.WriteLine($"{prod.producto.Nombre,-15} {prod.cantidad,-10} ${prod.total,8:F2}");
                }

                Console.WriteLine("-------------------------------------");
                Console.WriteLine($"Total: ${venta.Total:F2}");


                break;
            case "2": //historial de ventas
                Console.WriteLine("Modulo de historial de ventas");
                break;
            default:
                Console.WriteLine("Opcion no valida.");
                break;
        }

        break;
    default:
        Console.WriteLine("Opcion no valida.");
        break;

}
/*Console.WriteLine("Modulo de productos.");
empleado.Id = 0;
repoEmpleados.Actualizar(empleado);
for(int i = 0; i < listaEmpleados.Count; i++)
using project2.Clases;
using System;
namespace GestionEmpleados
{    class Program
    {        static void Main(string[] args)
        {            List<Empleado> empleados = new List<Empleado>
            {                //se pueden asignar empleados 
                new Programador("Emilian", 29, 35000m, "Java"),
                new Diseñador("George", 28, 30000, "Photoshop")            };
            Console.WriteLine("Equipo de trabajo\n");
            foreach (Empleado emp in empleados)
            {                emp.MostrarInformacion();
                emp.Trabajar(); //segun rol
                Console.WriteLine();
            }        }    }}*/