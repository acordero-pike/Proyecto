using System;
using System.Collections.Generic;

#nullable disable

namespace ProyectoAPI.Models
{
    public partial class Curso
    {
        public Curso()
        {
            Leccions = new HashSet<Leccion>();
        }

        public int IdCurso { get; set; }
        public string Nombre { get; set; }
        public string Descripción { get; set; }
        public double Costo { get; set; }
        public int IdInstructor { get; set; }
        public string Duracion { get; set; }

        public virtual DatosInstructor IdInstructorNavigation { get; set; }
        public virtual ICollection<Leccion> Leccions { get; set; }
    }
}
