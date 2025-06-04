using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelo
{
    public  class Bono: Producto
    {
        int _minutos;
        public int Minutos { get { return _minutos; } }

        public Bono(int _minutos) : base()
        {
            this._minutos = _minutos;
        }
        public override string ToString()
        {
            return base.ToString() + $" - {Minutos}";
        }

    }
}
