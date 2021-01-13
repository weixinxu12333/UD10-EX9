using System;
using System.Linq;
using System.Text;

namespace UD10_EX9
{
    public class Sala
    {
        private readonly bool[,] Asientos;
        private readonly Cine Cine;
        private readonly Pelicula Pelicula;

        public Sala(int filas, int columnas, Cine cine, Pelicula pelicula)
        {
            Asientos = new bool[filas, columnas];
            Cine = cine;
            Pelicula = pelicula;
            Cine.AñadirSala(this);
        }

        public string SentarOrden(Espectador espectador)
        {
            if (espectador.Edad < Pelicula.EdatMinima || espectador.DineroBolsillo < Cine.PrecioEntrada || !Asientos.Cast<bool>().Any(x => !x))
                return null;
            int i = 0, j = 0;
            for (i = Asientos.GetLength(0); i > 0; i--)
            {
                for (j = 0; j < Asientos.GetLength(1); j++)
                {
                    if(!Asientos[i - 1, j])
                    {
                        Asientos[i - 1, j] = true;
                        return $"{i}{ObtenerLetra(j)}";
                    }
                }
            }
            return null;
        }

        public string SentarAleatorio(Espectador espectador)
        {
            Random rd = new Random();
            if (espectador.Edad < Pelicula.EdatMinima || espectador.DineroBolsillo < Cine.PrecioEntrada || !Asientos.Cast<bool>().Any(x => !x))
                return null;

            var ocupado = true;
            int fila = 0, columna = 0;
            do
            {
                fila = rd.Next(0, Asientos.GetLength(0));
                columna = rd.Next(0, Asientos.GetLength(1));
                ocupado = Asientos[fila, columna];
                if (!ocupado)
                {
                    Asientos[fila, columna] = true;
                }
            } while (ocupado);

            return $"{fila + 1}{ObtenerLetra(columna)}";
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("  ");
            for (int i = 0; i < Asientos.GetLength(1); i++)
            {
                sb.Append(ObtenerLetra(i));
                sb.Append(' ');
            }
            sb.AppendLine();
            for (int i = 8; i > 0; i--)
            {
                sb.Append(i);
                sb.Append(' ');
                for (int j = 0; j < 9; j++)
                {
                    sb.Append(Asientos[i-1, j] ? 'X' : ' ');
                    sb.Append(' ');
                }
                sb.AppendLine();
            }
            return sb.ToString();
        }

        private static char ObtenerLetra(int columna)
        {
            // En la tabla ASCII, A corresponde a 65.
            return Convert.ToChar(65 + columna);
        }
    }
}
