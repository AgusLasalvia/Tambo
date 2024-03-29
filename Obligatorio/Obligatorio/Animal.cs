namespace Obligatorio{
    internal class Animal: IValidable{

        private string _id;
        private string _genero;

        private string _raza;
        private DateTime _fechaNacimiento;
        private double _costoAdquisicion;
        private double _costoAlimentacion;
        private double _pesoActual;
        private bool _hibrido;
        private List<Vacuna> _vacunas;
        private bool _estado;

        public Animal(string genero, string raza, DateTime fechaNacimiento, double costoAdquisicion, double costoAlimentacion, double pesoActual, bool hibrido, List<Vacuna> vacunas, bool estado)
        {
            _id = GenerarNuevoId();
            _genero = genero;
            _raza = raza;
            _fechaNacimiento = fechaNacimiento;
            _costoAdquisicion = costoAdquisicion;
            _costoAlimentacion = costoAlimentacion;
            _pesoActual = pesoActual;
            _hibrido = hibrido;
            _vacunas = vacunas;
            _estado = estado;
        }

        private string GenerarNuevoId()
        {
            string caracteres = "1234567890ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            string codigo = "";
            Random random = new Random();
            for (int i = 0; i < 8; i++)
            {
                int nrand = random.Next(0, caracteres.Length - 1);
                codigo += caracteres[nrand];
            }
            return codigo;

        }

        public void Validar(){
            if (string.IsNullOrEmpty(_genero)) throw new Exception("El animal debe tener un genero");

            if (string.IsNullOrEmpty(_raza)) throw new Exception("El animal debe tener una raza");

            if (_fechaNacimiento == DateTime.MinValue) throw new Exception("El animal debe tener una fecha de nacimiento");

            if (_costoAdquisicion == 0) throw new Exception("El animal debe tener un costo de adquisicion");

            if (_costoAlimentacion == 0) throw new Exception("El animal debe tener un costo de alimentacion");

            if (_pesoActual == 0) throw new Exception("El animal debe tener un peso actual");

            if (_vacunas.Count == 0) throw new Exception("El animal debe tener al menos una vacuna");}

    }



}