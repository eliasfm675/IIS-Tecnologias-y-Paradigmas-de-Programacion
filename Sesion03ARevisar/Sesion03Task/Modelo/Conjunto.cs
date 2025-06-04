using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelo
{
    public class Conjunto<T>
    {
        Lista<T> _lista;
        int _numberOfElements;
        public Lista<T> Lista { get; }
        public int NumberOfElements { get { return _lista.NumeroElementos; } }

        public Conjunto()
        {
            _lista = new Lista<T>();
        }
        public void Add(T o)
        {
            if (!_lista.Contiene(o))
            {
                _lista.Anadir(o);
            }

        }
        public bool Borrar(T o)
        {
            return _lista.Borrar(o);
        }
        public T GetElemento(int n)
        {
            return _lista.GetElemento(n);
        }
        public bool Contiene(T o)
        {
            return _lista.Contiene(o);
        }
        public override string ToString()
        {
            return _lista.ToString();
        }
        public static Conjunto<T> operator +(Conjunto<T> c1, T o)
        {
            c1.Add(o);
            return c1;
        }
        public static Conjunto<T> operator -(Conjunto<T> c1, T o)
        {
            c1.Borrar(o);
            return c1;
        }
        public static Conjunto<T> operator |(Conjunto<T> c1, Conjunto<T> c2)
        {
            Conjunto<T> c = new Conjunto<T>();
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
        public T this[int index]
        {
            get
            {
                if (index < 0 || index > NumberOfElements)
                {
                    throw new IndexOutOfRangeException("Index out of range");
                }
                return GetElemento(index);
            }
        }
        public static Conjunto<T> operator &(Conjunto<T> c1, Conjunto<T> c2)
        {
            Conjunto<T> c = new Conjunto<T>();
            for (int i = 0; i < c1.NumberOfElements; i++)
            {
                if (c2.Contiene(c1.GetElemento(i)))
                {
                    c.Add(c1.GetElemento(i));
                }

            }
            return c;
        }
        public static Conjunto<T> operator -(Conjunto<T> c1, Conjunto<T> c2)
        {
            Conjunto<T> c = new Conjunto<T>();
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
        public static bool operator ^(Conjunto<T> c1, T o)
        {
            return c1.Contiene(o);
        }

    }
}
