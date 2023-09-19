using System;

namespace UseBaseClassConstraint
{
    class PhoneNumber
    {
        public PhoneNumber(string n, string num)
        {
            Name = n;
            Number = num;
        }
        public string Number { get; set; }
        public string Name { get; set; }
    }

    class Friend : PhoneNumber
    {
        public Friend(string n, string num, bool wk) : base(n, num)
        {
            IsWorkNumber = wk;
        }
        public bool IsWorkNumber { get; private set; }
    }

    class Supplier : PhoneNumber
    {
        public Supplier(string n, string num) : base(n, num)
        {
        }
    }

    class EmailFriend
    {

    }

    class PhoneList<T> where T : PhoneNumber
    {
        T[] phList;
        int end;

        public PhoneList()
        {
            phList = new T[10];
            end = 0;
        }

        public bool Add(T newEntry)
        {
            if (end == 10) return false;
            phList[end] = newEntry;
            end++;
            return true;
        }

        public T FindByName(string name)
        {
            for (int i = 0; i < end; i++)
            {
                if (phList[i].Name == name)
                    return phList[i];
            }
            throw new NotFoundException();
        }

        public T FindByNumber(string number)
        {
            for (int i = 0; i < end; i++)
            {
                if (phList[i].Number == number)
                {
                    return phList[i];
                }
            }
            throw new NotFoundException();
        }
    }

    class NotFoundException : Exception
    {
        public NotFoundException() : base() { }
        public NotFoundException(string str) : base(str) { }
        public NotFoundException(string str, Exception inner) : base(str, inner) { }
        protected NotFoundException(
            System.Runtime.Serialization.SerializationInfo si,
            System.Runtime.Serialization.StreamingContext sc) : base(si, sc) { }
    }

    class UseBaseClassConstraint
    {
        static void Main()
        {
            PhoneList<Friend> plist = new PhoneList<Friend>();
            plist.Add(new Friend("Том", "555-1234", true));
            plist.Add(new Friend("Гари", "555-6756", true));
            plist.Add(new Friend("Матт", "555-9254", false));

            try
            {
                Friend frnd = plist.FindByName("Гари");

                Console.Write(frnd.Name + ": " + frnd.Number);

                if (frnd.IsWorkNumber)
                    Console.WriteLine("(рабочий)");
                else
                    Console.WriteLine();
            }
            catch (NotFoundException)
            {
                Console.WriteLine("Не найдено");
            }

            Console.WriteLine();

            PhoneList<Supplier> plist2 = new PhoneList<Supplier>();
            plist2.Add(new Supplier("Фирма Global Hardware", "555-8823"));
            plist2.Add(new Supplier("Агенство Computer Warehouse", "555-9256"));
            plist2.Add(new Supplier("Компания NetworkCity", "555-2564"));
            try
            {
                Supplier sp = plist2.FindByNumber("555-2564");
                Console.WriteLine(sp.Name + ": " + sp.Number);
            }
            catch(NotFoundException)
            {
                Console.WriteLine("Не найдено");
            }

            Console.ReadLine();
        }
    }
}
