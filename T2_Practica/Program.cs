using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace T2_Practica
{
    internal class Program
    {
        static ColaNotas Cola = new ColaNotas(50);
        static PilaNotas pilaDeEliminados = new PilaNotas(50);
        static void Main(string[] args)
        {
            GestionReserva();
            Console.ReadKey();
        }

        static void GestionReserva()
        {
            // Precargar datos de pacientes al iniciar el programa
            CargarPacientesRegistro.PrecargarDatos(Cola);
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
            Console.ForegroundColor = ConsoleColor.DarkBlue;
            Console.WriteLine("[2] Registro de Notas");
            Console.WriteLine("----------------------------------------------------------------------------------------------------------------------------------");
            Console.WriteLine("      Código de alumno      |      Código de Curso     |    Nota 1   |    Nota 2   |   Nota 3   |   Promedio   |    Observación   ");
            Console.WriteLine("----------------------------------------------------------------------------------------------------------------------------------");
            Console.ForegroundColor = ConsoleColor.DarkCyan;

            if (!Cola.vaciaCola())
            {
                Cola.verCola();
            }
            else
            {
                Console.WriteLine("No existen registros.");
            }

            Console.WriteLine("----------------------------------------------------------------------------------------------------------------------------------");
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
            ColaCurso colaCursos = new ColaCurso();
            int opcion;

            do
            {
                Console.Clear();
                Console.WriteLine("cursos");
                Console.WriteLine("1. Agregar cursos");
                Console.WriteLine("2. Mostrar curso");
                Console.WriteLine("3. Eliminar curso");
                Console.WriteLine("4. Modificar curso");
                Console.WriteLine("5. Salir");
                Console.Write("Seleccione una opción: ");
                opcion = int.Parse(Console.ReadLine());

                switch (opcion)
                {
                    case 1:
                        Console.Clear();
                        Console.Write("Código: ");
                        string codigo = Console.ReadLine();
                        Console.Write("Nombre: ");
                        string nombre = Console.ReadLine();
                        Console.Write("Créditos: ");
                        int creditos = int.Parse(Console.ReadLine());
                        Console.Write("Horas programadas: ");
                        int horas = int.Parse(Console.ReadLine());

                        colaCursos.Encolar(codigo, nombre, creditos, horas);
                        Console.WriteLine("Curso agregado con éxito.");
                        Console.ReadKey();
                        break;

                    case 2:
                        Console.Clear();
                        colaCursos.MostrarCursos();
                        Console.ReadKey();
                        break;

                    case 3:
                        Console.Clear();
                        NodoCurso eliminado = colaCursos.Desencolar();
                        if (eliminado != null)
                        {
                            Console.WriteLine($"Curso eliminado: {eliminado.Codigo} - {eliminado.Nombre}");
                        }
                        Console.ReadKey();
                        break;

                    case 4:
                        Console.Clear();
                        Console.Write("Ingrese el código del curso a modificar: ");
                        string codModificar = Console.ReadLine();
                        colaCursos.ModificarCurso(codModificar);
                        Console.ReadKey();
                        break;

                    case 5:
                        Console.WriteLine("Saliendo...");
                        break;

                    default:
                        Console.WriteLine("Opción no válida.");
                        Console.ReadKey();
                        break;
                }
            } while (opcion != 5);
        }
    }
}
