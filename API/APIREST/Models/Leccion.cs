using System;
using System.Collections.Generic;

#nullable disable

namespace APIREST.Models
{
    public partial class Leccion
    {
        public int IdLeccion { get; set; }
        public string Titulo { get; set; }
        public string Descripcion { get; set; }
        public string Duracion { get; set; }
        public string EnlaceVideo { get; set; }
        public int? IdCurso { get; set; }

        public virtual Curso IdCursoNavigation { get; set; }
    }
}
