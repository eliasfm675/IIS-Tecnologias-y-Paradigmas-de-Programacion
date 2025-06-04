using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Authentication.ExtendedProtection;
using System.Text;
using System.Threading.Tasks;

namespace Modelo
{
    public class Libro
    {
        public string Titulo { get; }
        public string Autor { get; }
        public int NumeroDePaginas { get; }
        public int AnoPublicacion { get; }
        public string Genero { get; }
        public Libro(string titulo, string autor, int numeropaginas, int anopublicacion, string genero)
        {
            Titulo = titulo;
            Autor = autor;
            NumeroDePaginas = numeropaginas;
            AnoPublicacion = anopublicacion;
            Genero = genero;


        }
        public override string ToString()
        {
            return $"{Titulo} - {Autor} - {NumeroDePaginas} - {AnoPublicacion} - {Genero}";
        }
        public override bool Equals(object? obj)
        {
            Libro l = obj as Libro;
            if(obj == null)
            {
                return false;
            }
            return l.Autor.Equals(Autor) ;
        }

    }
}
