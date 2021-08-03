using System;
using System.Collections.Generic;

#nullable disable

namespace APIREST.Models
{
    public partial class Comentario
    {
        public int IdComentario { get; set; }
        public string Pregunta { get; set; }
        public string Respuesta { get; set; }
        public int? Leccion { get; set; }

        public virtual Leccion LeccionNavigation { get; set; }
    }
}
