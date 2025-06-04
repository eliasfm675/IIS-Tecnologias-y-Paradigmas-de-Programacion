using System.Diagnostics;

namespace _03DatosParaleloLocales
{
    class Program
    {
        /// <summary>
        /// Se presenta una sobrecarga del método ForEach en la que cada partición genera un resultado local.
        /// 
        /// </summary>
        static void Main()
        {
            var vector = GenerarVectorAleatorio(-10, 10, 1000000);
            int resultadoTotal = 0;
            object _object = new object();

            Stopwatch sw = new Stopwatch();

            //sw.Start();

            ////<T,S> donde T es el tipo de origen y S es el tipo del resultado local.
            //Parallel.ForEach<int, int>(
            //    //IEnumerable<T> a recorrer. Potencialmente un hilo por elemento.
            //    vector,

            //    // Func<S> que inicializa la variable de resultado local para la partición.
            //    () => 0,

            //    //Func<T,ParallelLoopState, S> que representa el algoritmo a ejecutar.
            //    (actual, loopState, resultadoLocal) =>
            //    {

            //        resultadoLocal += actual;
            //        return resultadoLocal;
            //    },

            //    //Action<S> una vez finalizada la partición, ¿qué hacer con el resultado local?
            //    resultadoLocalFinal => Interlocked.Add(ref resultadoTotal, resultadoLocalFinal)
            //);
            //sw.Stop();

           // Console.WriteLine("El sumatorio total es {0}. Tiempo: {1}.", resultadoTotal, sw.ElapsedMilliseconds);

            //EJERCICIO:
            //Impleméntese el cálculo del valor mínimo en el vector anterior, siguiendo los dos enfoques posibles:
            //  - Empleando resultados parciales/locales.
            //  - No empleando resultados parciales/locales (téngase en cuenta los posibles recursos compartidos).
            // Imprímase el tiempo empleado para cada uno de los enfoques.
            sw.Restart();
            resultadoTotal = vector[0];
            Parallel.ForEach<int, int>(
                vector,
                () => Int32.MaxValue,
                (actual, loopState, resultadoLocal) =>
                {
                    return Math.Min(actual, resultadoLocal);
                },
                resultadoLocalFinal =>
                {
                    lock (_object)
                    {
                        resultadoTotal = Math.Min(resultadoTotal,resultadoLocalFinal);
                    }
                }

               );
            sw.Stop();
            Console.WriteLine("El minimo es {0}. Tiempo: {1}. Resultado real{2}", resultadoTotal, sw.ElapsedMilliseconds, vector.Min());
            sw.Restart();
            resultadoTotal = vector[0];
            int minimo = Int32.MaxValue;
            Parallel.ForEach<int>(vector, 
                    (actual, loopstate ) =>
                    {
                        lock (_object)
                            if (actual<minimo){
                           
                                minimo = actual;
                            }
                    }
                   );
            sw.Stop();
            Console.WriteLine("El minimo es {0}. Tiempo: {1}. Resultado real{2}", minimo, sw.ElapsedMilliseconds, vector.Min());

            //EJERCICIO:
            //Impleméntese el ejercicio anterior empleando el For, almacenando la POSICIÓN del valor mínimo.
            //Debe almacenarse la posición más cercana al inicio del vector que contenga el valor mínimo:
            //      {4, 5, 6, 1, 4, 5, 6, 1} -> Resultado esperado: 3
            int i = 0;
            int min = Int32.MaxValue;
            int pos = -1;
            int[] array = { 4, 5, 6, 1, 4, 5, 6, 1 };
            sw.Restart();
            Parallel.For(
                i,
                array.Length,
                (i) =>
                {
                    
                        if (array[i] < min)
                        {
                            lock (_object)
                            {
                                if (array[i]<min)//double check
                                {
                                    min = array[i];
                                    pos = i;
                                }
                               
                            }
                            
                        }
                    
                   
                }
             );
            sw.Stop();
            Console.WriteLine("El minimo es {0}. Tiempo: {1}. Resultado real{2} Posición {3}", min, sw.ElapsedMilliseconds, array.Min(), pos);
            int totalResult = 0;
            int min2 = Int32.MaxValue;
            int pos2 = -1;
            Parallel.For(0, array.Length,
                () => -1,
                (i, loopstate, resultadoLocal) =>
                {
                    if (array[i] < min2)
                    {
                        lock (_object)
                            if (array[i] < min2)
                            {
                                min2 = array[i];
                                pos2 = i;
                            }
                    }
                    return pos2;
                },
                resultadoLocalFinal =>
                {
                    lock (_object)
                        if (array[resultadoLocalFinal] < array[resultadoTotal])
                        {
                            totalResult = resultadoLocalFinal;
                        }
                     
                }
                                    

                );
            Console.WriteLine("El minimo es {0}. Tiempo: {1}. Resultado real{2} Posición {3}", min2, sw.ElapsedMilliseconds, array.Min(), pos2);

        }

        static int[] GenerarVectorAleatorio(int min, int max, int tam)
        {
            Random random = new Random();
            int[] vector = new int[tam];

            for (int i = 0; i < tam; i++)
                vector[i] = random.Next(min, max + 1);

            return vector;
        }
    }
}
