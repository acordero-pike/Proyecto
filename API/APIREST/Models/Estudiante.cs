using System;
using System.Collections.Generic;

#nullable disable

namespace APIREST.Models
{
    public partial class Estudiante
    {
        public Estudiante()
        {
            Compras = new HashSet<Compra>();
        }

        public int IdEstudianes { get; set; }
        public long? Nit { get; set; }
        public long? NumTarjeta { get; set; }
        public int? IdUsuario { get; set; }

        public virtual Usuario IdUsuarioNavigation { get; set; }
        public virtual ICollection<Compra> Compras { get; set; }
    }
}
