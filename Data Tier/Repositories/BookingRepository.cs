using Data_Tier.DBContext;
using Data_Tier.GenericRepository;
using Data_Tier.Models;
using Data_Tier.Repositories.IRepositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace Data_Tier.Repositories
{
    class BookingRepository : GenericRepository<Booking>, IBookingRepository
    {
        public BookingRepository(NoNODOCOContext context) : base(context)
        {
        }
    }
}
