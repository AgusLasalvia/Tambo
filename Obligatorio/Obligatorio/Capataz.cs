
namespace Obligatorio
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
        public void Validar(){}
    }
}