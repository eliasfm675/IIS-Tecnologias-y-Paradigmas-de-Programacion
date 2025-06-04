using System.Linq.Expressions;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
using Modelo;
namespace _04Ejercicios
{
    internal class Program
    {
        const int LONGITUD = 10;
        static void Main(string[] args)
        {
            Func<int, int, int> f1 = (x, y) => x * y;
            Predicate<string> p1 = s => s.Length == LONGITUD;
            Func<int, int, bool> f2 = (x, y) => x % y ==0 ;
            Console.WriteLine(f1(2, 3));
            Console.WriteLine(p1("1234567891"));
            Console.WriteLine(f2(4, 2));
            Predicate<Libro> predicate = p2 => p2.Autor[p2.Autor.Length-1] == 'z';
            Libro[] l1 = Factoria.CrearLibros();
            IEnumerable<Libro> l2 = Filtrar(l1, predicate);
            Mostrar(l1, libro => Console.WriteLine($"{libro.Titulo} - {libro.Autor}"));
            Console.WriteLine(Contar(l1, libro => libro.NumeroDePaginas<5));
            Console.WriteLine(Contar(l1, libro => libro.AnoPublicacion>19));
            Func<int, int> lambda = (a) => a * 2;
            Func<Func<int, int>, int, int> two = (a, b) => a(a(b));
            Console.WriteLine(two(lambda, 2));
            
        }

        public static int Contiene<T>(IEnumerable<T> n, Predicate<T> p)
        {
            int counter = 0;
            foreach(T t in n)
            {
                if (p(t))
                {
                    return counter;
                }
                counter++;
            }
            return -1;
        }
        public static IEnumerable<T> Filtrar<T>(IEnumerable<T> ienum, Predicate<T> pred)
        {
            IList<T> ilist = new List<T>();
            foreach (T t in ienum)
            {
                if (pred(t))
                {
                    ilist.Add(t);
                }
            }
            return ilist;
        }
        public static void Mostrar<T>(IEnumerable<T> ienum, Action<T> act)
        {
            foreach (T t in ienum)
            {
                act(t);
            }
        }
        public static int Contar<T>(IEnumerable<T> ienum, Predicate<T> p)
        {
            int counter = 0;
            foreach (T t in ienum)
            {
                if (p(t))
                {
                    counter++;
                }
            }
            return counter;
        }

    }
}
