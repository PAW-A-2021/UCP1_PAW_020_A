using System;
using System.Collections.Generic;

#nullable disable

namespace UCP1_PAW_020_A.Models
{
    public partial class Barang
    {
        public int IdBarang { get; set; }
        public string NamaBarang { get; set; }
        public string JenisBarang { get; set; }

        public virtual Customer IdBarangNavigation { get; set; }
    }
}
