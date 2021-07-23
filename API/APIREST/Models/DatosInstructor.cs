using System;
using System.Collections.Generic;

#nullable disable

namespace APIREST.Models
{
    public partial class DatosInstructor
    {
        public DatosInstructor()
        {
            Cursos = new HashSet<Curso>();
        }

        public int IdInstructor { get; set; }
        public string Estudios { get; set; }
        public string Certificacion { get; set; }
        public string ExperienciaLab { get; set; }
        public int CuentaBancaria { get; set; }
        public int Usuario { get; set; }

        public virtual Usuario UsuarioNavigation { get; set; }
        public virtual ICollection<Curso> Cursos { get; set; }
    }
}
