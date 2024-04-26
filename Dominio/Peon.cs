
namespace Dominio
{
    class Peon : Empleado, IValidable
    {   
        // Atributos 
        private bool _reside;
        private List<Tarea> _tareas;


        // Constructor
        public Peon(bool reside, string email, string password, string nombre, DateTime fechaIngreso) : base(email, password, nombre, fechaIngreso)
        {   
            _reside = reside;
            _tareas = new List<Tarea>(); // Genera una lista pero vacia
        }


        public override string ToString()
        {
            return base.ToString() + " Reside: " + _reside.ToString() + " Tareas: " + _tareas.Count.ToString();
        }


        // Metodos de clase
        public override void Validar(){
			base.Validar();
			if (_tareas == null) throw new Exception("El peon debe tener una lista de tareas");
		}
		
    }
}