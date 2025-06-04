using ObligatoriaSesion10;
using System.Diagnostics;
using System.Globalization;

namespace Ejercicio
{
    class Program
    {
        /*
         * This program processes Bitcoin value information obtained from the
         * url https://api.kraken.com/0/public/OHLC?pair=xbteur&interval=5.
         */
        static void Main(string[] args)
        {
            var data = Utils.GetBitcoinData();
            const int maxThreads = 50;
            const int value = 7000;
            Console.WriteLine(CultureInfo.CurrentCulture);
            //foreach (var d in data)
            //    Console.WriteLine(d);
            Stopwatch stopwatch = new Stopwatch();
            for (int numThreads=1; numThreads<=maxThreads; numThreads++)
            {
                Master ms = new Master(data, numThreads, value);
                stopwatch.Restart();
                double result = ms.Resolve();
                stopwatch.Stop();
                ShowLine(Console.Out, numThreads, stopwatch.ElapsedTicks, result);
                GC.Collect();
                GC.WaitForFullGCComplete();
            }
        }
        static void ShowLine(TextWriter stream, int numThreads, long ticks, double result)
        {
            stream.WriteLine("{0};{1:N0};{2:N2}", numThreads, ticks, result);
        }
    }
   

}
