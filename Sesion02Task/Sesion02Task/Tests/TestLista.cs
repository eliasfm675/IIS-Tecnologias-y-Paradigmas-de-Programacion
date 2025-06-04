using Modelo;
namespace Tests
{
    [TestClass]
    public class TestLista
    {
        [TestMethod]
        public void TestLista1()
        {
            
            List list = new List();
            Persona persona = new Persona();
            list.Anadir("1");
            list.Anadir(1);
            list.Anadir(1.23);
            list.Anadir(persona);
            Assert.IsTrue(list.NumeroElementos==4);
            Assert.IsTrue(list.Contiene(1));
            Assert.IsTrue(list.Contiene(1.23));
            Assert.IsTrue(list.Contiene(persona));
            Assert.IsTrue(list.Contiene("1"));
            Assert.AreEqual(1, list.GetElemento(1));

            list.Borrar("1");
            list.Borrar(1);
            list.Borrar(1.23);
            list.Borrar(persona);
            Assert.IsTrue(list.NumeroElementos == 0);


        }
    }
}