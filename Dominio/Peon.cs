
namespace Obligatorio
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


        // Metodos de clase
        public void Validar(){}
    }
}