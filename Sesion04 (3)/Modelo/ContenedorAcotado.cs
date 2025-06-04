

namespace Modelo
{
    /*
        La genericidad acotada nos permite establecer condicionantes para el uso de la genericidad:
        Siempre y cuando el tipo Valor implemente IComparable de ese tipo (el que sustituya a Valor).          
        Más info en:
        https://docs.microsoft.com/es-es/dotnet/csharp/programming-guide/generics/constraints-on-type-parameters

        NOTA: EN EL SIGUIENTE EJEMPLO SE ACOTA UNA CLASE. 
            SIN EMBARGO, TAMBIÉN ES POSIBLE ACOTAR MÉTODOS.
       */
    public class ContenedorAcotado<Clave, Valor> where Valor : IComparable<Valor>
    {
        private Valor _value;
        public Valor Value { get { return _value; } }

        private Clave _key;
        public Clave Key { get { return _key; } }


        public ContenedorAcotado(Clave key, Valor value)
        {
            _key = key;
            _value = value;
        }


        public bool Sustituir(Clave newKey, Valor newValue)
        {
            //Podemos hacer uso del CompareTo<Valor> gracias
            //al uso de la genericidad acotada.
            if (Value.CompareTo(newValue) < 0)
            {
                _value = newValue;
                _key = newKey;
                return true;
            }
            return false;
        }


        public override string ToString()
        {
            return String.Format("Clave: [{0}] Valor: [{1}]", _key, _value);
        }
    }
}
