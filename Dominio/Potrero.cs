namespace Dominio
{
	public class Potrero : IComparable<Potrero>, IValidable
	{
		private int _id;
		private static int s_ultId = 1;
		private string _descripcion;
		private int _cantidadHectareas;
		private int _cantidadMaxAnimales;
		private int _cantidadAnimalesPastan;
		private double _posiblePrecioVenta = 0;

		private List<Animal>? _animales;

		public double PosiblePrecioVenta
		{
			get
			{
				return _posiblePrecioVenta;
			}
		}
		public int Id { get { return _id; } }
		public int CantidadHectareas
		{
			get { return _cantidadHectareas; }
		}

		public string Descripcion
		{
			get { return _descripcion; }
		}

		public int CantidadAnimalesPastan
		{
			get { return _cantidadAnimalesPastan; }
			set { _cantidadAnimalesPastan = value; }
		}

		public int CantidadMaxAnimales
		{
			get { return _cantidadMaxAnimales; }
		}

		public List<Animal>? Animales
		{
			get { return _animales; }
		}

		//Constructor
		public Potrero(string descripcion, int cantidadHectareas, int cantidadMaxAnimales, List<Animal> animales)
		{
			_id = s_ultId;
			s_ultId++;
			_descripcion = descripcion;
			_animales = animales;
			_cantidadHectareas = cantidadHectareas;
			_cantidadMaxAnimales = cantidadMaxAnimales;
		}
		//Funcion para validar los datos ingresados por el usuario
		public void Validar()
		{
			if (string.IsNullOrEmpty(_descripcion)) throw new Exception("El portero debe tener una descripcion");

			if (_cantidadHectareas == 0) throw new Exception("El portero debe tener una cantidad de hectareas");

			if (_cantidadMaxAnimales == 0) throw new Exception("El portero debe tener una cantidad maxima de animales");

			if (_cantidadAnimalesPastan == 0) throw new Exception("El portero debe tener una cantidad de animales pastan");

			if (_animales == null) throw new Exception("El portero debe tener una lista de animales");

		}

		//Función la cual agreara un animal a la lista de animales
		public void AgregarAnimal(Animal animal)
		{
			if (_animales?.Count <= _cantidadMaxAnimales)
			{
				_animales.Add(animal);
				_cantidadAnimalesPastan = _animales.Count;

			}
			else
			{
				throw new Exception("No se pueden agregar mas animales al portero");
			}
		}

		//Funcion Validar() que valida los datos ingresados por el usuario 
		public override string ToString()
		{
			return $"Potrero: {_descripcion} - Hectareas: {_cantidadHectareas} - MaxAnimales: {_cantidadMaxAnimales} - AnimalesPastan: {_cantidadAnimalesPastan}";
		}

		public override bool Equals(object? obj)
		{
			return base.Equals(obj);
		}

		public int CompareTo(Potrero other)
		{
			int comparacion = this._cantidadMaxAnimales.CompareTo(other?._cantidadMaxAnimales);

			if (comparacion == 0)
			{
				comparacion = this._cantidadAnimalesPastan.CompareTo(other?._cantidadAnimalesPastan) * -1;
			}

			return comparacion;
		}

		public double PosiblePrecioVentaPotrero()
		{
			foreach (Animal a in _animales)
			{
				_posiblePrecioVenta += a.CalcularGanancia();
			}

			return _posiblePrecioVenta;
		}
	}
}
