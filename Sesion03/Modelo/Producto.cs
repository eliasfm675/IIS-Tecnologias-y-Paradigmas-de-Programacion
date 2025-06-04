using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelo
{
    public abstract class Producto: IFacturable
    {
        string _nombre;
        string _descripcion;
        int _stock;
        bool _disponibilidad;
        public string Nombre { get { return _nombre; } }
        public string Descripcion { get { return _descripcion; } }
        public int Stock { get { return _stock; } }
        public bool Disponibilidad { get { return _disponibilidad; } }
        public Producto(string _nombre = "Air Force", string _descripcion = "Unas Air Force", int _stock = 100, bool _disponibilidad = true)
        {
            this._nombre = _nombre;
            this._descripcion = _descripcion;
            this._stock = _stock;
            this._disponibilidad = _disponibilidad;
        }
        public void Reponer(int n)
        {
            //Invariante
            if (n<=0)
            {
                throw new ArgumentException("Cannot restore negative or zero items");
            }

            if (!Disponibilidad){
                _disponibilidad = true;
            }
            int originalStock = Stock;
            _stock += n;
            Debug.Assert(Stock==originalStock+n, "Postcondition assertion failed");
            //invariante
        }
        public void Comprar(int n)
        {
            //Invariante
            if (n<=0)
            {
                throw new ArgumentException("Cannot buy negative or zero items");
            }
            if (!Disponibilidad || Stock == 0)
            {
                throw new InvalidOperationException("There's no stock to buy from");
            }
            int originalStock = Stock;
            _stock -= n;
            if (Stock <= 0)
            {
                _disponibilidad = false;
                _stock = 0;
            }
            Debug.Assert(Stock==originalStock-n || Stock==0, "Postcondition has failed");
            //Invariante
        }
        public override string ToString()
        {
            return $"{Nombre} - {Descripcion} - {Stock} - {Disponibilidad}";
        }

        public abstract double GetBase(double d);
     

        public abstract double GetTipoIva(double d)



        public abstract double GetIva();

        public abstract double GetPrecio(double d);
     

        public abstract string GetConcepto(string s);


        public abstract string ToTicket();

    }
}
