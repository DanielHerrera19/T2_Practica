using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace T2_Practica
{
    internal class ColaNotas
    {
        private NodoNotas[] reservas;
        private int frente; // Índice del primer elemento
        private int final; // Índice del último elemento
        private int capacidad; // Capacidad de la cola

        // Constructor que inicializa la cola con un tamaño fijo
        public ColaNotas(int capacidad)
        {
            this.capacidad = capacidad;
            reservas = new NodoNotas[capacidad];
            frente = 0; // Inicialmente, el frente es 0
            final = -1; // Inicialmente la cola está vacía
        }

        // Método para agregar una reserva (Encolar)
        public bool encola(NodoNotas reserva)
        {
            if (final < capacidad - 1) // Comprobar si hay espacio en la cola
            {
                reservas[++final] = reserva; // Agregar reserva y aumentar el índice
                return true;
            }
            return false; // Cola llena
        }

        // Método para eliminar una reserva (Desencolar)
        public NodoNotas desencola()
        {
            if (frente > final) // Si la cola está vacía
            {
                Console.WriteLine("La cola está vacía, no hay datos para eliminar.");
                return null;
            }
            NodoNotas reservaEliminada = reservas[frente];
            frente++; // Mover el frente hacia adelante
            if (frente > final) // Si la cola queda vacía
            {
                frente = 0;
                final = -1;
            }
            return reservaEliminada;
        }

        // Método para mostrar las reservas desde el frente hasta el final
        public void verCola()
        {
            if (frente <= final) // Asegurarse de que hay elementos en la cola
            {
                for (int i = frente; i <= final; i++)
                {
                    // Mostrar los datos de la reserva
                    Console.WriteLine(reservas[i].Nota1.ToString().PadRight(15) + " | " +
                                      reservas[i].Nota2.ToString().PadRight(15) + " | " +
                                      reservas[i].Nota3.ToString().PadRight(12) + " | " +
                                      reservas[i].Promedio.ToString("F2").PadRight(12) + " | " +
                                      reservas[i].Observacion.PadRight(20));
                }
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