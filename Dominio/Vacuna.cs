namespace Dominio
{

    public class Vacuna : IValidable
    {
        private string _nombre;
        private string _descripcion;
        private string _patogenoPreviene;


        //Constructor
        public Vacuna(string nombre, string descripcion, string patogenoPreviene)
        {
            _nombre = nombre;
            _descripcion = descripcion;
            _patogenoPreviene = patogenoPreviene;
        }


        //Funcion Validar() que valida los datos ingresados por el usuario
        public void Validar()
        {
            if (string.IsNullOrEmpty(_nombre)) throw new Exception("La vacuna debe tener un nombre");

            if (string.IsNullOrEmpty(_descripcion)) throw new Exception("La vacuna debe tener una descripcion");

            if (string.IsNullOrEmpty(_patogenoPreviene)) throw new Exception("La vacuna debe tener un patogeno que previene");
        }

        public override string ToString()
        {
            return "Nombre: " + _nombre + " Descripcion: " + _descripcion + " Patogeno que previene: " + _patogenoPreviene;
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