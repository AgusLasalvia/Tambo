namespace Dominio;

public class Sistema
{
	
	public static Sistema? s_instancia = null;
	private List<Animal>? _animales = new List<Animal>();
	private List<Potrero>? _potreros = new List<Potrero>();
	private List<Vacuna>? _vacunas = new List<Vacuna>();

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

    public void AgregarAnimal(Animal animal)
    {
        _animales?.Add(animal);
    }

    public void AgregarPotrero(Potrero potrero)
    {
        _potreros?.Add(potrero);
    }

    public void AgregarVacuna(Vacuna vacuna)
    {
        _vacunas?.Add(vacuna);
    }



}
