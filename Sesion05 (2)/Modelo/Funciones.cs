

namespace Modelo
{
    public static class Funciones
    {


        /// <summary>
        /// Devuelve el resultado de a + b
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        public static int Sumar(int a, int b)
        {
            return a + b;
        }


        /// <summary>
        /// Devuelve el módulo de la operación a/b
        /// Devuelve 0 si b = 0
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        public static int Modulo(int a, int b)
        {
            if (b == 0)
                return 0;
            return a % b;
        }

        /// <summary>
        /// Devuelve el producto de dos enteros.
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        public static int Multiplicar(int a, int b)
        {
            return a * b;
        }



        public static void Imprime()
        {
            Console.WriteLine("Imprimiendo por pantalla");
        }


    }
}
