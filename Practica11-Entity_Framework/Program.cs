// See https://aka.ms/new-console-template for more information
using Practica11_Entity_Framework;

EstudianteContext contextdb = new EstudianteContext();

Console.WriteLine("          Bienvenido al Registro Estudiantil UNAB          ");
Console.WriteLine("-----------------------------------------------------------");

bool comprobar = true;
while (comprobar == true)
{
    Console.WriteLine("\n---------------------------");
    Console.WriteLine("           MEMU            ");
    Console.WriteLine("---------------------------"); 
    Console.Write("  1. Listar Estudiantes \n  2. Agregar estudiantes \n  3. Salir\nRespuesta: ");
    int desicion = Convert.ToInt32(Console.ReadLine());

    switch (desicion)
    {
        case 1:
            Console.WriteLine("\nListado de Estudiantes");
            Console.WriteLine("-----------------------------");
            Console.WriteLine(" Id  Nombres                 ");
            Console.WriteLine("-----------------------------");

            foreach (var est in contextdb.Estudiante)
            {
                Console.WriteLine($" {est.Id}   {est.Nombres} {est.Apellidos}  \n     Edad: {est.Edad}    Sexo: {est.Sexo}");
            }

            break;

        case 2:
            Console.WriteLine("\nAgregar Estudiantes");
            Console.WriteLine("-----------------------------");
            Console.Write("  1. Automaticamente(Prueba) \n  2. Ingresar nuevo estudiante \nRespuesta: ");
            int desicion2 = Convert.ToInt32(Console.ReadLine());

            switch (desicion2)
            {
                case 1:
                    Console.WriteLine("\nAgregar Estudiante Prueba");
                    Console.WriteLine("---------------------------------------");
                    contextdb.Database.EnsureCreated();
                    Estudiante estudiante1 = new Estudiante() { Nombres = "Rosa Maria", Apellidos = "Guardado Peña", Edad = 20, Sexo = "F" };
                    contextdb.Add(estudiante1);
                    contextdb.SaveChanges();

                    Console.WriteLine("\n - ESTUDIANTE INGRESADO CORRECTAMENTE \n");

                    foreach (var est in contextdb.Estudiante)
                    {
                        Console.WriteLine($" {est.Id}  Nombre: {est.Nombres} {est.Apellidos}  \n    Edad: {est.Edad}     Sexo: {est.Sexo}");
                    }

                    break;

                case 2:
                    int bucle = 1;
                    while (bucle == 1)
                    {
                        Console.WriteLine("\nAgregar Estudiante");
                        Console.WriteLine("----------------------------------");

                        try
                        {
                            Console.Write(" - Ingrese los nombres: \n   ");
                            string Nombres = Console.ReadLine();
                            Console.Write(" - Ingrese los apellidos: \n   ");
                            string Apellidos = Console.ReadLine();
                            Console.Write(" - Ingrese la edad: \n   ");
                            int Edad = Convert.ToInt32(Console.ReadLine());
                            
                            Console.WriteLine(" - Ingrese el sexo del estudiante");
                            Console.Write("   1. Masculino\n   2. Femenino\nSexo: ");
                            string? desicion3 = Console.ReadLine();
                            string Sexo = "";
                            
                            if (desicion3 == "1" || desicion3.ToLower() == "masculino")
                            {
                                Sexo = Convert.ToString('M');
                            }
                            else if (desicion3 == "2" || desicion3.ToLower() == "femenino")
                            {
                                Sexo = Convert.ToString('F');
                            }
                            else
                            {
                                Console.WriteLine("\n - Opcion Invalida \n   Ingrese los datos nuevamente");
                                bucle = 1;
                                continue;
                            }

                            Estudiante Estudiante = new Estudiante() { Nombres = Nombres, Apellidos = Apellidos, Edad = Edad, Sexo = Sexo};

                            contextdb.Add(Estudiante);
                            contextdb.SaveChanges();

                            Console.WriteLine("\n - ESTUDIANTE INGRESADO CORRECTAMENTE \n");

                            foreach (var est in contextdb.Estudiante)
                            {
                                Console.WriteLine($" {est.Id}  Nombre: {est.Nombres} {est.Apellidos}  \n    Edad: {est.Edad}     Sexo: {est.Sexo}");
                            }

                            Console.Write("\nPulse ENTER para continuar: ");
                            var cont = Console.ReadLine();

                        }
                        catch
                        {
                            Console.WriteLine("Error al agregar estudiante. Asegúrese de que los datos sean válidos.");
                        }

                        Console.WriteLine("\nColoque: ");
                        Console.WriteLine("   1. Agregar otro estudiante  ");
                        Console.WriteLine("   2. Salir                 ");
                        Console.Write("- ¿Que desea hacer? ");
                        bucle = Convert.ToInt32(Console.ReadLine());
                    }
                    break;

                default:
                    Console.WriteLine("\n - Opcion Incorrecta");
                    break;
            }
            break;

        case 3:
            Console.WriteLine("\nGracias por visitar nuestro programa \n - Feliz dia");
            comprobar = false;
            break;

        default:
            Console.WriteLine("\n - Opcion Incorrecta");
            break;
    }

}



