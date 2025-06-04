using System;

// Colecciones genéricas.
using System.Collections.Generic;
// LINQ
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text.RegularExpressions;
using Modelo;

namespace Linq
{
    class Program
    {

        private static Model modelo = new Model();

        static void Main()
        {
            //SintaxisLinq();
            //EjemploJoin();
            //EjemploGroupBy();

            
             Consulta1();
             Consulta2();
             Consulta3();
             Consulta4();
             Consulta5();
             Consulta6();
             Consulta7();


        }

        private static void SintaxisLinq()
        {
            //Obtener las llamadas de más de 15 segundos de duración


            //Sintaxis de consulta
            var c1 =
                from pc in modelo.PhoneCalls
                where pc.Seconds > 15
                select pc;
            Show(c1);

            Console.WriteLine();

            //Equivalente con sintaxis de métodos.
            //¡OJO! SE DEFINE LA CONSULTA. NO SE EJECUTA. ¿POR QUÉ? porque es perezoso
            var c1_m = modelo.PhoneCalls.Where(ll => ll.Seconds > 15);
            //¿Qué ocurre si la consulta anterior la finalizamos con un .ToList()?
            //que se genera la lista entera obligando al Ienumerable a generarse entero
            Show(c1_m);
            Limpiar();
        }

        private static void EjemploJoin()
        {
            //Mostrar las llamadas de cada empleado con el formato: "<Nombre>;<Duración de la llamada>"

            //El método Join, une dos colecciones a partir de un atributo común:
            //Lo utilizamos sobre un IEnumerable (modelo.PhoneCalls)
            var result = modelo.PhoneCalls.Join(

                modelo.Employees, //para unir sus elementos con los de un segundo IEnumerable (modelo.Employees)

                llamada => llamada.SourceNumber, //Atributo clave del primer IEnumerable (PhoneCalls)

                emp => emp.TelephoneNumber, //Atributo clave del 2º IEnumerable (Employees)

                (llamada, emp) => $"{emp.Name};{llamada.Seconds}" // Función que recibe y trata cada par de llamada-empleado de claves coincidentes.
            );

            Show(result);
            Limpiar();
        }

        
        private static void EjemploGroupBy()
        {
            //GroupBy: Vamos a mostrar la duración de las llamadas agrupadas por número de teléfono (origen)

            var llamadas = modelo.PhoneCalls;
            var resultado = llamadas.GroupBy(ll => ll.SourceNumber);

            //resultado ahora mismo es un  IEnumerable<IGrouping>
            Console.WriteLine("Imprimiendo directamente:");
            Show(resultado);


            Console.WriteLine("\nImprimiendo mediante recorrido:");
            foreach (var grupo in resultado)
            {
                //Cada IGrouping tiene una Key:
                Console.Write("\nClave [" + grupo.Key + "] : ");
                //Y tenemos un listado. En este caso, de llamadas:
                foreach (var llamada in grupo)
                {
                    Console.Write(llamada.Seconds + " ");
                }
            }

            //Sin embargo GroupBy nos presenta otras opciones, vamos a combinar éstas
            //con los objetos anónimos:

            var opcion2 = llamadas.GroupBy(
                ll => ll.SourceNumber, //Agrupamos por número de origen

                //el primer parámetro es el número de origen (clave)
                //el segundo parámetro es un IEnumerable<PhoneCall> asociados a esa clave.
                (numero, llamadasEncontradas) =>
                new //Vamos emplear una función que cree objetos anónimos con la info que necesitamos
                {
                    Key = numero,
                    //Duraciones sigue siendo un IEnumerable.
                    Duraciones = llamadasEncontradas.Select(ll => ll.Seconds)//.Aggregate("", (acumulado, actual) => $"{acumulado} {actual}")
                }
                );

            Console.WriteLine("\n\nImprimiendo directamente:");
            Show(opcion2);
            Console.WriteLine("\nImprimiendo con el Aggregate:");
            var conAggregate = opcion2.Select(a => $"{a.Key} : {a.Duraciones.Aggregate("", (acumulado, actual) => $"{acumulado} {actual}")}");
            //¿Podríamos hacer el Aggregate directamente en el objeto anónimo?
            Show(conAggregate);
            Limpiar();
        }

