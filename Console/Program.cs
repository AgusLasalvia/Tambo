using Dominio;

namespace Console
{
    public class Program
    {
        static void Main(string[] args)
        {
            Sistema sistema = Sistema.sistema;
            System.Console.ReadKey();
            bool exit = false;
            while (!exit)
            {
                // System.Console.Clear();
                MostrarMenu();
                int opcion = PedirNumero("Ingrese una opcion");
                switch (opcion)
                {
                    case 1:
                        sistema.ListarTodosLosAnimales();
                        break;
                    case 2:
                        sistema.PotreroEspecifico();
                        break;
                    case 3:
                        sistema.CambiarPrecioLana();
                        break;
                    case 4:
                        AgregarBovino(sistema);
                        break;
                    case 0:
                        exit = true;
                        break;
                    default:
                        System.Console.WriteLine("Opcion no valida");
                        break;
                }
                System.Console.WriteLine("Presione una tecla para continuar");
                System.Console.ReadKey();
            }
        }



        static void MostrarMenu()
        {
            List<string> menu = new List<string> {
                "1. Listar Animales",
                "2. Potreros Segun Cantidad de Hectareas y Cantidad de Animales",
                "3. Establecer por Kilogramo de Lana ",
                "0. Salir ",

            };

            foreach (string opcion in menu)
            {
                System.Console.WriteLine(opcion);
            }
        }

        private static void AgregarBovino(Sistema sistema)
        {
            TipoAlimentacion alimentacion = (TipoAlimentacion)PedirNumero("Ingrese el tipo de alimentacion (1. Pasto, 2. Balanceado)");
            double peso = PedirNumero("Ingrese el peso por kilo");
            TipoGenero genero = (TipoGenero)PedirNumero("Ingrese el genero (1. Macho, 2. Hembra)");
            string raza = PedirPalabra("Ingrese la raza");
            DateTime fechaNacimiento = PedirFecha("Ingrese la fecha de nacimiento");
            double costoAdquisicion = PedirNumero("Ingrese el costo de adquisicion");
            double costoAlimentacion = PedirNumero("Ingrese el costo de alimentacion");
            double pesoActual = PedirNumero("Ingrese el peso actual");
            bool hibrido = PedirBooleano("Es hibrido? (true/false)");
            bool estado = PedirBooleano("Es libre? (true/false)");
            Bovino bovino = new Bovino(alimentacion, peso, genero, raza, fechaNacimiento, costoAdquisicion, costoAlimentacion, pesoActual, hibrido, new List<Vacunacion>(), estado);
            sistema.AgregarAnimal(bovino);

        }

        static int PedirNumero(string mensaje)
        {
            System.Console.WriteLine(mensaje);
            bool verificar = int.TryParse(System.Console.ReadLine(), out int numero);
            if (!verificar) throw new Exception("El valor ingresado no es un numero");
            return numero;
        }

        static string PedirPalabra(string mensaje)
        {
            System.Console.WriteLine(mensaje);
            string palabra = System.Console.ReadLine() ?? string.Empty;
            if (string.IsNullOrEmpty(palabra)) throw new Exception("El valor ingresado no es valido");
            return palabra;
        }

        static DateTime PedirFecha(string mensaje)
        {
            System.Console.WriteLine(mensaje);
            DateTime.TryParse(System.Console.ReadLine(), out DateTime fecha);
            return fecha;
        }

        static bool PedirBooleano(string mensaje)
        {
            System.Console.WriteLine(mensaje);
            bool verificacion = bool.TryParse(System.Console.ReadLine(), out bool booleano);
            if (!verificacion) throw new Exception("El valor ingresado no es valido");
            return booleano;
        }
    }
}
