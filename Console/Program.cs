using Dominio;
namespace Console
{
    public class Program
    {

        static void Main(string[] args)
        {

            // Inicio de program
            Sistema sistema = Sistema.sistema;
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
                    // case 5:
                    //      sistema.ListarTodasLasTareas();
                    //      break;
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


        // -------------------------------

        // Funcion de Menu
        static void MostrarMenu()
        {
            List<string> menu = new List<string> {
                "1. Listar Animales",
                "2. Potreros Segun Cantidad de Hectareas y Cantidad de Animales",
                "3. Establecer por Kilogramo de Lana ",
                "4. Agregar Bovino",
                // "5. Listar Todas las Tareas",
                "0. Salir ",

            };

            foreach (string opcion in menu)
            {
                System.Console.WriteLine(opcion);
            }
        }


        //Funcion que agraga bovinos
        private static void AgregarBovino(Sistema sistema)
        {
            try
            {
                TipoAlimentacion alimentacion = (TipoAlimentacion)PedirNumero("Ingrese el tipo de alimentacion (1. Pasto, 2. Balanceado 3. Mixto)");
                double peso = PedirNumero("Ingrese el peso por kilo");
                TipoGenero genero = (TipoGenero)PedirNumero("Ingrese el genero (1. Macho, 2. Hembra)");
                string raza = PedirPalabra("Ingrese la raza");
                DateTime fechaNacimiento = PedirFecha("Ingrese la fecha de nacimiento (YYYY-MM-DD)");
                double costoAdquisicion = PedirNumero("Ingrese el costo de adquisicion");
                double costoAlimentacion = PedirNumero("Ingrese el costo de alimentacion");
                double pesoActual = PedirNumero("Ingrese el peso actual");
                bool hibrido = PedirBooleano("Es hibrido? (true/false)");
                bool estado = PedirBooleano("Es libre? (true/false)");
                Bovino bovino = new Bovino(alimentacion, peso, genero, raza, fechaNacimiento, costoAdquisicion, costoAlimentacion, pesoActual, hibrido, new List<Vacunacion>(), estado);
                sistema.AgregarAnimal(bovino);
            }
            catch (Exception ex)
            {
                System.Console.WriteLine(ex.Message);
                System.Console.WriteLine("Verifique los datos ingresados");
            }

        }


        //------------------------------
        //Funaciones para pedir al datos al usuario      

        //Funcion para pedir numero al usuario
        static int PedirNumero(string mensaje)
        {
            try
            {
                System.Console.WriteLine(mensaje);
                int numero = int.Parse(System.Console.ReadLine());
                return numero;
            }
            catch (Exception)
            {
                System.Console.WriteLine("El valor ingresado no es valido");
                return PedirNumero(mensaje);
            }
        }


        //Funcion para pedir palabra el usuario
        static string PedirPalabra(string mensaje)
        {
            try
            {
                System.Console.WriteLine(mensaje);
                string palabra = System.Console.ReadLine() ?? string.Empty;
                if (string.IsNullOrEmpty(palabra)) throw new Exception("El valor ingresado no es valido");
                return palabra;
            }
            catch (Exception)
            {
                System.Console.WriteLine("El valor ingresado no es valido");
                return PedirPalabra(mensaje);
            }

        }


        //Funcion para pedir fecha el usuario
        static DateTime PedirFecha(string mensaje)
        {
            try
            {
                System.Console.WriteLine(mensaje);
                DateTime fecha = DateTime.Parse(System.Console.ReadLine());
                return fecha;
            }
            catch (Exception)
            {
                System.Console.WriteLine("El formato ingresado no es valido");
                return PedirFecha(mensaje);
            }

        }


        //Funcion para pedir booleano el usuario
        static bool PedirBooleano(string mensaje)
        {
            try
            {
                System.Console.WriteLine(mensaje);
                bool.TryParse(System.Console.ReadLine(), out bool booleano);
                return booleano;
            }
            catch (Exception)
            {
                System.Console.WriteLine("El valor ingresado no es valido");
                return PedirBooleano(mensaje);
            }

        }
    }
}
