namespace Modelo
{
    public class Persona
    {
        public string Nombre { get; }

        public string Apellido { get; }

        public string Nif { get; }

        public override string ToString()
        {
            return $"{Nombre} {Apellido} con NIF: {Nif}";
        }

        public Persona(string nombre, string apellido, string nif)
        {
            Nombre = nombre;
            Apellido = apellido;
            Nif = nif;
        }

    }
}
