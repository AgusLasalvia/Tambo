namespace Dominio
{
	// Clase Hija de Animal
	// Clase Bovino
	public class Bovino : Animal, IValidable
	{
		//  Propiedades de la clase Bovino
		private TipoAlimentacion _tipoAlimentacion;
		private static double _pesoKilo = 0;

		private double _ganancia;
        public double Ganancia{
            get{
                return _ganancia;
            }
            set{
                _ganancia = value;
            }
        }

		public double PesoKilo
		{
			set { _pesoKilo = value; }
		}

		//  Constructor de la clase Bovino
		public Bovino(TipoAlimentacion tipoAliemntacion, TipoGenero genero, string raza, DateTime fechaNacimiento, double costoAdquisicion, double costoAlimentacion, double pesoActual, bool hibrido, List<Vacunacion> vacunas, bool estado)
					:
					base(genero, raza, fechaNacimiento, costoAdquisicion, costoAlimentacion, pesoActual, hibrido, vacunas, estado)
		{
			_tipoAlimentacion = tipoAliemntacion;
		}

		public double CalcularGanancia()
		{
			_ganancia = 0;

			return _ganancia;
		}


		public override void Validar()
		{
			base.Validar();

		}

		public override string ToString()
		{
			return base.ToString() + " Tipo de alimentacion: " + _tipoAlimentacion.ToString() + " Peso por kilo: " + _pesoKilo.ToString() + " Ganancia: " + _ganancia.ToString();
		}

		public override bool Equals(object? obj)
		{
			return base.Equals(obj);
		}

		public override int GetHashCode()
		{
			return base.GetHashCode();
		}
	}
}