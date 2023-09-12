using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Group
{
    class Transport
    {
        public string Name { get; set; }
        public string How { get; set; }

        public Transport(string n, string h)
        {
            Name = n;
            How = h;
        }
    }

    class GroupJoinDemo
    {
        public static void main()
        {
            string[] travelTypes =
            {
                "Воздушный",
                "Морской",
                "Наземный",
                "Речной"
            };

            Transport[] transports =
            {
                new Transport("велосипед", "Назменый"),
                new Transport("аэростат", "Воздушный"),
                new Transport("лодка", "Речной"),
                new Transport("самолет", "Воздушный"),
                new Transport("каноэ", "Речной"),
                new Transport("биплан", "Воздушный"),
                new Transport("автомашина", "Наземный"),
                new Transport("судно", "Морской"),
                new Transport("поезд", "Наземный"),
            };

            var byHow = from how in travelTypes
                        join trans in transports
                        on how equals trans.How
                        into lst
                        select new { How = how, Tlist = lst };

            foreach(var t in byHow)
            {
                Console.WriteLine("К категориии <{0}> траснпорт относится:", t.How);
                foreach (var m in t.Tlist)
                    Console.WriteLine(" " + m.Name);
                Console.WriteLine();
            }

        }
    }
}
