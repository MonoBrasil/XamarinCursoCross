using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using DBLib;


namespace DBLIBTest
{
    [TestFixture]
    public class LoginTest
    {
        [Test]
        public void InserirTest()
        {
            LoginDB l = new LoginDB();
            l.Login = "binhara";
            l.Senha = "123";
            l.Save();

            var result = LoginDB.Get(l.ID);

            Assert.AreEqual("binhara",result.Login);
            Assert.AreEqual("123", result.Senha);            
        }
  }
}

