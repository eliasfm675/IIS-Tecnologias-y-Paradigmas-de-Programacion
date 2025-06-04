using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelo
{
    public class Metodos
    {
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
        public static E Reducir<T, E>(IEnumerable<T> col, E acumulator, Func<E, T, E> fn)
        {
            foreach (T t in col)
            {
                acumulator = fn(acumulator, t);
            }
            return acumulator;
        }
    }
}
