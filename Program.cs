// ============================================================
// IMPORTACIONES
// ============================================================
// using System: permite usar Console, DateTime, etc.
using System;

// using GestionVehiculos: importa el namespace donde está la clase Vehiculo
// y el enumerado TipoVehiculo.
// En este caso es redundante porque Program ya está dentro del mismo namespace,
// pero no hace daño y sirve para entender que normalmente se importa.
using GestionVehiculos;

// ============================================================
// NAMESPACE
// ============================================================
// Mismo namespace que GestionVehiculos.cs.
// Al estar en el mismo namespace, Program puede usar Vehiculo y TipoVehiculo
// sin necesidad de escribir GestionVehiculos.Vehiculo cada vez.
namespace GestionVehiculos
{
    // ============================================================
    // CLASE Program
    // ============================================================
    // Esta clase no representa un vehículo.
    // Solo contiene el método Main, que es el punto de entrada del programa.
    class Program
    {
        // ============================================================
        // MÉTODO MAIN
        // ============================================================
        // Main es el método que C# ejecuta automáticamente al iniciar el programa.
        // static: pertenece a la clase Program, no a un objeto.
        // void: no devuelve nada.
        // string[] args: parámetros opcionales de línea de comandos (no se usan acá).
        static void Main(string[] args)
        {
            // ============================================
            // PRUEBA 1: Crear tres vehículos y mostrar datos iniciales
            // ============================================
            // Se crean tres objetos Vehiculo con distintos TipoVehiculo
            // (Auto, Utilitario, Premium) para probar los recargos y descripciones.
            // El constructor recibe: patente, precioBase, marca, modelo,
            // anioFabricacion y tipo.
            // Kilometraje no se pasa: queda en 0 por defecto.
            Console.WriteLine("=== PRUEBA 1: Datos iniciales ===\n");

            // v1: Auto, precio base 10000, año 2020.
            Vehiculo v1 = new Vehiculo("ABC123", 10000, "Toyota", "Corolla", 2020, TipoVehiculo.Auto);

            // v2: Utilitario, precio base 15000, año 2019.
            Vehiculo v2 = new Vehiculo("DEF456", 15000, "Ford", "Ranger", 2019, TipoVehiculo.Utilitario);

            // v3: Premium, precio base 25000, año 2022.
            Vehiculo v3 = new Vehiculo("GHI789", 25000, "BMW", "X5", 2022, TipoVehiculo.Premium);

            // MostrarDatos() devuelve un string con toda la información.
            // Console.WriteLine lo imprime en pantalla.
            Console.WriteLine(v1.MostrarDatos());
            Console.WriteLine(v2.MostrarDatos());
            Console.WriteLine(v3.MostrarDatos());

            // ============================================
            // PRUEBA 2: Modificar marca y modelo de v1
            // ============================================
            // Marca y Modelo son propiedades autoimplementadas de lectura y escritura.
            // Se pueden modificar directamente desde Main, sin validaciones.
            Console.WriteLine("=== PRUEBA 2: Modificar marca y modelo de v1 ===\n");

            v1.Marca = "Honda";   // Cambia la marca del vehículo v1.
            v1.Modelo = "Civic";  // Cambia el modelo del vehículo v1.

            // Se vuelve a mostrar para comprobar que los cambios se reflejan.
            Console.WriteLine(v1.MostrarDatos());

            // ============================================
            // PRUEBA 3: Registrar kilómetros y comprobar nuevo kilometraje
            // ============================================
            // Kilometraje tiene escritura privada.
            // La única forma de aumentarlo desde Main es RegistrarRecorrido().
            // El método valida que los km sean mayores que cero.
            Console.WriteLine("=== PRUEBA 3: Registrar recorrido ===\n");

            // Estado inicial del kilometraje (debería ser 0).
            Console.WriteLine("Kilometraje antes: " + v1.Kilometraje + " km");

            // Caso válido: 350 km.
            v1.RegistrarRecorrido(350);
            Console.WriteLine("Kilometraje después de 350 km: " + v1.Kilometraje + " km");

            // Caso inválido: -50 km. El método no debe modificar el kilometraje.
            v1.RegistrarRecorrido(-50);
            Console.WriteLine("Intento con -50 km (inválido): " + v1.Kilometraje + " km");

            // Caso inválido: 0 km. Tampoco debe modificarse.
            v1.RegistrarRecorrido(0);
            Console.WriteLine("Intento con 0 km (inválido): " + v1.Kilometraje + " km");

            // ============================================
            // PRUEBA 4: Modificar precio base y ver nuevo precio final
            // ============================================
            // PrecioBase es de SOLO ESCRITURA: se puede asignar, pero no leer.
            // PrecioFinal es CALCULADA: se recalcula cada vez que se consulta,
            // usando el nuevo precioBase y el Tipo.
            Console.WriteLine("\n=== PRUEBA 4: Modificar precio base ===\n");

            // Precio final antes de cambiar el precio base.
            Console.WriteLine("Precio final antes: $" + v1.PrecioFinal);

            // Se asigna un nuevo precio base válido (mayor que cero).
            v1.PrecioBase = 20000;

            // Precio final recalculado automáticamente.
            // Para v1 (Auto, recargo 0%): 20000 * 1 = 20000.
            Console.WriteLine("Precio final después de cambiar precio base a 20000: $" + v1.PrecioFinal);

            // ============================================
            // PRUEBA 5: Intentar datos inválidos y comprobar validaciones
            // ============================================
            // Se crean vehículos con datos inválidos para comprobar que las
            // propiedades con validación NO modifican el valor anterior.
            Console.WriteLine("\n=== PRUEBA 5: Validaciones ===\n");

            // Patente vacía: el set de Patente no la acepta.
            // Como el atributo privado se inicializa en "", la patente queda "".
            Vehiculo v4 = new Vehiculo("", 10000, "Fiat", "Cronos", 2021, TipoVehiculo.Auto);

            // El operador ?? (null-coalescing) devuelve el valor de la izquierda
            // si no es null, o el de la derecha si es null.
            // Acá se usa por si Patente devolviera null (en este caso no, devuelve "").
            Console.WriteLine("Patente inválida (vacía), patente real: " + (v4.Patente ?? "null"));

            // Precio base inválido (-5000): el set de PrecioBase no lo acepta.
            // Como precioBase queda en 0 (valor por defecto), el PrecioFinal es 0.
            Vehiculo v5 = new Vehiculo("XYZ999", -5000, "Fiat", "Cronos", 2021, TipoVehiculo.Auto);
            Console.WriteLine("Precio base inválido (-5000), precio final: $" + v5.PrecioFinal);

            // Año inválido (1800): el set de AnioFabricacion no lo acepta.
            // Como anioFabricacion queda en 0, la Antiguedad se calcula
            // como DateTime.Now.Year - 0, dando un número enorme.
            Vehiculo v6 = new Vehiculo("XYZ999", 10000, "Fiat", "Cronos", 1800, TipoVehiculo.Auto);
            Console.WriteLine("Año inválido (1800), antigüedad calculada: " + v6.Antiguedad);

            // ============================================
            // PRUEBA 6: Usar EsPatenteValida() sin crear un vehículo
            // ============================================
            // EsPatenteValida() es estático: se llama desde la clase Vehiculo,
            // no desde un objeto. No hace falta crear un vehículo con new.
            Console.WriteLine("\n=== PRUEBA 6: EsPatenteValida sin crear vehículo ===\n");

            // "ABC123" tiene 6 caracteres -> válida.
            Console.WriteLine("¿'ABC123' es válida? " + Vehiculo.EsPatenteValida("ABC123"));

            // "" está vacía -> inválida.
            Console.WriteLine("¿'' es válida? " + Vehiculo.EsPatenteValida(""));

            // null es nula -> inválida.
            Console.WriteLine("¿null es válida? " + Vehiculo.EsPatenteValida(null));

            // "AB1" tiene 3 caracteres -> inválida (menos de 6).
            Console.WriteLine("¿'AB1' es válida? " + Vehiculo.EsPatenteValida("AB1"));

            // ============================================
            // PRUEBA 7: Mostrar datos finales
            // ============================================
            // Se muestra el estado final de v1 después de todas las pruebas:
            // marca/modelo cambiados, kilometraje aumentado, precio base modificado.
            Console.WriteLine("\n=== PRUEBA 7: Datos finales de v1 ===\n");

            Console.WriteLine(v1.MostrarDatos());

            // Console.ReadKey() espera que el usuario presione una tecla
            // antes de cerrar la consola. Sirve para que no se cierre de golpe.
            Console.WriteLine("\nPresione una tecla para salir...");
            Console.ReadKey();
        }
    }
}