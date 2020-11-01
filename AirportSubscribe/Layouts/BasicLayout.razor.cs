using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AirportSubscribe
{
    public partial class BasicLayout 
    {
        private  bool IsLogin = true;
        private int LoginCount = 0;

        public void Login() {
            if (LoginCount>3)
            {
                IsLogin = true;
            }
            else
            {
                LoginCount += 1;
            }
        }
    }
}
