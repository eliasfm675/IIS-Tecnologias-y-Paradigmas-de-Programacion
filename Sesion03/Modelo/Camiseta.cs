using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelo
{
    public class Camiseta : Producto
    {
        string _talla;
        string _color;
        public string Talla{ get { return _talla; } }
        public string Color { get { return _color; } }
        public Camiseta(string _talla, string _color): base()
        {
            this._talla = _talla;
            this._color = _color;
        }
        public override string ToString()
        {
            return base.ToString() + $" - {Talla} - {Color}";
        }

        public override double GetBase(double d)
        {
            return d;
        }

        public override double GetTipoIva(double d)
        {
            return d;
        }

        public override double GetIva()
        {
            throw new NotImplementedException();
        }

        public override double GetPrecio(double d)
        {
            throw new NotImplementedException();
        }

        public override string GetConcepto(string s)
        {
            throw new NotImplementedException();
        }

        public override string ToTicket()
        {
            throw new NotImplementedException();
        }
    }
}
