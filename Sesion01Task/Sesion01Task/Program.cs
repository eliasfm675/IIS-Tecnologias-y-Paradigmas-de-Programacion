using Modelo;
namespace Sesion01Task
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List l = new List();
            l.Anadir(1);
            l.Anadir(2);
            l.Anadir(3);
            l.Anadir(4);
            l.Anadir(5);
            Console.WriteLine(l.Borrar(1));
            Console.WriteLine(l.GetElemento(0));
        }
    }
}
