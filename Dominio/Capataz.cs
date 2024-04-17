
namespace Dominio
{
    class Capataz : Empleado, IValidable
    {   
        // Atributos
        private int _cantPersonasACargo;


        // Constructor
        public Capataz(string email, string password, string nombre, int cantidadP, DateTime fechaIngreso) : base(email, password, nombre, fechaIngreso)
        {
            _cantPersonasACargo = cantidadP;

        }

        // Metodos de clase
        public  override void Validar(){
			base.Validar();
			if (_cantPersonasACargo == 0) throw new Exception("El capataz debe tener una cantidad de personas a cargo");
		}
    }
}