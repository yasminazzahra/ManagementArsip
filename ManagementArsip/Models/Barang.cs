using System;
using System.Collections.Generic;

#nullable disable

namespace ManagementArsip.Models
{
    public partial class Barang
    {
        public int IdBarang { get; set; }
        public string DeskripsiBarang { get; set; }
        public string KodeBarang { get; set; }
        public DateTime? TahunPengadaan { get; set; }
        public string MerkBarang { get; set; }
        public string StatusBarang { get; set; }
        public int? IdUser { get; set; }
        public DateTime? TanggalMasuk { get; set; }
    }
}
