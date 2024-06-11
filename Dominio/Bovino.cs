namespace Dominio
{
	// Clase Hija de Animal
	// Clase Bovino
	public class Bovino : Animal, IValidable
	{
		//  Propiedades de la clase Bovino
		private TipoAlimentacion _tipoAlimentacion;
		private static double _precioKilo = 0;

		public double Ganancia
		{
			get
			{
                return _ganancia;
            }
            set{
                _ganancia = value;
            }
        }

		public double PrecioKilo
		{
			set { _precioKilo = value; }
		}

		//  Constructor de la clase Bovino
		public Bovino(TipoAlimentacion tipoAliemntacion, TipoGenero genero, string raza, DateTime fechaNacimiento, double costoAdquisicion, double costoAlimentacion, double pesoActual, bool hibrido, List<Vacunacion> vacunas, bool estado)
					:
					base(genero, raza, fechaNacimiento, costoAdquisicion, costoAlimentacion, pesoActual, hibrido, vacunas, estado)
		{
			_tipoAlimentacion = tipoAliemntacion;
		}




		public override void Validar()
		{
			base.Validar();

		}

		public override string ToString()
		{
			return base.ToString() + " Tipo de alimentacion: " + _tipoAlimentacion.ToString() + " Peso por kilo: " + _precioKilo.ToString() + " Ganancia: " + _ganancia.ToString();
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
			return "Bovino";
		}

		public override double CalcularGanancia()
		{
			_ganancia = base.CalcularGanancia();
			_ganancia += _precioKilo * _pesoActual;
			if (_tipoAlimentacion == TipoAlimentacion.Grano) _ganancia += _ganancia * 0.30;
			if (_genero == TipoGenero.Hembra) _ganancia += _ganancia * 0.10;

			return _ganancia;
		}
	}
}