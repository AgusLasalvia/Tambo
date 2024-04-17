namespace Dominio
{
	public class Potrero : IValidable
	{
		private int _id;
		private int s_ultId = 1;
		private string _descripcion;
		private int _cantidadHectareas;
		private int _cantidadMaxAnimales;
		private int _cantidadAnimalesPastan;

		private double _ganancia;
		private List<Animal> _animales;


		public int CantidadHectareas
		{
			get { return _cantidadHectareas; }
		}

		public int CantidadMaxAnimales
		{
			get { return _cantidadMaxAnimales; }
		}


		public Potrero(string descripcion, int cantidadHectareas, int cantidadMaxAnimales, int cantidadAnimalesPastan, List<Animal> animales)
		{

			_id = s_ultId;
			s_ultId++;
			_descripcion = descripcion;
			_animales = animales;
			_cantidadHectareas = cantidadHectareas;
			_cantidadMaxAnimales = cantidadMaxAnimales;
			_cantidadAnimalesPastan = cantidadAnimalesPastan;
			_animales = animales;
		}


		public void Validar()
		{
			if (string.IsNullOrEmpty(_descripcion)) throw new Exception("El portero debe tener una descripcion");

			if (_cantidadHectareas == 0) throw new Exception("El portero debe tener una cantidad de hectareas");

			if (_cantidadMaxAnimales == 0) throw new Exception("El portero debe tener una cantidad maxima de animales");

			if (_cantidadAnimalesPastan == 0) throw new Exception("El portero debe tener una cantidad de animales pastan");

			if (_animales == null) throw new Exception("El portero debe tener una lista de animales");

		}

		public void AgregarAnimal(Animal animal)
		{
			if (_animales.Count <= _cantidadMaxAnimales)
			{
				_animales.Add(animal);
			}
			else
			{
				throw new Exception("No se pueden agregar mas animales al portero");
			}
		}

		public double CalcularGanancia()
		{
			_ganancia = 0;
			foreach (Animal animal in _animales)
			{
				if (animal is Bovino)
				{
					_ganancia += ((Bovino)animal).CalcularGanancia();
				}
				else if (animal is Ovino)
				{
					_ganancia += ((Ovino)animal).CalcularGanancia();
				}
			}
			return _ganancia;
		}




		public override string ToString()
		{
			return $"Potrero: {_descripcion} - Hectareas: {_cantidadHectareas} - MaxAnimales: {_cantidadMaxAnimales} - AnimalesPastan: {_cantidadAnimalesPastan}";
		}
	}
}