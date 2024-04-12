

namespace Console
{
    
    public class Program
    {
        
        static void Main ( string[] args )
        {
            System.Console.WriteLine ( "Hello World!" );
        }

        static void MostrarMen(){
            List<string> menu = new List<string> {
                // "1. Crear un nuevo curso",
                // "2. Eliminar un curso",
                // "3. Ver lista de cursos",
                // "4. Ver lista de cursos con alumnos",
                // "5. Ver lista de cursos con profesores",
                // "6. Ver lista de cursos con alumnos y profesores",
                // "7. Ver lista de alumnos",
                // "8. Ver lista de profesores",
                // "9. Ver lista de alumnos con cursos",
                // "10. Ver lista de profesores con cursos",
                // "11. Ver lista de alumnos con cursos y profesores",
                // "12. Ver lista de profesores con cursos y alumnos",
                // "13. Salir"
            };

            foreach(string opcion in menu){
                System.Console.WriteLine(opcion);
            }
        }

        static int PedirNumero(string mensaje)
        {
            System.Console.WriteLine(mensaje);
            int.TryParse(System.Console.ReadLine(), out int numero);
            return numero;
        }

        static string PedirPalabra(string mensaje)
        {
            System.Console.WriteLine(mensaje);
            return System.Console.ReadLine();
        }
    }
}
