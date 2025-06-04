using Modelo;
namespace Sesion02Task
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Conjunto c = new Conjunto();
            List l = new List();
            Persona p = new Persona();
           // l.Anadir(p);
            l.Anadir(2);
            l.Anadir(3);
            l.Borrar(2);
            l.Anadir("holaa");
            l.Anadir(2.98);
            l.Anadir(p);
           // l.Borrar(p);
            Console.WriteLine(l.ToString());
            c.Add(2);
            c.Add(3);
            c.Add(4);
            c.Add("Hola");
            c.Add(p);
            Console.WriteLine(c[2]);

        }
    }
}
