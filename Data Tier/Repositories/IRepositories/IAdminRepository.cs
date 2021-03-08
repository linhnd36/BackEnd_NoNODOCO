using Data_Tier.GenericRepository;
using Data_Tier.Models;
using Data_Tier.Models.Models_Customize;
using System;
using System.Collections.Generic;
using System.Text;

namespace Data_Tier.Repositories.IRepositories
{
    public interface IAdminRepository : IGenericRepository<Admin>
    {
        public Admin GetAdminInfo(LoginRequest userLogin);
    }
}
