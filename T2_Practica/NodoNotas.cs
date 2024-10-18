using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace T2_Practica
{
    internal class NodoNotas
    {
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public int Dni { get; set; }
        public long NumTarjeta { get; set; }
        public NodoNotas Siguiente { get; set; } // Apunta al siguiente nodo

        // Constructor para inicializar la reserva
        public NodoNotas(string nombre, string apellido, int dni, long numTarjeta)
        {
            Nombre = nombre;
            Apellido = apellido;
            Dni = dni;
            NumTarjeta = numTarjeta;
            Siguiente = null; // Inicialmente no apunta a ningún otro nodo
        }

        // Constructor vacío
        public NodoNotas()
        {
            // Este constructor vacío te permite crear un objeto sin parámetros.
        }
    }
}