using System;
using System.Collections.Generic;

#nullable disable

namespace APIREST.Models
{
    public partial class Compra
    {
        public Compra()
        {
            Detalles = new HashSet<Detalle>();
        }

        public int? IdEstudiante { get; set; }
        public int IdCompra { get; set; }
        public DateTime? Fecha { get; set; }
        public double? Total { get; set; }

        public virtual Estudiante IdEstudianteNavigation { get; set; }
        public virtual ICollection<Detalle> Detalles { get; set; }
    }
}
