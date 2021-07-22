using System;
using System.Collections.Generic;

#nullable disable

namespace APIREST.Models
{
    public partial class Usuario
    {
        public Usuario()
        {
            DatosInstructors = new HashSet<DatosInstructor>();
        }

        public int IdUsuario { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Telefono { get; set; }
        public string Correo { get; set; }
        public string Contraseña { get; set; }
        public bool? Status { get; set; }

        public virtual ICollection<DatosInstructor> DatosInstructors { get; set; }
    }
}
