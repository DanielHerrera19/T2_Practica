using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace T2_Practica
{
    internal class CargaEstudiante
    {
        public  void PrecargarDatos(ColaEstudiante cola)
        {
            // Precargar estudiantes con los datos solicitados
            cola.Encola(new NodoEstudiante("ALW-001", "JORGE PEREZ LLANOS", "SOLTERO", "M", 20));
            cola.Encola(new NodoEstudiante("ALW-002", "ANA DELGADO TERRONES", "SOLTERA", "F", 18));
            cola.Encola(new NodoEstudiante("ALW-003", "PABLO ZEGARRA BARRETO", "SOLTERO", "M", 23));
            cola.Encola(new NodoEstudiante("ALW-004", "ANGEL MONCADA FIGUEROA", "CASADO", "M", 21));
            cola.Encola(new NodoEstudiante("ALW-005", "CAROL PORTALES PINEDO", "CASADA", "F", 22));
            cola.Encola(new NodoEstudiante("ALW-006", "BERTHA MORALES VILLA", "SOLTERA", "F", 19));
            cola.Encola(new NodoEstudiante("ALW-007", "VICTOR PUENTE HURTADO", "CASADO", "M", 26));
            cola.Encola(new NodoEstudiante("ALW-008", "FERNANDO LEE DIAZ", "SOLTERO", "M", 25));
            cola.Encola(new NodoEstudiante("ALW-009", "PATRICIA GARCIA PEDRALES", "CASADA", "F", 24));
            cola.Encola(new NodoEstudiante("ALW-010", "MONICA PERALTA SALAS", "CASADA", "F", 28));
        }
    }
}
