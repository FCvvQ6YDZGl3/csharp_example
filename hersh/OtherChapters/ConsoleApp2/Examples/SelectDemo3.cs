using System;
using System.Linq;
using System.Net.Mail;


namespace LinqSelect
{
    class ContactInfo
    {
        public string Name { get; set; }
        public MailAddress EMail { get; set; }
        public string Phone {get; set; }
        public ContactInfo(string n, MailAddress a, string p)
        {
            Name = n;
            EMail = a;
            Phone = p;
        }
    }
    internal class SelectDemo3
    {
        public static void main()
        {
            ContactInfo[] contacts =
            {
                new ContactInfo("Герберт", new MailAddress("Herb@HerbSchildt.com"), "555-1010"),
                new ContactInfo("Том", new MailAddress("Tom@HerbSchildt.com"), "555-1101"),
                new ContactInfo("Сара", new MailAddress("Sara@HerbSchildt.com"), "555-0110")
            };

            var emailList = from entry in contacts
                            select entry;

            Console.WriteLine("Список адресов электронной почты");

            foreach (ContactInfo e in emailList)
                Console.WriteLine("{0}: {1}", e.Name, e.EMail.Address);
        }
    }
}
