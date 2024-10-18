using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace T2_Practica
{
    internal class CursosPrecargados
    {
        public void PrecargarDatos(ColaCurso cola)
        {
            // Crear nodos con datos predefinidos y agregarlos a la cola
            cola.encola(new NodoCurso("CUR-001", "FUNDAMENTOS DE ALGORITMOS", 3, 6));
            cola.encola(new NodoCurso("CUR-002", "FUNDAMENTOS DE PROGRAMACION", 3, 6));
            cola.encola(new NodoCurso("CUR-003", "ESTRUCTURA DE DATOS", 4, 6));
            cola.encola(new NodoCurso("CUR-004", "GESTION DE BASE DE DATOS", 3, 4));
            cola.encola(new NodoCurso("CUR-005", "PROGRAMACION EN JAVA", 4, 8));

        }
    }
}
