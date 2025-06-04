using System.Text;

namespace Modelo
{
    public class Node<T>
    {
        public object Value { get; set; }
        public Node<T> Next { get; set; }

        public Node(T value)
        {
            Value = value;
            Next = null;
        }
    }

    public class Lista<T>
    {
        private Node<T> head;
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

        public bool Borrar(object n)
        {
            if (head == null || numeroElementos == 0)
            {
                return false;
            }

            if (head.Value.Equals(n) && head.Value!=null)
            {
                head = head.Next;
                numeroElementos--;
                return true;
            }

            Node<T> currentNode = head;
            while (currentNode.Next != null && !currentNode.Next.Value.Equals(n) && currentNode.Next.Value!=null)
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
            return (T)currentNode.Value;
        }
        public bool Contiene(Object o)
        {
            for (int i = 0; i < numeroElementos; i++)
            {
                if (GetElemento(i).Equals(o) && GetElemento(i) != null)
                {
                    return true;
                }
            }
            return false;
        }
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < numeroElementos; i++)
            {
                sb.Append(GetElemento(i).ToString());
                if (i != numeroElementos - 1)
                {
                    sb.Append(" - ");
                }
            }
            return sb.ToString();
        }
        public  string ToStringStack()
        {
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < numeroElementos; i++)
            {
                sb.Append(GetElemento(i).ToString()+"\n");
                if (i != numeroElementos - 1)
                {
                    sb.Append("----\n");
                }
            }
            return sb.ToString();
        }
    }
}
