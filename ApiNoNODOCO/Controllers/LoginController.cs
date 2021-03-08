using ApiNoNODOCO.Service.IService;
using ApiNoNODOCO.Utilities;
using Data_Tier.Enums;
using Data_Tier.Models;
using Data_Tier.Models.Models_Customize;
using FirebaseAdmin.Auth;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiNoNODOCO.Controllers
{
    [Route("api/v1/")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private IAdminService _adminService;
        private ICustomerService _customerService;
        private IDriverService _driverService;

        public LoginController(IAdminService adminService, ICustomerService customerService, IDriverService driverService)
        {
            _adminService = adminService;
            _customerService = customerService;
            _driverService = driverService;
        }

        [HttpPost]
        [Route("login")]
        [AllowAnonymous]
        public async Task<ActionResult<dynamic>> LoginAsync([FromBody] LoginRequest user)
        {
            string uid = null;
            string mode = user.Mode;
            UserRecord userRecord;
            try
            {
                FirebaseToken decodedToken = await FirebaseAuth.DefaultInstance.VerifyIdTokenAsync(user.Token);
                uid = decodedToken.Uid;
                userRecord = await FirebaseAuth.DefaultInstance.GetUserAsync(uid);
            } catch     
            {
                if(!mode.Equals("1"))
                {
                    return NotFound(new { message = "Email login error." });
                }
                userRecord = await FirebaseAuth.DefaultInstance.GetUserAsync(uid);
            }
            

            if (user == null || uid == null)
                return NotFound(new { message = "Email login error." });

            string token = Token.GenerateJWTToken(user);

            switch (mode)
            {
                case "1":
                    Customer customer = _customerService.GetUserInfoInClaim(user);
                    if (customer == null)
                    {
                        customer = new Customer();
                        customer.Email = userRecord.Email;
                        customer.PhoneNumber = userRecord.PhoneNumber;
                        customer.LastName = userRecord.DisplayName;
                        customer.Status = Status.Account.ACTIVE;
                        customer.CreateDate = DateTime.Today;
                        _customerService.Create(customer);
                    }
                    else if (Status.Account.BANNED.Equals(customer.Status))
                    {
                        return NotFound(new { message = "Your email has been banned from logging in because of too many cancellation." });
                    }
                    return new
                    {
                        customer = customer,
                        token = token
                    };
                case "2":
                    Driver driver = _driverService.GetDriverInfo(user);
                    if (driver == null)
                    {
                        return NotFound(new { message = "Your email has not been registered or has been banned." });
                    }
                    return new
                    {
                        driver = driver,
                        token = token
                    };
                case "3":
                    Admin admin = _adminService.GetAdminInfo(user);
                    if (admin == null)
                    {
                        return NotFound(new { message = "Your email has not been registered or has been banned." });
                    }
                    return new
                    {
                        admin = admin,
                        token = token
                    };
                default:
                    return NotFound(new { message = "Email you are ban error." });
            }
        }

    }
}
