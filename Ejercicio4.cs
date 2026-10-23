namespace Examenu1POO
{
    public class Ejercicio4
    {
        public void Ejecutar()
        {
            List<string> urgentes = new List<string>(); //Lista para los pacientes urgentes
            List<string> normales = new List<string>(); //Lista para los pacientes normales
            int opcion = 0;

            while (opcion != 6)
            {
                Console.Clear();
                Console.WriteLine("1.Registrar Cliente");
                Console.WriteLine("2.Atender Siguiente");
                Console.WriteLine("3.Mostrar Fila");
                Console.WriteLine("4.Buscar Paciente");
                Console.WriteLine("5.Mostrar Cantidad");
                Console.WriteLine("6.Salir");       

                Console.WriteLine("Ingrese opción: ");
                opcion = int.TryParse(Console.ReadLine(), out int op) ? op : 0;

                switch (opcion)
                {
                    case 1:
                        string nombre = LeerNombre(urgentes, normales);
                        int prioridad = LeerPrioridad();
                        if (prioridad == 1)
                        {
                            urgentes.Add(nombre);
                        }
                        else
                        {
                            normales.Add(nombre);
                        }
                        Console.WriteLine("Paciente registrado");
                        break;

                    case 2:
                        if (urgentes.Count > 0)
                        {
                            Console.WriteLine($"Atendiendo URGENTE: {urgentes[0]}");
                            urgentes.RemoveAt(0);
                        }
                        else 
                        if (normales.Count > 0)
                        {
                            Console.WriteLine($"Atendiendo NORMAL: {normales[0]}");
                            normales.RemoveAt(0);
                        }
                        else
                        {
                            Console.WriteLine("No hay pacientes.");
                        }
                        break;

                    case 3:
                        Console.WriteLine("Urgentes:");
                        for (int i = 0; i < urgentes.Count; i++)
                        {
                            Console.WriteLine($"{i + 1}. {urgentes[i]}");
                        }
                        Console.WriteLine("Normales:");
                        for (int i = 0; i < normales.Count; i++)
                        {
                            Console.WriteLine($"{i + 1}. {normales[i]}");
                        }
                        Console.WriteLine($"Total en espera: {urgentes.Count + normales.Count}");
                        break;

                    case 4:
                        Console.WriteLine("Nombre a buscar: ");
                        string buscar = Console.ReadLine();
                        int iU = urgentes.IndexOf(buscar); //Urgentes
                        int iN = normales.IndexOf(buscar); //Normales

                        if (iU >= 0)
                        {
                            Console.WriteLine($"URGENTE. Posición: {iU + 1}. Delante: {iU}");
                        }
                        else 
                        if (iN >= 0)
                        {
                            Console.WriteLine($"NORMAL. Posición: {iN + 1}. Delante: {urgentes.Count + iN}");
                        }
                        else
                        {
                            Console.WriteLine("No encontrado");
                        }
                        break;

                    case 5:
                        Console.WriteLine($"Urgentes: {urgentes.Count} | Normales: {normales.Count} | Total: {urgentes.Count + normales.Count}");
                        break;

                    case 6:
                        Console.WriteLine("Saliendo del programa");
                        break;

                    default:
                        Console.WriteLine("Opción inválida");
                        break;
                }

                if (opcion != 6)
                {
                    Console.WriteLine("Pulse cualquier tecla para continuar");
                    Console.ReadKey();
                }
            }
        }
        //Validaciones
        private string LeerNombre(List<string> urgentes, List<string> normales)
        {
            string nombre = "";
            int valido = 0;
            do
            {
                Console.WriteLine("Ingrese nombre: ");
                nombre = Console.ReadLine();

                if (nombre == "")
                {
                    Console.WriteLine("No puede estar vacío, Ingrese nombre.");
                }
                else
                 if (urgentes.Contains(nombre) || normales.Contains(nombre))
                {
                    Console.WriteLine("El paciente ya existe.");
                }
                else
                {
                    valido = 1;
                }
            } while (valido == 0);
            return nombre;
        }
        private int LeerPrioridad()
        {
            int prioridad = 0;
            int valido = 0;
            do
            {
                Console.WriteLine("Prioridad (1=urgente, 2=normal): ");
                prioridad = int.TryParse(Console.ReadLine(), out int p) ? p : 0;

                if (prioridad == 1 || prioridad == 2)
                {
                    valido = 1;
                }
                else
                {
                    Console.WriteLine("Debe ser 1 o 2.");
                }
            } while (valido == 0);
            return prioridad;
        }
    }
}