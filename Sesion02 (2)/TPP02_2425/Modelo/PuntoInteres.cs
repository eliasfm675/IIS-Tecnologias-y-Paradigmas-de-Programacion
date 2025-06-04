using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelo
{
    public class PuntoInteres
    {
        public double Latitud { get; }
        public double Longitud { get; }
        public string Nombre { get; }

        public PuntoInteres(string nombre, double latitud, double longitud)
        {
            Latitud = latitud;
            Longitud = longitud;
            Nombre = nombre;
        }

        public override string ToString()
        {
            return $"{Nombre} está en {Latitud}, {Longitud}";
        }
    }
}
