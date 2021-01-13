using System;

namespace UD10_EX9
{
    public class Pelicula 
    {
        public string Titulo { get; set; }
        public string Duracion { get; set; }
        public int EdatMinima { get; set; }
        public string Director { get; set; }

        public Pelicula()
        {
        }

        public Pelicula(string titulo, string duracion, int edatMinima, string director)
        {
            Titulo = titulo;
            Duracion = duracion;
            EdatMinima = edatMinima;
            Director = director;
        }

        public static Pelicula GenerarPelicula()
        {
            Random rd = new Random();

            string[] peliculas = { "Pelicula 1", "Pelicula 2", "Pelicula 3", "Pelicula 4", "Pelicula 5", "Pelicula 6", "Pelicula 7", "Pelicula 8", "Pelicula 9", "Pelicula 10" };
            string peli = peliculas[rd.Next(peliculas.Length)];

            string[] duraciones = { "1h", "2h", "3h", "4h" };
            string duracion = duraciones[rd.Next(duraciones.Length)];

            int[] edades = {7, 12, 16, 18};
            int edad = edades[rd.Next(edades.Length)];

            string[] directores = {"Director 1", "Director 2", "Director 3", "Director 4", "Director 5", "Director 6", "Director 7", "Director 8", "Director 9", "Director 10" };
            string director = directores[rd.Next(directores.Length)] ;

            Pelicula pelicula = new Pelicula(peli, duracion, edad, director);
            Console.WriteLine("Titulo {0}, duracion {1}, edad minima {2}, director {3}", pelicula.Titulo, pelicula.Duracion,pelicula.EdatMinima, pelicula.Director);

            return pelicula;
        }
    }
}
