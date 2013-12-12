using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WsLibMobile
{
    public class LoginWS
    {
        public bool Login(string login, string senha)
        {
            var local = new localhost.Service1();
            var status =  local.MakeLogin(login, senha);
            return status;
        }
    }
}
