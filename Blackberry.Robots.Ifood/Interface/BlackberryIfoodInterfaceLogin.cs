using Blackberry.Robots.Ifood.Request;
using Blackberry.Robots.Ifood.Result;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blackberry.Robots.Ifood.Interface
{
    public class BlackberryIfoodInterfaceLogin
    {
        public LoginResult Login()
        {
            LoginResult result = new LoginRequest().Login();
            return result;
        }
    }
}
