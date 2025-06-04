using System.Diagnostics;
using System.IO;

namespace _05MasterWorkerEjercicio
{
    class Program
    {
        // A través de 2 arrays de enteros (el tamaño del 2º es <= al del 1º)
        // Calcular el número de veces que ses repite el 2º array en el primero.
        // Suponer que tendrá un máximo de longitudV1/longitudV2 hilos
        // Ejemplo:
        // { 2, 2, 1, 3, 2, 2, 1, 2, 1, 2, 2, 1 } y { 2, 2, 1}
        // Resultado: 3
        static void Main(string[] args)
        {
            //short[] v1 = new short[] { 2, 2, 1, 3, 2, 2, 1, 2, 1, 2, 2, 1 };
            //short[] v2 = new short[] { 2, 2, 1 };

            //Probarlo posteriormente con el RandomVector.
            short[] v1 = CreateRandomVector(1000, 0, 4);
            short[] v2 = CreateRandomVector(2, 0, 4);
            //v1.Contains
            int maxThreads = 50;
            Stopwatch sw = new Stopwatch();
            int result = 0;
            for (int numThreads=1; numThreads<=maxThreads; numThreads++)
            {
                Master ms = new Master(v1, v2, numThreads);
                sw.Restart();
                result = ms.Result();
                sw.Stop();
                Show(Console.Out, numThreads,sw.ElapsedTicks, result);
                GC.Collect();
                GC.WaitForFullGCComplete();
            }


        }

        public static short[] CreateRandomVector(int numberOfElements, short lowest, short greatest)
        {
            short[] vector = new short[numberOfElements];
            Random random = new Random();
            for (int i = 0; i < numberOfElements; i++)
                vector[i] = (short)random.Next(lowest, greatest + 1);
            return vector;
        }
        static void Show(TextWriter stream, int numHilos, long ticks, double resultado)
        {
            stream.WriteLine("{0};{1:N0};{2:N2}", numHilos, ticks, resultado);
        }
    }
}
