using System.Diagnostics;
using System.Numerics;

namespace _02ExclusionMutua
{
    internal class Program
    {


        static short[] vector = CrearVectorAleatorio(2000000, 0, 10);

        public static int aparicionesSecuencial; 

        public static int aparacionesMultihilo;


        private static readonly object _object = new object();

        static void Main()
        {
            long t1, t2 = 0;
            Stopwatch sw = new Stopwatch();
            sw.Restart();
            ContarSecuencialAparaciones(2);
            ContarSecuencialAparaciones(3);
            sw.Stop();
            t1 = sw.ElapsedTicks;
            Console.WriteLine($"[Secuencial] El número 2 y el 3 aparecen {aparicionesSecuencial} veces.");
            

            Thread[] hilos = new Thread[2];
            sw.Restart();
            for (int i = 0; i < hilos.Length; i++)
            {
                hilos[i] = new Thread(ContarAparicionesNumeroEnVector);
                hilos[i].Start(i + 2);
            }
            sw.Stop();
            t2 = sw.ElapsedTicks;
            foreach (var hilo in hilos)
                hilo.Join();  

            Console.WriteLine($"[Multihilo] El número 2 y el 3 aparecen {aparacionesMultihilo} veces.");

            Console.WriteLine($"Ticks en la versión secuencial --> {t1}\nTicks en la version multihilo {t2}");
       
            //Toma tiempos de la versión secuencial y la versión multihilo (Material de la sesión anterior)

            //¿Cuál es más rápida? ¿Por qué ocurre?
            //¿Se te ocurre alguna forma de mejorar la versión multihilo?
            //Impleméntala y toma tiempos.
        }

        static void ContarSecuencialAparaciones(short numero)
        {
            for (int i = 0; i < vector.Length; i++)
            {
                if (vector[i] == numero)
                {
                    aparicionesSecuencial++;   
                }
            }
        }

        static void ContarAparicionesNumeroEnVector(object? numero)
        {
            int buscado = (int)numero;
            for (int i = 0; i < vector.Length; i++)
            {
                if (vector[i] == buscado)
                {
                    // Sección crítica de código
                    // ¿Qué hace lock? es un semaforo, NOTA solo se debe encerrar la parte critica en el lock es decir la part een la que escribo y nada mas
                    lock (_object)//fijate que _object es static al igual que aparacionesMultihilo
                    {
                        aparacionesMultihilo++;
                    }
                    // Como regla básica, es necesario bloquear cualquier operación de escritura.
                    // Incluyendo los casos aparentemente más simples, como el de modificar/incrementar el valor de una variable.
                    // ¡REPASAD EN LA TEORÍA QUÉ OPERACIONES SON!
                    //SI ES UN RECURSO COMPARTIDO, SE HA DE METER EL LOCK SIEMPRE EN ESCRITURTA Y/O MODIFICACION además hay que tener cuidado con las lecturas como si metes el vector[i] en el lock
                }
            }
        }



        public static short[] CrearVectorAleatorio(int numElementos, short menor, short mayor)
        {
            short[] vector = new short[numElementos];
            Random random = new Random();
            for (int i = 0; i < numElementos; i++)
                vector[i] = (short)random.Next(menor, mayor + 1);
            return vector;
        }


    }
}
