using System;
using System.Collections.Generic;

#nullable disable

namespace ManagementArsip.Models
{
    public partial class Lokasi
    {
        public int IdLokasi { get; set; }
        public string NamaLokasi { get; set; }
        public int? IdUser { get; set; }
    }
}
