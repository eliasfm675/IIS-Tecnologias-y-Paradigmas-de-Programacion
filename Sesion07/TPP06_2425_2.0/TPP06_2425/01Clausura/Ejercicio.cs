
namespace _01Clausura
{
    public static class Ejercicio
    {
        /* Examen 21/22
        
        Ejercicio 1 (A – 1,50 puntos).

            Dado un valor inicial, impleméntese una clausura que, en cada invocación,
            devuelva un número aleatorio inferior al anterior devuelto.Una vez llegue al valor
            cero y lo devuelva, se regresará al valor inicial de forma automática.

            (B – 1,00 punto).

            Cree una versión del anterior que permita tanto volver al valor inicial de forma manual y/o modificarlo
                
            Añádase código en el método Main para probar ambas versiones.
        
         */
        public static Func<int> Ej1A(int n)
        {
            Random r = new Random();
            int current = n;
            int initial = n;
            return () =>
            {
                if (current <= 0)
                {
                    return initial;
                }
                int result = r.Next(current);
                current--;
                return result;
            };

        }
        public static Func<int> Ej1B(int n, int m = -1)
        {
            Random r = new Random();
            int original = n;
            if (m==-1)
            {
                m = original;
            }

            return () =>
            {
                if (original<=5)
                {
                    ChangeParametres(original, m, );
                }   
                if (original == 0)
                {
                    return n;
                }
                int result = r.Next(original);
                original--;
                return result;
            };

        }
        public static void ChangeParametres<T>(T value, out Action<T> set, out Func<T> get)
        {
            T _value = value;
            set = value => _value = value;
            get = () => _value;
        }


        /* Ejercicio Clase 1
         

        Implementar una clausura que devuelva el siguiente término de la sucesión de Fibonacci
        cada vez que se invoque la clausura:
        
                1,1,2,3,5,8…
        
        Utilícese como base/idea el ejemplo del contador.
        
        NOTA: No es necesario usar la clase Fibonacci PARA NADA, simplemente para
              aprender a calcular términos de Fibonnaci si no se sabe calcularlos.

        */



        /* Ejercicio Clase 2
         
           Impleméntese mediante un enfoque funcional el bucle While
           Pruébese la implementación para el ejemplo propuesto.

         */
        public static Action Ej2<T>(int x, T m, Action<T> a)
        {
            T n = m;
            int i = x;
            return () => {
                if (x != 0)
                {
                    a(n);
                }
                x--;
            };
        }

        public static void BucleWhileObjetos()
        {
            int j = 0;

            while (j < 10) //Condición
            {
                //Cuerpo
                j++;
                Console.WriteLine($"El valor de contador es {j}");
            }
        }

    }
}
