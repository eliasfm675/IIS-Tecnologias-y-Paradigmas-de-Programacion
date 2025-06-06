﻿
namespace _02Currificacion
{
    public static class Ejercicio
    {
        //Ejercicio 1..

        //Implementar de forma currificada el método Buscar entregado en la sesión anterior.
        //Demostrar el uso de su invocación y de la aplicación parcial.


        //Ejercicio 2.

        // Si - > 5 / 3 = 1 ; Resto = 2

        // Entonces -> 3 * 1 + 2 = 5;

        //Currifíquese la función y compruébese mediante el uso de la aplicación parcial el siguiente ejemplo:

        // Se sabe que la división:  20 / 6 = 3. Se desconoce el valor del resto.
        // Partiendo del valor 0, e incrementalmente, obténgase el resto.
        public static bool Ej2(int n)
        {
            Func<int, int> a = mult(3);
            int value = a(1);
            Func<int, int> b = sum(2);
            int result = b(value);
            return n == result;
        }
        static Func<int, int> mult(int a)
        {
            return b => a * b;
        }
        static Func<int, int> sum(int a)
        {
            return b => a + b;
        }

        public static bool ComprobarDivision(int divisor, int dividendo, int cociente, int resto)
        {
            return dividendo == cociente * divisor + resto;
        }
    }
}
