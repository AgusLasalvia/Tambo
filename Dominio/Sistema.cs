namespace Dominio;
// Clase Principal del Sistema
public class Sistema
{
	// Listas de Objetos para el Sistema
	private static Sistema? s_instancia = null;
	private List<Animal> _animales = new List<Animal>();
	private List<Potrero> _potreros = new List<Potrero>();
	private List<Vacuna> _vacunas = new List<Vacuna>();
	private List<Empleado> _empleados = new List<Empleado>();

	// Getter de Sistema
	public static Sistema sistema
	{
		get
		{
			s_instancia ??= new Sistema(); // Si s_instancia es null, crea una nueva instancia de Sistema
			return s_instancia; // Retorna la instancia de Sistema
		}
	}

	// Constructor de Sistema
	public Sistema()
	{
		PreCarga();
		UpdateAnimals();
	}

	// Login de Usarios
	public bool Login(string email, string password)
	{
		foreach (Empleado empleado in _empleados)
		{
			if (empleado.Email == email && empleado.Password == password) return true;
		}
		throw new Exception("Usuario o contraseña incorrectos");
	}



	// Método para Listar los Animales
	public void ListarTodosLosAnimales()
	{
		foreach (Animal animal in _animales)
		{
			Console.WriteLine(animal.ToString());

		}
	}


	// public void ListarTodasLasTareas()
	// {
	//     foreach (Tarea t in _tareas)
	//     {
	//         Console.WriteLine(t.ToString());

	//     }
	// }


	// Metodo para agregar Animal al sistema
	public void AgregarAnimal(Animal animal)
	{
		if (!_animales.Contains(animal))
		{
			animal.Validar();
			_animales.Add(animal);
		}
		else
		{
			throw new Exception("El animal ya existe");
		}
	}


	// Metodo para agregar Potrero al sistema
	public void AgregarPotrero(Potrero potrero)
	{
		potrero.Validar();
		_potreros?.Add(potrero);
	}


	// Metodo para agregar Vacuna al sistema
	public void AgregarVacuna(Vacuna vacuna)
	{
		vacuna.Validar();
		_vacunas?.Add(vacuna);
	}

	// Metodo para recivir una lista especifica de Potreros
	public List<Potrero> PotreroEspecifico()
	{
		int cantHectareas = PedirNumero("Ingrese la cantidad de hectareas");
		int cantPotrero = PedirNumero("Ingrese la cantidad maxima de animales");
		return PotreroSegunHectareaYPotrero(cantHectareas, cantPotrero);
	}

	// Metodo para recivir una lista especifica de Potreros
	private List<Potrero> PotreroSegunHectareaYPotrero(int cantHectareas, int cantPotrero)
	{
		List<Potrero> potreroEspecifico = new List<Potrero>();
		foreach (Potrero potrero in _potreros)
		{
			if (potrero.CantidadHectareas > cantHectareas && potrero.CantidadMaxAnimales > cantPotrero)
			{
				potreroEspecifico.Add(potrero);
			}
		}
		return potreroEspecifico;

	}


	// Metodo que utiliza el setter para cambiar el precio de la lana
	public void CambiarPrecioLana()
	{
		double precioLana = PedirNumero("Ingrese el precio de la lana");
		Ovino.PrecioLana = precioLana;

	}
	public int PedirNumero(string mensaje)
	{
		System.Console.WriteLine(mensaje);
		int.TryParse(Console.ReadLine(), out int numero);
		return numero;
	}

