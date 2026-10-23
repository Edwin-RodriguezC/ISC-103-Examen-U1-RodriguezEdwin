namespace Examenu1POO
{
    public class Ejercicio2
    {
        public void Ejecutar()
        {
            int tipoCombustible = LeerTipoCombustible();
            double litrosSolicitados = LeerLitros();
            double precio = 0;

            switch (tipoCombustible)
            {
                case 1:
                    precio = 28.50;
                    break;
                case 2:
                    precio = 32.00;
                    break;
                case 3:
                    precio = 26.75;
                    break;
            }

            double cargados = 0;
            Console.WriteLine("Iniciando la carga de combustible");
            
            while (cargados < litrosSolicitados)
            {
                double faltante = litrosSolicitados - cargados;
                
                if (faltante >= 5)
                {
                    cargados += 5;
                }
                else
                {
                    cargados += faltante;
                }
                
                Console.WriteLine($"Se han cargado {cargados:F2} litros...");
            }

            double subtotal = cargados * precio;
            double descuento = 0;

            if (subtotal >= 1500.00)
            {
                descuento = subtotal * 0.05;
            }
            else 
            if (subtotal >= 1000.00)
            {
                descuento = subtotal * 0.03;
            }

            double total = subtotal - descuento;

            Console.WriteLine("RECIBO DE CARGA DE COMBUSTIBLE");
            Console.WriteLine($"Total de litros: {cargados:F2}");
            Console.WriteLine($"Subtotal: L. {subtotal:F2}");
            Console.WriteLine($"Descuento: L. {descuento:F2}");
            Console.WriteLine($"TOTAL A PAGAR: L. {total:F2}");
        }
//Validaciones 
        private int LeerTipoCombustible()
        {
            int tipo = 0;
            int valido = 0;
            do
            {
                Console.WriteLine("Ingrese el tipo de combustible (1 = regular, 2 = premium, 3 = diésel): ");
                tipo = int.TryParse(Console.ReadLine(), out int t) ? t : 0;

                if (tipo >= 1)
                {
                    if (tipo <= 3)
                    {
                        valido = 1;
                    }
                    else
                    {
                        Console.WriteLine("Tipo inválido. Intente nuevamente.");
                    }
                }
                else
                {
                    Console.WriteLine("Tipo inválido. Intente nuevamente.");
                }
            } while (valido == 0);

            return tipo;
        }

        private double LeerLitros()
        {
            double litros = 0;
            int valido = 0;
            do
            {
                Console.WriteLine("Ingrese la cantidad de litros solicitada (máximo 60): ");
                litros = double.TryParse(Console.ReadLine(), out double l) ? l : 0;

                if (litros > 0)
                {
                    if (litros <= 60)
                    {
                        valido = 1;
                    }
                    else
                    {
                        Console.WriteLine("La cantidad excede el máximo permitido (60 litros).");
                    }
                }
                else
                {
                    Console.WriteLine("La cantidad debe ser mayor a cero.");
                }
            } while (valido == 0);

            return litros;
        }
    }
}