using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace T2_Practica
{
    internal class NodoNotas
    {
        public double Nota1 { get; set; }
        public double Nota2 { get; set; }
        public double Nota3 { get; set; }
        public double Promedio { get; set; }
        public string Observacion {  get; set; }
        public NodoNotas Siguiente { get; set; } // Apunta al siguiente nodo

        // Constructor para inicializar la reserva
        public NodoNotas(double nota1, double nota2, double nota3, double promedio, string observacion)
        {
            Nota1 = nota1;
            Nota2 = nota2;
            Nota3 = nota3;
            Promedio = promedio;
            Observacion = observacion;
            Siguiente = null; // Inicialmente no apunta a ningún otro nodo
        }

        // Constructor vacío
        public NodoNotas()
        {
            // Este constructor vacío te permite crear un objeto sin parámetros.
        }
    }
}