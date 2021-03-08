using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace Data_Tier.Models
{
    public partial class Vehicle
    {
        public Vehicle()
        {
            Booking = new HashSet<Booking>();
        }

        public int Id { get; set; }
        public string Brand { get; set; }
        public string LicensePlate { get; set; }
        public string Type { get; set; }
        public DateTime CreateDateTime { get; set; }
        public DateTime? UpdateDateTime { get; set; }
        public int Status { get; set; }
        public int CustomerId { get; set; }

        public virtual Customer Customer { get; set; }
        public virtual ICollection<Booking> Booking { get; set; }
    }
}
