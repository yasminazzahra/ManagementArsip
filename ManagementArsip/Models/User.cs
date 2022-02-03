using System;
using System.Collections.Generic;

#nullable disable

namespace ManagementArsip.Models
{
    public partial class User
    {
        public int IdUser { get; set; }
        public string NamaUser { get; set; }
        public string Nip { get; set; }
        public string Alamat { get; set; }
        public string NoHp { get; set; }
    }
}
