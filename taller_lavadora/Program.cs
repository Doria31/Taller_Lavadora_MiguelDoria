using System;
using System.Linq;

namespace taller_lavadora
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Lavadora lavadora = new Lavadora(); // Crea una instancia de la clase Lavadora

            bool continuar = true; // Variable para controlar el bucle de ejecución

            while (continuar) // Bucle principal para permitir que el usuario realice múltiples lavados
            {
                try // Intento de ejecutar un bloque de código que puede generar excepciones
                {
                    // Muestra un mensaje de bienvenida al usuario
                    Console.WriteLine("¡Bienvenido a Lavadoras Haceb S.A!");
                    Console.WriteLine("--------------------------------------");

                    // Solicita y lee el nombre del cliente
                    Console.Write("Ingrese su nombre: ");
                    string nombreCliente = Console.ReadLine();

                    // Solicita y valida la cantidad de kilos de ropa que el cliente quiere lavar
                    int kilos = SolicitarKilos();

                    // Solicita y valida el tipo de ropa que el cliente quiere lavar
                    string tipoRopa = SolicitarTipoRopa();

                    // Muestra una recomendación basada en el tipo de ropa seleccionado
                    MostrarRecomendacion(tipoRopa);

                    // Solicita y valida la temperatura para el lavado
                    int temperatura = SolicitarTemperatura();

                    // Solicita y valida el tiempo de lavado en minutos
                    int tiempoLavado = SolicitarTiempoLavado();

                    // Inicia el proceso de lavado, pasando los parámetros de kilos, tipo de ropa y tiempo de lavado
                    lavadora.IniciarLavado(kilos, tipoRopa, tiempoLavado);

                    // Muestra los resultados del ciclo de lavado cuando termina
                    lavadora.CicloTerminado();

                    // Pregunta al usuario si desea realizar otro lavado
                    Console.Write("¿Desea lavar más ropa? (si/no): ");
                    string respuesta = Console.ReadLine().ToLower(); // Lee la respuesta y la convierte a minúsculas
                    continuar = respuesta == "si"; // Si la respuesta es "si", continúa el ciclo de lavado
                }
                catch (Exception ex) // Captura cualquier excepción que se pueda generar durante la ejecución
                {
                    Console.WriteLine($"Error: {ex.Message}"); // Muestra el mensaje de error
                }
            }

            // Al finalizar el bucle, muestra un mensaje de despedida y espera que el usuario presione una tecla para cerrar
            Console.WriteLine("Programa terminado. Presione cualquier tecla para salir.");
            Console.ReadKey(); // Espera que el usuario presione una tecla
        }

        // Método para solicitar y validar los kilos de ropa
        static int SolicitarKilos()
        {
            int kilos;
            while (true)
            {
                Console.Write("Ingrese la cantidad de kilos a lavar (5 - 40): ");
                string inputKilos = Console.ReadLine();

                if (int.TryParse(inputKilos, out kilos)) // Verifica si es un número
                {
                    if (kilos >= 5 && kilos <= 40) // Verifica que esté dentro del rango
                    {
                        return kilos; // Devuelve el valor si es válido
                    }
                    else
                    {
                        Console.WriteLine("Error: La cantidad de kilos debe estar entre 5 y 40.");
                    }
                }
                else
                {
                    Console.WriteLine("Error: Debe ingresar un número válido para los kilos.");
                }
            }
        }

        // Método para solicitar y validar el tipo de ropa usando un número
        static string SolicitarTipoRopa()
        {
            string tipoRopa = "";
            while (true)
            {
                Console.WriteLine("Seleccione el tipo de ropa a lavar:");
                Console.WriteLine("1. Blanca");
                Console.WriteLine("2. Colores");
                Console.WriteLine("3. Algodón");
                Console.WriteLine("4. Lycra");
                Console.WriteLine("5. Sedas");
                Console.WriteLine("6. Jeans");
                Console.WriteLine("7. Tennis");
                Console.WriteLine("8. Toallas");
                Console.WriteLine("9. Acolchados");
                Console.WriteLine("10. Ropa Delicada");
                Console.WriteLine("11. Cortinas");
                Console.Write("Ingrese el número correspondiente al tipo de ropa: ");

                string input = Console.ReadLine();

                if (int.TryParse(input, out int opcion))
                {
                    switch (opcion)
                    {
                        case 1:
                            tipoRopa = "Blanca";
                            break;
                        case 2:
                            tipoRopa = "Colores";
                            break;
                        case 3:
                            tipoRopa = "Algodón";
                            break;
                        case 4:
                            tipoRopa = "Lycra";
                            break;
                        case 5:
                            tipoRopa = "Sedas";
                            break;
                        case 6:
                            tipoRopa = "Jeans";
                            break;
                        case 7:
                            tipoRopa = "Tennis";
                            break;
                        case 8:
                            tipoRopa = "Toallas";
                            break;
                        case 9:
                            tipoRopa = "Acolchados";
                            break;
                        case 10:
                            tipoRopa = "Ropa Delicada";
                            break;
                        case 11:
                            tipoRopa = "Cortinas";
                            break;
                        default:
                            Console.WriteLine("Opción no válida, por favor ingrese un número entre 1 y 11.");
                            continue;
                    }

                    return tipoRopa;
                }
                else
                {
                    Console.WriteLine("Error: Debe ingresar un número válido.");
                }
            }
        }

        // Método para solicitar y validar la temperatura para el lavado
        static int SolicitarTemperatura()
        {
            int temperatura;
            while (true)
            {
                Console.Write("Ingrese la temperatura para el lavado: ");
                string inputTemperatura = Console.ReadLine();

                if (int.TryParse(inputTemperatura, out temperatura))
                {
                    return temperatura; // Devuelve el valor de la temperatura si es válido
                }
                else
                {
                    Console.WriteLine("Error: Debe ingresar un número válido para la temperatura.");
                }
            }
        }

        // Método para solicitar y validar el tiempo de lavado en minutos
        static int SolicitarTiempoLavado()
        {
            int tiempoLavado;
            while (true)
            {
                Console.Write("Ingrese el tiempo de lavado: ");
                string inputTiempo = Console.ReadLine();

                if (int.TryParse(inputTiempo, out tiempoLavado) && tiempoLavado > 0) // Verifica que sea un número positivo
                {
                    return tiempoLavado; // Devuelve el tiempo de lavado si es válido
                }
                else
                {
                    Console.WriteLine("Error: Debe ingresar un número válido para el tiempo de lavado.");
                }
            }
        }

        // Método estático para mostrar una recomendación según el tipo de ropa
        static void MostrarRecomendacion(string tipoRopa)
        {
            switch (tipoRopa.ToLower()) // Convierte el tipo de ropa a minúsculas para evitar errores de capitalización
            {
                case "colores":
                case "algodón":
                case "lycra":
                case "sedas":
                case "ropa delicada":
                    Console.WriteLine("Recomendación: Utilizar agua fría (hasta 20º).");
                    break;
                case "jeans":
                    Console.WriteLine("Recomendación: Utilizar agua tibia (30º a 50º).");
                    break;
                case "toallas":
                case "acolchados":
                    Console.WriteLine("Recomendación: Utilizar agua caliente (55º a 90º).");
                    break;
                case "blanca":
                case "tennis":
                    Console.WriteLine("Recomendación: Utilizar agua caliente (55º a 90º).");
                    break;
                default:
                    Console.WriteLine("Tipo de ropa no reconocido. Asegúrese de ingresar un tipo válido.");
                    break;
            }
        }
    }
}



