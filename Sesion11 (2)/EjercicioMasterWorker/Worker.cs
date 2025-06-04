using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EjercicioMasterWorker
{

    public class Worker
    {
        private BitcoinValueData[] vector;
        private int startIndex, endIndex;
        private ConcurrentBag<double> result;
        private int value;
        internal ConcurrentBag<double> Result { get { return result; } }

        public Worker(BitcoinValueData[] vector, int startIndex, int endIndex, int value, ConcurrentBag<double> result)
        {
            this.vector = vector;
            this.startIndex = startIndex;
            this.endIndex = endIndex;
            this.value = value;
            this.result = result;
        }
        internal void Compute()
        {
            for (int i = this.startIndex; i <= this.endIndex; i++)
            {
                if (this.vector[i].Value > this.value)
                {
                    result.Add(vector[i].Value);
                }
            }
        }
    }
}