        private static void Consulta1()
        {
            // Modificar la consulta para mostrar los empleados cuyo nombre empieza por F.
            var resultado = modelo.Employees.Where(empleado => empleado.Name[0]=='F');

            Show(resultado);
            //El resultado esperado es: Felipe
          
        }

        private static void Consulta2()
        {

            //Mostrar Nombre y fecha de nacimiento de los empleados de Cantabria con el formato:
            // Nombre=<Nombre>,Fecha=<Fecha>
            var resultado = modelo.Employees.Where(employee => employee.Province.Equals("Cantabria")).Select(a => $"Nombre={a.Name},Fecha={a.DateOfBirth}");

            /*El resultado (sin formato) esperado es:
              Alvaro 19/10/1945 0:00:00
              Dario 16/12/1973 0:00:0066
            */
            Show(resultado);
        }



        // A partir de aquí, necesitaréis métodos presentes en: https://docs.microsoft.com/en-us/dotnet/api/system.linq.enumerable?view=net-8.0

        private static void Consulta3()
        {

            //Mostrar los nombres de los departamentos que tengan más de un empleado mayor de edad.
            var resultado = modelo.Departments.Where(dep => dep.Employees.Count(employee => employee.Age >= 18) > 1).Select(dep => dep.Name);


            /*El resultado esperado es:
                Computer Science
                Medicine
            */
            Show(resultado);

            //Posteriormente, cree una nueva versión de la consulta para que:
            //Muestre los nombres de los departamentos que tengan más de un empleado que
            //sea mayor de edad y su despacho (Office.Number) COMIENCE por "2.1"
            var resultado2 = modelo.Departments.Where(dep => dep.Employees.Count(employee => employee.Age >= 18 && employee.Office.Number.Substring(0, 3).Equals("2.1")) > 1 ).Select(dep => dep.Name);


            //El resultado esperado es: Medicine
            Show(resultado2);
        }

        private static void Consulta4()
        {
            var resultado = modelo.Departments.Where(dep => dep.Employees.Count(employee => employee.Office.Building.Equals("Faculty of Science")) == 0).Select(dep => dep.Name);
            //El nombre de los departamentos donde ningún empleado tenga despacho en el Building "Faculty of Science".
            //Resultado esperado: [Department: Mathematics]
            Show(resultado);
        }

        private static void Consulta5()
        {


            // Mostrar las llamadas de teléfono de más de 5 segundos de duración para cada empleado que tenga más de 50 años
            //Cada línea debería mostrar el nombre del empleado y la duración de la llamada en segundos.
            //El resultado debe estar ordenado por duración de las llamadas (de más a menos).
            /*
                { Nombre = Eduardo, Duracion = 23 }
                { Nombre = Eduardo, Duracion = 22 }
                { Nombre = Alvaro, Duracion = 15 }
                { Nombre = Alvaro, Duracion = 10 }
                { Nombre = Felipe, Duracion = 7 }
            */
            //var resultado = modelo.Employees.Join(
            //    modelo.PhoneCalls,
            //    llamada => llamada.Age,
            //    empleado => empleado.Seconds,
            //    (empleado, llamada) => new { Empleado = empleado, Llamada = llamada.Seconds }
            //  ).Where(tup => tup.Empleado.Age > 50 && tup.Llamada > 5).Select(tup => $"Nombre = {tup.Empleado.Name}, Duracion = {tup.Llamada}");

            //otra forma
            var resultado = modelo.Employees.Where(emp => emp.Age> 50 && !emp.Name.Equals("Bernardo")).Join(
               modelo.PhoneCalls.Where(ph => ph.Seconds>5),
               empleado => empleado.TelephoneNumber,
               llamada => llamada.SourceNumber,
               (empleado, llamada) => new { Empleado = empleado, Segundos = llamada.Seconds }
             ).OrderByDescending(tup => tup.Segundos).Select(tup => $"Nombre = {tup.Empleado.Name}, Duracion = {tup.Segundos}");
            Show(resultado);

        }



