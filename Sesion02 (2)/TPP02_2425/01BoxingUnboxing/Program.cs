using Modelo;
using System.Collections;
namespace _01BoxingUnboxing
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Value Types / Tipos de valor
            int numero = 3;
            bool esPar = false;

            //Conversión a object. Boxing implícito.
            //COPIA el valor y lo almacena:

            object oNumero = numero; 
            object oEsPar = esPar;

            numero = 4;

            Console.WriteLine("numero: {0} . oNumero : {1} .", numero, oNumero);


            //Proceso inverso: object a value type. Unboxing explícito.
            int numeroRecuperado = (int)oNumero;

            //InvalidCastException:
            //string numeroString = (string)oNumero;


            //Mediante el operador is, podemos comprobar compatibilidad con tipos.

            if (oNumero is int)
                Console.WriteLine("El operador is indica que oNumero es un int.");

            if (! (oNumero is string) )
            if (! (oNumero is string) )
                Console.WriteLine("oNumero no es un string.");

            //Mediante el operador as, podemos realizar conversiones seguras entre tipos.

            Persona persona = new Persona("Gervasio", "Suárez", "00000001-A");


            //conversión y comprobación. Si falla asigna null en lugar de lanzar excepción.
            Persona newPersona = oNumero as Persona;
            if (newPersona == null)
                Console.WriteLine("La conversión de oNumero a Persona ha fallado.");



            //Prueba ej1
            ArrayList l = new ArrayList();
            PuntoInteres p = new PuntoInteres("hola", 1 ,1);
            l.Add(persona);
            l.Add(persona);
            l.Add(p);
            l.Add(persona);
            l.Add(persona);
            l.Add(p);

            ej1(l);


            
        {
              
        }


        {
            
        }





















        }
        //EJERCICIO:
        //Crea un método estático que reciba un ArrayList:
        //  https://learn.microsoft.com/es-es/dotnet/api/system.collections.arraylist?view=net-8.0
        //El método debe mostrar por pantalla el recuento de objetos Persona y el recuento de objetos PuntoInteres.

        //Razona el operador utilizado. ¿Por qué no has utilizado el otro operador?
        public static void ej1(ArrayList list)
        {
            int personCounter = 0;
            int pointOfInterestCounter = 0;
            foreach (Object o in  list)
            {
                if (o is Persona)
                {
                    personCounter++;
                }else if(o is PuntoInteres)
                {
                    pointOfInterestCounter++;
                }

                
            }
            Console.WriteLine("Number of persons --> " + personCounter);
            Console.WriteLine("Number of points of interest --> " + pointOfInterestCounter);
        }
    }

}
