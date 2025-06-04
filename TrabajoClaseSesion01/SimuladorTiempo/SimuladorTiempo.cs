using System.Security.Cryptography;

namespace Modelo
{
    public enum Estaciones { Invierno = 0, Primavera = 1, Otoño = 2, Verano = 3 };
    public class SimuladorTiempo
    {
        DateTime _fecha;
        Estaciones _estacion;
        Random r = new Random();
        public DateTime Fecha
        {
            get
            {
                return _fecha;
            }
            
        }
        public Estaciones Estacion
        {
            get
            {
                return _estacion;
            }
            set
            {
                CalcularEstacion();
            }
        }
        public SimuladorTiempo()
        {
            _fecha = System.DateTime.Now;
            CalcularEstacion();
        }

        public void AvanzarDias()
        {
            int daysPassed = r.Next(2, 13);      
            _fecha = _fecha.AddDays(daysPassed);
            CalcularEstacion();

        }
        public void AvanzarMeses()
        {        
            int monthsPassed = r.Next(1, 5);
            _fecha = _fecha.AddMonths(monthsPassed);
            CalcularEstacion();

        }
        private void CalcularEstacion()
        {
            if(_fecha.Month>=2 && _fecha.Month <= 4)
            {
                _estacion = Estaciones.Primavera;
            }else if(_fecha.Month>=5 && _fecha.Month <= 7)
            {
                _estacion = Estaciones.Verano;
            }else if(_fecha.Month>=8 && _fecha.Month <= 10)
            {
                _estacion = Estaciones.Otoño;
            }
            else
            {
                _estacion = Estaciones.Invierno;
            }
        }
        public override String ToString()
        {
            return $"{_fecha.ToString()} {_estacion.ToString()}";
        }
    }
}
