namespace Modelo
{
    /// <summary>
    /// Ejemplo de clase genérica.
    /// Fíjate dónde se definen los marcadores de tipo.
    /// </summary>
    /// <typeparam name="TClave">Marcador de tipo</typeparam>
    /// <typeparam name="TValor">Otro marcador de tipo</typeparam>
    public class Contenedor<TClave, TValor>
    {

        private TValor _value;
        public TValor Value { get { return _value; } }

        private TClave _key;
        public TClave Key { get { return _key; } }


        public Contenedor(TClave key, TValor value)
        {
            _key = key;
            _value = value;
        }


        /*
        ¡NOTA!
            Fíjate que al estar definidos en la clase tanto TClave como TValor,
            no definimos el método como Sustituir<Clave,Valor>.
            Si hubiera un tercer parámetro genérico (K):

            Sustituir<K>(Clave newKey, Valor newValue, K otro){ ... }
        */
        public void Sustituir(TClave newKey, TValor newValue)
        {
            _key = newKey;
            _value = newValue;
            //Imaginemos que queremos hacer el cambio en función
            //del método CompareTo de la interfaz IComparable<T>

            //Tal y como está en esta clase la genericidad no podemos
            //Los marcadores de tipo (T,U,Clave,Valor...) solamente
            //nos proporcionan acceso a los métodos de Object.
            //Este problema lo resolvemos mediante genericidad acotada

            /* NO COMPILA porque _value igual no implementa compareTo en su tipo

           if (_value.CompareTo(newValue) == -1)
           {
               _value = newValue;
               _key = newKey;
               return true;
           }
           return false;
           */
        }

        public override string ToString()
        {
            return String.Format("Clave: [{0}] Valor: [{1}]", _key, _value);
        }

    }
}
