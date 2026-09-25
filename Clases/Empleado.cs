using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace project2.Clases
{
    public class Empleado
    {
        public int ID { get; set; }
        public int Codigo { get; set; }
        public string Nombre { get; set; }
        public int Edad { get; set; }
        public decimal Salario { get; set; }
        public Empleado() { }


        public Empleado(int id, int codigo, string nombre, int edad, decimal salario)
        {
            ID = id;
            Codigo = codigo;
            Nombre = nombre;
            Edad = edad;
            Salario = salario;
        }
        // Constructor vacío
        /*public Empleado()
        // Constructor con parámetros
        public Empleado(string nombre, int edad, decimal salario, int id)
        {
            Nombre = nombre;
            Edad = edad;
            Salario = salario;
            Id = id;
        }*/

        public virtual void MostrarInformacion()
        {
            Console.WriteLine("$[ID:{ ID}]\n Codigo: {Codigo}\n Empleado: {Nombre}\n Edad: {Edad}\n Salario: {Salario:C}");

           /* Console.WriteLine(
                $"Empleado: {Nombre}, Edad: {Edad}, Salario: {Salario:C}"
            );*/
        }

        /*public virtual void Trabajar()
        {
            /*Console.WriteLine(
                $"{Nombre} está realizando sus asignaciones laborales..."
            );
        }*/
    }
}
