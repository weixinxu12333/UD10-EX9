using System;

namespace UD10_EX9
{
    public class Program
    {
        static void Main(string[] args)
        {
            Pelicula peli = Pelicula.GenerarPelicula();
            Cine cine = new Cine(peli);
            Console.WriteLine(cine.PrecioEntrada);

            Sala sala = new Sala(8, 9, cine, peli);
            Console.WriteLine(sala);

            for (int i = 0; i < 50; i++)
            {
                Espectador espectador = Espectador.GenerarEspectador();
                var asiento = sala.SentarAleatorio(espectador);
                if(asiento == null)
                {
                    Console.WriteLine("El espectador no ha podido acceder al cine");
                }
                else
                {
                    Console.WriteLine($"Se ha sentado el espectador en el asiento {asiento}");
                }
                Console.WriteLine(sala);
            }


        }
    }
}
