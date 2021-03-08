using Data_Tier.DBContext;
using Data_Tier.GenericRepository;
using Data_Tier.Models;
using Data_Tier.Repositories.IRepositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace Data_Tier.Repositories
{
    public class WalletRepository : GenericRepository<Wallet>, IWalletRepository
    {
        public WalletRepository(NoNODOCOContext context) : base(context)
        {
        }
    }
}