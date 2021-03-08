using System;
using System.Collections.Generic;

namespace Data_Tier.Models
{
    public partial class Bonus
    {
        public Bonus()
        {
            DriverHaveBonus = new HashSet<DriverHaveBonus>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string BonusCode { get; set; }
        public double? Score { get; set; }
        public double MoneyBonus { get; set; }
        public string Note { get; set; }
        public int Status { get; set; }
        public DateTime StartDateTime { get; set; }
        public DateTime EndDateTime { get; set; }

        public virtual ICollection<DriverHaveBonus> DriverHaveBonus { get; set; }
    }
}
