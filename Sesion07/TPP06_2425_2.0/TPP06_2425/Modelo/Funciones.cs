namespace Modelo
{
    public static class Funciones
    {
        //Función referencialmente transparente
        public static int Suma(int a, int b)
        {
            return a + b;
        }

        //Función impura
        //¿Cómo la convertimos en función pura?
        public static int CalcularEdad(DateTime fechaNacimiento)
        {
            return (int)(DateTime.Now - fechaNacimiento).TotalDays / 365;
            
        }
        //Así:
        //public static int CalcularEdad(DateTime inicio, DateTime fechaNacimiento)
        //{
        //    return (int)(inicio - fechaNacimiento).TotalDays / 365;

        //}

        //¿Algún ejemplo más de función impura?




        public static int ContarSi<T>(IEnumerable<T> coleccion, Predicate<T> condicion)
        {
            int contador = 0;

            foreach (var elemento in coleccion)
                if (condicion(elemento))
                    contador++;

            return contador;
        }


        public static int ContarMenoresQue(IEnumerable<int> coleccion, int n)
        {
            int contador = 0;

            foreach (var elemento in coleccion)
                if (elemento < n)
                    contador++;

            return contador;
        }


        public static Func<int> CrearContador()
        {
            //¿Qué es _contador?
            int _contador = 0;


            //Se devuelve la clausura
            return () =>
            {
                _contador++;
                return _contador;
            };
        }


        public static void CrearContenedor<T>(T valor, out Action<T> set, out Func<T> get)
        {
            //Se define el estado
            T _valor = valor;

            //Clausuras a definir
            set = valor => _valor = valor;

            get = () => _valor;

        }


        /// <summary>
        /// Generador infinito de los términos de la sucesión de Fibonacci
        /// </summary>
        public static IEnumerable<int> FibonacciInfinito()
        {
            int primero = 1, segundo = 1;
            while (true)
            {
                // Devolvemos el primer valor.
                // ¡yield almacena el estado de la ejecución!
                // Cuando se vuelva a invocar
                // Se recupera el estado y continúa en la línea posterior al yield
                yield return primero;
                int suma = primero + segundo;
                primero = segundo;
                segundo = suma;
            }
        }


        /// <summary>
        /// Generador finito de términos de la sucesión de Fibonacci.
        /// </summary>
        public static IEnumerable<int> FibonacciFinito(int maxTermino)
        {
            int primero = 1, segundo = 1, termino = 1;
            while (true)
            {
                yield return primero;
                int suma = primero + segundo;
                primero = segundo;
                segundo = suma;
                if (termino++ == maxTermino)
                    // No hay más elementos, hacemos break con yield
                    yield break;
            }
        }

        public static IEnumerable<int> ImparesGeneradorEstricto(int desde, int cantidad)
        {
            ImprimirAlerta("Entra en el generador estricto");
            int n = 1, contador = 0;
            //Propósito de simulación, el cálculo sería mucho más simple sin usar while.
            //Avanzamos hasta llegar al término inicial.
            while (contador < desde)
            {
                n += 2;
                contador++;
            }
            IList<int> resultado = new List<int>();
            contador = 0;
            while (contador < cantidad)
            {
                contador++;
                resultado.Add(n);
                n += 2;
            }
            return resultado;
        }

        /// <summary>
        /// Secuencia infinita de impares implementada de manera perezosa (o lazy).
        /// </summary>
        public static IEnumerable<int> ImparesGeneradorLazy()
        {
            ImprimirAlerta("Entra en el generador perezoso");
            int n = 1;
            while (true)
            {
                if (n % 2 != 0)
                    yield return n;
                n += 2;
            }
        }


        public static IEnumerable<int> NumerosImparesLazy(int desde, int cuantos)
        {
            //using System.Linq métodos extensores
            //Skip salta N elementos.
            //Take selecciona N elementos a partir del actual.
            return ImparesGeneradorLazy().Skip(desde).Take(cuantos);
        }



        public static void ForEach<T>(this IEnumerable<T> enumerable, Action<T> action, int? maximoElementos = null)
        {
            int contador = 0;
            foreach (T item in enumerable)
            {
                if (maximoElementos.HasValue && maximoElementos.Value < contador++)
                    break;
                action(item);
            }
        }

        public static void ImprimirAlerta(string texto)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(texto);
            Console.ResetColor();
        }

        public static void LimpiarPantalla()
        {
            Console.WriteLine("\nPulse una tecla para continuar al siguiente ejemplo...");
            Console.ReadKey();
            Console.Clear();
        }
    }
}
