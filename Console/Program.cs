using Dominio;

namespace Console
{
	public class Program
	{
		static void Main(string[] args)
		{
			Sistema sistema = new Sistema();
			bool exit = false;
			while (!exit)
			{
				System.Console.Clear();
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

		static void AgregarOvino(){
			
		}

		static int PedirNumero(string mensaje)
		{
			System.Console.WriteLine(mensaje);
			int.TryParse(System.Console.ReadLine(), out int numero);
			return numero;
		}

		static string PedirPalabra(string mensaje)
		{
			System.Console.WriteLine(mensaje);
			return System.Console.ReadLine();
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
			bool.TryParse(System.Console.ReadLine(), out bool booleano);
			return booleano;
		}
	}
}
