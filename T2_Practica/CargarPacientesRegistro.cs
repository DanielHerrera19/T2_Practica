using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace T2_Practica
{
    internal class CargarPacientesRegistro
    {
        public static void PrecargarDatos(ColaNotas cola)
        {
            // Crear nodos con datos predefinidos y agregarlos a la cola
            cola.encola(new NodoNotas(12, 15, 16, 14.33, "APROBADO"));
            cola.encola(new NodoNotas(14, 11, 04, 9.67, "DESAPROBADO"));
            cola.encola(new NodoNotas(15, 12, 16, 14.33, "APROBADO"));
            cola.encola(new NodoNotas(11, 15, 16, 14.00, "APROBADO"));
            cola.encola(new NodoNotas(19, 10, 15, 14.67, "APROBADO"));
            cola.encola(new NodoNotas(05, 08, 19, 10.67, "DESAPROBADO"));
            cola.encola(new NodoNotas(11, 04, 20, 11.67, "APROBADO"));
            cola.encola(new NodoNotas(12, 12, 14, 12.67, "APROBADO"));
            cola.encola(new NodoNotas(16, 14, 11, 13.67, "APROBADO"));
            cola.encola(new NodoNotas(10, 07, 16, 11.00, "APROBADO"));
        }
    }
}
