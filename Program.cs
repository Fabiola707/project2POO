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

/*codigos validos:
empleados  -  codigo
Adriana    -  1000
Ingrid     -  1001
Dana       -  1010
Fabiola    -  1100
*/



Console.WriteLine("Menu:\n");
Console.WriteLine("1- Empleados\n");
Console.WriteLine("2- Productos\n");
//Console.WriteLine("3- Ventas\n");

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

        RepositorioEmpleados repositorioEmpleados = new RepositorioEmpleados();
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


        break;

    default:
        Console.WriteLine("Opcion no valida.");
        break;
}


        //Console.WriteLine("Modulo de productos.");


 // empleado.Id = 0;
 //repoEmpleados.Actualizar(empleado);

// for(int i = 0; i < listaEmpleados.Count; i++)


/*using project2.Clases;
//using System;
namespace GestionEmpleados
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Empleado> empleados = new List<Empleado>
            {
                //se pueden asignar empleados 
                new Programador("Emilian", 29, 35000m, "Java"),
                new Diseñador("George", 28, 30000, "Photoshop")
            };

            Console.WriteLine("Equipo de trabajo\n");
            foreach (Empleado emp in empleados)
            {
                emp.MostrarInformacion();
                emp.Trabajar(); //segun rol
                Console.WriteLine();
            }
        }
    }
}*/