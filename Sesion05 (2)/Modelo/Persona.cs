

namespace Modelo
{
    public class Persona
    {
        public string Nombre { get; }

        public string Apellido { get; }

        public string Nif { get;  }

        public int Edad { get; }


        public Persona(string nombre, string apellido, string nif, int edad)
        {
            Nombre = nombre;
            Apellido = apellido;
            Nif = nif;
            Edad = edad;
        }



        public override string ToString()
        {
            return String.Format("{0} {1} con NIF {2} tiene {3} años.", Nombre, Apellido, Nif, Edad);
        }

    }
}
