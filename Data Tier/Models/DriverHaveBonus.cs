using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace Data_Tier.Models
{
    public partial class DriverHaveBonus
    {
        public int Id { get; set; }
        public int Status { get; set; }
        public int DriverId { get; set; }
        public int BonusId { get; set; }

        public virtual Bonus Bonus { get; set; }
        public virtual Driver Driver { get; set; }
    }
}
