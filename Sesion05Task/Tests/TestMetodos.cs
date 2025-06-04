using Microsoft.VisualStudio.TestPlatform.TestHost;
using Modelo;
using System.Runtime.Intrinsics.X86;

namespace Tests
{
    [TestClass]
    public class TestMetodos
    {
        Persona[] lp = Factoria.CrearPersonas();
        Angulo[] la = Factoria.CrearAngulos();
        [TestMethod]
        public void BuscarTest()
        {

            Assert.AreEqual(lp[0],Metodos.Buscar(lp, x => x.Nif.EndsWith("A")));
            Assert.IsNotNull(Metodos.Buscar(la, x => x.Grados==90));
            Assert.IsNull(Metodos.Buscar(lp, x => x.Nif.EndsWith("6")));
        }
        [TestMethod]
        public void FiltrarTest()
        {
            Assert.AreEqual(2, Metodos.Filtrar(lp, x => x.Nif.EndsWith("A")).Count());
            IEnumerable<Angulo> it = Metodos.Filtrar(la, x => x.Grados >= 0 && x.Grados <= 90);
            Assert.IsNotNull(it);
            Assert.IsTrue(it.Count() > 0);
            foreach (Angulo a in it)
            {
                Assert.IsTrue(a.Grados>=0 && a.Grados<=90);
            }
        }
        [TestMethod]
        public void ReducirTest()
        {
            float sum = 0;
            foreach (Angulo a in la)
            {
                sum += a.Grados;
            }
            float acumulator = 0;
            Assert.AreEqual(sum, Metodos.Reducir(la, acumulator, (a, b) => a += b.Grados));
            int mCounter = 0;
            int pCounter = 0;
            Func<int, Persona, int> f1 = (a, b) =>
            {
                if (b.Nombre.Equals("María"))
                {
                    a++;
                }
                return a;
            };
            Func<int, Persona, int> f2 = (a, b) =>
            {
                if (b.Nombre.Equals("Pepe"))
                {
                    a++;
                }
                return a;
            };
            Assert.AreEqual(2, Metodos.Reducir(lp, mCounter, f1));
            Assert.AreEqual(1, Metodos.Reducir(lp, pCounter, f2));

        }
    }
}