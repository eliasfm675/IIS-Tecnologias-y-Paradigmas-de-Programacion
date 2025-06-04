using System.Diagnostics;

namespace _03Interlocked
{

    /// <summary>
    /// Una alternativa más eficiente a lock es el uso de la clase Interlocked (System.Threading)
    /// Realiza asignaciones de forma primitiva.
    /// Métodos más utilizados: Increment, Decrement, CompareExchange, Add.
    /// https://learn.microsoft.com/en-us/dotnet/api/system.threading.interlocked?view=net-8.0
    /// Observa bien con qué tipos pueden utilizarse.
    /// </summary>
    internal class Program
    {
        static int contador = 0;
        static int contador2 = 0;
        private static readonly object _object = new object();

        static void Incrementar()
        {
            for (int i = 0; i < 100000; i++)
            {
                Interlocked.Increment(ref contador);
            }
        }

        static void Main()
        {
            Thread[] hilos = new Thread[2];
            long t1, t2 = 0;
            Stopwatch sw = new Stopwatch();
            sw.Restart();
            for(int i = 0; i < hilos.Length; i++)
            {
                hilos[i] = new Thread(Incrementar);
                hilos[i].Start();
            }
            sw.Stop();
            t1 = sw.ElapsedTicks;

            foreach (var hilo in hilos)
                hilo.Join();

            Console.WriteLine($"Total del contador: {contador}");

            sw.Restart();
            for (int i = 0; i < hilos.Length; i++)
            {
                hilos[i] = new Thread(IncrementarEj);
                hilos[i].Start();
            }
            foreach (Thread t in hilos)
            {
                t.Join();
            }
            sw.Stop();
            t2 = sw.ElapsedTicks;
            Console.WriteLine($"Ticks de la versión con interlock --> {t1}\nTicks de la versión con lock --> {t2}\nResultados respectivos: {contador} |  {contador2}");


        }

        //EJERCICIO: Crear y entender un ejemplo para cada uno de los siguientes métodos de Interlocked:
        //Decrement, Add, Exchange y CompareExchange.
        static void Decrementar()
        {
            for (int i=0;i<100000;i++)
            {
                Interlocked.Decrement(ref contador);
            }
        }
        static void Add()
        {
            for (int i=0; i<100000; i++)
            {
                Interlocked.Add(ref contador, 5);
            }
        }
        static void Exchange()
        {
            for (int i=0; i<100000;i++)
            {
                Interlocked.Exchange(ref contador, 25);
            }
        }
        static void CompareExchange()
        {
            for (int i=0; i<100000;i++)
            {
                Interlocked.CompareExchange(ref contador, -1, i);
            }
        }
        //EJERCICIO: Impleméntese una versión del presente ejemplo utilizando lock y mídase el rendimiento de ambas versiones.
        static void Ejemplo()
        {
            Thread[] hilos = new Thread[2];
            for (int i = 0; i < hilos.Length; i++)
            {
                hilos[i] = new Thread(IncrementarEj);
                hilos[i].Start(contador);
            }

            foreach (var hilo in hilos)
                hilo.Join();

            Console.WriteLine($"Total del contador: {contador}");
        }
        static void IncrementarEj()
        {
                for (int i = 0; i < 100000; i++)
                {
                    lock (_object)
                    {
                        contador2++;
                    }
                    

                }

        }
    }
}
