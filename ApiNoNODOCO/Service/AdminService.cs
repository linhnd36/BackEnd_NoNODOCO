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
    public class AdminService : BaseService<Admin>, IAdminService
    {
        public AdminService(IUnitOfWork _unitOfWork, IGenericRepository<Admin> _service) : base(_unitOfWork, _service)
        {
        }
        public Admin GetAdminInfo(LoginRequest userLogin)
        {
            return _unitOfWork.Admin.GetAdminInfo(userLogin);
        }
    }
}
