using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelo
{
    public interface IFacturable
    {
        double GetBase(double d);
        double GetTipoIva(double d);
        double GetIva();
        double GetPrecio(double d);
        string GetConcepto(string s);
        string ToTicket();
    }
}
