namespace Dominio;

public class Sistema
{

    private static Sistema? s_instancia = null;
    private List<Animal> _animales = new List<Animal>();
    private List<Potrero> _potreros = new List<Potrero>();
    private List<Vacuna> _vacunas = new List<Vacuna>();
    private List<Tarea> _tareas = new List<Tarea>();

    private List<Vacunacion> _vacunaciones = new List<Vacunacion>();
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
        UpdateAnimals();
    }
    public void ListarTodosLosAnimales()
    {
        foreach (Animal animal in _animales)
        {
            Console.WriteLine(animal.ToString());

        }
    }


    public void ListarTodasLasTareas()
    {
        foreach (Tarea t in _tareas)
        {
            Console.WriteLine(t.ToString());

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
            if (potrero.CantidadHectareas > cantHectareas && potrero.CantidadMaxAnimales > cantPotrero)
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
        _tareas.Add(new Tarea("Control de enfermedades respiratorias en ovejas", new DateTime(2024, 5, 18), false, new DateTime(2024, 5, 19), "Prevenir contagios"));
        _tareas.Add(new Tarea("Entrenamiento de perros pastores y su integración con el rebaño", new DateTime(2024, 5, 19), false, new DateTime(2024, 5, 20), "Mejorar manejo del ganado"));
        _tareas.Add(new Tarea("Manejo de estrés en el ganado durante el transporte", new DateTime(2024, 5, 20), false, new DateTime(2024, 5, 21), "Reducir impacto negativo en la salud"));
        _tareas.Add(new Tarea("Supervisión del periodo de secado en vacas lecheras", new DateTime(2024, 5, 21), false, new DateTime(2024, 5, 22), "Preparación para la próxima lactancia"));
        _tareas.Add(new Tarea("Monitoreo del comportamiento y salud de los toros", new DateTime(2024, 5, 22), false, new DateTime(2024, 5, 23), "Detectar posibles problemas de salud"));
        _tareas.Add(new Tarea("Control de la calidad del agua para el ganado", new DateTime(2024, 5, 23), false, new DateTime(2024, 5, 24), "Mantener hidratación adecuada"));
        _tareas.Add(new Tarea("Registro y seguimiento de la reproducción en ovejas", new DateTime(2024, 5, 24), false, new DateTime(2024, 5, 25), "Optimizar la eficiencia reproductiva"));
        _tareas.Add(new Tarea("Inspección y limpieza de áreas de descanso para el ganado", new DateTime(2024, 5, 25), false, new DateTime(2024, 5, 26), "Promover el confort y bienestar"));
        _tareas.Add(new Tarea("Control de temperatura y ventilación en el galpón de aves", new DateTime(2024, 5, 26), false, new DateTime(2024, 5, 27), "Evitar el estrés por calor"));
        _tareas.Add(new Tarea("Realizar vacunación contra enfermedades respiratorias en bovinos", new DateTime(2024, 5, 13), false, new DateTime(2024, 5, 14), "Prioridad alta"));
        _tareas.Add(new Tarea("Controlar y tratar garrapatas en ovejas", new DateTime(2024, 5, 14), false, new DateTime(2024, 5, 15), "Necesario con urgencia"));
        _tareas.Add(new Tarea("Supervisar y asistir en parto de ovejas preñadas", new DateTime(2024, 5, 15), false, new DateTime(2024, 5, 16), "Inmediatamente"));
        _tareas.Add(new Tarea("Alimentar a los terneros con suplementos nutritivos", new DateTime(2024, 5, 16), false, new DateTime(2024, 5, 17), "Mantener crecimiento"));
        _tareas.Add(new Tarea("Controlar la calidad del forraje para ovinos", new DateTime(2024, 5, 17), false, new DateTime(2024, 5, 18), "Optimizar nutrición"));
        _tareas.Add(new Tarea("Monitorear signos de enfermedad en el ganado", new DateTime(2024, 5, 18), false, new DateTime(2024, 5, 19), "Prevenir brotes"));
        _tareas.Add(new Tarea("Entrenamiento y socialización de corderos", new DateTime(2024, 5, 19), false, new DateTime(2024, 5, 20), "Mejorar comportamiento"));
        _tareas.Add(new Tarea("Realizar tratamiento preventivo para mastitis en vacas lecheras", new DateTime(2024, 5, 20), false, new DateTime(2024, 5, 21), "Evitar infecciones"));
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
        _tareas.Add(new Tarea("Realizar tratamiento preventivo para mastitis en vacas lecheras", new DateTime(2024, 5, 20), false, new DateTime(2024, 5, 21), "Evitar infecciones"));
        _tareas.Add(new Tarea("Cuidado y revisión de pezuñas en bovinos", new DateTime(2024, 5, 21), false, new DateTime(2024, 5, 22), "Mantener salud"));
        _tareas.Add(new Tarea("Control de estrés en el ganado durante movimientos", new DateTime(2024, 5, 22), false, new DateTime(2024, 5, 23), "Minimizar pérdidas"));
        _tareas.Add(new Tarea("Supervisar y registrar el peso de los corderos", new DateTime(2024, 5, 23), false, new DateTime(2024, 5, 24), "Evaluar crecimiento"));
        _tareas.Add(new Tarea("Acondicionar y mantener refugios para el ganado", new DateTime(2024, 5, 24), false, new DateTime(2024, 5, 25), "Proteger contra condiciones climáticas"));
        _tareas.Add(new Tarea("Control de temperatura en nidos de aves de corral", new DateTime(2024, 5, 25), false, new DateTime(2024, 5, 26), "Optimizar condiciones de incubación"));
        _tareas.Add(new Tarea("Realizar castración de corderos machos", new DateTime(2024, 5, 26), false, new DateTime(2024, 5, 27), "Control de población y comportamiento"));
        _tareas.Add(new Tarea("Alimentar a los cerdos", new DateTime(2024, 5, 13), false, new DateTime(2024, 5, 14), "Prioridad alta"));
        _tareas.Add(new Tarea("Reparar la cerca del campo", new DateTime(2024, 5, 14), false, new DateTime(2024, 5, 15), "Necesario con urgencia"));
        _tareas.Add(new Tarea("Sembrar maíz en el terreno A", new DateTime(2024, 5, 15), false, new DateTime(2024, 5, 16), "Listo para la siembra"));
        _tareas.Add(new Tarea("Podar los árboles frutales", new DateTime(2024, 5, 16), false, new DateTime(2024, 5, 17), "Mantener la producción"));
        _tareas.Add(new Tarea("Revisar el sistema de riego", new DateTime(2024, 5, 17), false, new DateTime(2024, 5, 18), "Prepararse para la temporada seca"));
        _tareas.Add(new Tarea("Limpiar los establos", new DateTime(2024, 5, 18), false, new DateTime(2024, 5, 19), "Evitar enfermedades en los animales"));
        _tareas.Add(new Tarea("Preparar el suelo para plantar hortalizas", new DateTime(2024, 5, 19), false, new DateTime(2024, 5, 20), "Mejorar la calidad del suelo"));
        _tareas.Add(new Tarea("Fertilizar el campo", new DateTime(2024, 5, 20), false, new DateTime(2024, 5, 21), "Aumentar la productividad"));
        _tareas.Add(new Tarea("Comprar nuevos implementos agrícolas", new DateTime(2024, 5, 21), false, new DateTime(2024, 5, 22), "Optimizar el trabajo"));
        _tareas.Add(new Tarea("Entrenar al personal en nuevas técnicas de cultivo", new DateTime(2024, 5, 22), false, new DateTime(2024, 5, 23), "Mejorar la eficiencia"));
        _tareas.Add(new Tarea("Controlar plagas en los cultivos", new DateTime(2024, 5, 23), false, new DateTime(2024, 5, 24), "Evitar pérdidas de cosecha"));
        _tareas.Add(new Tarea("Revisar el estado de los equipos de labranza", new DateTime(2024, 5, 24), false, new DateTime(2024, 5, 25), "Prevenir averías"));
        _tareas.Add(new Tarea("Recolectar la cosecha de trigo", new DateTime(2024, 5, 25), false, new DateTime(2024, 5, 26), "Iniciar el proceso de almacenamiento"));
        _tareas.Add(new Tarea("Esterilizar el equipo de ordeño", new DateTime(2024, 5, 26), false, new DateTime(2024, 5, 27), "Mantener la higiene"));
        _tareas.Add(new Tarea("Vacunar ovinos contra enfermedades comunes", new DateTime(2024, 5, 13), false, new DateTime(2024, 5, 14), "Prioridad alta"));
        _tareas.Add(new Tarea("Controlar y tratar parásitos en bovinos", new DateTime(2024, 5, 14), false, new DateTime(2024, 5, 15), "Necesario con urgencia"));
        _tareas.Add(new Tarea("Desparasitación de terneros y ovejas", new DateTime(2024, 5, 13), false, new DateTime(2024, 5, 14), "Prioridad alta"));
        _tareas.Add(new Tarea("Supervisar el crecimiento y desarrollo de los corderos", new DateTime(2024, 5, 14), false, new DateTime(2024, 5, 15), "Necesario con urgencia"));
        _tareas.Add(new Tarea("Control de enfermedades reproductivas en el ganado bovino", new DateTime(2024, 5, 15), false, new DateTime(2024, 5, 16), "Inmediatamente"));
        _tareas.Add(new Tarea("Alimentación suplementaria para vacas en gestación", new DateTime(2024, 5, 16), false, new DateTime(2024, 5, 17), "Mantener salud de la madre y el feto"));
        _tareas.Add(new Tarea("Revisión de la condición corporal del ganado", new DateTime(2024, 5, 17), false, new DateTime(2024, 5, 18), "Optimizar alimentación"));
        _tareas.Add(new Tarea("Control de enfermedades respiratorias en ovejas", new DateTime(2024, 5, 18), false, new DateTime(2024, 5, 19), "Prevenir contagios"));
        _tareas.Add(new Tarea("Entrenamiento de perros pastores y su integración con el rebaño", new DateTime(2024, 5, 19), false, new DateTime(2024, 5, 20), "Mejorar manejo del ganado"));
        _tareas.Add(new Tarea("Manejo de estrés en el ganado durante el transporte", new DateTime(2024, 5, 20), false, new DateTime(2024, 5, 21), "Reducir impacto negativo en la salud"));
        _tareas.Add(new Tarea("Supervisión del periodo de secado en vacas lecheras", new DateTime(2024, 5, 21), false, new DateTime(2024, 5, 22), "Preparación para la próxima lactancia"));
        _tareas.Add(new Tarea("Monitoreo del comportamiento y salud de los toros", new DateTime(2024, 5, 22), false, new DateTime(2024, 5, 23), "Detectar posibles problemas de salud"));
        _tareas.Add(new Tarea("Control de la calidad del agua para el ganado", new DateTime(2024, 5, 23), false, new DateTime(2024, 5, 24), "Mantener hidratación adecuada"));
        _tareas.Add(new Tarea("Registro y seguimiento de la reproducción en ovejas", new DateTime(2024, 5, 24), false, new DateTime(2024, 5, 25), "Optimizar la eficiencia reproductiva"));
        _tareas.Add(new Tarea("Inspección y limpieza de áreas de descanso para el ganado", new DateTime(2024, 5, 25), false, new DateTime(2024, 5, 26), "Promover el confort y bienestar"));
        _tareas.Add(new Tarea("Control de temperatura y ventilación en el galpón de aves", new DateTime(2024, 5, 26), false, new DateTime(2024, 5, 27), "Evitar el estrés por calor"));
        _tareas.Add(new Tarea("Realizar vacunación contra enfermedades respiratorias en bovinos", new DateTime(2024, 5, 13), false, new DateTime(2024, 5, 14), "Prioridad alta"));
        _tareas.Add(new Tarea("Controlar y tratar garrapatas en ovejas", new DateTime(2024, 5, 14), false, new DateTime(2024, 5, 15), "Necesario con urgencia"));
        _tareas.Add(new Tarea("Supervisar y asistir en parto de ovejas preñadas", new DateTime(2024, 5, 15), false, new DateTime(2024, 5, 16), "Inmediatamente"));
        _tareas.Add(new Tarea("Alimentar a los terneros con suplementos nutritivos", new DateTime(2024, 5, 16), false, new DateTime(2024, 5, 17), "Mantener crecimiento"));
        _tareas.Add(new Tarea("Controlar la calidad del forraje para ovinos", new DateTime(2024, 5, 17), false, new DateTime(2024, 5, 18), "Optimizar nutrición"));
        _tareas.Add(new Tarea("Monitorear signos de enfermedad en el ganado", new DateTime(2024, 5, 18), false, new DateTime(2024, 5, 19), "Prevenir brotes"));
        _tareas.Add(new Tarea("Entrenamiento y socialización de corderos", new DateTime(2024, 5, 19), false, new DateTime(2024, 5, 20), "Mejorar comportamiento"));
        _tareas.Add(new Tarea("Realizar tratamiento preventivo para mastitis en vacas lecheras", new DateTime(2024, 5, 20), false, new DateTime(2024, 5, 21), "Evitar infecciones"));
        _tareas.Add(new Tarea("Cuidado y revisión de pezuñas en bovinos", new DateTime(2024, 5, 21), false, new DateTime(2024, 5, 22), "Mantener salud"));
        _tareas.Add(new Tarea("Control de estrés en el ganado durante movimientos", new DateTime(2024, 5, 22), false, new DateTime(2024, 5, 23), "Minimizar pérdidas"));
        _tareas.Add(new Tarea("Supervisar y registrar el peso de los corderos", new DateTime(2024, 5, 23), false, new DateTime(2024, 5, 24), "Evaluar crecimiento"));
        _tareas.Add(new Tarea("Acondicionar y mantener refugios para el ganado", new DateTime(2024, 5, 24), false, new DateTime(2024, 5, 25), "Proteger contra condiciones climáticas"));
        _tareas.Add(new Tarea("Control de temperatura en nidos de aves de corral", new DateTime(2024, 5, 25), false, new DateTime(2024, 5, 26), "Optimizar condiciones de incubación"));
        _tareas.Add(new Tarea("Realizar castración de corderos machos", new DateTime(2024, 5, 26), false, new DateTime(2024, 5, 27), "Control de población y comportamiento"));
        _tareas.Add(new Tarea("Alimentar a los cerdos", new DateTime(2024, 5, 13), false, new DateTime(2024, 5, 14), "Prioridad alta"));
        _tareas.Add(new Tarea("Reparar la cerca del campo", new DateTime(2024, 5, 14), false, new DateTime(2024, 5, 15), "Necesario con urgencia"));
        _tareas.Add(new Tarea("Sembrar maíz en el terreno A", new DateTime(2024, 5, 15), false, new DateTime(2024, 5, 16), "Listo para la siembra"));
        _tareas.Add(new Tarea("Podar los árboles frutales", new DateTime(2024, 5, 16), false, new DateTime(2024, 5, 17), "Mantener la producción"));
        _tareas.Add(new Tarea("Revisar el sistema de riego", new DateTime(2024, 5, 17), false, new DateTime(2024, 5, 18), "Prepararse para la temporada seca"));
        _tareas.Add(new Tarea("Limpiar los establos", new DateTime(2024, 5, 18), false, new DateTime(2024, 5, 19), "Evitar enfermedades en los animales"));
        _tareas.Add(new Tarea("Preparar el suelo para plantar hortalizas", new DateTime(2024, 5, 19), false, new DateTime(2024, 5, 20), "Mejorar la calidad del suelo"));
        _tareas.Add(new Tarea("Fertilizar el campo", new DateTime(2024, 5, 20), false, new DateTime(2024, 5, 21), "Aumentar la productividad"));
        _tareas.Add(new Tarea("Comprar nuevos implementos agrícolas", new DateTime(2024, 5, 21), false, new DateTime(2024, 5, 22), "Optimizar el trabajo"));
        _tareas.Add(new Tarea("Entrenar al personal en nuevas técnicas de cultivo", new DateTime(2024, 5, 22), false, new DateTime(2024, 5, 23), "Mejorar la eficiencia"));
        _tareas.Add(new Tarea("Controlar plagas en los cultivos", new DateTime(2024, 5, 23), false, new DateTime(2024, 5, 24), "Evitar pérdidas de cosecha"));
        _tareas.Add(new Tarea("Revisar el estado de los equipos de labranza", new DateTime(2024, 5, 24), false, new DateTime(2024, 5, 25), "Prevenir averías"));
        _tareas.Add(new Tarea("Recolectar la cosecha de trigo", new DateTime(2024, 5, 25), false, new DateTime(2024, 5, 26), "Iniciar el proceso de almacenamiento"));
        _tareas.Add(new Tarea("Esterilizar el equipo de ordeño", new DateTime(2024, 5, 26), false, new DateTime(2024, 5, 27), "Mantener la higiene"));
        _tareas.Add(new Tarea("Vacunar ovinos contra enfermedades comunes", new DateTime(2024, 5, 13), false, new DateTime(2024, 5, 14), "Prioridad alta"));
        _tareas.Add(new Tarea("Controlar y tratar parásitos en bovinos", new DateTime(2024, 5, 14), false, new DateTime(2024, 5, 15), "Necesario con urgencia"));
        _tareas.Add(new Tarea("Realizar marcaje y registro de nuevos corderos", new DateTime(2024, 5, 15), false, new DateTime(2024, 5, 16), "Inmediatamente"));
        _tareas.Add(new Tarea("Revisar y mantener el vallado de los corrales", new DateTime(2024, 5, 16), false, new DateTime(2024, 5, 17), "Mantener la seguridad"));
        _tareas.Add(new Tarea("Preparar instalaciones para la época de partos", new DateTime(2024, 5, 17), false, new DateTime(2024, 5, 18), "Prevenir problemas durante parto"));
        _tareas.Add(new Tarea("Revisar la nutrición del ganado bovino", new DateTime(2024, 5, 18), false, new DateTime(2024, 5, 19), "Optimizar rendimiento"));
        _tareas.Add(new Tarea("Control de peso y salud de ovejas preñadas", new DateTime(2024, 5, 19), false, new DateTime(2024, 5, 20), "Prevenir complicaciones"));
        _tareas.Add(new Tarea("Realizar esquila de ovejas", new DateTime(2024, 5, 20), false, new DateTime(2024, 5, 21), "Mantener higiene y salud"));
        _tareas.Add(new Tarea("Control sanitario y vacunación de terneros", new DateTime(2024, 5, 21), false, new DateTime(2024, 5, 22), "Evitar enfermedades"));
        _tareas.Add(new Tarea("Entrenamiento de perros pastores", new DateTime(2024, 5, 22), false, new DateTime(2024, 5, 23), "Mejorar manejo de ganado"));
        _tareas.Add(new Tarea("Mantenimiento de bebederos y comederos", new DateTime(2024, 5, 23), false, new DateTime(2024, 5, 24), "Optimizar alimentación"));
        _tareas.Add(new Tarea("Supervisar condiciones de pastoreo", new DateTime(2024, 5, 24), false, new DateTime(2024, 5, 25), "Maximizar aprovechamiento"));
        _tareas.Add(new Tarea("Monitorear signos de enfermedad en el ganado", new DateTime(2024, 5, 25), false, new DateTime(2024, 5, 26), "Prevenir brotes"));
        _tareas.Add(new Tarea("Planificar rotación de pastos", new DateTime(2024, 5, 26), false, new DateTime(2024, 5, 27), "Mantener calidad del forraje"));
        _tareas.Add(new Tarea("Control de enfermedades reproductivas en ovejas", new DateTime(2024, 5, 13), false, new DateTime(2024, 5, 14), "Prioridad alta"));
        _tareas.Add(new Tarea("Revisar y mantener la infraestructura de los establos", new DateTime(2024, 5, 14), false, new DateTime(2024, 5, 15), "Necesario con urgencia"));
        _tareas.Add(new Tarea("Alimentar a los terneros recién nacidos", new DateTime(2024, 5, 15), false, new DateTime(2024, 5, 16), "Inmediatamente"));
        _tareas.Add(new Tarea("Desparasitar y vacunar a los corderos", new DateTime(2024, 5, 16), false, new DateTime(2024, 5, 17), "Mantener la salud"));
        _tareas.Add(new Tarea("Supervisar el parto de vacas preñadas", new DateTime(2024, 5, 17), false, new DateTime(2024, 5, 18), "Prevenir complicaciones"));
        _tareas.Add(new Tarea("Control de malezas en los campos de pastoreo", new DateTime(2024, 5, 18), false, new DateTime(2024, 5, 19), "Optimizar rendimiento"));
        _tareas.Add(new Tarea("Inspeccionar y mantener los sistemas de agua", new DateTime(2024, 5, 19), false, new DateTime(2024, 5, 20), "Prevenir escasez de agua"));
        _tareas.Add(new Tarea("Castración de terneros machos", new DateTime(2024, 5, 20), false, new DateTime(2024, 5, 21), "Control de población"));
        _tareas.Add(new Tarea("Supervisar el destete de corderos", new DateTime(2024, 5, 21), false, new DateTime(2024, 5, 22), "Minimizar estrés"));
        _tareas.Add(new Tarea("Control de calidad de la leche en vacas lecheras", new DateTime(2024, 5, 22), false, new DateTime(2024, 5, 23), "Mantener estándares"));
        _tareas.Add(new Tarea("Revisar y limpiar las instalaciones de ordeño", new DateTime(2024, 5, 23), false, new DateTime(2024, 5, 24), "Mantener higiene"));
        _tareas.Add(new Tarea("Cuidado de ubres en vacas lecheras", new DateTime(2024, 5, 24), false, new DateTime(2024, 5, 25), "Prevenir mastitis"));
        _tareas.Add(new Tarea("Entrenamiento de bueyes para trabajos agrícolas", new DateTime(2024, 5, 25), false, new DateTime(2024, 5, 26), "Mejorar habilidades"));
        _tareas.Add(new Tarea("Monitorear el crecimiento de terneros", new DateTime(2024, 5, 26), false, new DateTime(2024, 5, 27), "Detectar problemas nutricionales"));
        _tareas.Add(new Tarea("Reparar cercas perimetrales", new DateTime(2024, 5, 13), false, new DateTime(2024, 5, 14), "Prioridad alta"));
        _tareas.Add(new Tarea("Mantenimiento de los techos de los establos", new DateTime(2024, 5, 14), false, new DateTime(2024, 5, 15), "Necesario con urgencia"));
        _tareas.Add(new Tarea("Podar árboles alrededor de las instalaciones", new DateTime(2024, 5, 15), false, new DateTime(2024, 5, 16), "Inmediatamente"));
        _tareas.Add(new Tarea("Revisión y limpieza de drenajes", new DateTime(2024, 5, 16), false, new DateTime(2024, 5, 17), "Mantener la funcionalidad"));
        _tareas.Add(new Tarea("Pintar y mantener los portones de acceso", new DateTime(2024, 5, 17), false, new DateTime(2024, 5, 18), "Mejorar apariencia"));
        _tareas.Add(new Tarea("Revisión de sistemas eléctricos en los establos", new DateTime(2024, 5, 18), false, new DateTime(2024, 5, 19), "Prevenir cortocircuitos"));
        _tareas.Add(new Tarea("Control de plagas en almacenes de alimento", new DateTime(2024, 5, 19), false, new DateTime(2024, 5, 20), "Mantener calidad de alimento"));
        _tareas.Add(new Tarea("Reparación de bebederos y sistemas de agua", new DateTime(2024, 5, 20), false, new DateTime(2024, 5, 21), "Evitar desperdicios"));
        _tareas.Add(new Tarea("Limpieza y desinfección de áreas comunes", new DateTime(2024, 5, 21), false, new DateTime(2024, 5, 22), "Prevenir enfermedades"));
        _tareas.Add(new Tarea("Reparación de pisos en los corrales", new DateTime(2024, 5, 22), false, new DateTime(2024, 5, 23), "Evitar lesiones"));
        _tareas.Add(new Tarea("Inspección de la iluminación en áreas de trabajo", new DateTime(2024, 5, 23), false, new DateTime(2024, 5, 24), "Mejorar condiciones laborales"));
        _tareas.Add(new Tarea("Revisión y mantenimiento de sistemas de ventilación", new DateTime(2024, 5, 24), false, new DateTime(2024, 5, 25), "Garantizar bienestar animal"));
        _tareas.Add(new Tarea("Limpieza de desagües y canaletas", new DateTime(2024, 5, 25), false, new DateTime(2024, 5, 26), "Prevenir inundaciones"));
        _tareas.Add(new Tarea("Control de malezas en áreas de paso", new DateTime(2024, 5, 26), false, new DateTime(2024, 5, 27), "Mejorar seguridad"));
        _tareas.Add(new Tarea("Reparación de vallas en áreas de pastoreo", new DateTime(2024, 5, 13), false, new DateTime(2024, 5, 14), "Prioridad alta"));
        _tareas.Add(new Tarea("Limpieza y desinfección de áreas de almacenamiento", new DateTime(2024, 5, 14), false, new DateTime(2024, 5, 15), "Necesario con urgencia"));
        _tareas.Add(new Tarea("Revisión de sistema de drenaje en los establos", new DateTime(2024, 5, 15), false, new DateTime(2024, 5, 16), "Inmediatamente"));
        _tareas.Add(new Tarea("Mantenimiento de caminos y accesos a los campos", new DateTime(2024, 5, 16), false, new DateTime(2024, 5, 17), "Mantener accesibilidad"));
        _tareas.Add(new Tarea("Instalación de sistemas de sombreado en corrales", new DateTime(2024, 5, 17), false, new DateTime(2024, 5, 18), "Proteger animales del calor"));
        _tareas.Add(new Tarea("Reparación de bebederos automáticos", new DateTime(2024, 5, 18), false, new DateTime(2024, 5, 19), "Evitar desperdicios de agua"));
        _tareas.Add(new Tarea("Poda y mantenimiento de cercos vivos", new DateTime(2024, 5, 19), false, new DateTime(2024, 5, 20), "Mejorar estética y funcionalidad"));
        _tareas.Add(new Tarea("Limpieza de estanques y depósitos de agua", new DateTime(2024, 5, 20), false, new DateTime(2024, 5, 21), "Mantener calidad de agua"));
        _tareas.Add(new Tarea("Revisión y reparación de techos de galpones", new DateTime(2024, 5, 21), false, new DateTime(2024, 5, 22), "Prevenir filtraciones"));
        _tareas.Add(new Tarea("Instalación de luces de seguridad en áreas sensibles", new DateTime(2024, 5, 22), false, new DateTime(2024, 5, 23), "Mejorar vigilancia nocturna"));
        _tareas.Add(new Tarea("Limpieza y desmalezado de áreas comunes", new DateTime(2024, 5, 23), false, new DateTime(2024, 5, 24), "Prevenir refugio de plagas"));
        _tareas.Add(new Tarea("Control de erosión en terrenos de pastoreo", new DateTime(2024, 5, 24), false, new DateTime(2024, 5, 25), "Conservar suelos"));
        _tareas.Add(new Tarea("Revisión y reparación de sistemas de alimentación automatizados", new DateTime(2024, 5, 25), false, new DateTime(2024, 5, 26), "Optimizar alimentación"));
        _tareas.Add(new Tarea("Mantenimiento de silos y depósitos de alimento", new DateTime(2024, 5, 26), false, new DateTime(2024, 5, 27), "Prevenir contaminación de alimento"));
        _tareas.Add(new Tarea("Castración de terneros machos", new DateTime(2024, 5, 20), false, new DateTime(2024, 5, 21), "Control de población"));
        _tareas.Add(new Tarea("Supervisar el destete de corderos", new DateTime(2024, 5, 21), false, new DateTime(2024, 5, 22), "Minimizar estrés"));
        _tareas.Add(new Tarea("Control de calidad de la leche en vacas lecheras", new DateTime(2024, 5, 22), false, new DateTime(2024, 5, 23), "Mantener estándares"));
        _tareas.Add(new Tarea("Revisar y limpiar las instalaciones de ordeño", new DateTime(2024, 5, 23), false, new DateTime(2024, 5, 24), "Mantener higiene"));
        _tareas.Add(new Tarea("Cuidado de ubres en vacas lecheras", new DateTime(2024, 5, 24), false, new DateTime(2024, 5, 25), "Prevenir mastitis"));
        _tareas.Add(new Tarea("Entrenamiento de bueyes para trabajos agrícolas", new DateTime(2024, 5, 25), false, new DateTime(2024, 5, 26), "Mejorar habilidades"));
        _tareas.Add(new Tarea("Monitorear el crecimiento de terneros", new DateTime(2024, 5, 26), false, new DateTime(2024, 5, 27), "Detectar problemas nutricionales"));
        _tareas.Add(new Tarea("Reparar cercas perimetrales", new DateTime(2024, 5, 13), false, new DateTime(2024, 5, 14), "Prioridad alta"));
        _tareas.Add(new Tarea("Mantenimiento de los techos de los establos", new DateTime(2024, 5, 14), false, new DateTime(2024, 5, 15), "Necesario con urgencia"));
        _tareas.Add(new Tarea("Podar árboles alrededor de las instalaciones", new DateTime(2024, 5, 15), false, new DateTime(2024, 5, 16), "Inmediatamente"));
        _tareas.Add(new Tarea("Revisión y limpieza de drenajes", new DateTime(2024, 5, 16), false, new DateTime(2024, 5, 17), "Mantener la funcionalidad"));
        _tareas.Add(new Tarea("Pintar y mantener los portones de acceso", new DateTime(2024, 5, 17), false, new DateTime(2024, 5, 18), "Mejorar apariencia"));
        _tareas.Add(new Tarea("Revisión de sistemas eléctricos en los establos", new DateTime(2024, 5, 18), false, new DateTime(2024, 5, 19), "Prevenir cortocircuitos"));
        _tareas.Add(new Tarea("Control de plagas en almacenes de alimento", new DateTime(2024, 5, 19), false, new DateTime(2024, 5, 20), "Mantener calidad de alimento"));
        _tareas.Add(new Tarea("Reparación de bebederos y sistemas de agua", new DateTime(2024, 5, 20), false, new DateTime(2024, 5, 21), "Evitar desperdicios"));
        _tareas.Add(new Tarea("Limpieza y desinfección de áreas comunes", new DateTime(2024, 5, 21), false, new DateTime(2024, 5, 22), "Prevenir enfermedades"));
        _tareas.Add(new Tarea("Reparación de pisos en los corrales", new DateTime(2024, 5, 22), false, new DateTime(2024, 5, 23), "Evitar lesiones"));


        // Animales (30 Animales)

        //Bovinos
        _animales.Add(new Bovino(TipoAlimentacion.Concentrado, 500, TipoGenero.Macho, "Hereford", new DateTime(2024, 5, 22), 200, 100, 600, true, new List<Vacunacion>(), true));
        _animales.Add(new Bovino(TipoAlimentacion.Pastura, 500, TipoGenero.Macho, "Hereford", new DateTime(2024, 5, 22), 200, 100, 600, true, new List<Vacunacion>(), true));
        _animales.Add(new Bovino(TipoAlimentacion.Concentrado, 450, TipoGenero.Hembra, "Angus", new DateTime(2024, 4, 18), 180, 90, 550, false, new List<Vacunacion>(), true));
        _animales.Add(new Bovino(TipoAlimentacion.Mezcla, 520, TipoGenero.Macho, "Simmental", new DateTime(2024, 3, 15), 250, 120, 480, false, new List<Vacunacion>(), true));
        _animales.Add(new Bovino(TipoAlimentacion.Pastura, 480, TipoGenero.Hembra, "Brahman", new DateTime(2024, 2, 10), 220, 110, 500, false, new List<Vacunacion>(), true));
        _animales.Add(new Bovino(TipoAlimentacion.Concentrado, 510, TipoGenero.Macho, "Limousin", new DateTime(2024, 1, 5), 230, 115, 490, true, new List<Vacunacion>(), true));
        _animales.Add(new Bovino(TipoAlimentacion.Pastura, 490, TipoGenero.Hembra, "Charolais", new DateTime(2023, 12, 1), 210, 105, 520, false, new List<Vacunacion>(), true));
        _animales.Add(new Bovino(TipoAlimentacion.Mezcla, 530, TipoGenero.Macho, "Aberdeen Angus", new DateTime(2023, 10, 27), 240, 125, 470, false, new List<Vacunacion>(), true));
        _animales.Add(new Bovino(TipoAlimentacion.Pastura, 470, TipoGenero.Hembra, "Gyr", new DateTime(2023, 9, 23), 200, 100, 540, true, new List<Vacunacion>(), true));
        _animales.Add(new Bovino(TipoAlimentacion.Concentrado, 560, TipoGenero.Macho, "Holstein", new DateTime(2023, 8, 19), 260, 130, 460, false, new List<Vacunacion>(), true));
        _animales.Add(new Bovino(TipoAlimentacion.Pastura, 440, TipoGenero.Hembra, "Jersey", new DateTime(2023, 7, 15), 190, 95, 570, false, new List<Vacunacion>(), true));
        _animales.Add(new Bovino(TipoAlimentacion.Mezcla, 580, TipoGenero.Macho, "Wagyu", new DateTime(2023, 6, 10), 280, 140, 450, true, new List<Vacunacion>(), true));
        _animales.Add(new Bovino(TipoAlimentacion.Pastura, 420, TipoGenero.Hembra, "Normando", new DateTime(2023, 5, 6), 170, 85, 580, false, new List<Vacunacion>(), true));
        _animales.Add(new Bovino(TipoAlimentacion.Mezcla, 600, TipoGenero.Macho, "Friesian", new DateTime(2023, 4, 1), 300, 150, 440, false, new List<Vacunacion>(), true));
        _animales.Add(new Bovino(TipoAlimentacion.Pastura, 400, TipoGenero.Hembra, "Chianina", new DateTime(2023, 2, 25), 160, 80, 590, true, new List<Vacunacion>(), true));

        //Ovinos
        _animales.Add(new Ovino(30, TipoGenero.Hembra, "Dorper", new DateTime(2023, 2, 25), 160, 80, 590, true, new List<Vacunacion>(), true)); _animales.Add(new Ovino(25, TipoGenero.Hembra, "Merino", new DateTime(2023, 3, 15), 170, 85, 580, false, new List<Vacunacion>(), true));
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
    public void UpdateAnimals()
    {
        foreach (Animal animal in _animales)
        {
            Random rnd = new Random();
			int random = rnd.Next(1, 10);
			_potreros[random].AgregarAnimal(animal);
		}
    }
}
