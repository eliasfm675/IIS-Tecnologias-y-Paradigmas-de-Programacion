using System.Diagnostics;
using System.Drawing;

namespace _02DatosParalelo
{
    class Program
    {
        /// <summary>
        /// TPL - Task Parallel Library o Librería de Tareas en Paralelo
        /// Simplifica la paralelización de aplicaciones:
        /// 
        /// Escala dinámicamente el nº de hilos en función del nº de CPUs
        /// 
        /// Ofrece servicios para la paralelización mediante la división de datos (data parallelism).
        /// 
        /// Ofrece servicios para la paralelización mediante tareas independientes (task parallelism).
        ///
        /// En este caso se resuelve Division.Datos.Secuencial con TPL (data parallelism)
        /// </summary>
        static void Main()
        {

            string[] ficheros = Directory.GetFiles(@"..\..\..\..\pics", "*.jpg");
            string nuevaCarpeta = @"..\..\..\..\pics\rotated";
            Directory.CreateDirectory(nuevaCarpeta);

            Stopwatch sw = new Stopwatch();

            // La siguiente tarea se realiza potencialmente en paralelo
            // Potencialmente se crean tantas tareas como elementos tiene el IEnumerable.

            //ForEach crea potencialmente un hilo por cada elemento de un IEnumerable

            // Recibe la tarea (Action) a ejecutar.
            int threadCounter = 0;//parte del ejercicio de abajo
            //object  _object = new object();
            sw.Start();
            Parallel.ForEach(ficheros, fichero => {
                string nombreFichero = Path.GetFileName(fichero);
                using (Bitmap bitmap = new Bitmap(fichero))
                {

                    //¿Y si hubiera recursos compartidos? Si hubiese aqui un contador podrias meter un interlock en vez de un lock
                    Interlocked.Increment(ref threadCounter);//parte del ejercicio de abajo
                    //lock (_object)
                    //    threadCounter++;

                    Console.WriteLine($"Procesando el fichero \"{nombreFichero}\" con el hilo ID={Thread.CurrentThread.ManagedThreadId}.");
                    bitmap.RotateFlip(RotateFlipType.Rotate180FlipNone);
                    bitmap.Save(Path.Combine(nuevaCarpeta, nombreFichero));
                }
            });            // TPL Espera a que acaben todos los hilos
            sw.Stop();

            //EJERCICIO ¿Cómo podríamos mostrar por pantalla el contador de hilos utilizados en el bloque anterior?
            Console.WriteLine($"Tiempo: {sw.ElapsedMilliseconds} ms.");
            Console.WriteLine($"Total threads used: {threadCounter}");

            //Existe también un Parallel.For: que es mejor usarlo si te piden trabajar con posiciones
            //https://docs.microsoft.com/es-es/dotnet/api/system.threading.tasks.parallel.for?view=net-8.0#system-threading-tasks-parallel-for(system-int32-system-int32-system-action((system-int32-system-threading-tasks-parallelloopstate)))
            //que recibiría el índice de inicio y el de final (no se incluiría).
            // For crea potencialmente un hilo a partir de un índice de de comienzo y final, no incluyendo el final
        }
        //es interesante para el examen pensar en dos bucles for anidados, en este caso se pararelizaria el externo para asi que el interno lo operen n hilos

    }
}
