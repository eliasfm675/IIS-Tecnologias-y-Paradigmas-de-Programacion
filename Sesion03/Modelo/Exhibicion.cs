using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelo
{
    public class Exhibicion: Evento
    {
        int _numAtletas;
        public int NumAtletas { get { return _numAtletas; }}
        public Exhibicion(int _numAtletas): base()
        {
            if(_numAtletas < 0)
            {
                throw new ArgumentException("Athlete number cannot be lower than 0");
            }
            this._numAtletas = _numAtletas;
        }
        public override string ToString()
        {
            return base.ToString() + $" - {NumAtletas}";
        }
    }
}
