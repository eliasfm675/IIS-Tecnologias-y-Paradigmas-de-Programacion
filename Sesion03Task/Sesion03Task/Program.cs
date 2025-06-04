using Modelo;
using System.Collections.Generic;
namespace Sesion02Task
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Conjunto c = new Conjunto();
            List l = new List();
            Persona p = new Persona();
            Pila pila = new Pila(10);
            // l.Anadir(p);
            l.Anadir(2);
            l.Anadir(3);
            l.Borrar(2);
            l.Anadir("holaa");
            l.Anadir(2.98);
            l.Anadir(p);
            //l.Borrar(p);
            Console.WriteLine(l.ToString());
            c.Add(2);
            c.Add(3);
            c.Add(4);
            c.Add("Hola");
            c.Add(p);
            //c.Borrar(p);
            Console.WriteLine(c);


            pila.Push(p);
            pila.Push(2);
            pila.Push(3);
            pila.Push(4);
            pila.Push("a");
            pila.Push("b");
            pila.Push("c");
            pila.Push("d");
            pila.Push(0);
            pila.Push(p);
           Object obj = pila.Pop();
            Console.WriteLine(pila);

        }
    }
}
