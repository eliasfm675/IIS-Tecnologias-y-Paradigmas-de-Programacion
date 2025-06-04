using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace Modelo
{
    public class Node<T>
    {
        public T Value { get; set; }
        public Node<T> Next { get; set; }

        public Node(T value)
        {
            Value = value;
            Next = null;
        }
    }

    public class Lista<T> : IEnumerable<T>
    {
        private Node<T>? head;
        private int numeroElementos;

        public int NumeroElementos
        {
            get { return numeroElementos; }
        }

        public Lista()
        {
            numeroElementos = 0;
            head = null;
        }

        public void Anadir(T n)
        {
            Node<T> node = new Node<T>(n);
            if (head == null)
            {
                head = node;
            }
            else
            {
                Node<T> currentNode = head;
                while (currentNode.Next != null)
                {
                    currentNode = currentNode.Next;
                }
                currentNode.Next = node;
            }
            numeroElementos++;
        }
        public bool Borrar(T n)
        {
            if (head == null)
            {
                return false;
            }

            if (head.Value.Equals(n))
            {
                head = head.Next;
                numeroElementos--;
                return true;
            }

            Node<T> currentNode = head;
            while (currentNode.Next != null && !currentNode.Next.Value.Equals(n))
            {
                currentNode = currentNode.Next;
            }

            if (currentNode.Next != null)
            {
                currentNode.Next = currentNode.Next.Next;
                numeroElementos--;
                return true;
            }

            return false;
        }

        public bool BorrarIndice(int index)
        {
            if (index < 0 || index >= numeroElementos)
            {
                return false;
            }

            if (index == 0)
            {
                head = head.Next;
            }
            else
            {
                Node<T> currentNode = head;
                for (int i = 0; i < index - 1; i++)
                {
                    currentNode = currentNode.Next;
                }
                currentNode.Next = currentNode.Next.Next;
            }

            numeroElementos--;
            return true;
        }

        public T GetElemento(int index)
        {
            if (index < 0 || index >= numeroElementos)
            {
                throw new IndexOutOfRangeException();
            }

            Node<T> currentNode = head;
            for (int i = 0; i < index; i++)
            {
                currentNode = currentNode.Next;
            }
            return currentNode.Value;
        }

        public bool Contiene(T o)
        {
            foreach (var item in this)
            {
                if (item.Equals(o))
                {
                    return true;
                }
            }
            return false;
        }
        public Lista<Q> Buscar<Q>(Func<T, Q> p)
        {
            Lista<Q> other = new Lista<Q>();
            foreach (var x in this)
            {
                other.Anadir(p(x));
            }
            return other;
        }
        public Lista<T> Filtrar(Predicate<T> p)
        {
            Lista<T> other = new Lista<T>();
            foreach (var x in this)
            {
                if (p(x))
                {
                    other.Anadir(x);
                }
            }
            return other;
        }
        public E Reducir<E>(Func<E, T, E> func, E acumulator = default(E))
        {
            foreach (var x in this)
            {
                acumulator = func(acumulator, x);
            }
            return acumulator;
        }
        public Lista<T> Invertir()
        {
            Lista<T> other = new Lista<T>();
            for (int i = NumeroElementos - 1; i > -1; i--)
            {
                other.Anadir(this.GetElemento(i));
            }
            return other;
        }
        public void ForEach(Action<T> a)
        {
            foreach (var x in this)
            {
                a(x);
            }
        }
        public Lista<Q> Map<Q>(Func<T, Q> func)
        {
            Lista<Q> other = new Lista<Q>();
            foreach (var x in this)
            {
                other.Anadir(func(x));
            }
            return other;

        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            foreach (var item in this)
            {
                sb.Append(item.ToString() + " - ");
            }
            if (sb.Length > 0)
                sb.Length -= 3; // Quita el último " - "
            return sb.ToString();
        }

        public string ToStringStack()
        {
            StringBuilder sb = new StringBuilder();
            foreach (var item in this)
            {
                sb.Append(item.ToString() + "\n----\n");
            }
            if (sb.Length > 5)
                sb.Length -= 5; // Quita el último "----\n"
            return sb.ToString();
        }

        public IEnumerator<T> GetEnumerator()
        {
            return new ListaEnumerator<T>(head);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }

    public class ListaEnumerator<T> : IEnumerator<T>
    {
        private Node<T> current;
        private Node<T> head; // Necesario para Reset()

        public ListaEnumerator(Node<T> head)
        {
            this.head = head;
            current = null; // Se inicializa antes del primer elemento
        }

        public bool MoveNext()
        {
            if (current == null)
            {
                current = head; // Comenzar desde el primer nodo
            }
            else
            {
                current = current.Next; // Mover al siguiente nodo
            }
            return current != null;
        }

        public void Reset()
        {
            current = null; // Volver al estado inicial
        }

        public T Current
        {
            get
            {
                if (current == null)
                {
                    throw new InvalidOperationException("El enumerador no está en una posición válida.");
                }
                return current.Value;
            }
        }

        object IEnumerator.Current => Current;

        public void Dispose() { /* No se necesita limpieza especial aquí */ }
    }
}
