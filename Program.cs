using System;
using System.Collections.Generic;

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
}