using System;
using System.Collections.Generic;
using System.Media;
using System.Threading;

namespace taller_lavadora
{
    public class Lavadora
    {
        private const int capacidad_maxima = 40; // Capacidad máxima de kilos
        private const int peso_minimo = 5; // Peso mínimo de ropa
        private const decimal costo_kilo = 4000m; // Costo por kilo de ropa
        private const decimal aumento_precio = 0.03m; // Aumento de precio para ciertos tipos de ropa
        private const decimal _utilidad = 0.40m; // Utilidad del negocio
        private const string ruta_sonido = @"C:\Users\USUARIO\source\repos\taller_lavadora\taller_lavadora\sounds"; // Ruta de los sonidos

        private List<string> tiposRopa;
        private int kilos;
        private string tipoRopa;
        public DateTime fechaHora;
        private bool cicloSecado;
        private int clientesAtendidos;

        // Constructor de la clase
        public Lavadora()
        {
            tiposRopa = new List<string> { "Blanca", "Colores", "Algodón", "Lycra", "Sedas", "Jeans", "Tennis", "Toallas", "Acolchados", "Ropa Delicada", "Cortinas" };
        }

        // Inicia el ciclo de lavado
        public void IniciarLavado()
        {
            // Solicitar y validar los kilos de ropa
            SolicitarKilos();

            // Solicitar y validar el tipo de ropa
            SolicitarTipoRopa();

            // Solicitar y validar el tiempo de lavado
            SolicitarTiempoLavado();

            // Ahora que tenemos todos los datos correctos, iniciamos el ciclo de lavado
            try
            {
                IniciarLavado(kilos, tipoRopa, 10); // 10 segundos de tiempo de lavado por defecto
                CicloTerminado();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }

        // Método para solicitar y validar los kilos de ropa
        private void SolicitarKilos()
        {
            while (true)
            {
                Console.Write("Ingrese los kilos de ropa (5 a 40): ");
                string inputKilos = Console.ReadLine();

                if (int.TryParse(inputKilos, out kilos)) // Verifica si es un número
                {
                    if (kilos >= peso_minimo && kilos <= capacidad_maxima) // Verifica que esté dentro del rango
                    {
                        break; // Salir del ciclo si la entrada es válida
                    }
                    else
                    {
                        Console.WriteLine($"Error: La cantidad de kilos debe estar entre {peso_minimo} y {capacidad_maxima}.");
                    }
                }
                else
                {
                    Console.WriteLine("Error: Debe ingresar un número válido para los kilos.");
                }
            }
        }

        // Método para solicitar y validar el tipo de ropa
        private void SolicitarTipoRopa()
        {
            while (true)
            {
                Console.Write("Ingrese el tipo de ropa (Blanca, Colores, Algodón, Lycra, Sedas, Jeans, Tennis, Toallas, Acolchados, Ropa Delicada, Cortinas): ");
                tipoRopa = Console.ReadLine();

                // Validación: Se comprueba si el tipo de ropa ingresado está en la lista de tipos válidos
                if (tiposRopa.Contains(tipoRopa)) // Verifica si el tipo de ropa es válido
                {
                    break; // Salir del ciclo si la entrada es válida
                }
                else
                {
                    Console.WriteLine("Error: Tipo de ropa no válido. Por favor ingrese un tipo de ropa correcto.");
                }
            }
        }

        // Método para solicitar y validar el tiempo de lavado
        private void SolicitarTiempoLavado()
        {
            int tiempoLavado = 0;
            while (true)
            {
                Console.Write("Ingrese el tiempo de lavado (en segundos): ");
                string inputTiempo = Console.ReadLine();

                if (int.TryParse(inputTiempo, out tiempoLavado) && tiempoLavado > 0) // Verifica si es un número positivo
                {
                    break; // Salir del ciclo si la entrada es válida
                }
                else
                {
                    Console.WriteLine("Error: Debe ingresar un número válido para el tiempo de lavado.");
                }
            }
        }

        // Método que simula el proceso de inicio de lavado
        public void IniciarLavado(int kilos, string tipoRopa, int tiempoLavado)
        {
            // Verifica que los valores sean correctos
            if (kilos < peso_minimo || kilos > capacidad_maxima)
                throw new ArgumentOutOfRangeException("La cantidad de kilos debe estar entre 5 y 40.");
            if (!tiposRopa.Contains(tipoRopa))
                throw new ArgumentException("Tipo de ropa no válido.");

            this.kilos = kilos;
            this.tipoRopa = tipoRopa;
            this.fechaHora = DateTime.Now;
            clientesAtendidos++;

            LlenadoAgua();
            Lavado(tiempoLavado);
            Enjuague();
            PreguntarSecado();
        }

        // Método para simular el llenado de agua en la lavadora
        private void LlenadoAgua()
        {
            Console.WriteLine("Llenando...");
            for (int i = 0; i < 3; i++)
            {
                Console.Write("...");
                ReproducirSonido(@"\llenado.wav");
                Thread.Sleep(1000); // Pausa de 2 segundos
            }
            Console.WriteLine("¡Llenado terminado!");
        }

        // Método para simular el proceso de lavado
        private void Lavado(int tiempoLavado)
        {
            Console.WriteLine("Lavando..."); // Muestra un mensaje indicando que se está comenzando el proceso de lavado.

            for (int i = 0; i < tiempoLavado; i++) // Bucle que se repite 'tiempoLavado' veces (tiempo en segundos)
            {
                Console.Write("..."); 
                ReproducirSonido(@"\lavado_enjuague.wav"); 
                Thread.Sleep(1000); 
            }

            Console.WriteLine(" ¡Lavado finalizado!"); // Al final del bucle, muestra el mensaje indicando que el proceso de lavado ha terminado.
        }


        // Método para simular el proceso de enjuague
        private void Enjuague()
        {
            Console.WriteLine("Enjuagando...");
            for (int i = 0; i < 3; i++)
            {
                Console.Write("...");
                ReproducirSonido(@"\lavado_enjuague.wav");
                Thread.Sleep(1000); // Pausa de 2 segundos
            }
            Console.WriteLine(" ¡Enjuague finalizado!");
        }

        // Método para preguntar al usuario si desea hacer el secado
        private void PreguntarSecado()
        {
            Console.Write("¿Desea secar las prendas (si/no)? ");
            string respuesta = Console.ReadLine().ToLower();
            cicloSecado = respuesta == "si";

            if (cicloSecado)
            {
                Secado();
            }
            else
            {
                Console.WriteLine("¡Ciclo de secado detenido!. Puede reanudar cuando desee.");
                ReanudarSecado();
            }
        }

        // Método para preguntar si se desea reanudar el secado
        private void ReanudarSecado()
        {
            Console.Write("¿Desea reanudar el secado (si/no)? ");
            string respuesta = Console.ReadLine().ToLower();
            if (respuesta == "si")
            {
                Secado();
            }
            else
            {
                Console.WriteLine("Procediendo a terminar el ciclo sin secado.");
            }
        }

        // Método para simular el proceso de secado
        private void Secado()
        {
            Console.WriteLine("Secando...");
            for (int i = 0; i < 3; i++)
            {
                Console.Write("...");
                ReproducirSonido(@"\secado.wav");
                Thread.Sleep(1000); // Pausa de 2 segundos
            }
            Console.WriteLine(" Secado finalizado.");
        }

        // Método para mostrar los resultados del ciclo de lavado
        public void CicloTerminado()
        {
            ReproducirSonido(@"\finalizado.wav");
            Console.WriteLine(ObtenerResultados());
        }

        // Método para obtener los resultados del ciclo
        public string ObtenerResultados()
        {
            decimal costo = CalcularCosto();
            decimal iva = costo * 0.19m;
            decimal totalConIva = costo + iva;
            decimal utilidad = costo * _utilidad;

            return $"Cliente: [Nombre Cliente]\n" +
                   $"Fecha y Hora: {fechaHora}\n" +
                   $"Kilos Lavados: {kilos}\n" +
                   $"Tipo de Ropa: {tipoRopa}\n" +
                   $"Costo sin IVA: {costo:C}\n" +
                   $"IVA: {iva:C}\n" +
                   $"Costo total con IVA: {totalConIva:C}\n" +
                   $"Utilidad: {utilidad:C}\n" +
                   $"-------------------------------------" +
                   $"Clientes atendidos: {clientesAtendidos}\n";
        }

        // Método para calcular el costo de la lavandería
        private decimal CalcularCosto()
        {
            decimal costo = costo_kilo * kilos;
            if (tipoRopa == "Blanca" || tipoRopa == "Algodón" || tipoRopa == "Tennis")
            {
                costo += costo * aumento_precio; // Aumento de precio para ciertos tipos de ropa
            }
            return costo;
        }

        // Método para reproducir sonidos
        private void ReproducirSonido(string nombreArchivo)
        {
            string rutaCompleta = ruta_sonido + nombreArchivo;
            try
            {
                using (SoundPlayer player = new SoundPlayer(rutaCompleta))
                {
                    player.PlaySync();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al reproducir el sonido: {ex.Message}");
            }
        }
    }
}

