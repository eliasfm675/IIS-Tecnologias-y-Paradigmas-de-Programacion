using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelo
{
    public class Estancia: Evento
    {
        int _numeroParticipantes;
        bool _incluyeComida;
        public int NumeroParticipantes { get { return _numeroParticipantes; } }
        public bool IncluyeComida { get { return _incluyeComida} }

        public Estancia(int _numeroParticipantes, bool _incluyeComida): base()
        {
            if (_numeroParticipantes <0)
            {
                throw new ArgumentException("Participants cannot be less than 0");
            }
            this._numeroParticipantes = _numeroParticipantes;
            this._incluyeComida = _incluyeComida;
        }
        public override string ToString()
        {
            return base.ToString() + $" - {NumeroParticipantes} - {IncluyeComida}";
        }
    }
}
