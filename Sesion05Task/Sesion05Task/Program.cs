using System;
using System.Drawing;
using System.Runtime.CompilerServices;
using Modelo;
namespace Sesion05Task
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Persona[] plist = Factoria.CrearPersonas();
            Angulo[] alist = Factoria.CrearAngulos();
            Predicate<Angulo> x = x => x.Grados == 90;
            Predicate<Persona> y = y => y.Nombre.Equals("Carlos");
            //Console.WriteLine(Buscar(alist, x));
            //Console.WriteLine(Buscar(plist, y));
            IEnumerable<Persona> lp = Filtrar(plist, p=> p.Edad>17);
            IEnumerable<Angulo> la = Filtrar(alist, a => a.Grados >=0 && a.Grados<=90);
            Func<double, Persona, double> f = (a, b) =>
            {
                if (b.Edad > 20)
                {
                    a += 1;
                }
                return a;
            };
           
            double acu = 0.0;
            Console.WriteLine(Reducir(lp, acu, f));

        }
        public static T? Buscar<T>(IEnumerable<T> col, Predicate<T> p)
        {
            foreach (T t in col)
            {
                if (p(t))
                {
                    return t;
                }
            }
            return default(T);
        }
        public static IEnumerable<T> Filtrar<T>(IEnumerable<T> col, Predicate<T> p)
        {
            IList<T> newColection = new List<T>();
            foreach (T t in col)
            {
                if (p(t))
                {
                    newColection.Add(t);
                }
            }
            return newColection;
        }
        public static E Reducir<T, E>(IEnumerable<T> col,E acumulator, Func<E,T,E> fn)
        {
            foreach(T t in col)
            {
                acumulator = fn(acumulator, t);
            }
            return acumulator;
        }
    }
}
