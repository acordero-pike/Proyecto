using System;
using System.Collections.Generic;

#nullable disable

namespace APIREST.Models
{
    public partial class Curso
    {
        public Curso()
        {
            Detalles = new HashSet<Detalle>();
        }

        public int IdCurso { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public double Costo { get; set; }
        public int IdInstructor { get; set; }
        public double Duracion { get; set; }

        public virtual DatosInstructor IdInstructorNavigation { get; set; }
        public virtual ICollection<Detalle> Detalles { get; set; }
    }
}
