namespace Dominio
{
	// Clase hija
	// Hereda de la clase Animal
	// Clase Ovino
	public class Ovino : Animal
	{

		// Propiedades de clase Ovino
		private static double _precioLana = 0.0;
		private static double _precioOvino = 0.0;
		private double _pesoKilo;


		// Setter de la propiedad PrecioLana
		public static double PrecioLana
		{
			set
			{
				if (value != 0 && value >= 0)
				{
					_precioLana = value;
				}
			}
		}

		// Setter de la propiedad PrecioOvino
		public static double PrecioOvino
		{
			set
			{
				if (value != 0 && value >= 0)
				{
					_precioOvino = value;
				}
			}
		}

		// Constructor de la clase Ovino
		public Ovino(double pesoKilo, TipoGenero genero, string raza, DateTime fechaNacimiento, double costoAdquisicion, double costoAlimentacion, double pesoActual, bool hibrido, List<Vacunacion> vacunas, bool estado)
					:
					base(genero, raza, fechaNacimiento, costoAdquisicion, costoAlimentacion, pesoActual, hibrido, vacunas, estado)
		{
			_pesoKilo = pesoKilo;
		}


		// Metodo para Validar datos del Ovino
		public override void Validar()
		{
			base.Validar();
			if (_pesoKilo == 0) throw new Exception("El ovino debe tener un peso por kilo");
		}


		// Metodo para mostrar los datos de un ovino
		public override string ToString()
		{
			return base.ToString();
		}

		public override bool Equals(object? obj)
		{
			return base.Equals(obj);
		}

		public override int GetHashCode()
		{
			return base.GetHashCode();
		}

		public override string GetTipo()
		{
			return "Ovino";
		}

		public override double CalcularGanancia()
		{
			_ganancia = base.CalcularGanancia();
			_ganancia += (_pesoKilo * _precioLana) + (_precioOvino * _pesoActual);
			if (_hibrido) _ganancia *= 0.95;
			return _ganancia;
		}
	}
}
