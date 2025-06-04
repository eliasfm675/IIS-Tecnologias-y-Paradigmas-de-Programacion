using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _05MasterWorkerEjercicio
{
    public class Master
    {
        private short[] v1;
        private short[] v2;
        private int numThreads;
        public Master(short[] v1, short[] v2, int numThreads) {
        
            this.v1 = v1;
            this.v2 = v2;
            this.numThreads = numThreads;
        
        }
        public short Result()
        {
            Worker[] workers = new Worker[numThreads];
            int elementsPerThread = workers.Length/numThreads;

            for (int i=0; i<numThreads; i++)
            {
                int startIndex = i*numThreads;
                int endIndex = (i+1)*numThreads-1;
                if (i==numThreads-1)
                {
                    endIndex = workers.Length-1;
                }
                workers[i] = new Worker(v1, v2, startIndex, endIndex);
            }
            Thread[] threads = new Thread[numThreads];
            for (int i=0; i<numThreads; i++)
            {
                threads[i]= new Thread(workers[i].Compute);
                threads[i].Name = $"Thread nº {i+1}";
                threads[i].Priority = ThreadPriority.Normal;
                threads[i].Start();

            }
            foreach (Thread t in threads)
            {
                t.Join();
            }
            short result = 0;
            foreach (Worker w in workers)
            {
                result += w.Result;
            }
            return result;
        }
    }
}
