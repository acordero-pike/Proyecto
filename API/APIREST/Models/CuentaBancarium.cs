using System;
using System.Collections.Generic;

#nullable disable

namespace APIREST.Models
{
    public partial class CuentaBancarium
    {
        public int IdCuenta { get; set; }
        public string NombreBanco { get; set; }
        public string NombreCuenta { get; set; }
        public string Tipo { get; set; }
        public long? Numero { get; set; }
    }
}
