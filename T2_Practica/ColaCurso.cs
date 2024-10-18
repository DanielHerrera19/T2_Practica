using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace T2_Practica
{
    internal class ColaCurso
    {
        private NodoCurso[] cursos;
        private int frente;
        private int final;
        private int capacidad;

        public ColaCurso(int capacidad)
        {
            this.capacidad = capacidad;
            cursos = new NodoCurso[capacidad];
            frente = 0;
            final = -1;

        }

        // Metodo para agregar un curso a la cola (Encolar)

        public bool encola(NodoCurso curso)
        {
            if (final < capacidad - 1) // Comprobar si hay espacio en la cola
            {
                cursos[++final] = curso; // Agregar reserva y aumentar el índice
                return true;
            }
            return false; // Cola llena
        }



        // Método para eliminar un curso de la cola (Desencolar)

        public NodoCurso desencola()
        {
            if (frente > final) // Si la cola está vacía
            {
                Console.WriteLine("La cola está vacía, no hay datos para eliminar.");
                return null;
            }
            NodoCurso CursoEliminada = cursos[frente];
            frente++; // Mover el frente hacia adelante
            if (frente > final) // Si la cola queda vacía
            {
                frente = 0;
                final = -1;
            }
            return CursoEliminada;
        }

        // Método para mostrar los cursos en la cola
        public void verColaCursos()
        {
            if (frente <= final) // Asegurarse de que hay elementos en la cola
            {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine("-------------------------------------------------------------------------------------------------");
                Console.WriteLine(" Código Curso  |          Nombre del Curso             | Créditos       |  Horas Programadas  ");
                Console.WriteLine("-------------------------------------------------------------------------------------------------");
                Console.ForegroundColor = ConsoleColor.White;

                for (int i = frente; i <= final; i++)
                {
                    // Mostrar los datos de la reserva
                    Console.WriteLine(cursos[i].Codigo.PadRight(14) + " | " +
                                      cursos[i].Nombre.PadRight(37) + " | " +
                                      cursos[i].Creditos.ToString().PadRight(14) + " | " +
                                      cursos[i].HorasProgramadas.ToString().PadRight(12));

                }

                Console.WriteLine("-------------------------------------------------------------------------------------------------");
            }
            else
            {
                Console.WriteLine("No hay datos en la cola.");
            }

        }

        // Método para verificar si la cola está vacía
        public bool vaciaCola()
        {
            return final < frente; // Verifica si la cola está vacía
        }
    }
}
