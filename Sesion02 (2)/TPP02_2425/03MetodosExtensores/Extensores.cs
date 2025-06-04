
using System.Collections;

namespace _03MetodosExtensores
{
    /// <summary>
    /// Los métodos extensores están contenidos en clases estáticas.
    /// </summary>
    public static class Extensores
    {
        /// <summary>
        /// Los métodos extensores son métodos estáticos.
        /// Afectan a la clase que se establece después del this
        /// En este caso, extendemos string con el método ContarVocalesSinTilde
        /// </summary>
        /// <param name="texto">¿Qué crees que es esto?</param>
        /// <returns>Número de vocales sin tilde</returns>
        public static int ContarVocalesSinTilde(this string texto)
        {
            int resultado = 0;
            foreach (char letra in texto)
                if ("aeiouAEIOU".Contains(letra))
                    resultado++;
            return resultado;

        }
        //Crear un método extensor de string que, a partir de un texto, cuente las repeticiones de una letra (debe recibir la letra, obviamente).
        public static int ContarVecesLetra(this string texto, char letra)
        {
            int times = 0;
            foreach (char letter in texto)
            {
                if(letter == letra)
                {
                    times++;
                }
            }
            return times;
        }
        //Crear un método extensor de DateTime Estacion() que devuelva la estación (string). No es necesario utilizar nada de la práctica anterior.
        public static string DevolverEstacion(this DateTime dt)
        {
            int month = dt.Month;
            if (month>=3 && month<=6)
            {
                return "Spring";
            }else if(month>=7 && month<= 9)
            {
                return "Summer";
            }else if (month>=10 && month<12)
            {
                return "Autumn";
            }
            else
            {
                return "Winter";
            }
        }
        //Crear un método extensor de vuestra clase Lista denominado Sum() que devuelva la suma de todos los elementos de la lista.  
        public static int Sum(this ArrayList l)
        {
            int sum = 0;
            foreach (int n in l)
            {
                sum += n;
            }
            return sum;
        }
    }
}
