﻿using Data_Tier.DBContext;
using Data_Tier.GenericRepository;
using Data_Tier.Models;
using Data_Tier.Models.Models_Customize;
using Data_Tier.Repositories.IRepositories;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Data_Tier.Enums;

namespace Data_Tier.Repositories
{
    public class DriverRepository : GenericRepository<Driver>, IDriverRepository
    {
        public DriverRepository(NoNODOCOContext context) : base(context)
        {
        }

        public Driver GetDriverInfo(LoginRequest userLogin)
        {
            var list = (from user in _context.Driver
                        where user.Email == userLogin.Email && user.Status == Status.Account.ACTIVE
                        select new
                        {
                            Email = user.Email,
                            FirstName = user.FirstName,
                            LastName = user.LastName,
                            DrivingLicense = user.DrivingLicense,
                            PhoneNumber = user.PhoneNumber,
                            Address = user.Address,
                            Rating = user.Rating,
                            Status = user.Status
                        }).ToList();

            if (list.Count == 0)
            {
                return null;
            }

            Driver result = new Driver();
            foreach (var data in list)
            {
                result.Email = data.Email;
                result.FirstName = data.FirstName;
                result.LastName = data.LastName;
                result.Status = data.Status;
            }
            return result;
        }
    }
}