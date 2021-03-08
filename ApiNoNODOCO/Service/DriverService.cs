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
    public class DriverService : BaseService<Driver>, IDriverService
    {
        public DriverService(IUnitOfWork _unitOfWork, IGenericRepository<Driver> _service) : base(_unitOfWork, _service)
        {
        }

        public Driver GetDriverInfo(LoginRequest userLogin)
        {
            return _unitOfWork.Driver.GetDriverInfo(userLogin);
        }
    }
}
