namespace Dominio
{
    public class Vacunacion : IValidable
    {
        private string? _animalVacunado;
        private Vacuna? _tipoVacuna;

        private DateTime _fechaVacunacion;

        private static DateTime _fechaVencimiento;


        public Vacunacion(string animalVacunado, Vacuna tipoVacuna, DateTime fechaVacunacion, DateTime fechaVencimiento)
        {
            _animalVacunado = animalVacunado;
            _tipoVacuna = tipoVacuna;
            _fechaVacunacion = fechaVacunacion;
            _fechaVencimiento = fechaVencimiento;
        }


        public void Validar()
        {
            if (string.IsNullOrEmpty(_animalVacunado)) throw new Exception("La vacunacion debe tener un animal vacunado");

            if (_tipoVacuna == null) throw new Exception("La vacunacion debe tener un tipo de vacuna");

            if (_fechaVacunacion > _fechaVencimiento) throw new Exception("La fecha de vacunacion no puede ser mayor a la fecha de vencimiento");

        }

    }

}