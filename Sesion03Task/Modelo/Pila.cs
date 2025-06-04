using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelo
{
    public class Pila
    {
        List _lista;
        uint _numeroMaxElementos;
        public List Lista { get { return _lista; } }
        public uint NumeroMaxElementos { get { return _numeroMaxElementos; } }
        public Pila(uint _numeroMaxElementos)
        {
            //precond
            if (_numeroMaxElementos == 0)
            {
                throw new ArgumentException("Max number of elements cannot be zero or less");
            }
            this._numeroMaxElementos = _numeroMaxElementos;
            _lista = new List();
            //inv
            Invariante();
            //postcond
            Debug.Assert(NumeroMaxElementos==_numeroMaxElementos, "Postcondition not matched");
            Debug.Assert(Lista!=null, "Postcondition not matched");
        }
        public void Invariante()
        {
            Debug.Assert(Lista!=null, "Invariant not matched");
            Debug.Assert(NumeroMaxElementos>=Lista.NumeroElementos, "Invariant not matched");
            Debug.Assert(0 <= Lista.NumeroElementos, "Invariant not matched");

        }
        public void Push(Object o)
        {
            //precond
            if (o==null)
            {
                throw new ArgumentException("Object pushed cannot be null");
            }
            if (Lista.NumeroElementos>=NumeroMaxElementos)
            {
                throw new InvalidOperationException("Cannot add elements to an already full stack");
            }
            Invariante();
            int oldNumber = Lista.NumeroElementos;
            List l = new List();
            l.Anadir(o);
            for(int i=0; i<Lista.NumeroElementos; i++)
            {
                l.Anadir(Lista.GetElemento(i));
            }
            _lista = l;
            //inv
            Invariante();
            //postcond
            Debug.Assert(Lista.NumeroElementos==oldNumber+1 || EstaLlena(), "Postcondition not matched");
            Debug.Assert(Lista.GetElemento(0).Equals(o),"Postcondition not matched");
        }
        public Object Pop()
        {
            //precond
            if (Lista.NumeroElementos == 0)
            {
                throw new InvalidOperationException("Cannot pop an element from the stack because it is empty");
            }
            Invariante();
            int oldNumber = Lista.NumeroElementos;
            Object obj = Lista.GetElemento(0);
            Lista.BorrarIndice(0);
            Invariante();
            Debug.Assert(oldNumber-1==Lista.NumeroElementos || EstaVacia(), "Postcondition failed");
            return obj;
        }
        public bool EstaVacia()
        {
            return Lista.NumeroElementos == 0;
        }
        public bool EstaLlena()
        {
            return Lista.NumeroElementos == NumeroMaxElementos;
        }

        public override string ToString()
        {
            return Lista.ToStringStack();
        }


    }
}
