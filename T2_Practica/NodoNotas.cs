using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace T2_Practica
{
    internal class NodoNotas
    {
        public float Nota1 { get; set; }
        public float Nota2 { get; set; }
        public float Nota3 { get; set; }
        public float Promedio { get; set; }
        public string Observacion {  get; set; }
        public NodoNotas Siguiente { get; set; } // Apunta al siguiente nodo

        // Constructor para inicializar la reserva
        public NodoNotas(float nota1, float nota2, float nota3, float promedio, string obeservacion)
        {
            Nota1 = nota1;
            Nota2 = nota2;
            Nota3 = nota3;
            Promedio = promedio;
            Observacion = obeservacion;
            Siguiente = null; // Inicialmente no apunta a ningún otro nodo
        }

        // Constructor vacío
        public NodoNotas()
        {
            // Este constructor vacío te permite crear un objeto sin parámetros.
        }
    }
}