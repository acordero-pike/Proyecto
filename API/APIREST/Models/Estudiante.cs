using System;
using System.Collections.Generic;

#nullable disable

namespace APIREST.Models
{
    public partial class Estudiante
    {
        public int IdEstudiante { get; set; }
        public string Nit { get; set; }
        public long NumeroTarjeta { get; set; }
        public int Usuario { get; set; }

        public virtual Usuario UsuarioNavigation { get; set; }
    }
}
