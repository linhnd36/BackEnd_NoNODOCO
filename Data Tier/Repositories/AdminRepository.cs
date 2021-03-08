using Data_Tier.DBContext;
using Data_Tier.GenericRepository;
using Data_Tier.Models;
using Data_Tier.Models.Models_Customize;
using Data_Tier.Repositories.IRepositories;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Data_Tier.Enums;

namespace Data_Tier.Repositories
{
    public class AdminRepository : GenericRepository<Admin>, IAdminRepository
    {
        public AdminRepository(NoNODOCOContext context) : base(context)
        {
        }
        public Admin GetAdminInfo(LoginRequest userLogin)
        {
            var list = (from user in _context.Admin
                        where user.Email == userLogin.Email  && user.Status == Status.Account.ACTIVE
                        select new
                        {
                            Email = user.Email,
                            Name = user.Name,
                            LastName = user.LastName,
                            Status = user.Status
                        }).ToList();

            if (list.Count == 0)
            {
                return null;
            }

            Admin result = new Admin();
            foreach (var data in list)
            {
                result.Email = data.Email;
                result.Name = data.Name;
                result.LastName = data.LastName;
                result.Status = data.Status;
            }
            return result;
        }
    }
}
