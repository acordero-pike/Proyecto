using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APIREST.Models.Solicitudes
{
    public class LeccionSolicitud
    {
        public string Titulo { get; set; }
        public string Descripcion { get; set; }
        public string Duracion { get; set; }
        public string EnlaceVideo { get; set; }
        public int IdCurso { get; set; }
    }
}
