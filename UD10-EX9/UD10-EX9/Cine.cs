using System;
using System.Collections.Generic;
using System.Linq;

namespace UD10_EX9
{
    public class Cine
    {
        public IEnumerable<Sala> Salas { get; private set; } = new List<Sala>();
        public Pelicula Pelicula { get; set; }
        public double PrecioEntrada { get; set; }

        public Cine(Pelicula pelicula)
        {
            Pelicula = pelicula;
            PrecioEntrada = generarPrecioEntrada();
        }

        public void AñadirSala(Sala sala)
        {
            var salas = Salas.ToList();
            salas.Add(sala);
            Salas = salas;
        }

        public int generarPrecioEntrada()
        {
            Random rd = new Random();
            return rd.Next(0, 10);
        }
    }
}
