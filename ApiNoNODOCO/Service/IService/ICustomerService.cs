using ApiVoucher.BaseService;
using Data_Tier.Models;
using Data_Tier.Models.Models_Customize;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiNoNODOCO.Service.IService
{
    public interface ICustomerService : IBaseService<Customer>
    {
        public Customer GetUserInfoInClaim(LoginRequest userLogin);
    }
}
