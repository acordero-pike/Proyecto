using System;
using System.Collections.Generic;

#nullable disable

namespace ProyectoAPI.Models
{
    public partial class CuentaBancarium
    {
        public CuentaBancarium()
        {
            DatosInstructors = new HashSet<DatosInstructor>();
        }

        public int IdCuenta { get; set; }
        public string NombreBanco { get; set; }
        public string NombreCuenta { get; set; }
        public string Tipo { get; set; }
        public int Numero { get; set; }

        public virtual ICollection<DatosInstructor> DatosInstructors { get; set; }
    }
}
