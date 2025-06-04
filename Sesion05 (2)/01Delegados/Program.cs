using Modelo;

namespace _01Delegados
{


    //Creamos un tipo (delegate) para cualquier método / función
    //que reciba 2 int y devuelva un int.
    public delegate int OperacionMatematica(int n1, int n2);


    public delegate void Log(string info);
    


    public class Program
    {
                

        static void Main()
        {
            //Referenciamos al método Concatenar porque CUMPLE LAS CONDICIONES del tipo delegado;
            //calculoPendiente está apuntando a la función Sumar.

            OperacionMatematica calculoPendiente = Funciones.Sumar; //no usar Funciones.Sumar() porque estaria intentando devolver el RESULTADO
            int resultado = calculoPendiente(1, 2);
            Console.WriteLine($"El resultado del cálculo es: {resultado}");


            calculoPendiente = Funciones.Modulo;
            resultado = calculoPendiente(10, 2);
            Console.WriteLine($"El nuevo resultado del cálculo es: {resultado}");


            int[] v1 = { 1, 2, 3, 4 };
            int[] v2 = { 2, 3, 4, 5 };
            //Los delegados pueden utilizarse como tipo de parámetros y retorno de funciones.
            //A estas funciones (que reciben y/o devuelven otras funciones, se les denomina 
            //FUNCIONES DE ORDEN SUPERIOR.

            int[] resultados = OperarCoincidentes(v1, v2, Funciones.Sumar);
            Console.WriteLine($"Se han realizado un total de {resultados.Length} operaciones");


            //Multicast
            Log? logger = LogConsola;
            logger += LogBaseDatos;
            logger += LogFichero;

            logger("Aplicación iniciada.");

            logger -= LogFichero;

            if (logger != null)
                logger("Aplicación finalizada.");

            logger = LogBaseDatos;
            logger("Fin del ejemplo.");


        }


 


        /// <summary>
        /// FUNCIÓN DE ORDEN SUPERIOR. Devuelve una función aleatoria de un array de funciones. 
        /// </summary>
        /// <param name="arrayFunciones"></param>
        /// <returns></returns>
        public static int[] OperarCoincidentes(int[] a, int[] b, OperacionMatematica operacion)
        {
            if (a.Length != b.Length)
                throw new InvalidOperationException("Los arrays deben tener el mismo tamaño.");


            int[] resultado = new int[a.Length];

            for(int i = 0; i < a.Length; i++)
                resultado[i] = operacion(a[i], b[i]);
            
            return resultado;
        }
        ///Func<int[], int[], Func<int, int, int>> operacion = (a, b, operacion) => {(el codigo)}


        public static void LogConsola(string texto)
        {
            Console.WriteLine($"[Consola] {texto}");
        }

        public static void LogBaseDatos(string texto)
        {
            //Simulación de conexión a db...
            Console.WriteLine($"[BD] \"{texto}\" insertado en la tabla de Log.");
        }

        public static void LogFichero(string texto)
        {
            //Simulación de escritura en fichero...
            Console.WriteLine($"[Fichero] \"{texto}\" insertado en el fichero log.txt .");
        }


    }
}
