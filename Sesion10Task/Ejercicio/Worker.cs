using ObligatoriaSesion10;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejercicio
{

    public class Worker
    {
        private BitcoinValueData[] vector;
        private int startIndex, endIndex;
        private long result;
        private int value;
        internal long Result {  get { return result; } }

        public Worker(BitcoinValueData[] vector, int startIndex, int endIndex, int value )
        {
            this.vector = vector;
            this.startIndex = startIndex;
            this.endIndex = endIndex;   
            this.value = value;
        }
        internal void Compute()
        {
            this.result = 0;
            for (int i=this.startIndex; i<=this.endIndex; i++)
            {
                if (this.vector[i].Value>=this.value)
                {
                    this.result += 1;
                }
            }
        }
    }
}
