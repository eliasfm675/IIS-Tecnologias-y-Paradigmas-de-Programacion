﻿namespace _04Deadlock
{
    class Cuenta
    {
        private decimal balance;
        private string numCuenta;

        public Cuenta(string numCuenta, decimal balance = 0)
        {
            this.balance = balance;
            this.numCuenta = numCuenta;
        }

        public string NumCuenta { get { return this.numCuenta; } }

        /// <summary>
        /// Extraer dinero de la cuenta
        /// <param name="amount">Cantidad de dinero a extraer</param>
        /// <returns>Si se ha extraído la cantidad de dinero o no.</returns>
        /// </summary>
        public bool Extraer(decimal cantidad)
        {
            if (this.balance < cantidad)
                return false;
            this.balance -= cantidad;
            return true;
        }

        /// <summary>
        /// Ingresa dinero en la cuenta
        /// <param name="cantidad">Cantidad de dinero a ingresar</param>
        /// </summary>
        public void Ingresar(decimal cantidad)
        {
            this.balance += cantidad;
        }


        /// <summary>
        /// Transfiere dinero de la cuenta actual (this) a la cuenta pasada como parámetro.
        /// <param name="destino">Cuenta a la que se va a realizar la transferencia</param>
        /// <param name="cantidad">Cantidad de dinero a transferir</param>
        /// <returns>Si la transferencia se ha realizado con éxito o no.</returns>
        /// </summary>
        public bool Transferir(Cuenta destino, decimal cantidad)
        {
            if (this.numCuenta.CompareTo(destino.NumCuenta) > 0)
            {
                lock (numCuenta)//bloqueo A, antes estaba puesto this, numCuenta es la solucion de le jercicio
                {
                    lock (destino)//bloqueo B
                    {
                        Thread.Sleep(100); // Simulamos procesamiento.
                        if (this.Extraer(cantidad))
                        {
                            destino.Ingresar(cantidad);
                            return true;
                        }
                        else
                            return false;
                    }
                }
            }
            else
            {
                lock (destino)//bloqueo A, antes estaba puesto this, numCuenta es la solucion de le jercicio
                {
                    lock (numCuenta)//bloqueo B
                    {
                        Thread.Sleep(100); // Simulamos procesamiento.
                        if (this.Extraer(cantidad))
                        {
                            destino.Ingresar(cantidad);
                            return true;
                        }
                        else
                            return false;
                    }
                }
            }
          
        }
    }
}
