using _02HilosExplicitaPOO;
namespace _03HilosExplicitaFunc
{
    internal class Program
    {
        static void Main(string[] args)
        {

            // En el ejemplo 02HilosExplicitaPOO, el método Run de cada Expositor no recibía parámetros.
            // De hecho, utilizábamos el propio objeto Expositor para encapsular los datos (valor y nVeces).
            // El/Los parámetro/s lo encapsulábamos como atributo/s de una clase.

            // A continuación veremos los casos desde un enfoque más funcional.

            //Thread recibe en su constructor cualquier Action con 0 o 1 parámetros de tipo object.

            Thread hiloParametrizado = new Thread(ObtenerDatos);

            //En el método Start pasamos un argumento (si es necesario).
            hiloParametrizado.Start("wwww.google.es");


            //También podríamos utilizar directamente una expresión lambda:
            Thread hiloSuelto = new Thread(
                     valor =>
                     {
                         Console.WriteLine("El hilo suelto recibe " + valor);
                     }
             );
            hiloSuelto.Start("Declarando el action directamente");


            //¿Y si necesitamos más parámetros? 

            //¿Qué concepto se está aplicando aquí?

            //Vamos a crear 4 hilos.
            //Cada hilo debería imprimir un par de valores: 40 y 41, 41 y 42, 42 y 43, 43 y 44... En cualquier orden.

            //EJERCICIO: ¿Cómo arreglamos esto?

            //Thread[] hilos = new Thread[4];
            //int numero = 40;
            //for (int i = 0; i < 4; i++)
            //{
            //    //Sin parámetro                
            //    hilos[i] = new Thread(
            //        () =>
            //        {
            //            Console.WriteLine($"{numero} {numero + 1}");
            //        }
            //        );
            //    hilos[i].Start();
            //    numero++;
            //}
            Thread[] hilos = new Thread[4];
            int numero = 40;
            for (int i = 0; i < 4; i++)
            {
                int copy = numero;
                //Sin parámetro                
                hilos[i] = new Thread(
                    () =>
                    {
                        Console.WriteLine($"{copy} {copy + 1}");
                        
                    }
                    );
                hilos[i].Start();
                numero++;
            }
            foreach (Thread t in hilos)
            {
                t.Join();
            }

            //EJERCICIO: Empleando un enfoque funcional, impleméntese la funcionalidad del ejercicio Expositor de HilosPOO.
            int tamaño = 4;
            Thread[] threads = new Thread[tamaño];
            for (int i=0;i<tamaño;i++)
            {
                int nVeces = 1 + i;
                int valor = i;
                threads[i] = new Thread(
                    () =>
                    {
                        new Expositor<int>(valor, nVeces).Run();
                    }
                    );
                threads[i].Name = "Hilo numero: " + i;
                threads[i].Priority = ThreadPriority.Normal;
                threads[i].Start();
                valor++;
            }
            foreach (Thread t in threads)
            {
                t.Join();
            }
        }

        public static void ObtenerDatos(object valor)
        {
            Console.WriteLine("Obteniendo datos del destino {0}", valor);
            //Simulamos carga de trabajo, fines demostrativos.
            Thread.Sleep(2000);
            Console.WriteLine("Datos obtenidos y almacenados");

        }
    }
}
