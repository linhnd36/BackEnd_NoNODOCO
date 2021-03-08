using Data_Tier.DBContext;
using Data_Tier.Repositories;
using Data_Tier.Repositories.IRepositories;
using System;
using System.Threading.Tasks;

namespace Data_Tier.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly NoNODOCOContext _context;

        public IAdminRepository Admin { get; private set; }
        public IBonusRepository Bonus { get; private set; }
        public IBookingRepository Booking { get; private set; }
        public ICustomerRepository Customer { get; private set; }
        public IDriverRepository Driver { get; private set; }
        public IDriverAvaiabilityRepository DriverAvaiability { get; private set; }
        public IDriverHaveBonusRepository DriverHaveBonus { get; private set; }
        public ITransactionWalletRepository TransactionWallet { get; private set; }
        public IVehicleRepository Vehicle { get; private set; }
        public IWalletRepository Wallet { get; private set; }

        private bool disposed = false;
        public UnitOfWork(NoNODOCOContext context)
        {
            _context = context;
            InitResponsitory();
        }
        private void InitResponsitory()
        {
            // Insert new Repository in here
            Admin = new AdminRepository(_context);
            Bonus = new BonusRepository(_context);
            Booking = new BookingRepository(_context);
            Customer = new CustomerRepository(_context);
            Driver = new DriverRepository(_context);
            DriverAvaiability = new DriverAvaiabilityRepository(_context);
            DriverHaveBonus = new DriverHaveBonusRepository(_context);
            TransactionWallet = new TransactionWalletRepository(_context);
            Vehicle = new VehicleRepository(_context);
            Wallet = new WalletRepository(_context);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    _context.Dispose();
                }
            }
            this.disposed = true;
        }
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        public Task<int> CommitAsync()
        {
            return this._context.SaveChangesAsync();
        }
        public Boolean Commit()
        {
            try
            {
                this._context.SaveChangesAsync();
                return true;
            }
            catch
            {
                return false;
            }
        }

    }
}
