using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace Data_Tier.Models
{
    public partial class TransactionWallet
    {
        public int Id { get; set; }
        public int Fluctuations { get; set; }
        public int Amount { get; set; }
        public DateTime DateTime { get; set; }
        public int Status { get; set; }
        public int WalletId { get; set; }
        public int BookingId { get; set; }

        public virtual Booking Booking { get; set; }
        public virtual Wallet Wallet { get; set; }
    }
}
