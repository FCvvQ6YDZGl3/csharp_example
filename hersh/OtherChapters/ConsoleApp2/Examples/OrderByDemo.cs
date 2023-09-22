using System;
using System.Linq;

namespace LinqOrdering
{
    class Account
    {
        public string FirstName { get; private set; }
        public string LastName { get; private set; }
        public double Balance { get; private set; }
        public string AccountNumber { get; private set; }

        public Account(string fn, string ln, string accnum, double b)
        {
            FirstName = fn;
            LastName = ln;
            AccountNumber = accnum;
            Balance = b;
        }
    }

    class OrderByDemo
    {
        public static void main()
        {
            Account[] accounts =
                { new Account("Том", "Смит", "132CK", 100.23),
                new Account("Том", "Смит", "132CD", 10000.00),
                new Account("Ральф", "Джонс", "436CD", 1923.85),
                new Account("Ральф", "Джонс", "454MM", 987.132),
                new Account("Тед", "Краммер", "897CD", 3223.19),
                new Account("Ральф", "Джонс", "434CK", -123.32),
                new Account("Сара", "Смит", "543MM", 5017.40),
                new Account("Сара", "Смит", "547CD", 34955.79),
                new Account("Сара", "Смит", "843CK", 345.00),
                new Account("Альберт", "Смит", "445CK", -213.67),
                new Account("Бетти", "Краммер", "968MM", 5146.67),
                new Account("Карл", "Смит", "078CD", 15345.99),
                new Account("Джени", "Джонс", "108CK", 10.98)
            };

            var accInfo = from acc in accounts
                          orderby acc.LastName, acc.FirstName, acc.Balance descending
                          select acc;
            Console.WriteLine("Счета в отсортированном порядке: ");

            string str = "";

            foreach (Account acc in accInfo)
            {
                if (str != acc.FirstName)
                {
                    Console.WriteLine();
                    str = acc.FirstName;
                }

                Console.WriteLine("{0}, {1}\tНомер счета: {2}, {3,10:C}",
                    acc.LastName, acc.FirstName,
                    acc.AccountNumber, acc.Balance);
            }
            Console.WriteLine();
        }
    }
}