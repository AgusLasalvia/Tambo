namespace Dominio;

public class Sistema
{
	
	private static Sistema? s_instancia = null;
	private List<Animal> _animales = new List<Animal>();
	private List<Potrero> _potreros = new List<Potrero>();
	private List<Vacuna> _vacunas = new List<Vacuna>();

	private List<Empleado>? _empleados = new List<Empleado>();

    public Sistema sistema
    {
        get
        {
            if (s_instancia == null)
            {
                s_instancia = new Sistema();
            }
            return s_instancia;
        }
    }


	public Sistema()
	{
		PreCarga();
	}
	public void ListarTodosLosAnimales()
	{
		foreach (Animal animal in _animales)
		{
			Console.WriteLine(animal.ToString());
			
		}
	}

	public void AgregarAnimal(Animal animal){
		if(!_animales.Contains(animal)){
			_animales.Add(animal);
		}
		else{
			throw new Exception("El animal ya existe");
		}	
	}

    public void AgregarPotrero(Potrero potrero)
    {
		potrero.Validar();
        _potreros?.Add(potrero);
    }

    public void AgregarVacuna(Vacuna vacuna)
    {
		vacuna.Validar();
        _vacunas?.Add(vacuna);
    }

	public void PotreroEspecifico(){
		int cantHectareas = PedirNumero("Ingrese la cantidad de hectareas");
		int cantPotrero = PedirNumero("Ingrese la cantidad de potreros");
		PotreroSegunHectareaYPotrero(cantHectareas, cantPotrero);
	}
	public void PotreroSegunHectareaYPotrero(int cantHectareas, int cantPotrero){
		foreach(Potrero potrero in _potreros){
			if(potrero.CantidadHectareas == cantHectareas && potrero.CantidadMaxAnimales == cantPotrero){
				Console.WriteLine(potrero.ToString());
			}
		}

	}


	public void CambiarPrecioLana(){
		double precioLana = PedirNumero("Ingrese el precio de la lana");
		Ovino.PrecioLana = precioLana;
	
	}
	public int PedirNumero(string mensaje)
	{
		System.Console.WriteLine(mensaje);
		int.TryParse(Console.ReadLine(), out int numero);
		return numero;
	}

	



	private void PreCarga(){
			 
	}

}
