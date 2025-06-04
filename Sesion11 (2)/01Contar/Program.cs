namespace _01Colores
{
    internal class Program
    {

        static short[] vector = CrearVectorAleatorio(1000000, 0, 10);


        public static int aparacionesMultihilo;
        //public static readonly object _object = new object();
        
        static void Main()
        {
            

            //Contar las veces que aparecen el número 2 sumadas a las del número 3. Secuencialmente:
            int aparacionesSecuencial = vector.Count(e => e == 2 || e == 3);
            Console.WriteLine($"[Secuencial] El número 2 y el 3 aparecen {aparacionesSecuencial} veces.");
            
            //Dos hilos. Uno contará el 2 y otro contará el 3

            Thread[] hilos = new Thread[2];
            for(int i = 0; i < hilos.Length; i++)
            {
                hilos[i] = new Thread(ContarAparicionesNumeroEnVector);
                hilos[i].Start(i + 2);
            }

            foreach (var hilo in hilos)
                hilo.Join();

            Console.WriteLine($"[Multihilo] El número 2 y el 3 aparecen {aparacionesMultihilo} veces.");


            //¿Funciona el programa? ¿Y si aumentamos drásticamente el tamaño del vector?¿Por qué?
            //¿Qué es una sección crítica?
        }

        static void ContarAparicionesNumeroEnVector(object? numero)
        {
            int buscado = (int)numero;
            
            for(int i = 0; i < vector.Length; i++)
            {
                if (vector[i] == buscado)
                    //lock (_object)
                    //{
                        aparacionesMultihilo++;
                    //}
                    
            }

        }



        public static short[] CrearVectorAleatorio(int numElementos, short menor, short mayor)
        {
            short[] vector = new short[numElementos];
            Random random = new Random();
            for (int i = 0; i < numElementos; i++)
                vector[i] = (short)random.Next(menor, mayor + 1);
            return vector;
        }
    }
}
