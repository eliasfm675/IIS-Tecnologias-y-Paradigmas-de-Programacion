using Modelo;
namespace Main
{
    internal class Program
    {
        static void Main(string[] args)
        {
            SimuladorTiempo s = new SimuladorTiempo();
            s.AvanzarDias();
            s.AvanzarMeses();
            Console.WriteLine(s);
        }
    }
}
