namespace Modelo
{
    /// <summary>
    /// Clase abstracta. 
    /// ¿Para qué se utilizan?
    /// </summary>
    public abstract class Animal
    {
        public string Nombre { get; set; }
        public Animal(string nombre)
        {
            this.Nombre = nombre;
        }

        //¿Podemos crear métodos abstractos? ¿Y propiedades?
        //¿Qué implicaciones tiene en las clases derivadas?

        /// <summary>
        /// Habilitamos Enlace Dinámico, utilizamos virtual.
        /// </summary>
        public virtual void Saludar() //el virtual es para habilitar el enlace dinámico, en java se hace automáticamente
        {
            Console.WriteLine($"[ANIMAL] Mi nombre es {Nombre}.");
        }

        /// <summary>
        /// Método Mover.
        /// </summary>
        public virtual void Mover()
        {
            Console.WriteLine($"[ANIMAL] {Nombre} se mueve.");
        }



    }
}