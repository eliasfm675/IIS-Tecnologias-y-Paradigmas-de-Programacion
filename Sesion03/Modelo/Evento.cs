using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelo
{
    public  class Evento
    {
        string _nombre;
        string _descripcion;
        DateTime _fechaInicio;
        DateTime _fechaFin;
        public string Nombre { get { return _nombre; } }
        public string Descripcion { get { return _descripcion; } }
        public DateTime FechaInicio { get { return _fechaInicio; } }
        public DateTime FechaFin { get { return _fechaFin;  } }
        public Evento(string _nombre = "Evento", string _descripcion ="Des")
        {
            this._nombre = _nombre;
            this._descripcion = _descripcion;
            _fechaInicio = DateTime.Now;
            _fechaFin = _fechaInicio.AddDays(60);
        }
        public override string ToString()
        {
            return $"{Nombre} - {Descripcion} - Inicio: {FechaInicio} - Fin: {FechaFin}"
        }

    }
}
