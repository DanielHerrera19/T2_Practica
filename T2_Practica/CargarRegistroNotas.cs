using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace T2_Practica
{
    internal class CargarRegistroNotas
    {
        public void PrecargarDatos(ColaNotas cola, ColaCurso cursito, ColaEstudiante estudian)
        {
            NodoEstudiante estudiante1 = estudian.BuscarEstudiante("ALW-001");
            NodoEstudiante estudiante2 = estudian.BuscarEstudiante("ALW-002");
            NodoEstudiante estudiante3 = estudian.BuscarEstudiante("ALW-003");
            NodoEstudiante estudiante4 = estudian.BuscarEstudiante("ALW-004");
            NodoEstudiante estudiante5 = estudian.BuscarEstudiante("ALW-005");
            NodoEstudiante estudiante6 = estudian.BuscarEstudiante("ALW-006");
            NodoEstudiante estudiante7 = estudian.BuscarEstudiante("ALW-007");
            NodoEstudiante estudiante8 = estudian.BuscarEstudiante("ALW-008");
            NodoEstudiante estudiante9 = estudian.BuscarEstudiante("ALW-009");
            NodoEstudiante estudiante10 = estudian.BuscarEstudiante("ALW-010");

            NodoCurso curso1 = cursito.BuscarCurso("CUR-001");
            NodoCurso curso2 = cursito.BuscarCurso("CUR-002");
            NodoCurso curso3 = cursito.BuscarCurso("CUR-003");
            NodoCurso curso4 = cursito.BuscarCurso("CUR-004");
            NodoCurso curso5 = cursito.BuscarCurso("CUR-005");

            // Crear nodos con datos predefinidos y agregarlos a la cola
            cola.encola(new NodoNotas(estudiante1,curso1,12, 15, 16, 14.33, "APROBADO"));
            cola.encola(new NodoNotas(estudiante2,curso2,14, 11, 04, 9.67, "DESAPROBADO"));
            cola.encola(new NodoNotas(estudiante3, curso4, 15, 12, 16, 14.33, "APROBADO"));
            cola.encola(new NodoNotas(estudiante4, curso4, 11, 15, 16, 14.00, "APROBADO"));
            cola.encola(new NodoNotas(estudiante5, curso5, 19, 10, 15, 14.67, "APROBADO"));
            cola.encola(new NodoNotas(estudiante6, curso5, 05, 08, 19, 10.67, "DESAPROBADO"));
            cola.encola(new NodoNotas(estudiante7, curso3, 11, 04, 20, 11.67, "APROBADO"));
            cola.encola(new NodoNotas(estudiante8, curso5, 12, 12, 14, 12.67, "APROBADO"));
            cola.encola(new NodoNotas(estudiante9, curso2, 16, 14, 11, 13.67, "APROBADO"));
            cola.encola(new NodoNotas(estudiante10, curso2, 10, 07, 16, 11.00, "APROBADO"));
        }
    }
}
