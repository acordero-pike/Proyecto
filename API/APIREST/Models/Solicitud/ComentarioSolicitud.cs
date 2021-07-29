using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APIREST.Models.Solicitudes
{
    public class ComentarioSolicitud
    {
        public string Pregunta { get; set; }
        public string Respuesta { get; set; }
        public int Leccion { get; set; }
    }
}
