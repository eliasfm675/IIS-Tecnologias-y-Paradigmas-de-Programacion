﻿namespace Modelo
{
    public class Persona
    {
        public string Nombre { get; }

        public string Apellido { get; }

        public string Nif { get; }

        public override string ToString()
        {
            return String.Format("{0} {1} con NIF {2}", Nombre, Apellido, Nif);
        }

        public Persona(string nombre, string apellido, string nif)
        {
            this.Nombre = nombre;
            this.Apellido = apellido;
            this.Nif = nif;
        }

    }
}

