using Modelo;

namespace ConsoleApp1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Func<double, Func<double, Func<double, double>>> descuentoTotal = pi => ad => un => (pi / 100) + (ad * (un - 1)) / 100;
            Func<double, Func<double, Func<double, double>>> pf = pu => u => dt => (pu * u) * (1 - dt);
            Console.WriteLine(pf(50)(3)(descuentoTotal(0.1)(0.02)(3)));
        }
        //a*b+c
       
        
    }
}
