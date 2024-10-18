using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace T2_Practica
{
    internal class PilaNotas
    {
        private NodoNotas[] pilaNotas; // Arreglo para almacenar reservas
        private int tope; // Índice del elemento más alto de la pila
        private int capacidad; // Capacidad máxima de la pila

        public PilaNotas(int capacidad)
        {
            this.capacidad = capacidad;
            pilaNotas = new NodoNotas[capacidad]; // Crear el arreglo con tamaño fijo
            tope = -1; // Inicialmente, la pila está vacía
        }

        // Apilar (push) la reserva eliminada
        public void ApilarRegistroEliminado(NodoNotas reserva)
        {
            if (tope < capacidad - 1) // Verificar si hay espacio en la pila
            {
                tope++;
                pilaNotas[tope] = reserva; // Agregar la reserva en la parte superior
                Console.WriteLine("Registro apilado correctamente.");
            }
            else
            {
                Console.WriteLine("Error: La pila está llena, no se pueden apilar más registros.");
            }
        }

        // Desapilar (pop) y devolver la reserva eliminada más reciente
        public NodoNotas DesapilarReserva()
        {
            if (tope >= 0) // Verificar si la pila no está vacía
            {
                NodoNotas reserva = pilaNotas[tope]; // Obtener la reserva en el tope
                tope--; // Reducir el tope
                return reserva; // Devolver la reserva desapilada
            }
            else
            {
                Console.WriteLine("Error: No hay reservas en la pila para desapilar.");
                return null;
            }
        }





        // Verificar si la pila está vacía
        public bool EstaVacia()
        {
            return tope == -1;
        }

        // Verificar si la pila está llena
        public bool EstaLlena()
        {
            return tope == capacidad - 1;
        }
    }
}
