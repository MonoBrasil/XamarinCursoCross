using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WsLibMobile;

namespace ConsoleTeste
{
    class Program
    {
        static void Main(string[] args)
        {
            LoginWS l = new LoginWS();
            var t = l.Login("binhara", "123");
            Console.WriteLine(  "REsultado :" + t );

             t = l.Login("binhara", "12212123");
            Console.WriteLine("REsultado :" + t);

            Console.ReadKey();



        }
    }
}
