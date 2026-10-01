using System;

namespace Curso_de_POO___GOB_CIUDAD.Funciones
{
    /// <summary>
    /// Representa a un jugador con nombre, puntos y nivel.
    /// Incluye sobrecarga de constructores, métodos, operadores y conversiones.
    /// </summary>
    public class PuntosJugador
    {
        // Atributos encapsulados
        private string nombreJugador;
        private int puntos;
        private int nivel;

        // ------------------------------------------------------------------
        // CONSTRUCTORES EN CASCADA
        // ------------------------------------------------------------------

        /// <summary>
        /// Constructor sin parámetros. Usa valores predeterminados.
        /// </summary>
        public PuntosJugador() : this("JugadorAnonimo", 0, 1)
        {
        }

        /// <summary>
        /// Constructor que recibe solo el nombre.
        /// </summary>
        public PuntosJugador(string nombre) : this(nombre, 0, 1)
        {
        }

        /// <summary>
        /// Constructor que recibe nombre y puntos.
        /// </summary>
        public PuntosJugador(string nombre, int puntos) : this(nombre, puntos, 1)
        {
        }

        /// <summary>
        /// Constructor completo: nombre, puntos y nivel.
        /// Aquí se realiza la inicialización completa y las validaciones.
        /// </summary>
        public PuntosJugador(string nombre, int puntos, int nivel)
        {
            // Validación: los puntos iniciales no pueden ser negativos
            if (puntos < 0)
            {
                puntos = 0;
            }

            // Validación: el nivel debe ser mayor o igual a 1
            if (nivel < 1)
            {
                nivel = 1;
            }

            this.nombreJugador = nombre;
            this.puntos = puntos;
            this.nivel = nivel;
        }

        // ------------------------------------------------------------------
        // PROPIEDADES (encapsulamiento)
        // ------------------------------------------------------------------

        public string NombreJugador { get { return nombreJugador; } }
        public int Puntos { get { return puntos; } }
        public int Nivel { get { return nivel; } }

        // ------------------------------------------------------------------
        // SOBRECARGA DEL MÉTODO AgregarPuntos
        // ------------------------------------------------------------------

        /// <summary>
        /// Agrega puntos al jugador sin motivo ni bonificación.
        /// </summary>
        public void AgregarPuntos(int puntos)
        {
            AgregarPuntos(puntos, "Sin motivo especificado", false);
        }

        /// <summary>
        /// Agrega puntos al jugador indicando el motivo.
        /// </summary>
        public void AgregarPuntos(int puntos, string motivo)
        {
            AgregarPuntos(puntos, motivo, false);
        }

        /// <summary>
        /// Agrega puntos al jugador indicando motivo y si aplica bonificación.
        /// Bonificación: si es true, se suma un 50% adicional sobre los puntos recibidos.
        /// </summary>
        public void AgregarPuntos(int puntos, string motivo, bool bonificacion)
        {
            // Validación: la cantidad a agregar debe ser mayor que 0
            if (puntos <= 0)
            {
                Console.WriteLine("La cantidad de puntos a agregar debe ser mayor que 0.");
                return;
            }

            int puntosFinales = puntos;

            if (bonificacion)
            {
                // Bonificación definida por el alumno: +50% sobre los puntos recibidos
                puntosFinales = puntos + (puntos / 2);
            }

            this.puntos += puntosFinales;

            Console.WriteLine($"{nombreJugador} recibió {puntosFinales} puntos. Motivo: {motivo}");
        }

        // ------------------------------------------------------------------
        // MÉTODO MostrarInformacion
        // ------------------------------------------------------------------

        /// <summary>
        /// Muestra por consola el nombre, los puntos y el nivel del jugador.
        /// </summary>
        public void MostrarInformacion()
        {
            Console.WriteLine("----- Información del jugador -----");
            Console.WriteLine($"Nombre: {nombreJugador}");
            Console.WriteLine($"Puntos: {puntos}");
            Console.WriteLine($"Nivel:  {nivel}");
            Console.WriteLine("-----------------------------------");
        }

        // ------------------------------------------------------------------
        // SOBRECARGA DE OPERADORES
        // ------------------------------------------------------------------

        /// <summary>
        /// Suma dos jugadores. El nuevo jugador combina los nombres, suma los puntos
        /// y toma el nivel máximo de ambos (representa el mayor rango alcanzado).
        /// </summary>
        public static PuntosJugador operator +(PuntosJugador a, PuntosJugador b)
        {
            string nombreCombinado = a.nombreJugador + " & " + b.nombreJugador;
            int puntosSumados = a.puntos + b.puntos;
            int nivelMaximo = a.nivel > b.nivel ? a.nivel : b.nivel;
            return new PuntosJugador(nombreCombinado, puntosSumados, nivelMaximo);
        }