	// Pre carga de datos para el funcionamiento de Sistema
	private void PreCarga()
	{
		// Capatazes (2 Capataces)
		_empleados.Add(new Capataz("rodolfo@gmail.com", "rodolfoPeon123!", "Rodolfo", 10, new DateTime(2021, 10, 10)));
		_empleados.Add(new Capataz("gonzalo.perez@gmail.com", "GonzaloPerez.555", "Gonzalo", 10, new DateTime(2019, 1, 4)));


		// Peones (10 Peones)
		_empleados.Add(new Peon(true, "johndoe789@hotmail.com", "JohnDoe123!", "John Doe", new DateTime(2021, 1, 1)));
		_empleados.Add(new Peon(false, "janedoe456@gmail.com", "JaneDoe123!", "Jane Doe", new DateTime(2021, 5, 1)));
		_empleados.Add(new Peon(false, "alexsmith789@yahoo.com", "AlexSmith1443!", "Alex Smith", new DateTime(2021, 5, 1)));
		_empleados.Add(new Peon(true, "emilyjohnson123@outlook.com", "EmilyJohnson2223!", "Emily Johnson", new DateTime(2021, 5, 1)));
		_empleados.Add(new Peon(true, "michaelbrown234@aol.com", "MichaelBrown1!", "Michael Brown", new DateTime(2021, 5, 1)));
		_empleados.Add(new Peon(false, "sarahwilson567@icloud.com", "SarahWilson3!", "Sarah Wilson", new DateTime(2021, 5, 1)));
		_empleados.Add(new Peon(true, "ryanmartinez890@protonmail.com", "RyanMartinez4443!", "Ryan Martinez", new DateTime(2021, 5, 1)));
		_empleados.Add(new Peon(false, "jessicataylor345@live.com", "JessicaTaylor563!", "Jessica Taylor", new DateTime(2021, 5, 1)));
		_empleados.Add(new Peon(true, "davidjones678@msn.com", "DavidJones123", "David Jones", new DateTime(2021, 5, 1)));
		_empleados.Add(new Peon(true, "amandajackson901@yahoomail.com", "AmandaJackson1233333!", "Amanda Jackson", new DateTime(2021, 5, 1)));


		// Vacunas (10 Vacunas)
		_vacunas.Add(new Vacuna("Vacuna contra la influenza", "Vacuna para prevenir la gripe", "Virus de la influenza"));
		_vacunas.Add(new Vacuna("Vacuna contra la hepatitis B", "Vacuna para prevenir la hepatitis B", "Virus de la hepatitis B"));
		_vacunas.Add(new Vacuna("Vacuna contra la varicela", "Vacuna para prevenir la varicela", "Virus de la varicela zóster"));
		_vacunas.Add(new Vacuna("Vacuna contra la poliomielitis", "Vacuna para prevenir la poliomielitis", "Virus de la poliomielitis"));
		_vacunas.Add(new Vacuna("Vacuna contra la tuberculosis", "Vacuna para prevenir la tuberculosis", "Mycobacterium tuberculosis"));
		_vacunas.Add(new Vacuna("Vacuna contra el tétanos", "Vacuna para prevenir el tétanos", "Clostridium tetani"));
		_vacunas.Add(new Vacuna("Vacuna contra la tos ferina", "Vacuna para prevenir la tos ferina", "Bordetella pertussis"));
		_vacunas.Add(new Vacuna("Vacuna contra la fiebre amarilla", "Vacuna para prevenir la fiebre amarilla", "Virus de la fiebre amarilla"));
		_vacunas.Add(new Vacuna("Vacuna contra el sarampión", "Vacuna para prevenir el sarampión", "Virus del sarampión"));




		// Tareas (15 por peon)
		((Peon)_empleados[2]).AgregarTarea(new Tarea("Realizar tratamiento preventivo para mastitis en vacas lecheras", new DateTime(2024, 5, 20), false, new DateTime(2024, 5, 21), "Evitar infecciones"));
		((Peon)_empleados[2]).AgregarTarea(new Tarea("Realizar tratamiento preventivo para mastitis en vacas lecheras", new DateTime(2024, 5, 20), false, new DateTime(2024, 5, 21), "Evitar infecciones"));
		((Peon)_empleados[2]).AgregarTarea(new Tarea("Cuidado y revisión de pezuñas en bovinos", new DateTime(2024, 5, 21), false, new DateTime(2024, 5, 22), "Mantener salud"));
		((Peon)_empleados[2]).AgregarTarea(new Tarea("Control de estrés en el ganado durante movimientos", new DateTime(2024, 5, 22), false, new DateTime(2024, 5, 23), "Minimizar pérdidas"));
		((Peon)_empleados[2]).AgregarTarea(new Tarea("Supervisar y registrar el peso de los corderos", new DateTime(2024, 5, 23), true, new DateTime(2024, 5, 24), "Evaluar crecimiento"));
		((Peon)_empleados[2]).AgregarTarea(new Tarea("Acondicionar y mantener refugios para el ganado", new DateTime(2024, 5, 24), true, new DateTime(2024, 5, 25), "Proteger contra condiciones climáticas"));
		((Peon)_empleados[2]).AgregarTarea(new Tarea("Control de temperatura en nidos de aves de corral", new DateTime(2024, 5, 25), true, new DateTime(2024, 5, 26), "Optimizar condiciones de incubación"));
		((Peon)_empleados[2]).AgregarTarea(new Tarea("Realizar castración de corderos machos", new DateTime(2024, 5, 26), true, new DateTime(2024, 5, 27), "Control de población y comportamiento"));
		((Peon)_empleados[2]).AgregarTarea(new Tarea("Alimentar a los cerdos", new DateTime(2024, 5, 13), true, new DateTime(2024, 5, 14), "Prioridad alta"));
		((Peon)_empleados[2]).AgregarTarea(new Tarea("Reparar la cerca del campo", new DateTime(2024, 5, 14), true, new DateTime(2024, 5, 15), "Necesario con urgencia"));
		((Peon)_empleados[2]).AgregarTarea(new Tarea("Sembrar maíz en el terreno A", new DateTime(2024, 5, 15), true, new DateTime(2024, 5, 16), "Listo para la siembra"));
		((Peon)_empleados[2]).AgregarTarea(new Tarea("Podar los árboles frutales", new DateTime(2024, 5, 16), true, new DateTime(2024, 5, 17), "Mantener la producción"));
		((Peon)_empleados[2]).AgregarTarea(new Tarea("Revisar el sistema de riego", new DateTime(2024, 5, 17), false, new DateTime(2024, 5, 18), "Prepararse para la temporada seca"));
		((Peon)_empleados[2]).AgregarTarea(new Tarea("Limpiar los establos", new DateTime(2024, 5, 18), false, new DateTime(2024, 5, 19), "Evitar enfermedades en los animales"));
		((Peon)_empleados[2]).AgregarTarea(new Tarea("Preparar el suelo para plantar hortalizas", new DateTime(2024, 5, 19), false, new DateTime(2024, 5, 20), "Mejorar la calidad del suelo"));

		((Peon)_empleados[3]).AgregarTarea(new Tarea("Fertilizar el campo", new DateTime(2024, 5, 20), false, new DateTime(2024, 5, 21), "Aumentar la productividad"));
		((Peon)_empleados[3]).AgregarTarea(new Tarea("Comprar nuevos implementos agrícolas", new DateTime(2024, 5, 21), false, new DateTime(2024, 5, 22), "Optimizar el trabajo"));
		((Peon)_empleados[3]).AgregarTarea(new Tarea("Entrenar al personal en nuevas técnicas de cultivo", new DateTime(2024, 5, 22), false, new DateTime(2024, 5, 23), "Mejorar la eficiencia"));
		((Peon)_empleados[3]).AgregarTarea(new Tarea("Controlar plagas en los cultivos", new DateTime(2024, 5, 23), true, new DateTime(2024, 5, 24), "Evitar pérdidas de cosecha"));
		((Peon)_empleados[3]).AgregarTarea(new Tarea("Revisar el estado de los equipos de labranza", new DateTime(2024, 5, 24), true, new DateTime(2024, 5, 25), "Prevenir averías"));
		((Peon)_empleados[3]).AgregarTarea(new Tarea("Recolectar la cosecha de trigo", new DateTime(2024, 5, 25), true, new DateTime(2024, 5, 26), "Iniciar el proceso de almacenamiento"));
		((Peon)_empleados[3]).AgregarTarea(new Tarea("Esterilizar el equipo de ordeño", new DateTime(2024, 5, 26), true, new DateTime(2024, 5, 27), "Mantener la higiene"));
		((Peon)_empleados[3]).AgregarTarea(new Tarea("Vacunar ovinos contra enfermedades comunes", new DateTime(2024, 5, 13), true, new DateTime(2024, 5, 14), "Prioridad alta"));
		((Peon)_empleados[3]).AgregarTarea(new Tarea("Controlar y tratar parásitos en bovinos", new DateTime(2024, 5, 14), true, new DateTime(2024, 5, 15), "Necesario con urgencia"));
		((Peon)_empleados[3]).AgregarTarea(new Tarea("Desparasitación de terneros y ovejas", new DateTime(2024, 5, 13), true, new DateTime(2024, 5, 14), "Prioridad alta"));
		((Peon)_empleados[3]).AgregarTarea(new Tarea("Supervisar el crecimiento y desarrollo de los corderos", new DateTime(2024, 5, 14), true, new DateTime(2024, 5, 15), "Necesario con urgencia"));
		((Peon)_empleados[3]).AgregarTarea(new Tarea("Control de enfermedades reproductivas en el ganado bovino", new DateTime(2024, 5, 15), true, new DateTime(2024, 5, 16), "Inmediatamente"));
		((Peon)_empleados[3]).AgregarTarea(new Tarea("Alimentación suplementaria para vacas en gestación", new DateTime(2024, 5, 16), true, new DateTime(2024, 5, 17), "Mantener salud de la madre y el feto"));
		((Peon)_empleados[3]).AgregarTarea(new Tarea("Revisión de la condición corporal del ganado", new DateTime(2024, 5, 17), false, new DateTime(2024, 5, 18), "Optimizar alimentación"));
		((Peon)_empleados[3]).AgregarTarea(new Tarea("Control de enfermedades respiratorias en ovejas", new DateTime(2024, 5, 18), false, new DateTime(2024, 5, 19), "Prevenir contagios"));

		((Peon)_empleados[4]).AgregarTarea(new Tarea("Entrenamiento de perros pastores y su integración con el rebaño", new DateTime(2024, 5, 19), false, new DateTime(2024, 5, 20), "Mejorar manejo del ganado"));
		((Peon)_empleados[4]).AgregarTarea(new Tarea("Manejo de estrés en el ganado durante el transporte", new DateTime(2024, 5, 20), false, new DateTime(2024, 5, 21), "Reducir impacto negativo en la salud"));
		((Peon)_empleados[4]).AgregarTarea(new Tarea("Supervisión del periodo de secado en vacas lecheras", new DateTime(2024, 5, 21), false, new DateTime(2024, 5, 22), "Preparación para la próxima lactancia"));
		((Peon)_empleados[4]).AgregarTarea(new Tarea("Monitoreo del comportamiento y salud de los toros", new DateTime(2024, 5, 22), false, new DateTime(2024, 5, 23), "Detectar posibles problemas de salud"));
		((Peon)_empleados[4]).AgregarTarea(new Tarea("Control de la calidad del agua para el ganado", new DateTime(2024, 5, 23), true, new DateTime(2024, 5, 24), "Mantener hidratación adecuada"));
		((Peon)_empleados[4]).AgregarTarea(new Tarea("Registro y seguimiento de la reproducción en ovejas", new DateTime(2024, 5, 24), true, new DateTime(2024, 5, 25), "Optimizar la eficiencia reproductiva"));
		((Peon)_empleados[4]).AgregarTarea(new Tarea("Inspección y limpieza de áreas de descanso para el ganado", new DateTime(2024, 5, 25), true, new DateTime(2024, 5, 26), "Promover el confort y bienestar"));
		((Peon)_empleados[4]).AgregarTarea(new Tarea("Control de temperatura y ventilación en el galpón de aves", new DateTime(2024, 5, 26), true, new DateTime(2024, 5, 27), "Evitar el estrés por calor"));
		((Peon)_empleados[4]).AgregarTarea(new Tarea("Realizar vacunación contra enfermedades respiratorias en bovinos", new DateTime(2024, 5, 13), true, new DateTime(2024, 5, 14), "Prioridad alta"));
		((Peon)_empleados[4]).AgregarTarea(new Tarea("Controlar y tratar garrapatas en ovejas", new DateTime(2024, 5, 14), true, new DateTime(2024, 5, 15), "Necesario con urgencia"));
		((Peon)_empleados[4]).AgregarTarea(new Tarea("Supervisar y asistir en parto de ovejas preñadas", new DateTime(2024, 5, 15), true, new DateTime(2024, 5, 16), "Inmediatamente"));
		((Peon)_empleados[4]).AgregarTarea(new Tarea("Alimentar a los terneros con suplementos nutritivos", new DateTime(2024, 5, 16), true, new DateTime(2024, 5, 17), "Mantener crecimiento"));
		((Peon)_empleados[4]).AgregarTarea(new Tarea("Controlar la calidad del forraje para ovinos", new DateTime(2024, 5, 17), false, new DateTime(2024, 5, 18), "Optimizar nutrición"));
		((Peon)_empleados[4]).AgregarTarea(new Tarea("Monitorear signos de enfermedad en el ganado", new DateTime(2024, 5, 18), false, new DateTime(2024, 5, 19), "Prevenir brotes"));
		((Peon)_empleados[4]).AgregarTarea(new Tarea("Entrenamiento y socialización de corderos", new DateTime(2024, 5, 19), false, new DateTime(2024, 5, 20), "Mejorar comportamiento"));

		((Peon)_empleados[5]).AgregarTarea(new Tarea("Realizar tratamiento preventivo para mastitis en vacas lecheras", new DateTime(2024, 5, 20), false, new DateTime(2024, 5, 21), "Evitar infecciones"));
		((Peon)_empleados[5]).AgregarTarea(new Tarea("Cuidado y revisión de pezuñas en bovinos", new DateTime(2024, 5, 21), false, new DateTime(2024, 5, 22), "Mantener salud"));
		((Peon)_empleados[5]).AgregarTarea(new Tarea("Control de estrés en el ganado durante movimientos", new DateTime(2024, 5, 22), false, new DateTime(2024, 5, 23), "Minimizar pérdidas"));
		((Peon)_empleados[5]).AgregarTarea(new Tarea("Supervisar y registrar el peso de los corderos", new DateTime(2024, 5, 23), true, new DateTime(2024, 5, 24), "Evaluar crecimiento"));
		((Peon)_empleados[5]).AgregarTarea(new Tarea("Acondicionar y mantener refugios para el ganado", new DateTime(2024, 5, 24), true, new DateTime(2024, 5, 25), "Proteger contra condiciones climáticas"));
		((Peon)_empleados[5]).AgregarTarea(new Tarea("Control de temperatura en nidos de aves de corral", new DateTime(2024, 5, 25), true, new DateTime(2024, 5, 26), "Optimizar condiciones de incubación"));
		((Peon)_empleados[5]).AgregarTarea(new Tarea("Realizar castración de corderos machos", new DateTime(2024, 5, 26), true, new DateTime(2024, 5, 27), "Control de población y comportamiento"));
		((Peon)_empleados[5]).AgregarTarea(new Tarea("Alimentar a los cerdos", new DateTime(2024, 5, 13), true, new DateTime(2024, 5, 14), "Prioridad alta"));
		((Peon)_empleados[5]).AgregarTarea(new Tarea("Reparar la cerca del campo", new DateTime(2024, 5, 14), true, new DateTime(2024, 5, 15), "Necesario con urgencia"));
		((Peon)_empleados[5]).AgregarTarea(new Tarea("Sembrar maíz en el terreno A", new DateTime(2024, 5, 15), true, new DateTime(2024, 5, 16), "Listo para la siembra"));
		((Peon)_empleados[5]).AgregarTarea(new Tarea("Podar los árboles frutales", new DateTime(2024, 5, 16), true, new DateTime(2024, 5, 17), "Mantener la producción"));
		((Peon)_empleados[5]).AgregarTarea(new Tarea("Revisar el sistema de riego", new DateTime(2024, 5, 17), false, new DateTime(2024, 5, 18), "Prepararse para la temporada seca"));
		((Peon)_empleados[5]).AgregarTarea(new Tarea("Limpiar los establos", new DateTime(2024, 5, 18), false, new DateTime(2024, 5, 19), "Evitar enfermedades en los animales"));
		((Peon)_empleados[5]).AgregarTarea(new Tarea("Preparar el suelo para plantar hortalizas", new DateTime(2024, 5, 19), false, new DateTime(2024, 5, 20), "Mejorar la calidad del suelo"));
		((Peon)_empleados[5]).AgregarTarea(new Tarea("Fertilizar el campo", new DateTime(2024, 5, 20), false, new DateTime(2024, 5, 21), "Aumentar la productividad"));
		((Peon)_empleados[5]).AgregarTarea(new Tarea("Comprar nuevos implementos agrícolas", new DateTime(2024, 5, 21), false, new DateTime(2024, 5, 22), "Optimizar el trabajo"));

		((Peon)_empleados[6]).AgregarTarea(new Tarea("Entrenar al personal en nuevas técnicas de cultivo", new DateTime(2024, 5, 22), false, new DateTime(2024, 5, 23), "Mejorar la eficiencia"));
		((Peon)_empleados[6]).AgregarTarea(new Tarea("Controlar plagas en los cultivos", new DateTime(2024, 5, 23), true, new DateTime(2024, 5, 24), "Evitar pérdidas de cosecha"));
		((Peon)_empleados[6]).AgregarTarea(new Tarea("Revisar el estado de los equipos de labranza", new DateTime(2024, 5, 24), true, new DateTime(2024, 5, 25), "Prevenir averías"));
		((Peon)_empleados[6]).AgregarTarea(new Tarea("Recolectar la cosecha de trigo", new DateTime(2024, 5, 25), true, new DateTime(2024, 5, 26), "Iniciar el proceso de almacenamiento"));
		((Peon)_empleados[6]).AgregarTarea(new Tarea("Esterilizar el equipo de ordeño", new DateTime(2024, 5, 26), true, new DateTime(2024, 5, 27), "Mantener la higiene"));
		((Peon)_empleados[6]).AgregarTarea(new Tarea("Vacunar ovinos contra enfermedades comunes", new DateTime(2024, 5, 13), true, new DateTime(2024, 5, 14), "Prioridad alta"));
		((Peon)_empleados[6]).AgregarTarea(new Tarea("Controlar y tratar parásitos en bovinos", new DateTime(2024, 5, 14), true, new DateTime(2024, 5, 15), "Necesario con urgencia"));
		((Peon)_empleados[6]).AgregarTarea(new Tarea("Realizar marcaje y registro de nuevos corderos", new DateTime(2024, 5, 15), true, new DateTime(2024, 5, 16), "Inmediatamente"));
		((Peon)_empleados[6]).AgregarTarea(new Tarea("Revisar y mantener el vallado de los corrales", new DateTime(2024, 5, 16), true, new DateTime(2024, 5, 17), "Mantener la seguridad"));
		((Peon)_empleados[6]).AgregarTarea(new Tarea("Preparar instalaciones para la época de partos", new DateTime(2024, 5, 17), false, new DateTime(2024, 5, 18), "Prevenir problemas durante parto"));
		((Peon)_empleados[6]).AgregarTarea(new Tarea("Revisar la nutrición del ganado bovino", new DateTime(2024, 5, 18), false, new DateTime(2024, 5, 19), "Optimizar rendimiento"));
		((Peon)_empleados[6]).AgregarTarea(new Tarea("Control de peso y salud de ovejas preñadas", new DateTime(2024, 5, 19), false, new DateTime(2024, 5, 20), "Prevenir complicaciones"));
		((Peon)_empleados[6]).AgregarTarea(new Tarea("Realizar esquila de ovejas", new DateTime(2024, 5, 20), false, new DateTime(2024, 5, 21), "Mantener higiene y salud"));
		((Peon)_empleados[6]).AgregarTarea(new Tarea("Control sanitario y vacunación de terneros", new DateTime(2024, 5, 21), false, new DateTime(2024, 5, 22), "Evitar enfermedades"));
		((Peon)_empleados[6]).AgregarTarea(new Tarea("Entrenamiento de perros pastores", new DateTime(2024, 5, 22), false, new DateTime(2024, 5, 23), "Mejorar manejo de ganado"));

		((Peon)_empleados[7]).AgregarTarea(new Tarea("Mantenimiento de bebederos y comederos", new DateTime(2024, 5, 23), true, new DateTime(2024, 5, 24), "Optimizar alimentación"));
		((Peon)_empleados[7]).AgregarTarea(new Tarea("Supervisar condiciones de pastoreo", new DateTime(2024, 5, 24), true, new DateTime(2024, 5, 25), "Maximizar aprovechamiento"));
		((Peon)_empleados[7]).AgregarTarea(new Tarea("Monitorear signos de enfermedad en el ganado", new DateTime(2024, 5, 25), true, new DateTime(2024, 5, 26), "Prevenir brotes"));
		((Peon)_empleados[7]).AgregarTarea(new Tarea("Planificar rotación de pastos", new DateTime(2024, 5, 26), true, new DateTime(2024, 5, 27), "Mantener calidad del forraje"));
		((Peon)_empleados[7]).AgregarTarea(new Tarea("Control de enfermedades reproductivas en ovejas", new DateTime(2024, 5, 13), true, new DateTime(2024, 5, 14), "Prioridad alta"));
		((Peon)_empleados[7]).AgregarTarea(new Tarea("Revisar y mantener la infraestructura de los establos", new DateTime(2024, 5, 14), true, new DateTime(2024, 5, 15), "Necesario con urgencia"));
		((Peon)_empleados[7]).AgregarTarea(new Tarea("Alimentar a los terneros recién nacidos", new DateTime(2024, 5, 15), true, new DateTime(2024, 5, 16), "Inmediatamente"));
		((Peon)_empleados[7]).AgregarTarea(new Tarea("Desparasitar y vacunar a los corderos", new DateTime(2024, 5, 16), true, new DateTime(2024, 5, 17), "Mantener la salud"));
		((Peon)_empleados[7]).AgregarTarea(new Tarea("Supervisar el parto de vacas preñadas", new DateTime(2024, 5, 17), false, new DateTime(2024, 5, 18), "Prevenir complicaciones"));
		((Peon)_empleados[7]).AgregarTarea(new Tarea("Control de malezas en los campos de pastoreo", new DateTime(2024, 5, 18), false, new DateTime(2024, 5, 19), "Optimizar rendimiento"));
		((Peon)_empleados[7]).AgregarTarea(new Tarea("Inspeccionar y mantener los sistemas de agua", new DateTime(2024, 5, 19), false, new DateTime(2024, 5, 20), "Prevenir escasez de agua"));
		((Peon)_empleados[7]).AgregarTarea(new Tarea("Castración de terneros machos", new DateTime(2024, 5, 20), false, new DateTime(2024, 5, 21), "Control de población"));
		((Peon)_empleados[7]).AgregarTarea(new Tarea("Supervisar el destete de corderos", new DateTime(2024, 5, 21), false, new DateTime(2024, 5, 22), "Minimizar estrés"));
		((Peon)_empleados[7]).AgregarTarea(new Tarea("Control de calidad de la leche en vacas lecheras", new DateTime(2024, 5, 22), false, new DateTime(2024, 5, 23), "Mantener estándares"));
		((Peon)_empleados[7]).AgregarTarea(new Tarea("Revisar y limpiar las instalaciones de ordeño", new DateTime(2024, 5, 23), true, new DateTime(2024, 5, 24), "Mantener higiene"));
		((Peon)_empleados[8]).AgregarTarea(new Tarea("Cuidado de ubres en vacas lecheras", new DateTime(2024, 5, 24), true, new DateTime(2024, 5, 25), "Prevenir mastitis"));
		((Peon)_empleados[8]).AgregarTarea(new Tarea("Entrenamiento de bueyes para trabajos agrícolas", new DateTime(2024, 5, 25), true, new DateTime(2024, 5, 26), "Mejorar habilidades"));
		((Peon)_empleados[8]).AgregarTarea(new Tarea("Monitorear el crecimiento de terneros", new DateTime(2024, 5, 26), true, new DateTime(2024, 5, 27), "Detectar problemas nutricionales"));
		((Peon)_empleados[8]).AgregarTarea(new Tarea("Reparar cercas perimetrales", new DateTime(2024, 5, 13), true, new DateTime(2024, 5, 14), "Prioridad alta"));
		((Peon)_empleados[8]).AgregarTarea(new Tarea("Mantenimiento de los techos de los establos", new DateTime(2024, 5, 14), true, new DateTime(2024, 5, 15), "Necesario con urgencia"));
		((Peon)_empleados[8]).AgregarTarea(new Tarea("Podar árboles alrededor de las instalaciones", new DateTime(2024, 5, 15), true, new DateTime(2024, 5, 16), "Inmediatamente"));
		((Peon)_empleados[8]).AgregarTarea(new Tarea("Revisión y limpieza de drenajes", new DateTime(2024, 5, 16), true, new DateTime(2024, 5, 17), "Mantener la funcionalidad"));
		((Peon)_empleados[8]).AgregarTarea(new Tarea("Pintar y mantener los portones de acceso", new DateTime(2024, 5, 17), false, new DateTime(2024, 5, 18), "Mejorar apariencia"));
		((Peon)_empleados[8]).AgregarTarea(new Tarea("Revisión de sistemas eléctricos en los establos", new DateTime(2024, 5, 18), false, new DateTime(2024, 5, 19), "Prevenir cortocircuitos"));
		((Peon)_empleados[8]).AgregarTarea(new Tarea("Control de plagas en almacenes de alimento", new DateTime(2024, 5, 19), false, new DateTime(2024, 5, 20), "Mantener calidad de alimento"));
		((Peon)_empleados[8]).AgregarTarea(new Tarea("Reparación de bebederos y sistemas de agua", new DateTime(2024, 5, 20), false, new DateTime(2024, 5, 21), "Evitar desperdicios"));
		((Peon)_empleados[8]).AgregarTarea(new Tarea("Limpieza y desinfección de áreas comunes", new DateTime(2024, 5, 21), false, new DateTime(2024, 5, 22), "Prevenir enfermedades"));
		((Peon)_empleados[8]).AgregarTarea(new Tarea("Reparación de pisos en los corrales", new DateTime(2024, 5, 22), false, new DateTime(2024, 5, 23), "Evitar lesiones"));
		((Peon)_empleados[8]).AgregarTarea(new Tarea("Inspección de la iluminación en áreas de trabajo", new DateTime(2024, 5, 23), true, new DateTime(2024, 5, 24), "Mejorar condiciones laborales"));
		((Peon)_empleados[8]).AgregarTarea(new Tarea("Revisión y mantenimiento de sistemas de ventilación", new DateTime(2024, 5, 24), true, new DateTime(2024, 5, 25), "Garantizar bienestar animal"));
		((Peon)_empleados[9]).AgregarTarea(new Tarea("Limpieza de desagües y canaletas", new DateTime(2024, 5, 25), true, new DateTime(2024, 5, 26), "Prevenir inundaciones"));
		((Peon)_empleados[9]).AgregarTarea(new Tarea("Control de malezas en áreas de paso", new DateTime(2024, 5, 26), true, new DateTime(2024, 5, 27), "Mejorar seguridad"));
		((Peon)_empleados[9]).AgregarTarea(new Tarea("Reparación de vallas en áreas de pastoreo", new DateTime(2024, 5, 13), true, new DateTime(2024, 5, 14), "Prioridad alta"));
		((Peon)_empleados[9]).AgregarTarea(new Tarea("Limpieza y desinfección de áreas de almacenamiento", new DateTime(2024, 5, 14), true, new DateTime(2024, 5, 15), "Necesario con urgencia"));
		((Peon)_empleados[9]).AgregarTarea(new Tarea("Revisión de sistema de drenaje en los establos", new DateTime(2024, 5, 15), true, new DateTime(2024, 5, 16), "Inmediatamente"));
		((Peon)_empleados[9]).AgregarTarea(new Tarea("Mantenimiento de caminos y accesos a los campos", new DateTime(2024, 5, 16), true, new DateTime(2024, 5, 17), "Mantener accesibilidad"));
		((Peon)_empleados[9]).AgregarTarea(new Tarea("Instalación de sistemas de sombreado en corrales", new DateTime(2024, 5, 17), false, new DateTime(2024, 5, 18), "Proteger animales del calor"));
		((Peon)_empleados[9]).AgregarTarea(new Tarea("Reparación de bebederos automáticos", new DateTime(2024, 5, 18), false, new DateTime(2024, 5, 19), "Evitar desperdicios de agua"));
		((Peon)_empleados[9]).AgregarTarea(new Tarea("Poda y mantenimiento de cercos vivos", new DateTime(2024, 5, 19), false, new DateTime(2024, 5, 20), "Mejorar estética y funcionalidad"));
		((Peon)_empleados[9]).AgregarTarea(new Tarea("Limpieza de estanques y depósitos de agua", new DateTime(2024, 5, 20), false, new DateTime(2024, 5, 21), "Mantener calidad de agua"));
		((Peon)_empleados[9]).AgregarTarea(new Tarea("Revisión y reparación de techos de galpones", new DateTime(2024, 5, 21), false, new DateTime(2024, 5, 22), "Prevenir filtraciones"));
		((Peon)_empleados[9]).AgregarTarea(new Tarea("Instalación de luces de seguridad en áreas sensibles", new DateTime(2024, 5, 22), false, new DateTime(2024, 5, 23), "Mejorar vigilancia nocturna"));
		((Peon)_empleados[9]).AgregarTarea(new Tarea("Limpieza y desmalezado de áreas comunes", new DateTime(2024, 5, 23), true, new DateTime(2024, 5, 24), "Prevenir refugio de plagas"));
		((Peon)_empleados[9]).AgregarTarea(new Tarea("Control de erosión en terrenos de pastoreo", new DateTime(2024, 5, 24), true, new DateTime(2024, 5, 25), "Conservar suelos"));
		((Peon)_empleados[9]).AgregarTarea(new Tarea("Revisión y reparación de sistemas de alimentación automatizados", new DateTime(2024, 5, 25), true, new DateTime(2024, 5, 26), "Optimizar alimentación"));
		((Peon)_empleados[10]).AgregarTarea(new Tarea("Mantenimiento de silos y depósitos de alimento", new DateTime(2024, 5, 26), true, new DateTime(2024, 5, 27), "Prevenir contaminación de alimento"));
		((Peon)_empleados[10]).AgregarTarea(new Tarea("Castración de terneros machos", new DateTime(2024, 5, 20), false, new DateTime(2024, 5, 21), "Control de población"));
		((Peon)_empleados[10]).AgregarTarea(new Tarea("Supervisar el destete de corderos", new DateTime(2024, 5, 21), false, new DateTime(2024, 5, 22), "Minimizar estrés"));
		((Peon)_empleados[10]).AgregarTarea(new Tarea("Control de calidad de la leche en vacas lecheras", new DateTime(2024, 5, 22), false, new DateTime(2024, 5, 23), "Mantener estándares"));
		((Peon)_empleados[10]).AgregarTarea(new Tarea("Revisar y limpiar las instalaciones de ordeño", new DateTime(2024, 5, 23), true, new DateTime(2024, 5, 24), "Mantener higiene"));
		((Peon)_empleados[10]).AgregarTarea(new Tarea("Cuidado de ubres en vacas lecheras", new DateTime(2024, 5, 24), true, new DateTime(2024, 5, 25), "Prevenir mastitis"));
		((Peon)_empleados[10]).AgregarTarea(new Tarea("Entrenamiento de bueyes para trabajos agrícolas", new DateTime(2024, 5, 25), true, new DateTime(2024, 5, 26), "Mejorar habilidades"));
		((Peon)_empleados[10]).AgregarTarea(new Tarea("Monitorear el crecimiento de terneros", new DateTime(2024, 5, 26), true, new DateTime(2024, 5, 27), "Detectar problemas nutricionales"));
		((Peon)_empleados[10]).AgregarTarea(new Tarea("Reparar cercas perimetrales", new DateTime(2024, 5, 13), true, new DateTime(2024, 5, 14), "Prioridad alta"));
		((Peon)_empleados[10]).AgregarTarea(new Tarea("Mantenimiento de los techos de los establos", new DateTime(2024, 5, 14), true, new DateTime(2024, 5, 15), "Necesario con urgencia"));
		((Peon)_empleados[10]).AgregarTarea(new Tarea("Podar árboles alrededor de las instalaciones", new DateTime(2024, 5, 15), true, new DateTime(2024, 5, 16), "Inmediatamente"));
		((Peon)_empleados[10]).AgregarTarea(new Tarea("Revisión y limpieza de drenajes", new DateTime(2024, 5, 16), true, new DateTime(2024, 5, 17), "Mantener la funcionalidad"));
		((Peon)_empleados[10]).AgregarTarea(new Tarea("Pintar y mantener los portones de acceso", new DateTime(2024, 5, 17), false, new DateTime(2024, 5, 18), "Mejorar apariencia"));
		((Peon)_empleados[10]).AgregarTarea(new Tarea("Revisión de sistemas eléctricos en los establos", new DateTime(2024, 5, 18), false, new DateTime(2024, 5, 19), "Prevenir cortocircuitos"));
		((Peon)_empleados[10]).AgregarTarea(new Tarea("Control de plagas en almacenes de alimento", new DateTime(2024, 5, 19), false, new DateTime(2024, 5, 20), "Mantener calidad de alimento"));
		((Peon)_empleados[11]).AgregarTarea(new Tarea("Reparación de bebederos y sistemas de agua", new DateTime(2024, 5, 20), false, new DateTime(2024, 5, 21), "Evitar desperdicios"));
		((Peon)_empleados[11]).AgregarTarea(new Tarea("Limpieza y desinfección de áreas comunes", new DateTime(2024, 5, 21), false, new DateTime(2024, 5, 22), "Prevenir enfermedades"));
		((Peon)_empleados[11]).AgregarTarea(new Tarea("Reparación de pisos en los corrales", new DateTime(2024, 5, 22), false, new DateTime(2024, 5, 23), "Evitar lesiones"));
		((Peon)_empleados[11]).AgregarTarea(new Tarea("Mantenimiento de silos y depósitos de alimento", new DateTime(2024, 5, 26), true, new DateTime(2024, 5, 27), "Prevenir contaminación de alimento"));
		((Peon)_empleados[11]).AgregarTarea(new Tarea("Castración de terneros machos", new DateTime(2024, 5, 20), false, new DateTime(2024, 5, 21), "Control de población"));
		((Peon)_empleados[11]).AgregarTarea(new Tarea("Supervisar el destete de corderos", new DateTime(2024, 5, 21), false, new DateTime(2024, 5, 22), "Minimizar estrés"));
		((Peon)_empleados[11]).AgregarTarea(new Tarea("Control de enfermedades respiratorias en ovejas", new DateTime(2024, 5, 18), false, new DateTime(2024, 5, 19), "Prevenir contagios"));
		((Peon)_empleados[11]).AgregarTarea(new Tarea("Entrenamiento de perros pastores y su integración con el rebaño", new DateTime(2024, 5, 19), false, new DateTime(2024, 5, 20), "Mejorar manejo del ganado"));
		((Peon)_empleados[11]).AgregarTarea(new Tarea("Manejo de estrés en el ganado durante el transporte", new DateTime(2024, 5, 20), false, new DateTime(2024, 5, 21), "Reducir impacto negativo en la salud"));
		((Peon)_empleados[11]).AgregarTarea(new Tarea("Supervisión del periodo de secado en vacas lecheras", new DateTime(2024, 5, 21), false, new DateTime(2024, 5, 22), "Preparación para la próxima lactancia"));
		((Peon)_empleados[11]).AgregarTarea(new Tarea("Monitoreo del comportamiento y salud de los toros", new DateTime(2024, 5, 22), false, new DateTime(2024, 5, 23), "Detectar posibles problemas de salud"));
		((Peon)_empleados[11]).AgregarTarea(new Tarea("Control de la calidad del agua para el ganado", new DateTime(2024, 5, 23), true, new DateTime(2024, 5, 24), "Mantener hidratación adecuada"));
		((Peon)_empleados[11]).AgregarTarea(new Tarea("Registro y seguimiento de la reproducción en ovejas", new DateTime(2024, 5, 24), true, new DateTime(2024, 5, 25), "Optimizar la eficiencia reproductiva"));
		((Peon)_empleados[11]).AgregarTarea(new Tarea("Inspección y limpieza de áreas de descanso para el ganado", new DateTime(2024, 5, 25), true, new DateTime(2024, 5, 26), "Promover el confort y bienestar"));
		((Peon)_empleados[11]).AgregarTarea(new Tarea("Control de temperatura y ventilación en el galpón de aves", new DateTime(2024, 5, 26), true, new DateTime(2024, 5, 27), "Evitar el estrés por calor"));




		// Animales (30 Animales)

		//Bovinos
		_animales.Add(new Bovino(TipoAlimentacion.Concentrado, TipoGenero.Macho, "Hereford", new DateTime(2024, 5, 22), 200, 100, 600, true, new List<Vacunacion>(), true));
		_animales.Add(new Bovino(TipoAlimentacion.Pastura, TipoGenero.Macho, "Hereford", new DateTime(2024, 5, 22), 200, 100, 600, true, new List<Vacunacion>(), true));
		_animales.Add(new Bovino(TipoAlimentacion.Concentrado, TipoGenero.Hembra, "Angus", new DateTime(2024, 4, 18), 180, 90, 550, false, new List<Vacunacion>(), true));
		_animales.Add(new Bovino(TipoAlimentacion.Mezcla, TipoGenero.Macho, "Simmental", new DateTime(2024, 3, 15), 250, 120, 480, false, new List<Vacunacion>(), true));
		_animales.Add(new Bovino(TipoAlimentacion.Pastura, TipoGenero.Hembra, "Brahman", new DateTime(2024, 2, 10), 220, 110, 500, false, new List<Vacunacion>(), true));
		_animales.Add(new Bovino(TipoAlimentacion.Concentrado, TipoGenero.Macho, "Limousin", new DateTime(2024, 1, 5), 230, 115, 490, true, new List<Vacunacion>(), true));
		_animales.Add(new Bovino(TipoAlimentacion.Pastura, TipoGenero.Hembra, "Charolais", new DateTime(2023, 12, 1), 210, 105, 520, false, new List<Vacunacion>(), true));
		_animales.Add(new Bovino(TipoAlimentacion.Mezcla, TipoGenero.Macho, "Aberdeen Angus", new DateTime(2023, 10, 27), 240, 125, 470, false, new List<Vacunacion>(), true));
		_animales.Add(new Bovino(TipoAlimentacion.Pastura, TipoGenero.Hembra, "Gyr", new DateTime(2023, 9, 23), 200, 100, 540, true, new List<Vacunacion>(), true));
		_animales.Add(new Bovino(TipoAlimentacion.Concentrado, TipoGenero.Macho, "Holstein", new DateTime(2023, 8, 19), 260, 130, 460, false, new List<Vacunacion>(), true));
		_animales.Add(new Bovino(TipoAlimentacion.Pastura, TipoGenero.Hembra, "Jersey", new DateTime(2023, 7, 15), 190, 95, 570, false, new List<Vacunacion>(), true));
		_animales.Add(new Bovino(TipoAlimentacion.Mezcla, TipoGenero.Macho, "Wagyu", new DateTime(2023, 6, 10), 280, 140, 450, true, new List<Vacunacion>(), true));
		_animales.Add(new Bovino(TipoAlimentacion.Pastura, TipoGenero.Hembra, "Normando", new DateTime(2023, 5, 6), 170, 85, 580, false, new List<Vacunacion>(), true));
		_animales.Add(new Bovino(TipoAlimentacion.Mezcla, TipoGenero.Macho, "Friesian", new DateTime(2023, 4, 1), 300, 150, 440, false, new List<Vacunacion>(), true));
		_animales.Add(new Bovino(TipoAlimentacion.Concentrado, TipoGenero.Hembra, "Angus", new DateTime(2023, 2, 25), 170, 75, 600, true, new List<Vacunacion>(), true));
		_animales.Add(new Bovino(TipoAlimentacion.Pastura, TipoGenero.Macho, "Hereford", new DateTime(2023, 5, 22), 180, 80, 590, false, new List<Vacunacion>(), true));
		_animales.Add(new Bovino(TipoAlimentacion.Concentrado, TipoGenero.Macho, "Limousin", new DateTime(2023, 4, 18), 190, 85, 580, true, new List<Vacunacion>(), true));
		_animales.Add(new Bovino(TipoAlimentacion.Pastura, TipoGenero.Hembra, "Charolais", new DateTime(2023, 3, 15), 200, 90, 570, false, new List<Vacunacion>(), true));
		_animales.Add(new Bovino(TipoAlimentacion.Mezcla, TipoGenero.Macho, "Aberdeen Angus", new DateTime(2023, 2, 10), 210, 95, 560, true, new List<Vacunacion>(), true));
		_animales.Add(new Bovino(TipoAlimentacion.Pastura, TipoGenero.Hembra, "Gyr", new DateTime(2023, 1, 5), 220, 100, 550, false, new List<Vacunacion>(), true));
		_animales.Add(new Bovino(TipoAlimentacion.Concentrado, TipoGenero.Macho, "Holstein", new DateTime(2023, 12, 1), 230, 105, 540, true, new List<Vacunacion>(), true));
		_animales.Add(new Bovino(TipoAlimentacion.Pastura, TipoGenero.Hembra, "Jersey", new DateTime(2023, 10, 27), 240, 110, 530, false, new List<Vacunacion>(), true));
		_animales.Add(new Bovino(TipoAlimentacion.Mezcla, TipoGenero.Macho, "Wagyu", new DateTime(2023, 9, 23), 250, 115, 520, true, new List<Vacunacion>(), true));
		_animales.Add(new Bovino(TipoAlimentacion.Pastura, TipoGenero.Hembra, "Normando", new DateTime(2023, 8, 19), 260, 120, 510, false, new List<Vacunacion>(), true));
		_animales.Add(new Bovino(TipoAlimentacion.Concentrado, TipoGenero.Macho, "Friesian", new DateTime(2023, 7, 15), 270, 125, 500, true, new List<Vacunacion>(), true));
		_animales.Add(new Bovino(TipoAlimentacion.Pastura, TipoGenero.Hembra, "Chianina", new DateTime(2023, 6, 10), 280, 130, 490, false, new List<Vacunacion>(), true));
		_animales.Add(new Bovino(TipoAlimentacion.Concentrado, TipoGenero.Macho, "Hereford", new DateTime(2023, 5, 6), 290, 135, 480, true, new List<Vacunacion>(), true));
		_animales.Add(new Bovino(TipoAlimentacion.Pastura, TipoGenero.Hembra, "Brahman", new DateTime(2023, 4, 1), 300, 140, 470, false, new List<Vacunacion>(), true));
		_animales.Add(new Bovino(TipoAlimentacion.Mezcla, TipoGenero.Macho, "Simmental", new DateTime(2023, 2, 25), 310, 145, 460, true, new List<Vacunacion>(), true));



		//Ovinos
		_animales.Add(new Ovino(30, TipoGenero.Hembra, "Dorper", new DateTime(2023, 2, 25), 160, 80, 590, true, new List<Vacunacion>(), true)); 
		_animales.Add(new Ovino(25, TipoGenero.Hembra, "Merino", new DateTime(2023, 3, 15), 170, 85, 580, false, new List<Vacunacion>(), true));
		_animales.Add(new Ovino(35, TipoGenero.Macho, "Suffolk", new DateTime(2023, 4, 20), 180, 90, 570, true, new List<Vacunacion>(), true));
		_animales.Add(new Ovino(28, TipoGenero.Hembra, "Texel", new DateTime(2023, 5, 10), 190, 95, 560, false, new List<Vacunacion>(), true));
		_animales.Add(new Ovino(38, TipoGenero.Macho, "Dorper", new DateTime(2023, 6, 5), 200, 100, 550, true, new List<Vacunacion>(), true));
		_animales.Add(new Ovino(22, TipoGenero.Hembra, "Romney", new DateTime(2023, 7, 2), 210, 105, 540, false, new List<Vacunacion>(), true));
		_animales.Add(new Ovino(32, TipoGenero.Macho, "Cotswold", new DateTime(2023, 8, 12), 220, 110, 530, true, new List<Vacunacion>(), true));
		_animales.Add(new Ovino(27, TipoGenero.Hembra, "Lincoln", new DateTime(2023, 9, 8), 230, 115, 520, false, new List<Vacunacion>(), true));
		_animales.Add(new Ovino(37, TipoGenero.Macho, "Border Leicester", new DateTime(2023, 10, 4), 240, 120, 510, true, new List<Vacunacion>(), true));
		_animales.Add(new Ovino(24, TipoGenero.Hembra, "Cheviot", new DateTime(2023, 11, 1), 250, 125, 500, false, new List<Vacunacion>(), true));
		_animales.Add(new Ovino(34, TipoGenero.Macho, "Columbia", new DateTime(2023, 12, 10), 260, 130, 490, true, new List<Vacunacion>(), true));
		_animales.Add(new Ovino(29, TipoGenero.Hembra, "Jacob", new DateTime(2024, 1, 18), 270, 135, 480, false, new List<Vacunacion>(), true));
		_animales.Add(new Ovino(39, TipoGenero.Macho, "Rambouillet", new DateTime(2024, 2, 25), 280, 140, 470, true, new List<Vacunacion>(), true));
		_animales.Add(new Ovino(26, TipoGenero.Hembra, "Polypay", new DateTime(2024, 3, 30), 290, 145, 460, false, new List<Vacunacion>(), true));
		_animales.Add(new Ovino(36, TipoGenero.Macho, "Shetland", new DateTime(2024, 4, 28), 300, 150, 450, true, new List<Vacunacion>(), true));
		_animales.Add(new Ovino(33, TipoGenero.Hembra, "Suffolk", new DateTime(2023, 2, 25), 170, 75, 600, true, new List<Vacunacion>(), true));
		_animales.Add(new Ovino(27, TipoGenero.Hembra, "Merino", new DateTime(2023, 3, 15), 180, 80, 590, false, new List<Vacunacion>(), true));
		_animales.Add(new Ovino(37, TipoGenero.Macho, "Texel", new DateTime(2023, 4, 20), 190, 85, 580, true, new List<Vacunacion>(), true));
		_animales.Add(new Ovino(31, TipoGenero.Hembra, "Dorper", new DateTime(2023, 5, 10), 200, 90, 570, false, new List<Vacunacion>(), true));
		_animales.Add(new Ovino(39, TipoGenero.Macho, "Romney", new DateTime(2023, 6, 5), 210, 95, 560, true, new List<Vacunacion>(), true));
		_animales.Add(new Ovino(23, TipoGenero.Hembra, "Cotswold", new DateTime(2023, 7, 2), 220, 100, 550, false, new List<Vacunacion>(), true));
		_animales.Add(new Ovino(35, TipoGenero.Macho, "Lincoln", new DateTime(2023, 8, 12), 230, 105, 540, true, new List<Vacunacion>(), true));
		_animales.Add(new Ovino(29, TipoGenero.Hembra, "Border Leicester", new DateTime(2023, 9, 8), 240, 110, 530, false, new List<Vacunacion>(), true));
		_animales.Add(new Ovino(40, TipoGenero.Macho, "Cheviot", new DateTime(2023, 10, 4), 250, 115, 520, true, new List<Vacunacion>(), true));
		_animales.Add(new Ovino(25, TipoGenero.Hembra, "Columbia", new DateTime(2023, 11, 1), 260, 120, 510, false, new List<Vacunacion>(), true));
		_animales.Add(new Ovino(35, TipoGenero.Macho, "Jacob", new DateTime(2024, 1, 18), 270, 125, 500, true, new List<Vacunacion>(), true));
		_animales.Add(new Ovino(41, TipoGenero.Hembra, "Rambouillet", new DateTime(2024, 2, 25), 280, 130, 490, false, new List<Vacunacion>(), true));
		_animales.Add(new Ovino(28, TipoGenero.Macho, "Polypay", new DateTime(2024, 3, 30), 290, 135, 480, true, new List<Vacunacion>(), true));
		_animales.Add(new Ovino(38, TipoGenero.Hembra, "Shetland", new DateTime(2024, 4, 28), 300, 140, 470, false, new List<Vacunacion>(), true));
		_animales.Add(new Ovino(32, TipoGenero.Macho, "Merino", new DateTime(2024, 5, 30), 310, 145, 460, true, new List<Vacunacion>(), true));


		// Potreros (10 Potreros)
		_potreros.Add(new Potrero("Potrero 1", 50, 100, new List<Animal>()));
		_potreros.Add(new Potrero("Potrero 2", 70, 120, new List<Animal>()));
		_potreros.Add(new Potrero("Potrero 3", 30, 80, new List<Animal>()));
		_potreros.Add(new Potrero("Potrero 4", 40, 90, new List<Animal>()));
		_potreros.Add(new Potrero("Potrero 5", 80, 140, new List<Animal>()));
		_potreros.Add(new Potrero("Potrero 6", 60, 100, new List<Animal>()));
		_potreros.Add(new Potrero("Potrero 7", 50, 100, new List<Animal>()));
		_potreros.Add(new Potrero("Potrero 8", 70, 120, new List<Animal>()));
		_potreros.Add(new Potrero("Potrero 9", 30, 80, new List<Animal>()));
		_potreros.Add(new Potrero("Potrero 10", 20, 60, new List<Animal>()));


		/* TODO:
            - todos los animales a un potrero
        */
	}

	//  Metodo para ingresar los animales existentes dentro de un potrero
	private void UpdateAnimals()
	{
		Random rnd = new Random();
		foreach (Animal animal in _animales)
		{

			int random = rnd.Next(1, 10);
			_potreros[random].AgregarAnimal(animal);
		}
	}


}
