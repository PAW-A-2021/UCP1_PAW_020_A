using System;
using System.Collections.Generic;

#nullable disable

namespace UCP1_PAW_020_A.Models
{
    public partial class Transaksi
    {
        public int IdBarang { get; set; }
        public int? IdJumlah { get; set; }
        public int? IdHarga { get; set; }
        public int? IdBayar { get; set; }

        public virtual Customer IdBarangNavigation { get; set; }
        public virtual Bonu Bonu { get; set; }
    }
}
