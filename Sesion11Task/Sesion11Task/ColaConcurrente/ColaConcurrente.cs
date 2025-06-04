using Modelo;

namespace Modelo
{
    public class ColaConcurrente<T>
    {
        private int _numElements = 0;
        private Lista<T> _elements;
        public int NumeroElementos { get { return _numElements; } }
        public bool EstaVacia { get { return _numElements == 0; } }
        public readonly object _lock = new object();
        public ColaConcurrente()
        {
            _elements = new Lista<T>();
        }
        public void Anadir(T n)
        {
            lock(_lock){
                _elements.Anadir(n);
                _numElements++;
            }
       
        }
        public bool Extraer(out T item)
        {
            lock (_lock)
            {
                if (EstaVacia)
                {
                    item = default(T);
                    return false;
                }
                item = _elements.GetElemento(0);
                _elements.BorrarIndice(0);
                _numElements--;
                return true;
            }
         
        }
        public T PrimerElemento
        {
            get
            {
                lock (_lock)
                {
                    if (EstaVacia)
                    {
                        throw new InvalidOperationException("The queue is empty");
                    }
                    return _elements.GetElemento(0);
                }
            }
        }
    }
}
