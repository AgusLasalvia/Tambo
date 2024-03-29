namespace Obligatorio
{
    internal class Ovinos : Animal
    {
        private static double _precioLana = 0;
        private static double _precioOvino = 0;
        private double _pesoKilo;


        public Ovinos(double pesoKilo, string genero, string raza, DateTime fechaNacimiento, double costoAdquisicion,
                    double costoAlimentacion, double pesoActual, bool hibrido, List<Vacuna> vacunas, bool estado)
                    :
                    base(genero, raza, fechaNacimiento, costoAdquisicion, costoAlimentacion, pesoActual, hibrido, vacunas, estado)
        {
            _pesoKilo = pesoKilo;
        }
    }
}