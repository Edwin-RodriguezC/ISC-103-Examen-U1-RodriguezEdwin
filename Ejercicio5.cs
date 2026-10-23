namespace Examenu1POO
{
    public class Ejercicio5
    {
        public void Ejecutar()
        {
            List<string> noms = new List<string>();//Lista para los nombres de los productos
            List<int> exts = new List<int>();//Lista para las existencias
            List<decimal> precios = new List<decimal>();//Lista para los precios
            int op = 0;

            while (op != 6)
            {
                Console.Clear();
                Console.WriteLine("1.Registrar ");
                Console.WriteLine("2.Vender ");
                Console.WriteLine("3.Abastecer ");
                Console.WriteLine("4.Inventario ");
                Console.WriteLine("5.Alertas ");
                Console.WriteLine("Opción: ");
                op = int.TryParse(Console.ReadLine(), out int o) ? o : 0;

                switch (op)
                {
                    case 1:
                        string nom = LeerNuevo(noms);
                        int ext = LeerCant("Existencia (>=0): ", 0);
                        decimal precio = LeerPrecio();
                        noms.Add(nom);
                        exts.Add(ext);
                        precios.Add(precio);
                        Console.WriteLine("Registrado.");
                        break;

                    case 2:
                        if (noms.Count > 0)
                        {
                            string nv = LeerExistente(noms);
                            int cv = LeerCant("Cantidad a vender: ", 1);
                            int iV = noms.IndexOf(nv);
                            if (exts[iV] >= cv)
                            {
                                exts[iV] -= cv;
                                Console.WriteLine($"Venta: L. {cv * precios[iV]:F2}");
                            }
                            else
                            {
                                Console.WriteLine($"Solo hay {exts[iV]} disponibles.");
                            }
                        }
                        break;

                    case 3:
                        if (noms.Count > 0)
                        {
                            string na = LeerExistente(noms);
                            int ca = LeerCant("Cantidad a abastecer: ", 1);
                            exts[noms.IndexOf(na)] += ca;
                            Console.WriteLine("Abastecido.");
                        }
                        break;

                    case 4:
                        decimal total = 0;
                        for (int i = 0; i < noms.Count; i++)
                        {
                            decimal v = exts[i] * precios[i];
                            total += v;
                            Console.WriteLine($"{noms[i]} | Ext: {exts[i]} | Precio: L.{precios[i]:F2} | Total: L.{v:F2}");
                        }
                        Console.WriteLine($"TOTAL INVENTARIO: L.{total:F2}");
                        break;

                    case 5:
                        Console.WriteLine("Alertas (Existencia <= 5):");
                        for (int i = 0; i < noms.Count; i++)
                        {
                            if (exts[i] <= 5)
                            {
                                Console.WriteLine($"- {noms[i]} ({exts[i]})");
                            }
                        }

                        if (noms.Count > 0)
                        {
                            int idxMax = 0;
                            decimal maxVal = exts[0] * precios[0];
                            for (int i = 1; i < noms.Count; i++)
                            {
                                decimal act = exts[i] * precios[i];
                                if (act > maxVal)
                                {
                                    maxVal = act;
                                    idxMax = i;
                                }
                            }
                            Console.WriteLine($"Mayor valor en inventario: {noms[idxMax]} (L.{maxVal:F2})");
                        }
                        break;

                    case 6:
                        Console.WriteLine("Saliendo...");
                        break;

                    default:
                        Console.WriteLine("Inválido.");
                        break;
                }

                if (op != 6)
                {
                    Console.WriteLine("Presione algo...");
                    Console.ReadKey();
                }
            }
        }
//VALIDACIONES      
        private string LeerNuevo(List<string> noms)
        {
            string n = "";
            int valido = 0;
            do
            {
                Console.WriteLine("Nombre nuevo: ");
                n = Console.ReadLine();
                if (n == "") Console.WriteLine("Vacío.");
                else if (noms.Contains(n)) Console.WriteLine("Ya existe.");
                else valido = 1;
            } while (valido == 0);
            return n;
        }

        private string LeerExistente(List<string> noms)
        {
            string n = "";
            int valido = 0;
            do
            {
                Console.WriteLine("Nombre existente: ");
                n = Console.ReadLine();
                if (noms.Contains(n)) valido = 1;
                else Console.WriteLine("No existe.");
            } while (valido == 0);
            return n;
        }

        private int LeerCant(string msj, int min)
        {
            int c = 0;
            int valido = 0;
            do
            {
                Console.WriteLine(msj);
                c = int.TryParse(Console.ReadLine(), out int v) ? v : -1;
                if (c >= min) valido = 1;
                else Console.WriteLine($"Mínimo {min}.");
            } while (valido == 0);
            return c;
        }

        private decimal LeerPrecio()
        {
            decimal p = 0;
            int valido = 0;
            do
            {
                Console.WriteLine("Precio (> 0): ");
                p = decimal.TryParse(Console.ReadLine(), out decimal v) ? v : 0;
                if (p > 0) valido = 1;
                else Console.WriteLine("Debe ser > 0.");
            } while (valido == 0);
            return p;
        }
    }
}