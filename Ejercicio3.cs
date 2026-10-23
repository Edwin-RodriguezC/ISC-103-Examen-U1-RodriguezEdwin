namespace Examenu1POO

{
    public class Ejercicio3
    {
        public void Ejecutar()
        {
            string[] nombres = { "Marcio", "Bryan", "Pedro", "Jan", "Alarcon", "Edwin", "Daniela", "Valeria", "Ligny", "Diego" };
            bool[] asistencias = { true, false, true, true, false, true, true, true, false, true }; 

            Console.WriteLine(" LISTA DE PARTICIPANTES ");
            int asistieron = 0;
            int faltaron = 0;

            for (int i = 0; i < nombres.Length; i++)
            {
                string estado = asistencias[i] == true ? "Asistió" : "Faltó";
                Console.WriteLine($"{nombres[i]} - {estado}");

                if (asistencias[i] == true)
                {
                    asistieron += 1;
                }
                else
                {
                    faltaron += 1;
                }
            }

            Console.WriteLine("\nRESUMEN DE ASISTENCIA\n");
            Console.WriteLine($"Asistieron: {asistieron}");
            Console.WriteLine($"Faltaron: {faltaron}");
            double porcentaje = (double)asistieron / nombres.Length * 100;
            Console.WriteLine($"Porcentaje de asistencia: {porcentaje:F2}%");

            Console.WriteLine("\nPARTICIPANTES QUE FALTARON\n");
            int indice = 0;
            foreach (string nombre in nombres)
            {
                if (asistencias[indice] == false)
                {
                    Console.WriteLine(nombre);
                }
                indice += 1;
            }

            Console.WriteLine("\n BÚSQUEDA DE PARTICIPANTE \n");
            string nombreBuscar = LeerNombreBusqueda();
            int encontrado = 0;

            for (int i = 0; i < nombres.Length; i++)
            {
                if (nombres[i] == nombreBuscar)
                {
                    encontrado = 1;
                    string estadoBusqueda = asistencias[i] == true ? "Asistió" : "Faltó";
                    Console.WriteLine($"Participante encontrado en la posición {i + 1}. Estado: {estadoBusqueda}");
                }
            }

            if (encontrado == 0)
            {
                Console.WriteLine("El participante no se encontró en la lista.");
            }

            Console.WriteLine("\n--- PARTICIPANTES EN ORDEN INVERSO ---");
            for (int i = nombres.Length - 1; i >= 0; i--)
            {
                Console.WriteLine(nombres[i]);
            }
        }
//Validaciones
        private string LeerNombreBusqueda()
        {
            string nombre = "";
            int valido = 0;

            do
            {
                Console.WriteLine("Ingrese el nombre del participante a buscar: ");
                nombre = Console.ReadLine();

                if (nombre == "")
                {
                    Console.WriteLine("El nombre no puede estar vacío.");
                }
                else
                {
                    valido = 1;
                }
            } while (valido == 0);

            return nombre;
        }
    }
}