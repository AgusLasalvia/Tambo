namespace Obligatorio{
    internal class Portero : IValidable {
        private int _id ;
        private int s_ultId = 0;
        private string _descripcion;
        private int _cantidadHectareas;
        private int _cantidadMaxAnimales;
        private int _cantidadAnimalesPastan;
        private List<Animal> _animales;

        public Portero(string descripcion, int cantidadHectareas, int cantidadMaxAnimales, int cantidadAnimalesPastan, List<Animales> animales) 
        {
            _id = s_ultId;
            s_ultId ++;
            _descripcion = descripcion;
            _animales = animales;
            _cantidadHectareas = cantidadHectareas;
            _cantidadMaxAnimales = cantidadMaxAnimales;
            _cantidadAnimalesPastan = cantidadAnimalesPastan;
            _animales = animales;
        }
        



    }
}