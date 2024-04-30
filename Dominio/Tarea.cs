namespace Dominio
{
    public class Tarea : IValidable
    {
        private int _id = 0;
        private static int s_ultimoId = 0;
        private string? _descripcion;

        private DateTime _fechaPactada;

        private bool _estado;
        private DateTime _fechaCierre;
        private string? _comentario;


        public Tarea(string descripcion, DateTime fechaPactada, bool estado, DateTime fechaCierre, string comentario)
        {
            s_ultimoId++;
            _id = s_ultimoId;
            _descripcion = descripcion;
            _fechaPactada = fechaPactada;
            _estado = estado;
            _fechaCierre = fechaCierre;
            _comentario = comentario;
        }

        public void Validar()
        {
            if (string.IsNullOrEmpty(_descripcion)) throw new Exception("La tarea debe tener una descripcion");

            if (_fechaPactada == DateTime.MinValue) throw new Exception("La tarea debe tener una fecha pactada");

            if (_fechaCierre == DateTime.MinValue) throw new Exception("La tarea debe tener una fecha de cierre");

            if (_fechaCierre < _fechaPactada) throw new Exception("La fecha de cierre no puede ser anterior a la fecha pactada");

            if (_estado == null) throw new Exception("La tarea debe tener un estado");

            if (string.IsNullOrEmpty(_comentario)) throw new Exception("La tarea debe tener un comentario");
        }

        public override string ToString()
        {
            return $"ID: {_id}, Descripcion: {_descripcion}, Plazo: {_fechaPactada} a {_fechaCierre}, Comentario: {_comentario}";
        }


    }
}
