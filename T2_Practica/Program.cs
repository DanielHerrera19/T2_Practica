using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace T2_Practica
{
    internal class Program
    {
        static ColaCurso colaCursos = new ColaCurso(50);
        static ColaEstudiante ColaE = new ColaEstudiante(50);

        static ColaNotas Cola = new ColaNotas(50);
        static PilaNotas pilaDeEliminados = new PilaNotas(50);
        static void Main(string[] args)
        {
            RegistroDENotas();
            Console.ReadKey();
        }

        static void RegistroDENotas()
        {
            // Precargar datos de pacientes al iniciar el programa
            CargarRegistroNotas.PrecargarDatos(Cola);
            int opcion;

            // Definir el menú para la cola de reservas
            do
            {
                MostrarMenu();
                opcion = ObtenerOpcion();

                switch (opcion)
                {
                    case 1: // Agregar una reserva a la cola
                        AgregarNotas();
                        break;

                    case 2: // Mostrar todas las reservas en la cola
                        MostrarReporteNotas();
                        break;

                    case 3: // Eliminar una reserva de la cola
                        EliminarReporteDeNotas();
                        break;

                    case 4: // Vaciar la cola
                        VaciarCola();
                        break;

                    case 5: // Salir
                        break;

                    default:
                        Console.WriteLine("Opción no válida, intenta nuevamente.");
                        break;
                }

                Console.ReadKey();
            } while (opcion != 5);
        }

        static void MostrarMenu()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("Registro de Notas");
            Console.WriteLine("*************************");
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("[1] Agregar Notas");
            Console.WriteLine("[2] Mostrar Registro");
            Console.WriteLine("[3] Eliminar el primer registro hecho");
            Console.WriteLine("[4] Vaciar Registro");
            Console.WriteLine("[5] Salir");
            Console.Write("Elige una opción: ");
        }

        // Método para obtener la opción del menú
        static int ObtenerOpcion()
        {
            int opcion = 0;
            try
            {
                opcion = int.Parse(Console.ReadLine());
            }
            catch (FormatException)
            {
                Console.WriteLine("Por favor, ingresa un número válido.");
            }
            return opcion;
        }

        // Método para agregar una reserva
        static void AgregarNotas()
        {
            Console.Clear();
            Console.WriteLine("[1] Registrar de Notas");

            double nota1 = ObtenerNota("Nota 1: ");
            double nota2 = ObtenerNota("Nota 2: ");
            double nota3 = ObtenerNota("Nota 3: ");

            double promedio;
            promedio = (nota1 + nota2 + nota3)/3;

            string observacion;
            if (promedio >= 10.5)
            {
                observacion = "APROBADO";
            }
            else
            {
                observacion = "DESAPROBADO";
            }

            // Crear el nodo de reserva utilizando el constructor con parámetros
            NodoNotas NOTAS = new NodoNotas(nota1, nota2, nota3, promedio, observacion);

            // Agregar la reserva a la cola
            if (Cola.encola(NOTAS))
            {
                Console.WriteLine("Notas agregada exitosamente.");
            }
            else
            {
                Console.WriteLine("Error: Cola llena. No se puede agregar más notas.");
            }
        }

        // Método para mostrar todas las reservas
        static void MostrarReporteNotas()
        {
            Console.Clear();
            if (!Cola.vaciaCola())
            {
                Cola.verCola();
            }
            else
            {
                Console.WriteLine("No existen registros.");
            }
        }

        // Método para eliminar la primera reserva de la cola
        static void EliminarReporteDeNotas()
        {
            Console.Clear();
            Console.WriteLine("[3] Eliminar Registro");

            NodoNotas NotasEliminar = Cola.desencola();

            if (NotasEliminar != null)
            {
                // Apilar la reserva eliminada en la pila
                pilaDeEliminados.ApilarRegistroEliminado(NotasEliminar);
            }
            else
            {
                Console.WriteLine("Error: No hay notas para eliminar.");
            }
        }

        // Método para vaciar la cola
        static void VaciarCola()
        {
            Console.Clear();
            Console.WriteLine("[4] Vaciar Cola");
            Cola = new ColaNotas(50); // Reinicia la cola
            Console.WriteLine("Cola vaciada exitosamente.");
        }

        // Método para obtener una nota con validación
        static float ObtenerNota(string mensaje)
        {
            float nota;
            while (true)
            {
                Console.Write(mensaje);
                if (float.TryParse(Console.ReadLine(), out nota) && nota >= 0 && nota <= 20)
                {
                    break; // Salir del bucle si la nota es válida
                }
                Console.WriteLine("Error: La nota debe estar entre 0 y 20. Intenta de nuevo.");
            }
            return nota;
        }

        static void PantallaCursos()
        {

            CursosPrecargados.PrecargarDatos(colaCursos);
            int opcion;

            do
            {
                MostrarMenuCursos();
                opcion = int.Parse(Console.ReadLine());

                switch (opcion)
                {
                    case 1:
                        AgregarCurso();

                        break;

                    case 2:
                        MostrarCursos();
                        break;

                    case 3:
                        EliminarCurso();
                        break;

                    case 4:
                        VaciarColaCurso();
                        break;

                    case 5:
                        break;

                    default:
                        Console.WriteLine("Opción no válida, intenta nuevamente.");
                        break;
                }
                Console.ReadKey();
            } while (opcion != 5);
        }

        static void MostrarMenuCursos()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("\nCURSOS");
            Console.WriteLine("********");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("[1] Agregar cursos");
            Console.WriteLine("[2] Mostrar curso");
            Console.WriteLine("[3] Eliminar curso");
            Console.WriteLine("[4] Vaciar Cola");
            Console.WriteLine("[5] Salir");
            Console.Write("Seleccione una opción: ");
        }

        static void AgregarCurso()
        {
            Console.Clear();
            Console.Write("Código: ");
            string codigo = Console.ReadLine();
            Console.Write("Nombre: ");
            string nombre = Console.ReadLine();
            Console.Write("Créditos: ");
            int creditos = int.Parse(Console.ReadLine());
            Console.Write("Horas programadas: ");
            int horas = int.Parse(Console.ReadLine());

            NodoCurso CURSOSX = new NodoCurso(codigo, nombre, creditos, horas);

            if (colaCursos.encola(CURSOSX))
            {
                Console.WriteLine("Curso agregada exitosamente.");
            }
            else
            {
                Console.WriteLine("Error: Cola llena. No se puede agregar más cursos.");
            }
        }

        static void MostrarCursos()
        {
            Console.Clear();

            if (!colaCursos.vaciaCola())
            {
                colaCursos.verColaCursos();
            }
            else
            {
                Console.WriteLine("No existen registros.");
            }
        }

        static void EliminarCurso()
        {
            Console.Clear();
            Console.WriteLine("[3] Eliminar curso");

            NodoCurso Eliminarcurso = colaCursos.desencola();

            if (Eliminarcurso != null)
            {
                Console.WriteLine("Curso eliminado exitosamente:");
                Console.WriteLine("Código: " + Eliminarcurso.Codigo);
                Console.WriteLine("Nombre: " + Eliminarcurso.Nombre);
                Console.WriteLine("Creditos: " + Eliminarcurso.Creditos);
                Console.WriteLine("Horas Programadas: " + Eliminarcurso.HorasProgramadas);

            }
            else
            {
                Console.WriteLine("Error: No hay cursos para eliminar.");
            }
        }
        static void VaciarColaCurso()
        {
            Console.Clear();
            Console.WriteLine("[4] Vaciar Cola");
            colaCursos = new ColaCurso(50); // Reinicia la cola
            Console.WriteLine("Cola vaciada exitosamente.");
        }

        static void MostrarMenuE()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("\nSistema de Gestión de Estudiantes");
            Console.WriteLine("*********************************");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("[1] Agregar Estudiante");
            Console.WriteLine("[2] Mostrar Estudiantes");
            Console.WriteLine("[3] Eliminar al primer Estudiante");
            Console.WriteLine("[4] Vaciar Estudiantes");
            Console.WriteLine("[5] Salir");
            Console.Write("Elige una opción: ");
        }

        static void EStudiantes()
        {

            // Precargar datos de estudiantes al iniciar el programa
            CargaEstudiante.PrecargarDatos(ColaE);
            int opcion;

            // Definir el menú para la cola de estudiantes
            do
            {
                MostrarMenuE();
                opcion = ObtenerOpcion();

                switch (opcion)
                {
                    case 1: // Agregar un estudiante a la cola
                        AgregarEstudiante();
                        break;

                    case 2: // Mostrar todos los estudiantes en la cola
                        MostrarEstudiantes();
                        break;

                    case 3: // Eliminar un estudiante de la cola
                        EliminarEstudiante();
                        break;

                    case 4: // Vaciar la cola
                        VaciarColaE();
                        break;

                    case 5: // Salir
                        Console.WriteLine("Saliendo del sistema...");
                        break;

                    default:
                        Console.WriteLine("Opción no válida, intenta nuevamente.");
                        break;
                }

                Console.ReadKey();
            } while (opcion != 5);
        }

        // Método para agregar un estudiante
        static void AgregarEstudiante()
        {
            Console.Clear();
            Console.WriteLine("[1] Agregar Estudiante");

            // Ingresar los datos del estudiante
            Console.Write("Código de Alumno: ");
            string codigoAlumno = Console.ReadLine();
            Console.Write("Nombre del Alumno: ");
            string nombreAlumno = Console.ReadLine();
            Console.Write("Estado Civil (SOLTER@/CASAD@): ");
            string estadoCivil = Console.ReadLine();
            Console.Write("Sexo (M/F): ");
            string sexo = Console.ReadLine();
            Console.Write("Edad: ");
            int edad;
            while (!int.TryParse(Console.ReadLine(), out edad))
            {
                Console.WriteLine("Por favor, ingresa un número válido para la edad.");
                Console.Write("Edad: ");
            }

            // Crear el nodo de estudiante utilizando el constructor con parámetros
            NodoEstudiante estudiante = new NodoEstudiante(codigoAlumno, nombreAlumno, estadoCivil, sexo, edad);

            // Agregar el estudiante a la cola
            if (ColaE.Encola(estudiante))
            {
                Console.WriteLine("Estudiante agregado exitosamente.");
            }
            else
            {
                Console.WriteLine("Error: Cola llena. No se puede agregar más estudiantes.");
            }

        }

        // Método para mostrar todos los estudiantes
        static void MostrarEstudiantes()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("[2] Mostrar Estudiantes");
            Console.WriteLine("-------------------------------------------------------------------------------");
            Console.WriteLine(" Código Alumno  |    Nombre Alumno              | Estado Civil  | Sexo  | Edad");
            Console.WriteLine("-------------------------------------------------------------------------------");
            Console.ForegroundColor = ConsoleColor.White;

            if (!ColaE.VaciaCola())
            {
                ColaE.VerCola();
            }
            else
            {
                Console.WriteLine("No hay estudiantes en la cola.");
            }

            Console.WriteLine("-------------------------------------------------------------------------------");
        }

        // Método para eliminar al primer estudiante de la cola
        static void EliminarEstudiante()
        {
            Console.Clear();
            Console.WriteLine("[3] Eliminar Estudiante");

            NodoEstudiante estudianteEliminado = ColaE.Desencola();

            if (estudianteEliminado != null)
            {
                Console.WriteLine("Estudiante eliminado exitosamente:");
                Console.WriteLine("Código: " + estudianteEliminado.CodigoAlumno);
                Console.WriteLine("Nombre: " + estudianteEliminado.NombreAlumno);
                Console.WriteLine("Estado Civil: " + estudianteEliminado.EstadoCivil);
                Console.WriteLine("Sexo: " + estudianteEliminado.Sexo);
                Console.WriteLine("Edad: " + estudianteEliminado.Edad);
            }
            else
            {
                Console.WriteLine("Error: No hay estudiantes para eliminar.");
            }
        }

        // Método para vaciar la cola
        static void VaciarColaE()
        {
            Console.Clear();
            Console.WriteLine("[4] Vaciar Cola");
            ColaE = new ColaEstudiante(50); // Reinicia la cola
            Console.WriteLine("Cola vaciada exitosamente.");
        }

        public static int Pantalla_Principal()
        {
            int opcion = 0;
            do
            {
                //Liampiar pantalla
                Console.Clear();

                Console.ForegroundColor = ConsoleColor.DarkBlue;
                Console.WriteLine("======================================");
                Console.WriteLine("|           MENU PRINCIPAL            |");
                Console.WriteLine("======================================");
                Console.ForegroundColor = ConsoleColor.DarkCyan;
                Console.WriteLine("1. Gestionar los cursos");
                Console.WriteLine("2. Gestionar los estudiantes");
                Console.WriteLine("3. Gestionar las notas");
                Console.WriteLine("4. Salir");
                Console.WriteLine("======================================");
                //Solicitar opción 
                Console.Write("Elige una opcion:");

                // Validación de la entrada
                if (int.TryParse(Console.ReadLine(), out opcion))
                {
                    // Evaluar la opción seleccionada
                    switch (opcion)
                    {
                        case 1:

                            break;

                        case 2:

                            break;

                        case 3:

                            break;

                        case 4:
                            // Opción de salida
                            Console.WriteLine("Saliendo del sistema...");
                            Thread.Sleep(1000);
                            Environment.Exit(0);  // Cierra la consola
                            break;

                        default:
                            Console.WriteLine("Opción incorrecta. Intenta nuevamente.");
                            break;
                    }
                }
                else
                {
                    // Mensaje de error si la entrada no es un número
                    Console.WriteLine("Por favor, ingresa un número válido.");
                }
                // Pausa para que el usuario pueda ver el mensaje antes de limpiar la pantalla
                if (opcion != 4) // Solo pausar si no es la opción de salida
                {
                    Console.WriteLine("Presiona cualquier tecla para continuar...");
                    Console.ReadKey();
                }

            } while (opcion != 4); // Repetir el ciclo hasta que se elija la opción 4
            return opcion;
        }
    }
}
