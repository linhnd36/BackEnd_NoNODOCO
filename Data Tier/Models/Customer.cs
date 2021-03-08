using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace Data_Tier.Models
{
    public partial class Customer
    {
        public Customer()
        {
            BookingAssign = new HashSet<Booking>();
            BookingCustumer = new HashSet<Booking>();
            Vehicle = new HashSet<Vehicle>();
            Wallet = new HashSet<Wallet>();
        }

        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public string Adress { get; set; }
        public int Status { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime UpdateDate { get; set; }

        public virtual ICollection<Booking> BookingAssign { get; set; }
        public virtual ICollection<Booking> BookingCustumer { get; set; }
        public virtual ICollection<Vehicle> Vehicle { get; set; }
        public virtual ICollection<Wallet> Wallet { get; set; }
    }
}
