using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoFinal2
{
    public class Sesion
    {
        public int SesionID { get; set; }
        public int UsuarioID { get; set; }
        public DateTime Fecha { get; set; }
        public TimeSpan HoraInicio { get; set; }
        public TimeSpan HoraFinalizacion { get; set; }

        // Constructor que acepta todos los parámetros
        public Sesion(int sesionID, int usuarioID, DateTime fecha, TimeSpan horaInicio, TimeSpan horaFinalizacion)
        {
            SesionID = sesionID;
            UsuarioID = usuarioID;
            Fecha = fecha;
            HoraInicio = horaInicio;
            HoraFinalizacion = horaFinalizacion;
        }

        // Constructor vacío
        public Sesion()
        {
        }

    }
}
