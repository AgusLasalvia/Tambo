
namespace Dominio
{
    public class Capataz : Empleado, IValidable
    {
        // Atributos
        private int _cantPersonasACargo;


        // Constructor
        public Capataz(string email, string password, string nombre, int cantidadP, DateTime fechaIngreso) : base(email, password, nombre, fechaIngreso)
        {
            _cantPersonasACargo = cantidadP;

        }


        //Funcion que sobre escribe la funcion ToString
        public override string ToString()
        {
            return base.ToString() + " Cantidad de personas a cargo: " + _cantPersonasACargo.ToString();
        }



        //Funcion que sobre escribe la funcion Validar() de su clase padre
        public override void Validar()
        {
            base.Validar();
            if (_cantPersonasACargo == 0) throw new Exception("El capataz debe tener una cantidad de personas a cargo");
        }

        public override bool Equals(object? obj)
        {
            return base.Equals(obj);
        }

        // public override int GetHashCode()
        // {
        //     return base.GetHashCode();
        // }

        public override string GetTipo()
        {
            return "Capataz";
        }
    }
}