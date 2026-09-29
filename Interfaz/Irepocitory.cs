using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using project2.Clases;

//namespace project2.Clases;

namespace project2.Interfaz
{
    internal interface Irepocitory<T>
    {
        void Registro(T empleado);

        void Borrar(T empleado);

        void Actualizar(T empleado);
        public List<T> Lista();
        public List<T> Buscar(string nombre);
        //declarar el get by id de los productos
        public T GetById(int id);
    

    }
}
