using Modelo;

namespace TestLista
{
    [TestClass]
    public class TestLista
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
            Lista<Person> l = new Lista<Person>();
            l.Anadir(new Person("0","pepe"));
            l.Anadir(new Person("1","chema"));
            l.Anadir(new Person("2","mauricio"));
            l.Anadir(new Person("3","jose"));
            Lista<string> lista = l.Buscar(x => x.Name);
            Assert.IsTrue(lista.Contiene("pepe") && lista.Contiene("mauricio") && lista.Contiene("jose") && lista.Contiene("chema"));
        }
       
        internal class Person
        {
            public string Id { get; }
            public string Name { get; }
            public Person(string id, string name)
            {
                this.Id = id;
                this.Name = name;
            }
        }
    }
}