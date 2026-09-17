using GestionEmpleados;
using System;
using System.Collections.Generic;
using System.Text;

namespace GestionEmpleados
{
    //hereda de la clase empleado
    public class Programador : Empleado
    {
        public string LenguajeProgramacion { get; set; }

        public Programador(string nombre, int edad, decimal salario, string lenguajeProgramacion) 
            : base(nombre, edad, salario)
        {
            LenguajeProgramacion = lenguajeProgramacion;
            //asignar el lenguaje de programación que se le da en el constructor
        }
        public void Programar()
        {
            Console.WriteLine($"{Nombre} está programando en {LenguajeProgramacion}...");
            //nombre del programador y el lenguaje de programación
            //el lenguaje asignado en la clase programador
        }
        public override void MostrarInformacion()
        {
            Programar();//llama el metodo de programar
        }
    }
}
