namespace Obligatorio
{
    internal class Bovino : Animal
    {   
        private TipoAlimentacion _tipoAlimentacion;
        private static double _pesoKilo;


        public Bovino(TipoAlimentacion tipoAliemntacion , double pesoKilo, string genero, string raza, DateTime fechaNacimiento, double costoAdquisicion,
                    double costoAlimentacion, double pesoActual, bool hibrido, List<Vacuna> vacunas, bool estado)
                    :
                    base(genero, raza, fechaNacimiento, costoAdquisicion, costoAlimentacion, pesoActual, hibrido, vacunas, estado)
        {
            _pesoKilo = pesoKilo;
            _tipoAlimentacion = tipoAliemntacion;
        }
    }
}