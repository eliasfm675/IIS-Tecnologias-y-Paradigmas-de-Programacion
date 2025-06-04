

namespace Modelo
{
    public class Contador
    {
        private int _numero;

        public int Valor
        {
            get { return _numero; }
        }

        public Contador()
        {
            _numero = 0;
        }

        public void Incrementar()
        {
            _numero++;
        }
    }
}
