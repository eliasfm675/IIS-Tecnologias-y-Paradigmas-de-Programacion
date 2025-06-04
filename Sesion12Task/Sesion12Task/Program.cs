using Modelo;
using System.Diagnostics;

namespace Sesion12Task
{
    /// <summary>
    /// Versión Paralelizada de Procesado.Tareas.Secuencial
    /// Paralelización de Tareas
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            String texto = ProcesadorTextos.LeerFicheroTexto(@"..\..\..\..\clarin.txt");
            string[] palabras = ProcesadorTextos.DividirEnPalabras(texto);



            //Variables que serán utilizadas por las tareas:

            string[] palabrasMasLargas = null, palabrasMasCortas = null, palabrasAparecenMasVeces = null, palabrasAparecenMenosVeces = null;


            string palabraVeces = "a";


            int masRepeticiones = 0, menosRepeticiones = 0, signosPuntuacion = 0, totalVeces = 0;

            // El método Invoke de la clase Parallel se emplea en la paralelización de tareas independientes:
            // Recibe Actions - Haciendo uso de la palabra clave params : 
            //Esto nos permite ir pasando N parámetros separados por comas. En este caso Actions y, cada uno, es una tarea.

            // Crea potencialmente un hilo por cada tarea
            // Espera a que acaben todos los hilos

            //Nótese que al ser Actions no devuelven nada, por eso están almacenando los resultados en las variables definidas más arriba.

            Stopwatch sw = new Stopwatch();
            sw.Start();

            Parallel.Invoke(

                //!Ojo! ¿Y si X tareas utilizasen un recurso compartido?
                //() => signosPuntuacion = ProcesadorTextos.ContarSignosPuntuacion(texto),
                //() => palabrasMasLargas = ProcesadorTextos.PalabrasMasLargas(palabras),
                //() => palabrasMasCortas = ProcesadorTextos.PalabrasMasCortas(palabras),
                //() => palabrasAparecenMasVeces = ProcesadorTextos.PalabrasAparecenMasVeces(palabras, out masRepeticiones),
                //() => palabrasAparecenMenosVeces = ProcesadorTextos.PalabrasAparecenMenosVeces(palabras, out menosRepeticiones),
                () => totalVeces = ProcesadorTextos.Palabra(palabras, palabraVeces)

            );

            sw.Stop();

            //ProcesadorTextos.MostrarResultados(signosPuntuacion, palabrasMasCortas, palabrasMasLargas, palabrasAparecenMenosVeces, menosRepeticiones,
            //    palabrasAparecenMasVeces, masRepeticiones, palabraVeces, totalVeces);
            ProcesadorTextos.ShowWordParallel(palabraVeces, totalVeces);
            long t1 = sw.ElapsedMilliseconds;
            Console.WriteLine($"Tiempo: {t1} ms.");
            totalVeces = 0;
            sw.Restart();
            foreach (string s in palabras)
            {
                if (s.Equals(palabraVeces))
                {
                    totalVeces++;
                }
            }
            sw.Stop();
            Console.WriteLine($"> Versión Secuencial --> {palabraVeces} aparece un total de {totalVeces} veces");
            long t2 = sw.ElapsedMilliseconds;
            Console.WriteLine($"Tiempo: {t2} ms.");
            Console.WriteLine($"Rendimiento de la version paralela respecto a la secuencial usando foreach --> {t2/t1}");
            Console.WriteLine("Ahora usaremos LINQ y PLINQ respectivamente");
            sw.Restart();
            Console.WriteLine($"> Versión Secuencial --> {palabraVeces} aparece un total de {palabras.Count(x => x.Equals(palabraVeces))} veces");
            sw.Stop();
            //Aquí nos encontramos con que habitualmente la versión paralela es más lenta que la secuencial, esto se debe
            //a las condiciones de carrera que se encuentran a la hora de actualizar el contador usando un bucle paralelo.
            //Para notar mejoría sustancial de la versión paralela frente a la secuencial deberíamos aumentar el tamaño del problema de forma considerable

            long t3 = sw.ElapsedMilliseconds;
            Console.WriteLine($"Tiempo: {t1} ms.");
            sw.Restart();
            Parallel.Invoke(
                
                () => ProcesadorTextos.ShowWordParallelPLINQ(palabras, palabraVeces)
                );
            sw.Stop();
            Console.WriteLine($"Tiempo: {t2} ms.");
            Console.WriteLine($"Rendimiento de la version paralela respecto a la secuencial usando LINQ y PLINQ --> {t1 / t2}");
            //Ahora mediante el uso de PLINQ y LINQ en lugar de un foreach, podemos observar que los tiempos de PLINQ son mucho más rápidos que los de LINQ secuencial
        }
    }
}
