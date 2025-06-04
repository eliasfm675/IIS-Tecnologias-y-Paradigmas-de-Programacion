
using System.Reflection.Metadata.Ecma335;

namespace _02Currificacion
{
    public static class Ejercicio
    {
        //Ejercicio 1..

        //Implementar de forma currificada el método Buscar entregado en la sesión anterior.
        //Demostrar el uso de su invocación y de la aplicación parcial.
       public static bool Ej1<T>(T thing, IEnumerable<T> list)
        {
            
            Func<IEnumerable<T>, Func<Predicate<T>, T>> f = ienum => pred =>
            {
                foreach (var t in ienum)
                {
                    if (pred(t))
                    {
                        return t;
                    }
                }
                return default(T);
            };
            return thing.Equals(f(list)(x => x.Equals(thing)));


        }


        //Ejercicio 2.

        // Si - > 5 / 3 = 1 ; Resto = 2

        // Entonces -> 3 * 1 + 2 = 5;

        //Currifíquese la función y compruébese mediante el uso de la aplicación parcial el siguiente ejemplo:

        // Se sabe que la división:  20 / 6 = 3. Se desconoce el valor del resto.
        // Partiendo del valor 0, e incrementalmente, obténgase el resto.
        public static bool Ej2(int n)
        {
            Func<int, Func<int, Func<int, int>>> currificacionmul = a => b => c => a * b + c;
            return n == currificacionmul(3)(1)(2);
        }
    }
}
