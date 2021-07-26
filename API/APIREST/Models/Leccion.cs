using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace APIREST.Models
{
    public partial class Leccion
    {
        [Key]
        public int IdLeccion { get; set; }
        public string Titulo { get; set; }
        public string Descripcion { get; set; }
        public string Duracion { get; set; }
        public string EnlaceVideo { get; set; }
        public int IdCurso { get; set; }

        public virtual Curso IdCursoNavigation { get; set; }
    }
}
