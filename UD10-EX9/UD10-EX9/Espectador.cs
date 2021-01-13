using System;

namespace UD10_EX9
{
     public class Espectador
    {
        public string Nombre { get; set; }
        public int Edad { get; set; }
        public double DineroBolsillo { get; set; }

        public Espectador()
        {
        }

        public Espectador(string nombre, int edad, double dineroBolsillo)
        {
            Nombre = nombre;
            Edad = edad;
            DineroBolsillo = dineroBolsillo;
        }

        public static Espectador GenerarEspectador()
        {
            Random rd = new Random();

            string[] nombres = {"Hannah", "Gariela", "Esther", "Daniela", "Iris", "Raul", "Leo", "Hector", "Zeus", "Alvaro"};
            string nombre = nombres[rd.Next(nombres.Length)];
            int edad = rd.Next(0,100);
            double dineroBolsillo = rd.Next(0, 20);

            Espectador espectador = new Espectador(nombre, edad, dineroBolsillo);
            Console.WriteLine("Nombre {0}, edad {1}, dinero en el bolsillo {2}", espectador.Nombre, espectador.Edad, espectador.DineroBolsillo);

            return espectador;
        }

    }
}
