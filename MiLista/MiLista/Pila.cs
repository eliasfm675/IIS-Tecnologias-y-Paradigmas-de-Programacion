using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelo
{
    public class Pila<T>
    {
        Lista<T> _lista;
        uint _numeroMaxElementos;
        //public List Lista { get { return _lista; } } //esto fuera, porque no interesa que se vea la lista desde fuera
        public uint NumeroMaxElementos { get { return _numeroMaxElementos; } }
        public bool EstaVacia { get { return _lista.NumeroElementos == 0; } }
        public bool EstaLlena { get { return _lista.NumeroElementos == NumeroMaxElementos; } }
        public Lista<T> TestingLista { get { return _lista; } }
        public Pila(uint _numeroMaxElementos)
        {
            //precond
            if (_numeroMaxElementos == 0)
            {
                throw new ArgumentException("Max number of elements cannot be zero or less");
            }
            this._numeroMaxElementos = _numeroMaxElementos;
            _lista = new Lista<T>();
#if DEBUG
            //inv
            Invariante();
            //postcond
            Debug.Assert(NumeroMaxElementos == _numeroMaxElementos, "Postcondition not matched");
            Debug.Assert(_lista != null, "Postcondition not matched");
#endif
        }
        private void Invariante()
        {
            Debug.Assert(_lista != null, "Invariant not matched");
            Debug.Assert(NumeroMaxElementos >= _lista.NumeroElementos, "Invariant not matched");
            Debug.Assert(0 <= _lista.NumeroElementos, "Invariant not matched");

        }
        public void Push(T o)
        {
            //precond
            if (o == null)
            {
                throw new ArgumentException("Object pushed cannot be null");
            }
            if (_lista.NumeroElementos >= NumeroMaxElementos)
            {
                throw new InvalidOperationException("Cannot add elements to an already full stack");
            }
#if DEBUG
            Invariante();
#endif
            int oldNumber = _lista.NumeroElementos;
            Lista<T> l = new Lista<T>();
            l.Anadir(o);
            for (int i = 0; i < _lista.NumeroElementos; i++)
            {
                l.Anadir(_lista.GetElemento(i));
            }
            _lista = l;
#if DEBUG
            //inv
            Invariante();
            //postcond
            Debug.Assert(_lista.NumeroElementos == oldNumber + 1 || EstaLlena, "Postcondition not matched");
            Debug.Assert(_lista.GetElemento(0).Equals(o), "Postcondition not matched");
#endif
        }
        public T Pop()
        {
            //precond
            if (_lista.NumeroElementos == 0)
            {
                throw new InvalidOperationException("Cannot pop an element from the stack because it is empty");
            }
#if DEBUG
            Invariante();
#endif
            int oldNumber = _lista.NumeroElementos;
            T obj = _lista.GetElemento(0);
            _lista.BorrarIndice(0);
#if DEBUG
            Invariante();
            Debug.Assert(oldNumber - 1 == _lista.NumeroElementos || EstaVacia, "Postcondition failed");
#endif
            return obj;
        }
        public override string ToString()
        {
            return _lista.ToStringStack();
        }



    }
}
