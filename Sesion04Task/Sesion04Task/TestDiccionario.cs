using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Linq;

namespace Sesion04Task
{
    [TestClass]
    public class TestDiccionario
    {
        [TestMethod]
        public void TestAddKeyValue()
        {
            IDictionary<int, string> map1 = new Dictionary<int, string>();
            map1.Add(1, "hola");
            Assert.AreEqual("hola", map1[1]);
            IDictionary<Object, Object> map = new Dictionary<Object, Object>();
            map.Add(5, null);
            map.Add(1, 2);
            map.Add(4, 3.14);
            map.Add("hola", 32);
            map.Add(2.1, "dos punto uno");
            Assert.AreEqual(null, map[5]);
            Assert.AreEqual(map.Keys.ElementAt(0), 5);
            Assert.AreEqual(32, map["hola"]);
            Assert.AreEqual(map.Keys.ElementAt(map.Count -1), 2.1);
            Assert.AreEqual(map.Count, 5);//we check the amount of pairs

            Assert.IsFalse(map.ContainsKey(45678));//we check if a key is in the map or not
            Assert.IsTrue(map.ContainsKey(1));


            //we get and change the value of a key
            Assert.AreEqual(map[1], 2);
            map[1] = "jamon";
            Assert.AreEqual(map[1], "jamon");
            Assert.AreNotEqual(map[1], 2);

            //now we will remove some elements, if present it returns true otherwise it will return false
            Assert.IsTrue(map.Remove(5));
            Assert.IsFalse(map.Remove(5));
            Assert.IsFalse(map.ContainsKey(5));   
            Assert.IsTrue(map.Remove(4));
            Assert.IsFalse(map.ContainsKey(4));
            Assert.IsFalse(map.ContainsKey(78));
            Assert.IsFalse(map.Remove(78));

            //and finally we iterate over the map using a foreach loop
            int counter = 0;
            foreach (KeyValuePair<Object, Object> o  in map)
            {
                counter++;
            }
            Assert.AreEqual(3, counter);
        }
    }
}
