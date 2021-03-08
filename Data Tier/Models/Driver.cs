using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace Data_Tier.Models
{
    public partial class Driver
    {
        public Driver()
        {
            Booking = new HashSet<Booking>();
            DriverAvaiability = new HashSet<DriverAvaiability>();
            DriverHaveBonus = new HashSet<DriverHaveBonus>();
            Wallet = new HashSet<Wallet>();
        }

        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string DrivingLicense { get; set; }
        public string PhoneNumber { get; set; }
        public string Address { get; set; }
        public double Rating { get; set; }
        public int Status { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime? UpdateDate { get; set; }
        public int AdminRegisterId { get; set; }
        public int AdminUpdateId { get; set; }

        public virtual Admin AdminRegister { get; set; }
        public virtual Admin AdminUpdate { get; set; }
        public virtual ICollection<Booking> Booking { get; set; }
        public virtual ICollection<DriverAvaiability> DriverAvaiability { get; set; }
        public virtual ICollection<DriverHaveBonus> DriverHaveBonus { get; set; }
        public virtual ICollection<Wallet> Wallet { get; set; }
    }
}
