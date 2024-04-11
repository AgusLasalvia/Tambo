namespace Dominio;

public class Sistema
{
	
	private static Sistema s_instancia;
	private List<Animal> _animales;
	private List<Potrero> _potreros;
	private List<Vacuna> _vacunas;
	private List<Empleado> _empleados;

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


	private PrecargarPeones()
	{
		Peon[] peones = new Peon[]
		{
			new Peon("juan.garcia23@gmail.com", "password1", DateTime.Parse("2023-03-15"), true, null),
			new Peon("maria.lopez78@hotmail.com", "password2", DateTime.Parse("2023-05-20"), false, null),
			new Peon("jose.perez45@yahoo.com", "password3", DateTime.Parse("2023-07-10"), true, null),
			new Peon("ana.martinez92@outlook.com", "password4", DateTime.Parse("2023-08-22"), false, null),
			new Peon("carlos.fernandez31@example.com", "password5", DateTime.Parse("2023-10-05"), true, null),
			new Peon("laura.sanchez67@gmail.com", "password6", DateTime.Parse("2023-11-18"), false, null),
			new Peon("pedro.ramirez10@hotmail.com", "password7", DateTime.Parse("2023-12-30"), true, null),
			new Peon("sofia.gonzalez84@yahoo.com", "password8", DateTime.Parse("2024-01-08"), false, null),
			new Peon("luis.torres57@example.com", "password9", DateTime.Parse("2024-02-14"), true, null),
			new Peon("elena.garcia89@gmail.com", "password10", DateTime.Parse("2024-03-29"), false, null)
		}

	}

	private PrecargarVacunas() { }

	private PrecargarPotreros() { }

	private PrecargarAnimales() { }



}