        /// <summary>
        /// Resta los puntos del segundo jugador al primero.
        /// Si el resultado es negativo se toma 0 (los puntos no pueden ser negativos).
        /// </summary>
        public static PuntosJugador operator -(PuntosJugador a, PuntosJugador b)
        {
            int diferencia = a.puntos - b.puntos;
            if (diferencia < 0)
            {
                diferencia = 0;
            }
            return new PuntosJugador("Diferencia", diferencia, 1);
        }

        /// <summary>
        /// Determina si dos jugadores son iguales según su cantidad de puntos.
        /// </summary>
        public static bool operator ==(PuntosJugador a, PuntosJugador b)
        {
            if (ReferenceEquals(a, b)) return true;
            if (a is null || b is null) return false;
            return a.puntos == b.puntos;
        }

        /// <summary>
        /// Determina si dos jugadores son distintos según su cantidad de puntos.
        /// </summary>
        public static bool operator !=(PuntosJugador a, PuntosJugador b)
        {
            return !(a == b);
        }

        public override bool Equals(object obj)
        {
            if (obj is PuntosJugador otro)
            {
                return this == otro;
            }
            return false;
        }

        public override int GetHashCode()
        {
            return puntos.GetHashCode();
        }

        // ------------------------------------------------------------------
        // CONVERSIONES
        // ------------------------------------------------------------------

        /// <summary>
        /// Conversión explícita: PuntosJugador -> int (devuelve la cantidad de puntos).
        /// </summary>
        public static explicit operator int(PuntosJugador j)
        {
            return j.puntos;
        }

        /// <summary>
        /// Conversión implícita: int -> PuntosJugador (crea un jugador con esos puntos).
        /// </summary>
        public static implicit operator PuntosJugador(int puntos)
        {
            return new PuntosJugador("JugadorConvertido", puntos, 1);
        }
    }

    public class Ejercicio2
    {
        public static void Ejecutar()
        {
            // =============================================================
            // ETAPA 1 — Constructores y métodos
            // =============================================================
            Console.WriteLine("=== ETAPA 1: Constructores y métodos ===");

            PuntosJugador j1 = new PuntosJugador();
            PuntosJugador j2 = new PuntosJugador("Ana");
            PuntosJugador j3 = new PuntosJugador("Beto", 500);
            PuntosJugador j4 = new PuntosJugador("Carla", 800, 5);

            j1.MostrarInformacion();
            j2.MostrarInformacion();
            j3.MostrarInformacion();
            j4.MostrarInformacion();

            Console.WriteLine("Probando sobrecargas de AgregarPuntos:");
            j1.AgregarPuntos(100);
            j2.AgregarPuntos(200, "Misión completada");
            j3.AgregarPuntos(150, "Bonus de fin de semana", true);
            j4.AgregarPuntos(-50, "Prueba inválida");

            j1.MostrarInformacion();
            j2.MostrarInformacion();
            j3.MostrarInformacion();
            j4.MostrarInformacion();

            // =============================================================
            // ETAPA 2 — Sobrecarga de operadores y conversiones
            // =============================================================
            Console.WriteLine("=== ETAPA 2: Sobrecarga de operadores ===");

            PuntosJugador a = new PuntosJugador("A", 500, 3);
            PuntosJugador b = new PuntosJugador("B", 300, 2);

            // Suma
            PuntosJugador suma = a + b;
            Console.WriteLine("Resultado de a + b:");
            suma.MostrarInformacion();

            // Resta
            PuntosJugador resta = a - b;
            Console.WriteLine("Resultado de a - b:");
            resta.MostrarInformacion();

            // Igualdad
            PuntosJugador c = new PuntosJugador("C", 500, 7);
            if (a == c)
            {
                Console.WriteLine("a == c (mismos puntos)");
            }

            // Desigualdad
            if (a != b)
            {
                Console.WriteLine("a != b (distintos puntos)");
            }

            // Conversión explícita
            int puntosDeA = (int)a;
            Console.WriteLine($"Conversión explícita (int)a = {puntosDeA}");

            // Conversión implícita
            PuntosJugador d = 1000;
            Console.WriteLine("Conversión implícita PuntosJugador d = 1000:");
            d.MostrarInformacion();
        }
    }
}