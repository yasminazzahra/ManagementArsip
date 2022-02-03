using System;
using System.Collections.Generic;

#nullable disable

namespace ManagementArsip.Models
{
    public partial class Peminjaman
    {
        public int IdPeminjaman { get; set; }
        public DateTime? TanggalPeminjaman { get; set; }
        public int? IdBarang { get; set; }
        public DateTime? TanggalPengembalian { get; set; }
        public string DeskripsiPeminjaman { get; set; }
        public int? JumlahPeminjaman { get; set; }
        public int? IdUser { get; set; }
    }
}
