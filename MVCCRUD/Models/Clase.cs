using System;
using System.Collections.Generic;

namespace MVCCRUD.Models
{
    public partial class Clase
    {
        public int Id { get; set; }
        public string? Nombre { get; set; }
        public string? Profesor { get; set; }
        public DateTime? DiaClase { get; set; }
    }
}
