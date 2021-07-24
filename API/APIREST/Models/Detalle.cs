using System;
using System.Collections.Generic;

#nullable disable

namespace APIREST.Models
{
    public partial class Detalle
    {
        public int CodCurso { get; set; }
        public double? Precio { get; set; }
        public int IdCompra { get; set; }

        public virtual Curso CodCursoNavigation { get; set; }
        public virtual Compra IdCompraNavigation { get; set; }
    }
}
