namespace Examenu1POO

{
    public class Ejercicio1
    {
        public void Ejecutar()
        {
            Console.WriteLine("Ingrese el nombre del cliente: ");
            string nombre = Console.ReadLine();

            int zona = LeerZona();
            double peso = LeerPeso();
            int servicio = LeerServicio();
            double valorDeclarado = LeerValorDeclarado();

            double tarifaBase = 0;
            switch (zona)
            {
                case 1:
                    tarifaBase = 60.00;
                    break;
                case 2:
                    tarifaBase = 100.00;
                    break;
                case 3:
                    tarifaBase = 150.00;
                    break;
            }

            double recargoPeso = 0;
            if (peso <= 1)
            {
                recargoPeso = 0;
            }
            else 
            if (peso <= 5)
            {
                recargoPeso = 40.00;
            }
            else 
            if (peso <= 10)
            {
                recargoPeso = 80.00;
            }
            else
            {
                recargoPeso = 140.00;
            }

            double sumaBasePeso = tarifaBase + recargoPeso;
            double recargoServicio = 0;

            switch (servicio)
            {
                case 1:
                    recargoServicio = 0;
                    break;
                case 2:
                    recargoServicio = sumaBasePeso * 0.25;
                    break;
                case 3:
                    recargoServicio = sumaBasePeso * 0.50;
                    break;
            }

            double seguro = 0;
            if (valorDeclarado > 5000.00) 
            {
                seguro = valorDeclarado * 0.02;
            }

            double subtotal = sumaBasePeso + recargoServicio + seguro;
            double descuento = 0;

            if (subtotal > 700.00)
            {
                descuento = subtotal * 0.05;
            }

            double total = subtotal - descuento;
            string textoSeguro = valorDeclarado > 5000.00 ? "Envío asegurado" : "Envío sin seguro";

            Console.WriteLine("RECIBO");
            Console.WriteLine($"Cliente: {nombre}");
            Console.WriteLine($"Tarifa base (Zona {zona}): L. {tarifaBase:F2}"); //El F2 es para dos decimales
            Console.WriteLine($"Recargo por peso ({peso:F2} kg): L. {recargoPeso:F2}");
            Console.WriteLine($"Recargo por servicio ({servicio}): L. {recargoServicio:F2}");
            Console.WriteLine($"Estado: {textoSeguro}");
            Console.WriteLine($"Cobro por seguro: L. {seguro:F2}");
            Console.WriteLine($"Subtotal: L. {subtotal:F2}");
            Console.WriteLine($"Descuento: L. {descuento:F2}");
            Console.WriteLine($"TOTAL A PAGAR: L. {total:F2}");
        }
// Validaciones 
        private int LeerZona()
        {
            int zona = 0;
            int valido = 0;
            do
            {
                Console.WriteLine("Ingrese la zona (1 = local, 2 = departamental, 3 = nacional): ");
                zona = int.TryParse(Console.ReadLine(), out int z) ? z : 0;

                if (zona >= 1)
                {
                    if (zona <= 3)
                    {
                        valido = 1;
                    }
                    else
                    {
                        Console.WriteLine("Zona inválida. Intente de nuevo.");
                    }
                }
                else
                {
                    Console.WriteLine("Zona inválida. Intente de nuevo.");
                }
            } while (valido == 0);

            return zona;
        }

        private double LeerPeso()
        {
            double peso = 0;
            int valido = 0;
            do
            {
                Console.WriteLine("Ingrese el peso en kilogramos (mayor a cero): ");
                peso = double.TryParse(Console.ReadLine(), out double p) ? p : 0;

                if (peso > 0)
                {
                    valido = 1;
                }
                else
                {
                    Console.WriteLine("El peso debe ser mayor a cero.");
                }
            } while (valido == 0);

            return peso;
        }

        private int LeerServicio()
        {
            int servicio = 0;
            int valido = 0;
            do
            {
                Console.WriteLine("Ingrese el tipo de servicio (1 = estándar, 2 = express, 3 = mismo día): ");
                servicio = int.TryParse(Console.ReadLine(), out int s) ? s : 0;

                if (servicio >= 1)
                {
                    if (servicio <= 3)
                    {
                        valido = 1;
                    }
                    else
                    {
                        Console.WriteLine("Servicio inválido. Intente de nuevo.");
                    }
                }
                else
                {
                    Console.WriteLine("Servicio inválido. Intente de nuevo.");
                }
            } while (valido == 0);

            return servicio;
        }

        private double LeerValorDeclarado()
        {
            double valor = -1;
            int valido = 0;
            do
            {
                Console.WriteLine("Ingrese el valor declarado del paquete: ");
                valor = double.TryParse(Console.ReadLine(), out double v) ? v : -1;

                if (valor >= 0)
                {
                    valido = 1;
                }
                else
                {
                    Console.WriteLine("El valor declarado no puede ser negativo.");
                }
            } while (valido == 0);

            return valor;
        }
    }
}