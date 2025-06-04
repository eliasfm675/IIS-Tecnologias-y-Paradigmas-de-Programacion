
//Colecciones Genéricas
//using System.Collections.Generic;

//Colecciones NO genéricas
//using System.Collections;

namespace _02IEnumerable
{
    class Program
    {
        static void Main(string[] args)
        {
            string palabra = "palabra";
            Console.WriteLine("Recorriendo palabra con foreach - IEnumerable");
            //Podemos usar el foreach porque String implementa IEnumerable
            foreach (var letra in palabra)
            {
                Console.Write(letra + " ");
            }

            Console.WriteLine("\nRecorriendo palabra con IEnumerator");
            //Realmente lo que se está haciendo es lo siguiente
            //IEnumerable tiene un único método y lo que hace éste es
            //Es devolver un IEnumerator (iterador)

            IEnumerator<char> iterador = palabra.GetEnumerator();
            while (iterador.MoveNext())
                Console.Write(iterador.Current + " ");


            //Nota: La tabla de multiplicar empieza multiplicando por 1.

            TablaMultiplicar tablaDel7 = new TablaMultiplicar(7, 10);
            Console.WriteLine("\nImplementación propia de IEnumerable e IEnumerator en una clase:");
            foreach (int elemento in tablaDel7)
                Console.WriteLine(elemento);

            metodo();

        }
        //EJERCICIO DE EXAMEN
        /*
         * Crear un método que reciba dos colecciones que implementen IEnumerable<T>
         * Y devuelva como resultado un IEnumerable<T> con los valores que coincidan en la misma posición.
         * Resolver el ejercicio utilizando ITERADORES (IEnumerator).
         * Probar enviando:
         * Un array de caracteres y un string.
         * Una lista de caracteres y un string.
         * Vuestra lista con caracteres y otra lista vuestra con caracteres.
         * El resultado se recorre en un foreach y se imprime elemento a elemento.
        */
        
        public static void metodo()
        {
            List<char> c1L = new List<char>();
            c1L.Add('a');
            c1L.Add('b');
            c1L.Add('c');
            c1L.Add('d');
            string c2 = "abcd";
            IEnumerable<char> l = Ejercicio<char>.p(c1L, c2);
            char[] c1A = ['a', 'b', 'c', 'd'];
            IEnumerable<char> array = Ejercicio<char>.p(c1A, c2);
            foreach (var c in l)
            {
                Console.WriteLine(c);
            }
            foreach (var c in array)
            {
                Console.WriteLine(c);
            }
        }
        public static class Ejercicio<T>
        {

            public static IEnumerable<T> ejercicio(IEnumerable<T> c1, IEnumerable<T> c2)

            {
                IEnumerator<T> enumerator1 = c1.GetEnumerator();
                IEnumerator<T> enumerator2 = c2.GetEnumerator();
                IList<T> list = new List<T>();
                while (enumerator1.MoveNext() && enumerator2.MoveNext())
                {
                    if (enumerator1.Current.Equals(enumerator2.Current))
                    {
                        list.Add(enumerator1.Current);
                    }
                }
                return list;
            }
            public static IEnumerable<T> p<T>(IEnumerable<T> list, IEnumerable<T> list2)
            {
                IEnumerator<T> iterador = list.GetEnumerator();
                IEnumerator<T> iterador2 = list2.GetEnumerator();
                while (iterador.MoveNext() && iterador2.MoveNext())
                {
                    if (iterador.Current.Equals(iterador2.Current))
                    {
                        yield return iterador.Current;
                    }
                }
            }

        }
    }
}
