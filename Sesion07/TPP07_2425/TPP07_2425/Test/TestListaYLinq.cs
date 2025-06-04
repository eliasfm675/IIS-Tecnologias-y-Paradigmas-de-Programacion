using Modelo;

namespace TestLista
{
    [TestClass]
    public class TestListaYLinq
    {

        [TestMethod]
        public void TestInvertir()
        {
            Lista<int> lista = new Lista<int>();
            lista.Anadir(1);
            lista.Anadir(2);
            lista.Anadir(3);
            lista.Anadir(4);
            lista.Anadir(5);
            lista.Anadir(6);
            Lista<int> lista2 = lista.Invertir();
            for (int i = 0; i < lista.NumeroElementos; i++)
            {
                Assert.AreEqual(lista.GetElemento(i), lista2.GetElemento(lista2.NumeroElementos - 1 - i));
            }

        }
        [TestMethod]
        public void TestMap()
        {
            Lista<string> lista = new Lista<string>();
            lista.Anadir("abc");
            lista.Anadir("cda");
            lista.Anadir("bfc");
            lista.Anadir("plc");
            lista.Anadir("ooo");
            lista.Anadir("jajaj");
            Lista<int> lista2 = lista.Map(x => x.Count());
            Assert.AreEqual(lista2.GetElemento(lista2.NumeroElementos - 1), 5);
            Assert.AreEqual(lista2.GetElemento(0), 3);
            Assert.AreEqual(lista2.GetElemento(1), 3);
            Assert.AreEqual(lista2.GetElemento(2), 3);
            Assert.AreEqual(lista2.GetElemento(3), 3);
            Assert.AreEqual(lista2.GetElemento(4), 3);
        }
        [TestMethod]
        public void TestFiltrar()
        {
            Lista<int> l = new Lista<int>();
            IList<int> ilist = new List<int>();
            int j = 0;
            for (int i = 0; i < 100; i++)
            {

                if (i % 2 == 0)
                {
                    ilist.Add(i);
                }
                l.Anadir(i);
            }
            Lista<int> lista2 = l.Filtrar(x => x % 2 == 0);
            Assert.AreEqual(lista2.NumeroElementos, ilist.Count());
            for (int i = 0; i < lista2.NumeroElementos; i++)
            {
                Assert.AreEqual(lista2.GetElemento(i), ilist[i]);
            }
        }
        [TestMethod]
        public void TestReducir()
        {
            Lista<int> l = new Lista<int>();
            int acumulator = 1;
            l.Anadir(1);
            l.Anadir(2);
            l.Anadir(3);
            l.Anadir(4);
            l.Anadir(5);
            l.Anadir(6);
            int result = 1;
            foreach (int n in l)
            {
                result *= n;
            }
            Assert.AreEqual(l.Reducir((y, x) => y *= x, acumulator), result);

        }
        [TestMethod]
        public void TestBuscar()
        {
            Lista<Persona> l = new Lista<Persona>();
            l.Anadir(new Persona("0", "pepe", "90"));
            l.Anadir(new Persona("1", "chema", "88"));
            l.Anadir(new Persona("2", "mauricio", "44"));
            l.Anadir(new Persona("3", "jose", "45"));
            Lista<string> lista = l.Buscar(x => x.Apellido);
            Assert.IsTrue(lista.Contiene("pepe") && lista.Contiene("mauricio") && lista.Contiene("jose") && lista.Contiene("chema"));
        }
        [TestMethod]
        public void TestFirstOrDefault()
        {
            Persona[] personas = Factoria.CrearPersonas();
            Angulo[] angulos = Factoria.CrearAngulos();
            Assert.AreEqual(personas.FirstOrDefault(x => x.Nombre.Equals("María")), personas[0]);
            Assert.IsNull(personas.FirstOrDefault(x => x.Nombre.Equals("kajbciacbiu")));
            Assert.IsNotNull(angulos.FirstOrDefault(x => x.Grados==90));
            Assert.IsNull(angulos.FirstOrDefault(x => x.Grados == 8000));

        }
        [TestMethod]
        public void TestWhere()
        {
            Persona[] personas = Factoria.CrearPersonas();
            Angulo[] angulos = Factoria.CrearAngulos();
            Assert.AreEqual(personas.Where(x => x.Nombre.Equals("María")).Count(), 2);
            Assert.AreEqual(personas.Where(x => x.Nombre.Equals("kajbciacbiu")).Count(), 0);
            Assert.IsTrue(angulos.Where(x => x.Grados == 90).Count()>=1);
            Assert.AreEqual(angulos.Where(x => x.Grados == 8000).Count(), 0);
        }
        [TestMethod]
        public void TestAggregate()
        {
            Persona[] personas = Factoria.CrearPersonas();
            Angulo[] angulos = Factoria.CrearAngulos();
            double accumulator = 0.0;
            double result = 0.0;
            foreach (var item in angulos)
            {
                result += item.Grados;
            }
            Func<double, Angulo, double> f = (x, y) => x+=y.Grados;
            Assert.AreEqual(angulos.Aggregate(accumulator, f), result);
            Assert.AreEqual(angulos.Aggregate(accumulator, (x,y)=>x>y.Seno() ? x: y.Seno()), 1);
            accumulator = 0.0;
            Assert.AreEqual(personas.Aggregate(accumulator, (acumulator, person)=>person.Nombre.Equals("María") ? accumulator++: accumulator), 2);
            accumulator = 0.0;
            Assert.AreEqual(personas.Aggregate(accumulator, (acumulator, person) => person.Nombre.Equals("Pedro") ? accumulator++ : accumulator), 0);

        }
        [TestMethod]
        public void TestSelect()
        {
            Persona[] personas = Factoria.CrearPersonas();
            Angulo[] angulos = Factoria.CrearAngulos();
            IEnumerable<string> listp = personas.Select(x => x.Apellido + ", " + x.Nombre);
            for (int i = 0; i<listp.Count(); i++)
            {
                Assert.AreEqual(listp.ElementAt(i), personas[i].Apellido +", " + personas[i].Nombre);
            }
            Func<Angulo, string> f = x =>
            {
                if (x.Grados >= 0 && x.Grados <= 90)
                {
                    return "Primero";
                }
                else if (x.Grados > 90 && x.Grados <= 180)
                {
                    return "Segundo";
                }
                else if (x.Grados > 180 && x.Grados <= 270)
                {
                    return "Tercero";
                }
                else
                {
                    return "Cuarto";
                }
            };
            IEnumerable<string> lista = angulos.Select(f);
            Assert.IsTrue(lista.Contains("Primero") && lista.Contains("Segundo") && lista.Contains("Tercero") && lista.Contains("Cuarto"));
        }

    }
}