using System;

namespace NamedParamDemo
{
    [AttributeUsage(AttributeTargets.All)]
    public class RemarkAttribute : Attribute
    {
        string pri_remark;

        public string Supplement;

        public RemarkAttribute(string comment)
        {
            pri_remark = comment;
            Supplement = "Отсутствует";
        }

        public string Remark
        {
            get
            {
                return pri_remark;
            }
        }

        public int Priority { get; set; }
    }

    [RemarkAttribute("В этом классе используется атрибут.",
        Supplement = "Это дополнительная информация",
        Priority = 10)]
    class UseAttrib
    {
    }
    class Program
    {
        static void Main()
        {
            Type t = typeof(UseAttrib);

            Console.WriteLine("Атрибуты в классе " + t.Name + ": ");
            object[] attribs = t.GetCustomAttributes(false);
            foreach (object o in attribs)
                Console.WriteLine(o);

            Type tRemAtt = typeof(RemarkAttribute);
            RemarkAttribute ra = (RemarkAttribute)Attribute.GetCustomAttribute(t, tRemAtt);

            Console.Write("Примечание: ");
            Console.WriteLine(ra.Remark);

            Console.Write("Дополнение: ");
            Console.WriteLine(ra.Supplement);

            Console.WriteLine("Приоритет: " + ra.Priority);
            Console.ReadKey();
            Console.ReadKey();
        }
    }
}
