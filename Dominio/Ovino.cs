namespace Dominio
{
	internal class Ovino : Animal
	{
		private static double _precioLana = 0.0;
		private static double _precioOvino = 0.0;
		private double _pesoKilo;

		private double _ganancia;

		public static double PrecioLana {
			set{
				if(value != 0 && value >= 0){
					_precioLana = value;
				}
			}
		}

		public static double PrecioOvino{
			set{
				if(value != 0 && value >= 0){
					_precioOvino = value;
				}
			}
		}

		public Ovino(double pesoKilo, TipoGenero genero, string raza, DateTime fechaNacimiento, double costoAdquisicion,
					double costoAlimentacion, double pesoActual, bool hibrido, List<Vacunacion> vacunas, bool estado)
					:
					base(genero, raza, fechaNacimiento, costoAdquisicion, costoAlimentacion, pesoActual, hibrido, vacunas, estado)
		{
			_pesoKilo = pesoKilo;
		}

		public double CalcularGanancia()
		{
			return _ganancia;
		}

		public override void Validar()
		{
			base.Validar();
			if (_pesoKilo == 0) throw new Exception("El ovino debe tener un peso por kilo");
		}
	}
}