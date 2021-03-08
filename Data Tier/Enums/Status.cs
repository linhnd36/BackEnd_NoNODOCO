using System;
using System.Collections.Generic;
using System.Text;

namespace Data_Tier.Enums
{
    public static class Status
    {
        public static class Driving
        {
            public const int NOT_READY = 0;
            public const int READY = 1;
            public const int ACCEPT_BOOKING = 2;
            public const int IN_BOOKING = 3;
        }
        public static class Account
        {
            public const int ACTIVE = 1;
            public const int BANNED = 0;
        }
    }
}
