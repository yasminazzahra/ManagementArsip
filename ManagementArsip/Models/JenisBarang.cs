using System;
using System.Collections.Generic;

#nullable disable

namespace ManagementArsip.Models
{
    public partial class JenisBarang
    {
        public int IdJenisbarang { get; set; }
        public string NamaJenisbarang { get; set; }
        public int? IdBarang { get; set; }
    }
}
