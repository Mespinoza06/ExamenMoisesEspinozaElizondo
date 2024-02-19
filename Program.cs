// See https://aka.ms/new-console-template for more information

using System.Numerics;

int opcion = 0;
string[] cedula = new string[2];
string[] nombre = new string[2];
string[] telefono = new string[2];
string[] tipoSangre = new string[2];
string[] direccion = new string[2];
int[] fechaNacimient = new int[2];
int[] fn=new int[2];
int[] consulta=new int[2];
string [] contador= new string[2];
int total = 0;
string edades ="";
int tiempo = 0;
int num = 0;
// Catalogo de medicamento
int[] codigoMedicamento = new int[2];
string[] nombreMedicamento = new string[2];
int[] cantidad = new int[2];
DateTime fechaNacimiento;



do
{
    Console.WriteLine("=================================");
    Console.WriteLine("Sistema de Gestión de Pacientes");
    Console.WriteLine("=================================");
    Console.WriteLine("1. Agregar Paciente");
    Console.WriteLine("2. Agregar Medicamento al Catálogo");
    Console.WriteLine("3. Asignar Tratamiento Médico a un Paciente");
    Console.WriteLine("4. Consultas");
    Console.WriteLine("5. Salir");
    Console.WriteLine("=================================");

    opcion = int.Parse(Console.ReadLine());

    switch (opcion)
    {
        case 1:
            try
            {
                for (int i = 0; i < cedula.Length; i++)
                {

                    Console.WriteLine($"Digite la Cedula del Paciente {i + 1}:");
                    cedula[i] = Console.ReadLine();

                    Console.WriteLine($"Digite el Nombre del Paciente {i + 1}:");
                    nombre[i] = Console.ReadLine();

                    Console.WriteLine($"Digite el Numero de Teléfono del Paciente {i + 1}:");
                    telefono[i] = Console.ReadLine();

                    Console.WriteLine($"Digite el Tipo de Sangre del Paciente {i + 1}:");
                    tipoSangre[i] = Console.ReadLine();

                    Console.WriteLine($"Digite la Dirección del Paciente {i + 1}:");
                    direccion[i] = Console.ReadLine();


                    Console.WriteLine("Ingrese la fecha de nacimiento en formato DD/MM/YYYY:");
                    string inputFechaNacimiento = Console.ReadLine();


                    //trata de analizar el formato que la fecha que se ingresa con la del sistema, y la convierte en el formato de fecha para podr ser restada
                    if (DateTime.TryParseExact(inputFechaNacimiento, "dd/MM/yyyy", null, System.Globalization.DateTimeStyles.None, out fechaNacimiento))
                    {
                        // Obtener la fecha actual
                        DateTime fechaActual = DateTime.Today;

                        // Calcula la edad
                        int edad = fechaActual.Year - fechaNacimiento.Year;
                        int nacimiento = fechaNacimiento.Year;
                        fn[i] = nacimiento;



                        // Muestra la edad
                        Console.WriteLine($"La edad es: {edad} años");
                        
                    }
                    else
                    {
                        Console.WriteLine("Formato de fecha incorrecto. Por favor, ingrese la fecha en el formato especificado.");
                    }
                    total++;

                }
            }
            catch (Exception)
            {

                Console.WriteLine("error de formato");
            }
            
            break;

        case 2:
            try
            {
                for (int i = 0; i < codigoMedicamento.Length; i++)
                {
                    Console.WriteLine($"Digite el Código del Medicamento {i + 1}:");
                    codigoMedicamento[i] = int.Parse(Console.ReadLine());

                    Console.WriteLine($"Digite el Nombre del Medicamento {i + 1}:");
                    nombreMedicamento[i] = Console.ReadLine();

                    Console.WriteLine($"Digite la Cantidad de Medicamentos {i + 1}:");
                    cantidad[i] = int.Parse(Console.ReadLine());
                }
            }
            catch (Exception)
            {

                Console.WriteLine("error de formato");
                
            }
           
            break;

        case 3://asignar tratamiento a paciente
            try
            {
                Console.WriteLine("Digite el número de cédula del Paciente:");
                string buscar = Console.ReadLine();

                int pacienteIndex = Array.IndexOf(cedula, buscar); //busca un elemento dentro del arreglo y regresa su indice
                if (pacienteIndex == -1)
                {
                    Console.WriteLine("No se encontró ningún paciente con esa cédula.");
                    continue;
                }

                Console.WriteLine("Paciente encontrado.");
                int index = 0;
                int medicamentosAsignados = 0;

                index = consulta[pacienteIndex];


                do
                {
                    Console.WriteLine("Digite el código del medicamento a recetar:");
                    int recetar = int.Parse(Console.ReadLine());

                    int medicamentoIndex = Array.IndexOf(codigoMedicamento, recetar);//busca un elemento dentro del arreglo y regresa su indice
                    if (medicamentoIndex == -1)
                    {
                        Console.WriteLine("El medicamento no está en el catálogo.");
                        continue;
                    }

                    Console.WriteLine("Medicamento encontrado.");
                    int cont = 0;
                    contador[cont] = nombreMedicamento[cont];
                    cont++;

                    Console.WriteLine("Digite cuántas unidades necesita:");
                    int unidades = int.Parse(Console.ReadLine());

                    if (unidades <= 0)
                    {
                        Console.WriteLine("La cantidad debe ser mayor que cero.");
                        continue;
                    }

                    if (unidades > cantidad[medicamentoIndex])
                    {
                        Console.WriteLine("La cantidad en inventario es insuficiente.");
                        continue;
                    }

                    if (medicamentosAsignados >= 3)
                    {
                        Console.WriteLine("Ya se han asignado el máximo de 3 medicamentos.");
                        break;
                    }

                    cantidad[medicamentoIndex] -= unidades;
                    Console.WriteLine($"Unidades restantes en inventario para {nombreMedicamento[medicamentoIndex]}: {cantidad[medicamentoIndex]}");

                    medicamentosAsignados++;

                    Console.WriteLine("¿Desea ingresar otro código de medicamento? (s/n)");
                    string respuesta = Console.ReadLine().ToLower();
                    if (respuesta != "s")
                    {
                        break;
                    }
                } while (medicamentosAsignados < 3);
            }
            catch (Exception)
            {
                Console.WriteLine("Error de formato");


            }
           
            break;


        case 4:
            Array.Sort(nombre);// acomoda el vector en forma abc
            int niño = 0;
            int adulto = 0;
            int adultoMayor = 0;
            int veterano = 0;

            Console.WriteLine("=============================================================================================");
            Console.WriteLine("======================================CONSULTAS==============================================");
            Console.WriteLine($"La cantidad de pancientes registados fueron: {total}");
            Console.WriteLine($"Los medicamentos recetados fueron: {string.Join(", ", nombreMedicamento)}");//concatena los valores del vactor



            int[] nuevosIndices = new int[nombre.Length];
            string[] cedulaAcomodadas = new string[nombre.Length];
            string[] telefonosAcomodados = new string[nombre.Length];
            string[] sangresAcomodados = new string[nombre.Length];
            string[] direccionAcomodados = new string[nombre.Length];
            int[] fechasAcomodados = new int[nombre.Length];

            

            for (int i = 0; i < nombre.Length; i++)// se supone que busca el indice de como se acomodo nombres y se los da a los demas vectores para no perder el indice
            {
                int indice = Array.IndexOf(nombre, nombre[i]);
                nuevosIndices[i] = indice;

                cedulaAcomodadas[i] = cedula[indice];
                telefonosAcomodados[i] = telefono[indice];
                sangresAcomodados[i] = tipoSangre[indice];
                direccionAcomodados[i] = direccion[indice];
                fechasAcomodados[i] = fn[indice];

                //me costo demasido lograr este punto

            }

            for (int i = 0; i < cedula.Length; i++)
            {
                Console.WriteLine($"Cédula: {cedulaAcomodadas[i]} Nombre: {nombre[i]} Teléfono: {telefonosAcomodados[i]} Tipo de Sangre: {sangresAcomodados[i]} Dirección: {direccionAcomodados[i]} Fecha de nacimiento: {fechasAcomodados[i]}  ");
            }
            

            //sumas las edades segun su rango
            for (int i = 0; i < nombre.Length; i++)
            {
                if (fechasAcomodados[i] >= 0 && fechasAcomodados[i] <= 10)
                {
                    niño++;
                }
                else if (fechasAcomodados[i] >= 11 && fechasAcomodados[i] <= 30)
                {
                    adulto++;
                }
                else if (fechasAcomodados[i] >= 31 && fechasAcomodados[i] <= 50)
                {
                    adultoMayor++;
                }
                else if (fechasAcomodados[i] >= 51)
                {
                    veterano++;
                }

            }

            Console.WriteLine($"La cantidad de pacientes en edades entre 0-10 años:[ {niño} ], 11-30 años [ {adulto} ], 31-50 años [ {adultoMayor} ], mayores de 51 años.[ {veterano} ]");

            break;

        case 5:
            Console.WriteLine("Saliendo del programa...");
            break;

        default:
            Console.WriteLine("Opción inválida. Intente de nuevo.");
            break;
    }

} while (opcion != 5);
    
