using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelo
{
    public class Conjunto
    {
        List _lista;
        int _numberOfElements;
        public List Lista { get; set; }
        public int NumberOfElements { get { return _lista.NumeroElementos; } }
       
        public Conjunto()
        {
            _lista = new List();
        }
        public void Add(Object o)
        {
            _lista.Anadir(o);
        }
        public bool Borrar(Object o)
        {
            return _lista.Borrar(o);
        }
        public Object GetElemento(int n)
        {
            return _lista.GetElemento(n);
        }
        public bool Contiene(Object o)
        {
            return _lista.Contiene(o);
        }
        public override string ToString()
        {
            return _lista.ToString();
        }
        public static Conjunto operator +(Conjunto c1, Object o)
        {
            c1.Add(o);
            return c1;
        }
        public static Conjunto operator -(Conjunto c1, Object o)
        {
            c1.Borrar(o);
            return c1;
        }
        public static Conjunto operator |(Conjunto c1, Conjunto c2)
        {
            Conjunto c = new Conjunto();
            for (int i = 0; i < c1.NumberOfElements; i++)
            {
                c.Add(c1.GetElemento(i));
            }
            for (int i = 0; i < c2.NumberOfElements; i++)
            {
                c.Add(c2.GetElemento(i));
            }
            return c;
        }
        public Object this[int index]
        {
            get
            {
                if(index<0 || index > NumberOfElements)
                {
                    throw new IndexOutOfRangeException("Index out of range");
                }
                return GetElemento(index);
            }
        }
        public static Conjunto operator &(Conjunto c1, Conjunto c2)
        {
            Conjunto c = new Conjunto();
            for (int i = 0; i < c1.NumberOfElements; i++)
            {
                if (c2.Contiene(c1.GetElemento(i)))
                {
                    c.Add(c1.GetElemento(i));
                }
               
            }
            return c;
        }
        public static Conjunto operator -(Conjunto c1, Conjunto c2)
        {
            Conjunto c = new Conjunto();
            for (int i = 0; i < c1.NumberOfElements; i++)
            {
                c.Add(c1.GetElemento(i));
            }
            for (int i = 0; i < c2.NumberOfElements; i++)
            {
                c.Borrar(c2.GetElemento(i));
            }
            return c;
        }
        public static bool operator ^(Conjunto c1, Object o)
        {
            return c1.Contiene(o);
        }

    }
}
