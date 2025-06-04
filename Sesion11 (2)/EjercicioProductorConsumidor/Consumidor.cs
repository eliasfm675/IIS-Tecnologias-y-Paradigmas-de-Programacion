using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace EjercicioProductorConsumidor
{
    class Consumidor
    {

        private Queue<Producto> cola;

        public Consumidor(Queue<Producto> cola)
        {
            this.cola = cola;
        }

        public void Run()
        {
            Random random = new Random();
            while (true)
            {
                Console.WriteLine("- Sacando producto...");
                Producto producto = null;
                lock (cola)
                {
                    //while (cola.Count == 0)
                    //    Thread.Sleep(100);
                    if (cola.Count()>0)
                    {
                        producto = cola.Dequeue();
                    }
                    
                }
                if (producto==null)
                {
                        Thread.Sleep(100);
                }
                else
                {
                    Console.WriteLine("- Producto sacado: {0}.", producto);
                    Thread.Sleep(300);
                }
               
            }
        }

    }
}
