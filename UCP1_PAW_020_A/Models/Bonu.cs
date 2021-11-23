using System;
using System.Collections.Generic;

#nullable disable

namespace UCP1_PAW_020_A.Models
{
    public partial class Bonu
    {
        public int IdBonus { get; set; }
        public string JumlahBonus { get; set; }

        public virtual Transaksi IdBonusNavigation { get; set; }
    }
}
