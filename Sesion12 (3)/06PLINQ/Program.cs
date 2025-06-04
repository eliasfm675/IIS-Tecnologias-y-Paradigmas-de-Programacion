using System.Collections.Concurrent;
using System.Diagnostics;

namespace _06PLINQ
{
    /// <summary>
    ///PLINQ es la implementación paralela de LINQ
    ///  - Elige dinámicamente el número de hilos concurrente
    ///  - Si la consulta puede obtener mejoras de rendimiento con paralelización: LINQ particiona los datos y ejecuta las tareas concurrentemente
    ///  - En caso contrario, la ejecuta de forma secuencial.
    ///  Linq: vector.Select(e => Math.Sqrt(e));
    ///  Plinq: vector.AsParallel().Select(e => Math.Sqrt(e));
    ///  Nótese el AsParallel()
    /// </summary>
    /// 
    class Program
    {
        /// <summary>
        /// Este programa cuenta el número de palabras en un fichero de texto: secuencialmente y paralelizadamente
        /// En ocasiones, el programa falla en tiempo de ejecución. ¿Por qué?
        /// Además:
        /// - La toma de tiempos no está funcionando correctamente. ¿Por qué?
        /// - ¿Qué ocurre si no imprimimos el Count() de los resultados. ¿Por qué?
        /// 
        /// Los errores más comunes con PLINQ:
        /// https://docs.microsoft.com/es-es/dotnet/standard/parallel-programming/potential-pitfalls-with-plinq
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            String texto = ProcesadorTextos.LeerFicheroTexto(@"..\..\..\..\clarin.txt");
            string[] palabras = ProcesadorTextos.DividirEnPalabras(texto);

            Stopwatch sw = new Stopwatch();
            List<string> palabrasMinusculas = new List<string>();
            long contador = 0;


            //Función que pasa una palabra a minúsculas y la almacena en una lista
            //Además, incrementa un contador.
            //Nótese que en la función se utilizan las variables definidas más arriba.

            Func<string, string> ContarPalabras = palabra =>
            {
                contador += 1;
                string palabraMinusculas = palabra.ToLower();
                palabrasMinusculas.Add(palabraMinusculas);
                return palabraMinusculas;
            };

            int contadorResultado = 0;

            sw.Start();
            var resultadoListaMinusculas = palabras.Select(ContarPalabras);
            contadorResultado = resultadoListaMinusculas.Count();

            sw.Stop();

            //Versión secuencial

            Console.WriteLine($"\nSecuencialmente {sw.ElapsedMilliseconds} ms. Num. Contadas {palabrasMinusculas.Count()} de un total de {contadorResultado}.");
            Console.WriteLine($"Contador: {contador}");



            //Versión PLINQ



            List<string> palabrasMinusculasPLINQ = new List<string>();
            //ConcurrentBag<string> palabrasMinusculasPLINQ = new ConcurrentBag<string>();
            contador = 0;
            object _object = new object();
            //podria o bien poner el lock con object a la hora de añadir, o bien usar una concurrentbag

            //Misma función que ContarPalabras.
            Func<string, string> ContarPalabras2 = palabra =>
            {
                //contador += 1;
                Interlocked.Increment(ref contador);
                string palabraMinusculas = palabra.ToLower();
                lock (_object)
                {
                    palabrasMinusculasPLINQ.Add(palabraMinusculas);

                }
                return palabraMinusculas;

            };

            int contadorResultadoPLINQ = 0;


            sw.Reset();
            sw.Start();



            //En PLINQ, se añade AsParallel para  indicar que operaciones posteriores deberían ejecutarse (POTENCIALMENTE) de forma paralelizada
            
            // PLINQ no necesariamente mantiene el orden del IEnumerable original. Por ejemplo:
            // {1, 2, 3, 4, 5, 6, 7,...,500} y aplicamos un Where para obtener los múltiplos de 5, podríamos obtener: 
            // {50, 45, 5, 1,....} o en cualquier otro orden.
            // .AsOrdered() mantendría el orden original a coste de perjudicar el rendimiento.

            var resultadoListaMinusculasPLINQ = palabras.AsParallel().Select(ContarPalabras2);
            sw.Stop();

            //¿Qué ocurre si comentamos la siguiente línea?
            contadorResultadoPLINQ = resultadoListaMinusculasPLINQ.Count();

            Console.WriteLine($"\nParalelizadamente {sw.ElapsedMilliseconds} ms. Num. Contadas {palabrasMinusculasPLINQ.Count()} de un total de {contadorResultadoPLINQ}.");
            Console.WriteLine($"Contador: {contador}");



            /*Ejercicio
             * Siguiendo el esquema de los ejercicios anteriores, impleméntese una versión paralelizada
             * protegiendo correctamente el acceso a recursos compartidos.
             * Compárese con los tiempos anteriores
             * 
            */

        }
    }
}
