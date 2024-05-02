namespace Dominio
{
	public class Vacunacion : IValidable
	{
		private Vacuna? _tipoVacuna;

		private DateTime _fechaVacunacion;

		private DateTime _fechaVencimiento;

		//Constructor
		public Vacunacion(Vacuna tipoVacuna, DateTime fechaVacunacion)
		{
			_tipoVacuna = tipoVacuna;
			_fechaVacunacion = fechaVacunacion;
			// _fechaVencimiento 
		}

		//Funcion Validar() que valida los datos ingresados por el usuario
		public void Validar()
		{
			if (_tipoVacuna == null) throw new Exception("La vacunacion debe tener un tipo de vacuna");

			if (_fechaVacunacion > _fechaVencimiento) throw new Exception("La fecha de vacunacion no puede ser mayor a la fecha de vencimiento");

		}

		public override string ToString()
		{
			return $"Tipo de vacuna: {_tipoVacuna}, Fecha de vacunacion: {_fechaVacunacion}, Fecha de vencimiento: {_fechaVencimiento}";
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