using System;
using System.Linq;
using System.Net.Mail;

namespace LinqSelect
{

    internal class SelectDemo2
    {
        public static void main()
        {
            MailAddress[] addrs =
            {
                new MailAddress("Herb@HerbSchildt.com"),
                new MailAddress("Tom@HerbSchildt.com"),
                new MailAddress("Sara@HerbSchildt.com")
            };
            var eAddrs = from entry in addrs
                         select entry.Address;
            Console.WriteLine("Адреса электронной почты:");

            foreach(string s in eAddrs)
                Console.WriteLine(" " + s);
        }
    }
}
