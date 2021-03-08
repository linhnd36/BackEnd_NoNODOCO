using Data_Tier.DBContext;
using Data_Tier.GenericRepository;
using Data_Tier.Models;
using Data_Tier.Models.Models_Customize;
using Data_Tier.Repositories.IRepositories;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;

namespace Data_Tier.Repositories
{
    public class CustomerRepository : GenericRepository<Customer>, ICustomerRepository
    {
        public CustomerRepository(NoNODOCOContext context) : base(context)
        {
        }
        public Customer GetUserInfoInClaim(LoginRequest userLogin)
        {
            var list = (from user in _context.Customer
                       where user.Email == userLogin.Email 
                       select new
                       {
                           Email = user.Email,
                           FirstName = user.FirstName,
                           LastName = user.LastName,
                           PhoneNumber = user.PhoneNumber,
                           Adress = user.Adress,
                           Status = user.Status
                       }).ToList();

            if (list.Count == 0)
            {
                return null;
            }

            Customer result = new Customer();
            foreach (var data in list)
            {
                result.Email = data.Email;
                result.FirstName = data.FirstName;
                result.LastName = data.LastName;
                result.PhoneNumber = data.PhoneNumber;
                result.Adress = data.Adress;
                result.Status = data.Status;
            }
            return result;
        }
    }
}