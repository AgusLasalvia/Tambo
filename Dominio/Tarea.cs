namespace Dominio
{
	// Clase Tarea
	public class Tarea : IValidable, IComparable<Tarea>
	{
		// Propiedades de clase Tarea
		private int _id = 0;
		private static int s_ultimoId = 0;
		private string _descripcion;

		private DateTime _fechaPactada;

		private bool _estado;
		private DateTime _fechaCierre;
		private string _comentario;


		public string Descripcion
		{
			get { return _descripcion; }
		}

		public DateTime FechaPactada
		{
			get { return _fechaPactada; }
		}


		public DateTime FechaCierre
		{
			get { return _fechaCierre; }
			set { _fechaCierre = value; }
		}

		public string Comentario
		{
			get { return _comentario; }
            set { _comentario = value; }
		}

		public bool Estado
		{
			get { return _estado; }
			set { _estado = value; }
		}

		public int Id{
			get { return _id; }
		}

		// Constructor de la clase Tarea
		public Tarea(string descripcion, DateTime fechaPactada, bool estado, DateTime fechaCierre, string comentario)
		{
			s_ultimoId++;
			_id = s_ultimoId;
			_descripcion = descripcion;
			_fechaPactada = fechaPactada;
			_estado = estado;
			_fechaCierre = fechaCierre;
			_comentario = comentario;
		}

		// Metodo para Validar los datos de la clase Tarea
		public void Validar()
		{
			if (string.IsNullOrEmpty(_descripcion)) throw new Exception("La tarea debe tener una descripcion");

			if (_fechaPactada == DateTime.MinValue) throw new Exception("La tarea debe tener una fecha pactada");

			if (_fechaCierre == DateTime.MinValue) throw new Exception("La tarea debe tener una fecha de cierre");

			if (_fechaCierre < _fechaPactada) throw new Exception("La fecha de cierre no puede ser anterior a la fecha pactada");

			if (string.IsNullOrEmpty(_comentario)) throw new Exception("La tarea debe tener un comentario");
		}


		// Metodo para obtener todos 
		public override string ToString()
		{
			return $"ID: {_id}, Descripcion: {_descripcion}, Plazo: {_fechaPactada} a {_fechaCierre}, Comentario: {_comentario} Estado: {_estado}";
		}

		public override bool Equals(object? obj)
		{
			return base.Equals(obj);
		}

		public int CompareTo(Tarea other)
		{
			return this._fechaPactada.CompareTo(other._fechaPactada);
		}
	}
}
