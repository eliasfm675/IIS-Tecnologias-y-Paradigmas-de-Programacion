using Modelo;
namespace _03Opcional
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Producto p = new Producto();
            Producto c = new Camiseta("XL", "Blanco");
            Producto b = new Bono(9000);
            p.Reponer(100000);
            c.Comprar(100);
            c.Reponer(1);
            Console.WriteLine(p.ToString()+"\n"+c +"\n" + b);
        }
    }
}
