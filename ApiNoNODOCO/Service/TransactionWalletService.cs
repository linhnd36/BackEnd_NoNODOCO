using ApiNoNODOCO.Service.IService;
using ApiVoucher.BaseService;
using Data_Tier.GenericRepository;
using Data_Tier.Models;
using Data_Tier.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiNoNODOCO.Service
{
    public class TransactionWalletService : BaseService<TransactionWallet>, ITransactionWalletService
    {
        public TransactionWalletService(IUnitOfWork _unitOfWork, IGenericRepository<TransactionWallet> _service) : base(_unitOfWork, _service)
        {
        }
    }
}
