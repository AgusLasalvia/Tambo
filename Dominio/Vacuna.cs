namespace Dominio
{

    public class Vacuna: IValidable
    {
        private string _nombre;
        private string _descripcion;
        private string _patogenoPreviene;


        public Vacuna(string nombre, string descripcion, string patogenoPreviene)
        {
            _nombre = nombre;
            _descripcion = descripcion;
            _patogenoPreviene = patogenoPreviene;
        }

        public void Validar(){
            if (string.IsNullOrEmpty(_nombre)) throw new Exception("La vacuna debe tener un nombre");

            if (string.IsNullOrEmpty(_descripcion)) throw new Exception("La vacuna debe tener una descripcion");

            if (string.IsNullOrEmpty(_patogenoPreviene)) throw new Exception("La vacuna debe tener un patogeno que previene");
        }
    }
}