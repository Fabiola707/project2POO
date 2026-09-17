using System;
using System.Collections.Generic;
using System.Text;

namespace GestionEmpleados
{
    //hereda de la clase empleado
    internal class Diseñador : Empleado
    {
        public string HerramientaDiseño { get; set; }
        public Diseñador(string nombre, int edad, decimal salario, string herramientaDiseño)
            : base(nombre, edad, salario)
        {
            HerramientaDiseño = herramientaDiseño;
            //asignar la herramienta de diseño que se le da en el constructor
        }
        public void Diseñar()
        {
            Console.WriteLine($"{Nombre} está diseñando con {HerramientaDiseño}");
            //imprime el nombre del diseñador y la herramienta de diseño
        }
        public override void Trabajar()
        {
            Diseñar(); //llama el metodo de diseñar
        }
    }
}
