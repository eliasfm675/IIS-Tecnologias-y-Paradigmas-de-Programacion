using Modelo;
namespace _02DelegadosPredefinidos
{
    public class Program
    {
        public static string Concatenar(char a, char b)
        {
            return String.Format("{0}{1}", a, b);
        }

        public static bool TieneLongitudUno(string cadena)
        {
            return cadena.Length == 1;
        }

        public static void Almacena(int valor)
        {
            //<-- Código que simula almacenar el valor en algún lugar.
            Console.WriteLine("LOG: El valor {0} ha sido almacenado", valor);
        }

        static void Main(string[] args)
        {
            //Func Puede recibir entre 0 y 16 parámetros y siempre retorna un valor

            Func<char, char, string> funcion = Concatenar;
            Console.WriteLine(funcion('f', 'u'));

            //Predicate Siempre recibe un único parámetro y siempre devuelve bool.
            //¿Qué alternativa tenemos?

            Predicate<string> funcionPredicado = TieneLongitudUno;
            String cadena = "S";

            if (funcionPredicado(cadena)) //Recordad, para invocar tenemos que usar () con los parámetros necesarios.
                Console.WriteLine(cadena + " tiene longitud 1.");
            else
                Console.WriteLine(cadena + " no tiene longitud 1.");

            //Action recibe entre 0 y 16 parámetros y NO DEVUELVE NADA (void)

            Action<int> funcionAction = Almacena;
            funcionAction(2);

            int valor = 2;

            //Pasamos como primer parámetro una función. AplicaciónDoble ¿Es una función de orden superior?
            int resultado = AplicaciónDoble(Suma, valor);
            Console.WriteLine("Resultado de la aplicación doble: {0}", resultado);

            //Ejemplo de orden superior.
            Persona[] personas = Factoria.CrearPersonas();
            Persona[] adultas = Array.FindAll(personas, EsAdulta);
            //Persona[] adultas = Array.FindAll(personas, persona => persona.Edad>=18);

            adultas.ForEach(Console.WriteLine);
        }

        public static int Suma(int a)
        {
            return a + a;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="funcion"></param>
        /// <param name="a"></param>
        /// <returns></returns>
        public static int AplicaciónDoble(Func<int, int> funcion, int a)
        {
            // Puedo pasar el resultado de la primera aplicación al mismo método.
            //El Func necesita un int y devuelve un int.
            return funcion(funcion(a));
        }

        private static bool EsAdulta(Persona persona)
        {
            return persona.Edad >= 18;
        }
        //Predicate<Persona> EsAdulta = p => p.Edad >=18
    }
}
