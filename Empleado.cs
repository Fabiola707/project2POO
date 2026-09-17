using System;
using System.Collections.Generic;
using System.Text;

namespace GestionEmpleados
{
    public class Empleado
    {
        public string Nombre { get; set; }
        public int Edad { get; set; }
        public decimal Salario { get; set; }
        public Empleado(string nombre, int edad, decimal salario)
        {
            Nombre = nombre;
            Edad = edad;
            Salario = salario;
        }
        public virtual void MostrarInformacion()
        {
            Console.WriteLine($"Empleado: {Nombre}, Edad: {Edad}, Salario: ${Salario:C}");
        }
        public virtual void Trabajar()
        {
            Console.WriteLine($"{Nombre} está realizando sus asignaciones laborales...");
        }
    }
}
