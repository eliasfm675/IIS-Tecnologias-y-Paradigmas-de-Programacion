using ObligatoriaSesion10;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejercicio
{
    public class Master
    {
        private BitcoinValueData[] vector;
        private int numThreads;
        private int value;
        public Master(BitcoinValueData[] vector,int numThreads,int value)
        {
            if (numThreads<1 ||numThreads>vector.Length)
            {
                throw new ArgumentException("The number of threads must be less or equal to the size of the array");
            }
            this.value = value;
            this.vector = vector;
            this.numThreads = numThreads;

        }
        public double Resolve()
        {
            Worker[] ws = new Worker[this.numThreads];
            int elementsPerThread = this.vector.Length/numThreads;
            for (int i=0; i<this.numThreads; i++)
            {
                int startIndex = i*elementsPerThread;
                int endIndex = (i+1)*elementsPerThread-1;
                if (i==this.numThreads-1)
                {
                    endIndex = this.numThreads-1;
                }
                ws[i] = new Worker(this.vector, startIndex, endIndex, value);
            }
            Thread[] threads = new Thread[ws.Length];
            for (int i=0; i<ws.Length; i++)
            {
                threads[i] = new Thread(ws[i].Compute);
                threads[i].Name = "Worker nº: " + (i+1);
                threads[i].Priority = ThreadPriority.Normal;
                threads[i].Start();
            }
            foreach (Thread t in threads)
            {
                t.Join();
            }
            long result = 0;
            foreach (Worker w in ws)
            {
                result += w.Result;
            }
            return result;
        }

    }
}