        private static void Consulta6()
        {
            //Mostrar la llamada realizada más larga para cada empleado, mostrando por pantalla: Nombre_empleado : duracion_llamada_mas_larga
            /* ¡OJO NO ESTÁ APLICADO EL FORMATO 
                { Nombre = Alvaro, Maxima = 15 }
                { Nombre = Bernardo, Maxima = 63 }
                { Nombre = Eduardo, Maxima = 23 }
                { Nombre = Felipe, Maxima = 7 }
             */
            var resultado = modelo.PhoneCalls
                   .Join(
                       modelo.Employees,
                       llamada => llamada.SourceNumber,
                       empleado => empleado.TelephoneNumber,
                       (llamada, empleado) => new { empleado.Name, llamada.Seconds })
                   .GroupBy(tup => tup.Name)
                   .Select(group => new
                   {
                       Nombre = group.Key,
                       Maxima = group.Max(x => x.Seconds)
                   })
                   .Select(tup => $"Nombre = {tup.Nombre}, Maxima = {tup.Maxima}");
            Show(resultado);
        }


        private static void Consulta7()
        {
            // Mostrar, agrupados por provincia, el nombre de los empleados
            //Tanto la provincia como los empleados de cada provicia seguirán un orden alfabético.



            /*Resultado esperado:
                Alicante : Carlos
                Asturias : Bernardo Felipe
                Cantabria : Alvaro Dario               
                Granada : Eduardo

            */
            var resultado = modelo.Employees.GroupBy(
                empleado => empleado.Province,
                (provincia, emp) => new
                {
                    Provincia = provincia,
                    Nombre = emp.Select(tup => tup.Name)
                }


                ).OrderBy(a => a.Provincia).Select(a => $"{a.Provincia} : {a.Nombre.Aggregate("", (acumulator, siguiente) => $"{acumulator} {siguiente}")}");
            Show(resultado);
        }
        public static void Ejercicio1()
        {
            var resultado = modelo.Employees
       .Where(emp => emp.Department.Equals("Computer Science") &&
                     emp.Office.Equals("Faculty of Science") &&
                     modelo.PhoneCalls.Any(call => call.SourceNumber == emp.TelephoneNumber && call.Seconds > 60))
       .Select(emp => emp.Name);

            Show(resultado);

        }
        public static void Ejercicio2()
        {
            var resultado = modelo.PhoneCalls.Where(e => modelo.Employees.Where(x => x.Department.Equals("Computer Science")).Select(x => x.TelephoneNumber).Contains(e.SourceNumber)).Sum(x => x.Seconds);
            Console.WriteLine(resultado);
        }
        public static void Ejercicio3()
        {
            var resultado = modelo.Departments
     .Select(dep => new
     {
         NombreDepartamento = dep.Name,
         DuracionTotal = modelo.PhoneCalls
             .Where(call => dep.Employees.Select(emp => emp.TelephoneNumber).Contains(call.SourceNumber))
             .Sum(call => call.Seconds)
     })
     .OrderBy(dep => dep.NombreDepartamento)
     .Select(dep => $"Departamento={dep.NombreDepartamento};Duración={dep.DuracionTotal}");

            Show(resultado);

        }
        private static void Ejercicio4()
        {
            var resultado = modelo.Departments
     .Select(dep => new
     {
         NombreDepartamento = dep.Name,
         DuracionTotal = modelo.PhoneCalls
             .Where(call => dep.Employees.Select(emp => emp.TelephoneNumber).Contains(call.SourceNumber))
             .Sum(call => call.Seconds)
     })
     .OrderBy(dep => dep.NombreDepartamento)
     .Select(dep => $"Departamento={dep.NombreDepartamento};Duración={dep.DuracionTotal}");

            Show(resultado);


        }
        private static void Ejercicio5()
        {
            var edadMinima = modelo.Employees.Min(emp => emp.Age); // 1️⃣ Obtener la edad mínima

            var resultado = modelo.Employees
                .Where(emp => emp.Age == edadMinima) // 2️⃣ Filtrar empleados con la edad mínima
                .Join(modelo.Departments,
                      emp => emp.Department,
                      dep => dep,
                      (emp, dep) => new { DepName = dep.Name, EmpName = emp.Name, emp.Age }) // 3️⃣ Unir empleados con departamentos
                .Select(x => $"Departamento={x.DepName}; Empleado={x.EmpName}; Edad={x.Age}"); // 4️⃣ Formatear la salida

            Show(resultado);

        }
        private static void Show<T>(IEnumerable<T> colección)
        {
            foreach (var item in colección)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine("Elementos en la colección: {0}.", colección.Count());
        }

        private static void Limpiar()
        {
            Console.WriteLine("Pulse una tecla para continuar la ejecución...");
            Console.ReadKey();
            Console.Clear();
        }
    }
}
