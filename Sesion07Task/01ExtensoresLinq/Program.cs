using Modelo;
using System.Security.Cryptography.X509Certificates;

namespace _01ExtensoresLinq
{
    class Program
    {
        static void Main()
        {

            IEnumerable<int> valores = Enumerable.Range(1, 9);
            //Enumerable.range(1,10).Map(n => "a") generaría un enumerable de 0 elementos que son todos a's

            Console.WriteLine("Colecciones de enteros.");

            //Uso de métodos extensores
            //Map transforma una secuencia de <T>s en una secuencia de <Q>s.
            valores.Map(n => n * n).ForEach(Console.WriteLine);
            Console.WriteLine();

            valores.Map(n => n * n).Map(n => n / 2.0).ForEach(Console.WriteLine);
            Console.WriteLine();

            valores.Map(n => new Angulo(n))
                .Map(a => a.Grados)
                .ForEach(Console.WriteLine); 

            Console.WriteLine();

            Console.WriteLine("\nColecciones de Personas.");

            var personas = Factoria.CrearPersonas();

            var nombres = personas.Map(p => p.Nombre);
            nombres.ForEach(Console.WriteLine);
            Console.WriteLine();

            var iniciales = personas.Map(p => p.Nombre).Map(cadena => cadena[0]); //En la version lazy se genera cada elemento (la linea entera --> la primera letra) 1 a 1 en el foreach
            iniciales.ForEach(Console.WriteLine);
            Console.WriteLine();
            personas.Map(p => p.Nif + "\t" + p.Nombre + "\t" + p.Apellido).ForEach(Console.WriteLine);


            //¿Qué estamos haciendo aquí? Creando un objeto anónimo
            var info = personas.Map(p => new
                {
                    Nombre = p.Nombre,
                    Dni = p.Nif
                }
            );

            info.ForEach(Console.WriteLine);





            //Método ZIP de Linq: Combina dos secuencias:

            var combinación = valores.Zip(personas.Map(p => p.Nombre));//Ienumerable de una tupla
            combinación.Map(c => c.First + " : " + c.Second).ForEach(Console.WriteLine);



            /*
             * Ejercicio: Implementa una versión perezosa del Map.(hecha en extensores)
             */
            /**
             * Una condicion de los metodos extensores es que han de ser estaticos
             * han de usar el this para su propio parametro y que su clase sea estatica
             * 
             * 

            /* EJERCICIO: Implementa el método Zip de LINQ:
             * - Colecciones potecialmente infinitas.
             * - Trabajará con tuplas .
             * */
            var combo = Zip(valores, personas.Map(p => p.Nombre));
            combo.Map(c => c.First + " : " + c.Second).ForEach(Console.WriteLine);

        }
        public static IEnumerable<(T First,E Second)> Zip<T,E>(IEnumerable<T> ienum, IEnumerable<E> ineum2)
        {
            IEnumerator<T> enumerator1 = ienum.GetEnumerator();
            IEnumerator<E> enumerator2 = ineum2.GetEnumerator();
            while (enumerator1.MoveNext() && enumerator2.MoveNext())
            {
                yield return (enumerator1.Current, enumerator2.Current);
            }
        }
       
    }
}
