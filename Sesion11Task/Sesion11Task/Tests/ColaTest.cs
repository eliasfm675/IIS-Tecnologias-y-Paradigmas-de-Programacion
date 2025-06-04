using Modelo;
namespace Tests
{
    
    [TestClass]
    public class ColaTest
    {
        [TestMethod]
        public void AnadirTest()
        {
            ColaConcurrente<int> cc = new ColaConcurrente<int>();
            int numThreads = 20;
            Thread[] threads = new Thread[numThreads];

            for (int i = 0; i < numThreads; i++)
            {
                int threadId = i; 
                threads[i] = new Thread(() => cc.Anadir(threadId));
                threads[i].Name = $"Thread nº{i}";
                threads[i].Start();
            }

            foreach (Thread t in threads)
            {
                t.Join();
            }

            Assert.AreEqual(numThreads, cc.NumeroElementos);
        }
        [TestMethod]
        public void ExtraerTest()
        {
            ColaConcurrente<int> cc = new ColaConcurrente<int>();
            int numThreads = 20;
            Thread[] threads = new Thread[numThreads];
            List<int> elements = new List<int>();

            for (int i = 0; i < numThreads; i++)
            {
                cc.Anadir(i);
                elements.Add(i);
            }

            int[] extracted = new int[numThreads];
            for (int i = 0; i < numThreads; i++)
            {
                int index = i;
                threads[i] = new Thread(() =>
                {
                    if (cc.Extraer(out int item))
                    {
                        extracted[index] = item;
                    }
                });
                threads[i].Start();
            }

            foreach (Thread t in threads)
            {
                t.Join();
            }

            Assert.AreEqual(numThreads-1, extracted.Count(x => x != 0));//we dont take into account the zero because its the default value for integers 
            Assert.IsTrue(cc.EstaVacia);

            CollectionAssert.AreEquivalent(elements, extracted.ToList());
        }
    }
}