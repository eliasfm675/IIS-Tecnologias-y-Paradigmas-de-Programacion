using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _05MasterWorkerEjercicio
{
    public class Worker
    {
        private short[] v1;
        private short[] v2;
        private int startIndex;
        private int endIndex;
        private short result = 0;

        internal short Result { get { return result; } }

        public Worker(short[] v1, short[] v2, int startIndex, int endIndex)
        {
            this.v1 = v1;
            this.v2 = v2;
            this.startIndex = startIndex;
            this.endIndex = Math.Min(endIndex, v1.Length - v2.Length);
        }

        internal void Compute()
        {
            for (int i = startIndex; i <= endIndex; i++)
            {
                bool match = true;
                for (int j = 0; j < v2.Length; j++)
                {
                    if (v1[i + j] != v2[j])
                    {
                        match = false;
                        break;
                    }
                }
                if (match)
                {
                    result++;
                }
            }
        }
    }
}