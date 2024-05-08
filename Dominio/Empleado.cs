namespace Dominio
{
	// Clase padre Abstracta Empleado
	public abstract class Empleado : IValidable
	{
		// Atributos de clase
		protected string _email;
		protected string _password;
		protected string _nombre;
		protected DateTime _fechaIngreso;


		// Propiedades de clase
		public string Email
		{
			get { return _email; }
		}

		public string Password
		{
			get { return _password; }
		}

		public string Nombre
		{
			get { return _nombre; }
		}

		public DateTime FechaIngreso
		{
			get { return _fechaIngreso; }
		}

		// Constructor de clase
		public Empleado(string email, string password, string nombre, DateTime fechaIngreso)
		{
			_email = email;
			_password = password;
			_nombre = nombre;
			_fechaIngreso = fechaIngreso;
		}



		// Metodos de clase 
		public override string ToString()
		{
			return "Nombre: " + _nombre + " Email: " + _email + " Fecha de ingreso: " + _fechaIngreso.ToString("dd/MM/yyyy");
		}

		// Metodos de clase para Validar datos del animal
		public virtual void Validar()
		{
			if (string.IsNullOrEmpty(_email)) throw new Exception("El empleado debe tener un email");

			if (string.IsNullOrEmpty(_password)) throw new Exception("El empleado debe tener un password");

			if (string.IsNullOrEmpty(_nombre)) throw new Exception("El empleado debe tener un nombre");

			if (_fechaIngreso == DateTime.MinValue) throw new Exception("El empleado debe tener una fecha de ingreso");
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