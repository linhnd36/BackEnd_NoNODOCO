using System;
using System.Threading.Tasks;
using Data_Tier.Repositories.IRepositories;

namespace Data_Tier.UnitOfWork
{
    public interface IUnitOfWork : IDisposable
    {
        
        IAdminRepository Admin { get; }
        IBonusRepository Bonus { get; }
        IBookingRepository Booking { get; }
        ICustomerRepository Customer { get; }
        IDriverRepository Driver { get; }
        IDriverAvaiabilityRepository DriverAvaiability { get; }
        IDriverHaveBonusRepository DriverHaveBonus { get; }
        ITransactionWalletRepository TransactionWallet { get; }
        IVehicleRepository Vehicle { get; }
        IWalletRepository Wallet { get; }

        Boolean Commit();
        Task<int> CommitAsync();
    }
}
