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
     
        public Persona(string nombre = "Marvin", string apellido = "Caldueño", string nif = "123456789")
        {
            Nombre = nombre;
            Apellido = apellido;
            Nif = nif;
        }

    }
}
