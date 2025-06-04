using Modelo;

namespace Test
{
    [TestClass]
    public class StackTest
    {
        private Pila<Object> pila;
        const uint MAX_SIZE = 10;
        [TestInitialize]
        public void setup()
        {
            pila = new Pila<Object>(MAX_SIZE);
        }
        [TestMethod]
        public void StackPush()
        {
            Persona p1 = new Persona();
            Persona p2 = new Persona("Jose", "Perez", "431426718");
            pila.Push(1);
            pila.Push(2);
            pila.Push("hola");
            pila.Push("pepe");
            pila.Push(2.01);
            pila.Push(9.08);
            pila.Push(p1);
            pila.Push(p2);
            pila.Push('a');
            pila.Push("ultimo");
            try
            {
                pila.Push(1);
            }
            catch (InvalidOperationException e)
            {
                Assert.AreEqual("Cannot add elements to an already full stack", e.Message);
            }
            try
            {
                pila.Push(null);
            }
            catch (ArgumentException e)
            {
                Assert.AreEqual("Object pushed cannot be null", e.Message);
            }
            Assert.AreEqual(10, pila.TestingLista.NumeroElementos);
        }
        [TestMethod]
        public void StackPop()
        {
            Persona p1 = new Persona();
            Persona p2 = new Persona("Jose", "Perez", "431426718");
            pila.Push(1);
            pila.Push(2);
            pila.Push("hola");
            pila.Push("pepe");
            pila.Push(2.01);
            pila.Push(9.08);
            pila.Push(p1);
            pila.Push(p2);
            pila.Push('a');
            pila.Push("ultimo");

            for(int i=0; i<10; i++)
            {
                pila.Pop();
            }
            try
            {
                pila.Pop();
            }
            catch (InvalidOperationException e)
            {
                Assert.AreEqual("Cannot pop an element from the stack because it is empty", e.Message);
            }
            Assert.AreEqual(0, pila.TestingLista.NumeroElementos);
        }
        [TestMethod]
        public void StackFullandEmpty()
        {
            Persona p1 = new Persona();
            Persona p2 = new Persona("Jose", "Perez", "431426718");
            Assert.IsTrue(pila.EstaVacia());
            Assert.IsFalse(pila.EstaLlena());
            pila.Push(1);
            Assert.IsFalse(pila.EstaVacia());
            Assert.IsFalse(pila.EstaLlena());
            pila.Push(2);
            pila.Push("hola");
            pila.Push("pepe");
            pila.Push(2.01);
            pila.Push(9.08);
            pila.Push(p1);
            pila.Push(p2);
            pila.Push('a');
            pila.Push("ultimo");
            Assert.IsTrue(pila.EstaLlena());
        }
    }
}