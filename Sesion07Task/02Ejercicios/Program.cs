using _01ExtensoresLinq;
using Modelo;

namespace _02Ejercicios
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //buscar --> firstordefault
            //filtrar --> where
            //reducir --> aggregate
            //map --> select
            Persona[] personas = Factoria.CrearPersonas();
            Angulo[] angulos = Factoria.CrearAngulos();
            personas.Where(p => p.Nombre.Equals("María")).ForEach(Console.WriteLine);
            personas.Where(p => p.Nif.EndsWith('F')).ForEach(Console.WriteLine);
           
            personas.Select(p => p.Nombre + " - " + p.Apellido).ForEach(Console.WriteLine);
            angulos.Select(a => a.Radianes).ForEach(Console.WriteLine);
            double a = 0.0;

        }
    }
}
