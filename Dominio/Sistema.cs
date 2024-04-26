namespace Dominio;

public class Sistema
{

    private static Sistema? s_instancia = null;
    private List<Animal> _animales = new List<Animal>();
    private List<Potrero> _potreros = new List<Potrero>();
    private List<Vacuna> _vacunas = new List<Vacuna>();

    private List<Empleado>? _empleados = new List<Empleado>();

    public static Sistema sistema
    {
        get
        {
            s_instancia ??= new Sistema();
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

    public void AgregarAnimal(Animal animal)
    {
        if (!_animales.Contains(animal))
        {
            _animales.Add(animal);
        }
        else
        {
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

    public void PotreroEspecifico()
    {
        int cantHectareas = PedirNumero("Ingrese la cantidad de hectareas");
        int cantPotrero = PedirNumero("Ingrese la cantidad de potreros");
        PotreroSegunHectareaYPotrero(cantHectareas, cantPotrero);
    }
    public void PotreroSegunHectareaYPotrero(int cantHectareas, int cantPotrero)
    {
        foreach (Potrero potrero in _potreros)
        {
            if (potrero.CantidadHectareas == cantHectareas && potrero.CantidadMaxAnimales == cantPotrero)
            {
                Console.WriteLine(potrero.ToString());
            }
        }

    }


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

        // Potreros (10 Potreros)
        _potreros.Add(new Potrero("Potrero 1", 50, 100, 80, new List<Animal>()));
        _potreros.Add(new Potrero("Potrero 2", 70, 120, 90, new List<Animal>()));
        _potreros.Add(new Potrero("Potrero 3", 30, 80, 60, new List<Animal>()));
        _potreros.Add(new Potrero("Potrero 4", 40, 90, 70, new List<Animal>()));
        _potreros.Add(new Potrero("Potrero 5", 80, 140, 110, new List<Animal>()));
        _potreros.Add(new Potrero("Potrero 6", 60, 100, 85, new List<Animal>()));
        _potreros.Add(new Potrero("Potrero 7", 50, 100, 80, new List<Animal>()));
        _potreros.Add(new Potrero("Potrero 8", 70, 120, 90, new List<Animal>()));
        _potreros.Add(new Potrero("Potrero 9", 30, 80, 60, new List<Animal>()));
        _potreros.Add(new Potrero("Potrero 10", 20, 60, 40, new List<Animal>()));

        // Animales (30 Animales)
        /* TODO:


            - 15 tareas por peon
            - todos los animales a un potrero
        */
    }

}
