using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

#nullable disable

namespace APIREST.Models
{
    public partial class Comentario
    {
        [Key]
        public int IdComentario { get; set; }
        public string Pregunta { get; set; }
        public int Leccion { get; set; }

    }
}
