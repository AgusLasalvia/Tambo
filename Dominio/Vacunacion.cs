namespace Dominio
{
	public class Vacunacion : IValidable
	{
		private Vacuna? _tipoVacuna;

		private DateTime _fechaVacunacion;

		private DateTime _fechaVencimiento;


		public Vacunacion(Vacuna tipoVacuna, DateTime fechaVacunacion)
		{
			_tipoVacuna = tipoVacuna;
			_fechaVacunacion = fechaVacunacion;
			// _fechaVencimiento 
		}


		public void Validar()
		{
			if (_tipoVacuna == null) throw new Exception("La vacunacion debe tener un tipo de vacuna");

			if (_fechaVacunacion > _fechaVencimiento) throw new Exception("La fecha de vacunacion no puede ser mayor a la fecha de vencimiento");

		}

	}

}