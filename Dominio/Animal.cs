namespace Dominio
{
    // Clase abstracta Animal
    public abstract class Animal : IValidable
    {
        // Atributos de la clase Animal
        protected string _id;
        protected TipoGenero _genero;
        protected string _raza;
        protected DateTime _fechaNacimiento;
        protected double _costoAdquisicion;
        protected double _costoAlimentacion;
        protected double _pesoActual;
        protected bool _hibrido;
        protected double _ganancia = 0;
        protected List<Vacunacion>? _vacunas;
        protected bool _estado;

        public string Id
        {
            get
            {
                return _id;
            }
        }

        public double PesoActual
        {
            get { return _pesoActual; }
        }

        public TipoGenero Genero
        {
            get { return _genero; }
        }

        public bool Estado
        {
            get
            {
                return _estado;
            }
            set{
                _estado = value;
            }
        }

        public double CostoAdquisicion
        {
            get
            {
                return _costoAdquisicion;
            }
        }

        public double Ganancia
        {
            get
            {
                return _ganancia;
            }
        }

        // Constructor de la clase Animal
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


        // Funcino para generar un nuevo ID
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

        public void AgregarVacunacion(Vacuna vacuna){
            _vacunas?.Add(new Vacunacion(vacuna));
        }


        // Funcion para Validar los datos del animal
        public virtual void Validar()
        {
            if (!Enum.IsDefined(typeof(TipoGenero), _genero)) throw new Exception("El animal debe tener un genero");

            if (string.IsNullOrEmpty(_raza)) throw new Exception("El animal debe tener una raza");

            if (_fechaNacimiento == DateTime.MinValue && _fechaNacimiento > DateTime.Today) throw new Exception("El animal debe tener una fecha de nacimiento");

            if (_costoAdquisicion == 0 && _costoAdquisicion > 0) throw new Exception("El animal debe tener un costo de adquisicion");

            if (_costoAlimentacion == 0 && _costoAlimentacion > 0) throw new Exception("El animal debe tener un costo de alimentacion");

            if (_pesoActual == 0 && _pesoActual > 0) throw new Exception("El animal debe tener un peso actual");

            // if (_vacunas?.Count ==q 0) throw new Exception("El animal debe tener al menos una vacuna");

        }

        // Funcion para obtener los datos del animal en formato string
        public override string ToString()
        {
            return $"ID: {_id}, Raza: {_raza}, Peso Actual: {_pesoActual}, Genero: {_genero} ";
        }

        public override bool Equals(object? obj)
        {
            return base.Equals(obj);
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }


        public abstract string GetTipo();

        public virtual double CalcularGanancia()
        {
            _ganancia = _costoAdquisicion + _costoAlimentacion + (200 * _vacunas.Count);
            return _ganancia;
        }
    }
}