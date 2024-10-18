using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace T2_Practica
{
    internal class ColaCurso
    {
        private NodoCurso frente;
        private NodoCurso final;

        public ColaCurso()
        {
            frente = null;
            final = null;
            PrecargarCursos();
        }

        // Metodo para agregar un curso a la cola (Encolar)
        public void Encolar(string codigo, string nombre, int creditos, int horasProgramadas)
        {
            NodoCurso nuevoNodo = new NodoCurso(codigo, nombre, creditos, horasProgramadas);
            if (final == null)
            {
                frente = nuevoNodo;
                final = nuevoNodo;
            }
            else
            {
                final.Siguiente = nuevoNodo;
                final = nuevoNodo;
            }
        }

        // Método para eliminar un curso de la cola (Desencolar)
        public NodoCurso Desencolar()
        {
            if (frente == null)
            {
                Console.WriteLine("La cola está vacía.");
                return null;
            }
            NodoCurso nodoEliminado = frente;
            frente = frente.Siguiente;
            if (frente == null)
            {
                final = null;
            }
            return nodoEliminado;
        }

        // Método para modificar un curso en la cola
        public bool ModificarCurso(string codigo)
        {
            NodoCurso actual = frente;
            while (actual != null)
            {
                if (actual.Codigo.Equals(codigo, StringComparison.OrdinalIgnoreCase))
                {
                    Console.WriteLine("Curso encontrado. Ingrese los nuevos datos:");
                    Console.Write("Nuevo Nombre: ");
                    actual.Nombre = Console.ReadLine();
                    Console.Write("Nuevos Créditos: ");
                    actual.Creditos = int.Parse(Console.ReadLine());
                    Console.Write("Nuevas Horas Programadas: ");
                    actual.HorasProgramadas = int.Parse(Console.ReadLine());

                    Console.WriteLine("Curso modificado con éxito.");
                    return true;
                }
                actual = actual.Siguiente;
            }
            Console.WriteLine("No se encontró un curso con ese código.");
            return false;
        }

        // Método para mostrar los cursos en la cola
        public void MostrarCursos()
        {
            NodoCurso actual = frente;
            if (actual == null)
            {
                Console.WriteLine("No hay cursos en la cola.");
                return;
            }

            Console.WriteLine("------------------------------------------------------------------");
            Console.WriteLine("|  CODIGO  |             NOMBRE             | CREDITOS |  HORAS  |");
            Console.WriteLine("------------------------------------------------------------------");

            while (actual != null)
            {
                Console.WriteLine($"| {actual.Codigo,-8} | {actual.Nombre,-30} | {actual.Creditos,-8} | {actual.HorasProgramadas,-7} |");
                actual = actual.Siguiente;
            }

            Console.WriteLine("------------------------------------------------------------------");
        }

        private void PrecargarCursos()
        {
            Encolar("CUR-001", "FUNDAMENTOS DE ALGORITMOS", 3, 6);
            Encolar("CUR-002", "FUNDAMENTOS DE PROGRAMACION", 3, 6);
            Encolar("CUR-003", "ESTRUCTURA DE DATOS", 4, 6);
            Encolar("CUR-004", "GESTION DE BASE DE DATOS", 3, 4);
            Encolar("CUR-005", "PROGRAMACION EN JAVA", 4, 8);
        }
    }
}
