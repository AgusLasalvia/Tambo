
namespace Dominio
{
	class Peon : Empleado, IValidable
	{
		// Atributos 
		private bool _reside;
		private List<Tarea>? _tareas;


		public List<Tarea> Tareas
		{
			get { return _tareas; }
		}

		public bool Reside
		{
			get { return _reside; }
		}

		// Constructor
		public Peon(bool reside, string email, string password, string nombre, DateTime fechaIngreso) : base(email, password, nombre, fechaIngreso)
		{
			_reside = reside;
			_tareas = new List<Tarea>(); // Genera una lista pero vacia
		}



		public void AgregarTarea(Tarea tarea)
		{
			_tareas.Add(tarea);
		}





		//Funcion que sobre escribe la funcion ToString()
		public override string ToString()
		{
			return base.ToString() + " Reside: " + _reside.ToString() + " Tareas: " + _tareas.Count.ToString();
		}




		//Funcion que sobre escribe la funcion Validar() de su clase padre
		public override void Validar()
		{
			base.Validar();
			if (_tareas == null) throw new Exception("El peon debe tener una lista de tareas");
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