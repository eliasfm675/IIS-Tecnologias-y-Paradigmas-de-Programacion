namespace Modelo
{
    public class Node
    {
        public int Value { get; set; }
        public Node Next { get; set; }

        public Node(int value)
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

        public void Anadir(int n)
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

        public bool Borrar(int n)
        {
            if (head == null || numeroElementos == 0)
            {
                return false;
            }

            if (head.Value == n)
            {
                head = head.Next;
                numeroElementos--;
                return true;
            }

            Node currentNode = head;
            while (currentNode.Next != null && currentNode.Next.Value != n)
            {
                currentNode = currentNode.Next;
            }

            if (currentNode.Next != null && currentNode.Next.Value == n)
            {
                currentNode.Next = currentNode.Next.Next;
                numeroElementos--;
                return true;
            }

            return false;
        }

        public int GetElemento(int index)
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
    }
}
