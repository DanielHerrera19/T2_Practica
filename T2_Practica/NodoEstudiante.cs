using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace T2_Practica
{
    internal class NodoEstudiante
    {
        public string CodigoAlumno { get; set; }
        public string NombreAlumno { get; set; }
        public string EstadoCivil { get; set; }
        public string Sexo { get; set; }
        public int Edad { get; set; }
        public NodoEstudiante Siguiente { get; set; }


        public NodoEstudiante(string codigo, string nombre, string estadoCivil, string sexo, int edad)
        {
            CodigoAlumno = codigo;
            NombreAlumno = nombre;
            EstadoCivil = estadoCivil;
            Sexo = sexo;
            Edad = edad;
            Siguiente = null; // Inicialmente no apunta a ningún otro nodo

        }

        // Constructor vacío
        public NodoEstudiante()
        {
            // Este constructor vacío te permite crear un objeto sin parámetros.
        }
    }
}
