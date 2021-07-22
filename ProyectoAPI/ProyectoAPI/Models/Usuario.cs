using System;
using System.Collections.Generic;

#nullable disable

namespace ProyectoAPI.Models
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
        public int Telefono { get; set; }
        public string Correo { get; set; }
        public string Contraseña { get; set; }

        public virtual ICollection<DatosInstructor> DatosInstructors { get; set; }
    }
}
