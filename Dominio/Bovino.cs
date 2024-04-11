namespace Dominio
{
	internal class Bovino : Animal, IValidable
	{
		private TipoAlimentacion _tipoAlimentacion;
		private static double _pesoKilo;

		private double _ganancia;
        

		public Bovino(TipoAlimentacion tipoAliemntacion, double pesoKilo, TipoGenero genero, string raza, DateTime fechaNacimiento, double costoAdquisicion,
					double costoAlimentacion, double pesoActual, bool hibrido, List<Vacunacion> vacunas, bool estado)
					:
					base(genero, raza, fechaNacimiento, costoAdquisicion, costoAlimentacion, pesoActual, hibrido, vacunas, estado)
		{
			_pesoKilo = pesoKilo;
			_tipoAlimentacion = tipoAliemntacion;
		}

		public double CalcularGanancia()
		{
			_ganancia = 0;

			return _ganancia;
		}

		public new void Validar()
		{
			base.Validar();
			if (_pesoKilo == 0) throw new Exception("El bovino debe tener un peso por kilo");
	
		}

	}
}