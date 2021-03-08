using ApiVoucher.BaseService;
using Data_Tier.Models;
using Data_Tier.Models.Models_Customize;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiNoNODOCO.Service.IService
{
    public interface IDriverService : IBaseService<Driver>
    {
        public Driver GetDriverInfo(LoginRequest user);
    }
}
