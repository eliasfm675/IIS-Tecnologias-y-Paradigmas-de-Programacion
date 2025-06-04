using System.Numerics;
using System.Runtime.CompilerServices;

namespace _02DelegadosPredefinidos
{
    public static class Extensores
    {
        /// <summary>
        /// ¿Qué hace esta función?
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="coleccion"></param>
        /// <param name="accion"></param>
        public static void ForEach<T>(this IEnumerable<T> coleccion, Action<T> accion)
        {
            foreach (T item in coleccion)
                accion(item);
        }

    }
}
