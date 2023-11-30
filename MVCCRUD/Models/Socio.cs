using System;
using System.Collections.Generic;

namespace MVCCRUD.Models
{
    public partial class Socio
    {
        public int Id { get; set; }
        public string? Nombre { get; set; }
        public DateTime? FechaIngreso { get; set; }
        public int? Dni { get; set; }
    }
}
