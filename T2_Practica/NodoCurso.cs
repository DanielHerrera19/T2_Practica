using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace T2_Practica
{
    internal class NodoCurso
    {
        public string Codigo { get; set; }
        public string Nombre { get; set; }
        public int Creditos { get; set; }
        public int HorasProgramadas { get; set; }
        public NodoCurso Siguiente { get; set; }

        public NodoCurso(string codigo, string nombre, int creditos, int horasProgramadas)
        {
            Codigo = codigo;
            Nombre = nombre;
            Creditos = creditos;
            HorasProgramadas = horasProgramadas;
            Siguiente = null;
        }
    }
}
