using System.Collections;

namespace _03MetodosExtensores
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Demostración de métodos extensores.
            string prueba = "murciélago";
            //¡OJO! Fíjate que, en este caso, no estamos pasándole nada al método extensor.
            int vocalesSinTilde = prueba.ContarVocalesSinTilde();
            Console.WriteLine("El texto {0} contiene {1} vocales sin tilde", prueba, vocalesSinTilde);


            //Ejercicios
            //Crear un método extensor de string que, a partir de un texto, cuente las repeticiones de una letra (debe recibir la letra, obviamente).
            char letra = 'l';
            string palabra = "lalalaooollo"; //should be 5
            Console.WriteLine("Times that " + letra + "has appeared --> " + palabra.ContarVecesLetra(letra));

            //Crear un método extensor de DateTime Estacion() que devuelva la estación (string). No es necesario utilizar nada de la práctica anterior.
            DateTime dt = DateTime.Now;
            Console.WriteLine("Current season is --> " + dt.DevolverEstacion());
            //Crear un método extensor de vuestra clase Lista denominado Sum() que devuelva la suma de todos los elementos de la lista.   
            ArrayList l = new ArrayList();
            for(int i = 0; i < 5; i++)
            {
                l.Add(i); //0+1+2+3+4
            }
            Console.WriteLine("The sum of the numbers of the list is --> " + l.Sum());

        }
    }
}
