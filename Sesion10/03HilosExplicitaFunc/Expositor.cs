
namespace _02HilosExplicitaPOO
{
    class Expositor<T>
    {
        private T _objeto;
        private int _nVeces;

        public Expositor(T objeto, int nVeces)
        {
            this._objeto = objeto;
            this._nVeces = nVeces;
        }

        /// <summary>
        /// Este método será La tarea que realice el hilo.
        /// ¿Qué hace?
        /// </summary>
        public void Run()
        {
            int i = 0;
            //¿Qué indica Thread.CurrentThread.ManagedThreadId? la identificacion del hilo
            Console.WriteLine($"Comienza el hilo ID={Thread.CurrentThread.ManagedThreadId} que escribirá {_objeto} {_nVeces} veces.");

            while (i < _nVeces)
            {
                 //Dormimos el hilo
                //¿Para qué es útil? ¿Y para qué NO debe utilizarse?

                Thread.Sleep(2000);
                Console.WriteLine(
                    $"Operación número {i+1} del hilo [ID={Thread.CurrentThread.ManagedThreadId};" +
                    $" NOMBRE={Thread.CurrentThread.Name}; " +
                    $"PRIORIDAD={Thread.CurrentThread.Priority}] con valor {_objeto}"
                );
                i++;
            }
            Console.WriteLine($"Fin del hilo ID = {Thread.CurrentThread.ManagedThreadId}.");
 
        }
    }
}
