﻿using System;
using System.Collections.Generic;

#nullable disable

namespace APIREST.Models
{
    public partial class Curso
    {
        public int IdCurso { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public decimal Costo { get; set; }
        public int? IdInstructor { get; set; }
        public decimal Duracion { get; set; }

        public virtual DatosInstructor IdInstructorNavigation { get; set; }
    }
}