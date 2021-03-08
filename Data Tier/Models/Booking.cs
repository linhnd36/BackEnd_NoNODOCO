using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace Data_Tier.Models
{
    public partial class Booking
    {
        public Booking()
        {
            TransactionWallet = new HashSet<TransactionWallet>();
        }

        public int Id { get; set; }
        public double TotalMoney { get; set; }
        public double Km { get; set; }
        public int Status { get; set; }
        public string From { get; set; }
        public string To { get; set; }
        public string Feedback { get; set; }
        public double Rate { get; set; }
        public DateTime DateTimeStart { get; set; }
        public DateTime? DateTimeEnd { get; set; }
        public DateTime? FinishDate { get; set; }
        public int DriverId { get; set; }
        public int CustumerId { get; set; }
        public int AssignId { get; set; }
        public int? VehicleId { get; set; }

        public virtual Customer Assign { get; set; }
        public virtual Customer Custumer { get; set; }
        public virtual Driver Driver { get; set; }
        public virtual Vehicle Vehicle { get; set; }
        public virtual ICollection<TransactionWallet> TransactionWallet { get; set; }
    }
}
