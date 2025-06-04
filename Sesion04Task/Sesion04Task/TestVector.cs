using System;

namespace Sesion04Task
{
    [TestClass]
    public class TestVector
    {
        //Ilist<T> list = new List<T>
        [TestMethod]
        public void TestAdd()
        {
            IList<int> li = new List<int>();
            li.Add(1);
            li.Add(-1);
            li.Add(2);
            Assert.IsTrue(li.Count == 3); //testing the element count
            IList<string> ls = new List<string>();
            ls.Add("hola");
            ls.Add("a");
            ls.Add("");
            Assert.IsTrue(ls.Count == 3);
            IList<double> lf = new List<double>();
            lf.Add(2.0);
            lf.Add(3.56);
            lf.Add(1.67);
            Assert.IsTrue(lf.Count == 3);
            IList<Object> lo = new List<Object>();
            lo.Add(1);
            lo.Add("");
            lo.Add(2.08);
            Assert.IsTrue(lo.Count == 3);
        }
        [TestMethod]
        public void TestOverride()
        {
            IList<Object> lo = new List<Object>();
            lo.Add(1);
            lo.Add("");
            lo.Add(2.08);
            Assert.AreEqual("", lo.ElementAt(1));
            lo.RemoveAt(1);
            lo.Insert(1,"Hola");
            Assert.AreEqual("Hola", lo.ElementAt(1));
            Assert.IsTrue(lo.Count == 3);
            Assert.IsTrue(lo.Contains(1));//test list contains x element
            Assert.IsFalse(lo.Contains(""));//test list does not contain x element
        }
        [TestMethod]
        public void TestFirstIndex()
        {
            int Ielement = 3;
            IList<int> li = new List<int>();
            li.Add(1);
            li.Add(2);
            li.Add(3);
            li.Add(4);
            li.Add(3);
            Assert.AreEqual(li.Count, 5);
            Assert.AreEqual(GetFirstIndex(li, Ielement), 2);//the method inferes the type of the arguments so I don't put it in the call's signature
            Assert.AreNotEqual(GetFirstIndex(li, Ielement), 4);
            IList<string> ls = new List<string>();
            string Selement = "Hello";
            ls.Add("hola");
            ls.Add("adios");
            ls.Add("goodbye");
            ls.Add("hello");
            ls.Add("ahfaoifhfah");
            ls.Add("Hello");
            Assert.AreEqual(ls.Count, 6);
            Assert.AreEqual(GetFirstIndex(ls, Selement), 5);
            Assert.AreNotEqual(GetFirstIndex(ls, Selement), 2);
            Assert.AreEqual(GetFirstIndex(ls, ""), -1); //If it is not in the list it returns -1 index
            IList<double> ld = new List<double>();
            double Delement = 3.45;
            ld.Add(3.456);
            ld.Add(Delement);
            ld.Add(-Delement);
            ld.Add(3.14);
            Assert.AreEqual(ld.Count, 4);
            Assert.AreEqual(GetFirstIndex(ld, Delement), 1);
            Assert.AreNotEqual(GetFirstIndex(ld, Delement), 2);
            IList<Object> lo = new List<Object>();
            Object Oelement = 4.18;
            lo.Add(null);
            lo.Add(1);
            lo.Add(-2);
            lo.Add(4.18);
            lo.Add("Jaime");
            Assert.AreEqual(lo.Count, 5);
            Assert.AreEqual(GetFirstIndex(lo, Oelement), 3);
            Assert.AreNotEqual(GetFirstIndex(lo, Oelement), 0);
            Assert.AreEqual(GetFirstIndex(lo, null), 0);




            //now we delete

            //list of integers
            Assert.IsTrue(li.Remove(1));
            Assert.IsTrue(li.Remove(2));
            Assert.IsTrue(li.Remove(3));
            Assert.IsTrue(GetFirstIndex(li, Ielement)==li.Count-1);//we check that only the first one was deleted
            Assert.IsTrue(li.Remove(4));
            Assert.IsTrue(li.Remove(3));
            Assert.IsFalse(li.Remove(1));
            Assert.IsTrue(li.Count == 0);
            //list of strings
            Assert.IsTrue(ls.Remove("hello"));
            Assert.IsTrue(ls.Remove("hola"));
            Assert.IsTrue(ls.Count == 4);
            //list of doubles
            Assert.IsTrue(ld.Remove(3.14));
            Assert.IsTrue(ld.Remove(-3.45));
            Assert.IsTrue(ld.Remove(3.45));
            Assert.IsTrue(ld.Count == 1);
            //list of objects
            Assert.IsTrue(lo.Remove(null));
            Assert.IsTrue(lo.Remove(-2));
            Assert.IsTrue(lo.Remove("Jaime"));
            Assert.IsTrue(lo.Count == 2);
        }

        [TestMethod]
        public void TestforeachIteration()
        {
            IList<int> li = new List<int>();
            li.Add(1);
            li.Add(-1);
            li.Add(2);
            Assert.IsTrue(li.Count == 3); //testing the element count
            IList<string> ls = new List<string>();
            ls.Add("hola");
            ls.Add("a");
            ls.Add("");
            Assert.IsTrue(ls.Count == 3);
            IList<double> ld = new List<double>();
            ld.Add(2.0);
            ld.Add(3.56);
            ld.Add(1.67);
            Assert.IsTrue(ld.Count == 3);
            IList<Object> lo = new List<Object>();
            lo.Add(1);
            lo.Add("");
            lo.Add(2.08);
            Assert.IsTrue(lo.Count == 3);

            int counter = 0;
            foreach(int i in li)
            {
                counter++;
            }
            Assert.AreEqual(counter, li.Count);
            counter = 0;
            foreach(string s in ls)
            {
                counter++;
            }
            Assert.AreEqual(counter, ls.Count);
            counter = 0;
            foreach (double d in ld)
            {
                counter++;
            }
            Assert.AreEqual(counter, ld.Count);
            counter = 0;
            foreach (Object o in lo)
            {
                counter++;
            }
            Assert.AreEqual(counter, lo.Count);
        }
        private int GetFirstIndex<T>(IList<T> li, T element) //is removed because if not the method is non usable with Ilist<object> 
        {
            int index = -1;
            for (int i = 0; i < li.Count; i++)
            {
                if (Equals(li[i],element))//this way i can compare nulls
                {
                    index = i;
                    break;
                }
            }
            return index;
        }
        //private int GetFirstIndexGeneric<T>(IList<T> li, T element) where T : IComparable<T> //is removed because if not the method is non usable with Ilist<object> 
        //{
        //    int index = -1;
        //    for (int i = 0; i < li.Count; i++)
        //    {
        //        if (li[i].CompareTo(element) == 0)
        //        {
        //            index = i;
        //            break;
        //        }
        //    }
        //    return index;
        //}

    }
}