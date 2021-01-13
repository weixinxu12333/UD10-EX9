using System;

namespace Ejercicio9
{
    class Espectador
    {
        // ATRIBUTOS
        private string nombre;
        private int edad;
        private double dinero;
        // CONSTRUCTORES 
        public Espectador(string nombre, int edad, double dinero)
        {
            this.nombre = nombre;
            this.edad = edad;
            this.dinero = dinero;
        }
        // METODOS
        public string Nombre { set { this.nombre = value; } get { return nombre; } }
        public int Edad { set { this.edad = value; } get { return edad; } }
        public double Dinero { set { this.dinero = value; } get { return dinero; } }

        public void pagar(double precio)
        { dinero -= precio; }
        public bool edadMinima(int edadMin)
        { return edad >= edadMin; }
        public bool tieneDinero(double precioEntrada)
        { return dinero >= precioEntrada; }

        public string toString()
        { return "El espectador se llama: " + nombre + ", tiene " + edad + " años y lleva " + dinero + " encima."; }

    }
    class Asiento
    {
        // ATRIBUTOS
        private char letra;
        private int fila;
        private Espectador espectador;

        // CONSTRUCTORES
        public Asiento(char letra, int fila)
        {
            this.letra = letra;
            this.fila = fila;
            this.espectador = null;
        }

        // METODOS
        public char Letra { set { this.letra = value; } get { return letra; } }
        public int Fila { set { this.fila = value; } get { return fila; } }
        public Espectador Espectador { set { this.espectador = value; } get { return espectador; } }

        public bool ocupado() { return espectador != null; }
        public string toString()
        {
            if (ocupado()) { return "Asiento: " + fila + letra + " esta ocupado."; }
            return "Asiento: " + fila + letra + " esta vacio.";
        }
    }
    class Pelicula
    {
        // ATRIBUTOS
        private string titulo;
        private int duracion;
        private int edadMin;
        private string director;

        // CONSTRUCTOR
        public Pelicula(string titulo, int duracion, int edadMin, string director)
        {
            this.titulo = titulo;
            this.duracion = duracion;
            this.edadMin = edadMin;
            this.director = director;
        }

        // METODOS
        public string Titulo { set { this.titulo = value; } get { return titulo; } }
        public int Duracion { set { this.duracion = value; } get { return duracion; } }
        public int Edadmin { set { this.edadMin = value; } get { return edadMin; } }
        public string Director { set { this.director = value; } get { return director; } }

        public string toString() { return "La pelicula " + titulo + " del director " + director + " tiene una duracion de " + duracion + " y la edad minima para poder verla es " + edadMin; }
    }
    class Cine
    {
        // ATRIBUTOS
        private Asiento[,] asientos;
        private double precio;
        private Pelicula pelicula;

        //CONSTRUCTOR
        public Cine(int filas, int columnas, double precio, Pelicula pelicula)
        {
            asientos = new Asiento[filas, columnas];
            this.precio = precio;
            this.pelicula = pelicula;
            rellenaAsientos();
        }

        // METODOS
        public Asiento[,] Asientos { set { this.asientos = value; } get { return asientos; } }
        public double Precio { set { this.precio = value; } get { return precio; } }
        public Pelicula Pelicula { set { this.pelicula = value; } get { return pelicula; } }

        private void rellenaAsientos()
        {
            int fila = 0;
            for (int i = 0; i < asientos.Length; i++)
            {
                for (int x = 0; x < asientos.Length; x++)
                { asientos[i,x] = new Asiento((char)('A' + x), fila); }
                fila--;
            }
        }
        public bool haySitio()
        {
            for (int i = 0; i < asientos.Length; i++)
            {
                for (int x = 0; i < asientos.Length; x++)
                {
                    if (!asientos[i, x].ocupado())
                        return true;
                }
            }
            return false;
        }
        public bool siOcupado(int fila, char letra)
        { return Asiento(fila, letra).ocupado(); }
        public bool sePuedeSentar(Espectador e)
        { return e.tieneDinero(Precio) && e.edadMinima(pelicula.Edadmin); }
        public void sentar(int fila, char letra, Espectador e)
        { Asiento(fila, letra).Espectador = e; }
        public Asiento Asiento(int fila, char letra)
        { return asientos[asientos.Length - fila - 1, letra - 'A']; }
        public int Filas { get { return asientos.Length; } }
        public int Columnas { get { return asientos.Length; } }

        public void mostrarTodo()
        {
            Console.WriteLine("Pelicula: " + pelicula);
            Console.WriteLine("Precio de la entrada: " + precio);
            Console.WriteLine("");
            for (int i = 0; i < asientos.Length; i++)
            {
                for (int x = 0; x < asientos.Length; x++)
                { Console.WriteLine(asientos[i, x]); }
            }
        }
    }
    class Metodos
    {
        public static string[] nombres = { "Viksen", "Alberto", "Maria", "Laura", "Marta", "Jesus", "Fran", "Alba","Cristian","Ylenia" };
        public static int numAleatorio(int minimo, int maximo)
        { Random aleatorio = new Random();
            int num = (int)(aleatorio.NextDouble() * (minimo - (maximo + 1)) + (maximo + 1));
            return num;
        }
    }
        class Program
        {
            static void Main(string[] args)
            {
            Pelicula peli = new Pelicula("A todo gas", 100, 18, "Alguno");
            Cine cine = new Cine(8, 9, 10.50, peli);

            Console.WriteLine("Cuantos espectadores vab a ver la pelicula?");
            int numEspecta = Convert.ToInt32(Console.ReadLine());


            Espectador e;
            int fila;
            char letra;

            Console.WriteLine("Espectadores generados:");
                for (int i=0; i<numEspecta && cine.haySitio();i++)
                {
                e = new Espectador
                    (
                    Metodos.nombres[Metodos.numAleatorio(0, Metodos.nombres.Length - 1)],
                    Metodos.numAleatorio(12, 50),
                    Metodos.numAleatorio(5, 50)
                    );
                Console.WriteLine(e);
                do
                    {
                    fila = Metodos.numAleatorio(0, cine.Filas - 1);
                    letra = (char)Metodos.numAleatorio('A', 'A' + (cine.Columnas - 1));
                    } while (cine.haySitio());

                if (cine.sePuedeSentar(e))
                    { e.pagar(cine.Precio);
                    cine.sentar(fila, letra, e);
                    }
                }
            Console.WriteLine("");
            cine.mostrarTodo();
            Console.ReadKey();
            }
        }

    
}
