namespace Dominio
{
    public class Animal : IValidable
    {

        protected string _id;
        protected TipoGenero _genero;
        protected string _raza;
        protected DateTime _fechaNacimiento;
        protected double _costoAdquisicion;
        protected double _costoAlimentacion;
        protected double _pesoActual;
        protected bool _hibrido;
        protected List<Vacunacion> _vacunas;
        protected bool _estado;

        public Animal(TipoGenero genero, string raza, DateTime fechaNacimiento, double costoAdquisicion, double costoAlimentacion, double pesoActual, bool hibrido, List<Vacunacion> vacunas, bool estado)
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

        private static string GenerarNuevoId()
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

        public void Validar()
        {
            if (!Enum.IsDefined(typeof(TipoGenero), _genero)) throw new Exception("El animal debe tener un genero");

            if (string.IsNullOrEmpty(_raza)) throw new Exception("El animal debe tener una raza");

            if (_fechaNacimiento == DateTime.MinValue) throw new Exception("El animal debe tener una fecha de nacimiento");

            if (_costoAdquisicion == 0) throw new Exception("El animal debe tener un costo de adquisicion");

            if (_costoAlimentacion == 0) throw new Exception("El animal debe tener un costo de alimentacion");

            if (_pesoActual == 0) throw new Exception("El animal debe tener un peso actual");

            if (_vacunas.Count == 0) throw new Exception("El animal debe tener al menos una vacuna");

        }

        public override string ToString()
        {
            return $"ID: {_id}, Raza: {_raza}, Peso Actual: {_pesoActual}, Genero: {_genero} ";
        }



    }



}