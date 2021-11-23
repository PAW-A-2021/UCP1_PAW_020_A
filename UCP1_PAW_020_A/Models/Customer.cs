using System;
using System.Collections.Generic;

#nullable disable

namespace UCP1_PAW_020_A.Models
{
    public partial class Customer
    {
        public int IdCustomer { get; set; }
        public string NamaCustomer { get; set; }

        public virtual Barang Barang { get; set; }
        public virtual Transaksi Transaksi { get; set; }
    }
}
