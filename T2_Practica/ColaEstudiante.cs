using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace T2_Practica
{
    internal class ColaEstudiante
    {
        private NodoEstudiante[] estudiantes;
        private int frente;  // Índice del primer elemento
        private int final;   // Índice del último elemento
        private int capacidad; // Capacidad de la cola

        // Constructor que inicializa la cola con un tamaño fijo
        public ColaEstudiante(int capacidad)
        {
            this.capacidad = capacidad;
            estudiantes = new NodoEstudiante[capacidad];
            frente = 0;  // Inicialmente, el frente es 0
            final = -1;  // Inicialmente la cola está vacía
        }

        // Método para agregar un estudiante (Encolar)
        public bool Encola(NodoEstudiante estudiante)
        {
            if (final < capacidad - 1)  // Comprobar si hay espacio en la cola
            {
                estudiantes[++final] = estudiante;  // Agregar estudiante y aumentar el índice
                return true;
            }
            Console.WriteLine("La cola está llena, no se puede agregar más estudiantes.");
            return false;  // Cola llena
        }

        // Método para eliminar un estudiante (Desencolar)
        public NodoEstudiante Desencola()
        {
            if (frente > final)  // Si la cola está vacía
            {
                Console.WriteLine("La cola está vacía, no hay estudiantes para eliminar.");
                return null;
            }
            NodoEstudiante estudianteEliminado = estudiantes[frente];
            frente++;  // Mover el frente hacia adelante
            if (frente > final)  // Si la cola queda vacía
            {
                frente = 0;
                final = -1;
            }
            return estudianteEliminado;
        }

        // Método para mostrar los estudiantes desde el frente hasta el final
        public void VerCola()
        {
            if (frente <= final)  // Asegurarse de que hay elementos en la cola
            {
                for (int i = frente; i <= final; i++)
                {
                    // Mostrar los datos del estudiante
                    Console.WriteLine(estudiantes[i].CodigoAlumno.PadRight(15) + " | " +
                                      estudiantes[i].NombreAlumno.PadRight(29) + " | " +
                                      estudiantes[i].EstadoCivil.PadRight(13) + " | " +
                                      estudiantes[i].Sexo.PadRight(5) + " | " +
                                      estudiantes[i].Edad.ToString().PadRight(3));
                }
            }
            else
            {
                Console.WriteLine("No hay estudiantes en la cola.");
            }
        }

        // Método para verificar si la cola está vacía
        public bool VaciaCola()
        {
            return final < frente;  // Verifica si la cola está vacía
        }

        public NodoEstudiante BuscarEstudiante(string codigoAlumno)
        {
            for (int i = frente; i <= final; i++)
            {
                if (estudiantes[i].CodigoAlumno.Equals(codigoAlumno, StringComparison.OrdinalIgnoreCase)) // Cambiado a estudiantes[i]
                {
                    return estudiantes[i]; // Devolver el nodo encontrado
                }
            }
            return null; // No encontrado
        }

        
    }
}