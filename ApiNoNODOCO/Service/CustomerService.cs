using ApiNoNODOCO.Service.IService;
using ApiVoucher.BaseService;
using Data_Tier.GenericRepository;
using Data_Tier.Models;
using Data_Tier.Models.Models_Customize;
using Data_Tier.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiNoNODOCO.Service
{
    public class CustomerService : BaseService<Customer>, ICustomerService
    {
        public CustomerService(IUnitOfWork _unitOfWork, IGenericRepository<Customer> _service) : base(_unitOfWork, _service)
        {
        }

        public Customer GetUserInfoInClaim(LoginRequest userLogin)
        {
            return _unitOfWork.Customer.GetUserInfoInClaim(userLogin);
        }
    }
}
