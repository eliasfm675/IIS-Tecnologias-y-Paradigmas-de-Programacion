using System.Text;

namespace Modelo
{
    public class Node
    {
        public object Value { get; set; }
        public Node Next { get; set; }

        public Node(object value)
        {
            Value = value;
            Next = null;
        }
    }

    public class List
    {
        private Node head;
        private int numeroElementos;

        public int NumeroElementos
        {
            get { return numeroElementos; }
        }

        public List()
        {
            numeroElementos = 0;
            head = null;
        }

        public void Anadir(object n)
        {
            Node node = new Node(n);
            if (head == null)
            {
                head = node;
            }
            else
            {
                Node currentNode = head;
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

            Node currentNode = head;
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
                Node currentNode = head;
                for (int i = 0; i < index - 1; i++)
                {
                    currentNode = currentNode.Next;
                }
                currentNode.Next = currentNode.Next.Next;
            }

            numeroElementos--;
            return true;
        }


        public object GetElemento(int index)
        {
            if (index < 0 || index >= numeroElementos)
            {
                throw new IndexOutOfRangeException();
            }

            Node currentNode = head;
            for (int i = 0; i < index; i++)
            {
                currentNode = currentNode.Next;
            }
            return currentNode.Value;
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
