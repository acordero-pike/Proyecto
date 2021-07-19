using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APIREST.Models.Solicitudes
{
    public class CursoSolicitud
    {
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public float Costo { get; set; }
        public int? IdInstructor { get; set; }
        public float Duracion { get; set; }

      
    }
}
