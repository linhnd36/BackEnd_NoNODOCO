using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace Data_Tier.Models
{
    public partial class DriverAvaiability
    {
        public int Id { get; set; }
        public DateTime TimeStartApp { get; set; }
        public DateTime TimeCloseApp { get; set; }
        public DateTime Date { get; set; }
        public int DriverId { get; set; }

        public virtual Driver Driver { get; set; }
    }
}
