using System;
using System.Collections.Generic;

namespace Data_Tier.Models
{
    public partial class Admin
    {
        public Admin()
        {
            DriverAdminRegister = new HashSet<Driver>();
            DriverAdminUpdate = new HashSet<Driver>();
        }

        public int Id { get; set; }
        public string LastName { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public int Status { get; set; }

        public virtual ICollection<Driver> DriverAdminRegister { get; set; }
        public virtual ICollection<Driver> DriverAdminUpdate { get; set; }
    }
}
