using System;
using System.Collections.Generic;
using System.Text;

namespace Data_Tier.Models.Models_Customize
{
    public class LoginRequest
    {
        
        public string Email { get; set; }
        public string Token { get; set; }
        public string Mode { get; set; }
        public LoginRequest(String Email)
        {
            this.Email = Email;
        }
    }
}
