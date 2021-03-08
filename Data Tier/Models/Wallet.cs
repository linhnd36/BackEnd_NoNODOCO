using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace Data_Tier.Models
{
    public partial class Wallet
    {
        public Wallet()
        {
            TransactionWallet = new HashSet<TransactionWallet>();
        }

        public int Id { get; set; }
        public double Balance { get; set; }
        public int Status { get; set; }
        public string TypeWallet { get; set; }
        public string Unit { get; set; }
        public DateTime DateTimeUpdate { get; set; }
        public int? DriverId { get; set; }
        public int? CustumerId { get; set; }

        public virtual Customer Custumer { get; set; }
        public virtual Driver Driver { get; set; }
        public virtual ICollection<TransactionWallet> TransactionWallet { get; set; }
    }
}
