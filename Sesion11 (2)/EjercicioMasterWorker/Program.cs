
using System.Diagnostics;

namespace EjercicioMasterWorker
{
    internal class Program
    {
        /// <summary>
        /// A partir del Master Worker de la entrega obligatoria, prueba las siguientes modificaciones:
        /// -Los workers almacenarán en una lista común "Resultado", los valores que sean superiores a la cantidad buscada.
        ///     - No admitirá duplicados.
        ///     - La lista Resultado la pasa el Master a los workers, por lo que es LA MISMA PARA TODOS LOS WORKERS.
        /// </summary>
        static void Main()
        {
            var bc = Utils.GetBitcoinData();
            IList<double> resultado = new List<double>();
            int maxThreads = 20;
            int value = 7000;
            Stopwatch stopwatch = new Stopwatch();
            for (int i = 1; i < maxThreads; i++)
            {
                Master m = new Master(bc, i, value);
                stopwatch.Restart();
                resultado = m.Resolve();
                stopwatch.Stop();
            }
            foreach (double d in resultado.Order())
            {
                Console.WriteLine(d);
            }
        }
    }
}
