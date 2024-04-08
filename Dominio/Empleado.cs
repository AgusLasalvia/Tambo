namespace Obligatorio
{
    internal class Empleado 
    {
        // Atributos
        private string _email;
        private string _password;
        private string _nombre;
        private DateTime _fechaIngreso;


        // Constructor
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

    }
}