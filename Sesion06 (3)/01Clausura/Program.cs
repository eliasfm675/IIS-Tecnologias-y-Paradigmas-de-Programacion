using Modelo;

namespace _01Clausura
{
    internal static class Program
    {

        static void Main()
        {

            //.Range permite crear colecciones de enteros. Partimos de 0 hasta llegar a 20 ELEMENTOS 
            // En este caso, [0, 19].
            IEnumerable<int> coleccion = Enumerable.Range(0, 20);

            int n = 8;

            //Concepto de Clausura (cierre, closure). Una clausura es una funcion que tiene estado
            //Compárese este Predicado con la función de "Funciones.ContarMenoresQue"

            Predicate<int> EsMenor = numero => numero < n; // <- ¿Es una función pura?
            int resultado = Funciones.ContarSi(coleccion, EsMenor);
            Console.WriteLine($"La colección tiene {resultado} valores menores que {n}");

            n = 4; //¿Qué es n?
            resultado = Funciones.ContarSi(coleccion, EsMenor);
            Console.WriteLine($"La colección tiene {resultado} valores menores que {n}");

            Funciones.LimpiarPantalla();


            //Un contador en POO
            Contador contador = new Contador();
            contador.Incrementar();
            Console.WriteLine($"[POO] El valor del contador es {contador.Valor}");

            //Mismo enfoque empleando Clausura
            //En este caso, incrementa y devuelve el valor.

            Func<int> incrementarValor = Funciones.CrearContador();
            incrementarValor();
            int valor = incrementarValor();
            Console.WriteLine($"[Contador Clausura] Valor actual del contador: {valor}");


            //En POO manipulamos el estado mediante métodos.
            Contenedor<int> contenedor = new Contenedor<int>(5);
            contenedor.SetValor(20);
            Console.WriteLine($"[Objetos] Almacenado: {contenedor.GetValor()}");



            //¿Y si se necesitan varias clausuras para manipular el estado?
            //Múltiples funciones: uso del out o, alternativamente, tuplas.

            //set recibe el nuevo valor y no devuelve nada.
            Action<int> ContenedorSetValor;
            //get no recibe nada y devuelve un valor.
            Func<int> ContenedorGetValor;

            Funciones.CrearContenedor<int>(5, out ContenedorSetValor, out ContenedorGetValor);
            Console.WriteLine($"[Clausuras] Almacenado: {ContenedorGetValor()}");

            ContenedorSetValor(20);

            Console.WriteLine($"[Clausuras] Almacenado: {ContenedorGetValor()}");

            Func<int> fej1 = Ejercicio.Ej1A(20);
            for(int i = 0; i< 30; i++)
            {
                Console.WriteLine($"Value is --> {fej1()}");
            }
        }



    }
}
