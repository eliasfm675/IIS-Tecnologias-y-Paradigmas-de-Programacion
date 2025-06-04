//Añade el using que falta
using Modelo;
namespace Consola
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");
            //Instanciamos a la autora utilizando el constructor.
            Autor a1 = new Autor("Wisława", "Szymborska");
            Console.WriteLine("Nuevo registro: {0}", a1);

            //Instanciamos al autor utilizando un inicializador de objeto.
            Autor a2 = new Autor { Nombre = "Hermann", Apellido = "Hesse" }; //llama al por defecto y luego asigna a2.Nombre = "Hermann", se hace para evitar confundirse al pasar parámetros
            Console.WriteLine("Nuevo registro: {0}", a2);
            Autor a3 = new Autor();
            Console.WriteLine("Nuevo registro: {0}", a3);





#if DEBUG
            Console.WriteLine("Ejecución modo DEBUG");
#elif RELEASE
            Console.WriteLine("Ejecución modo RELEASE");
#endif

        }
    }
}
