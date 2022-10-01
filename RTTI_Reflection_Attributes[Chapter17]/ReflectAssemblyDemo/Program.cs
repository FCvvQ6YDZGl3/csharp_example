using System;
using System.Reflection;

namespace ReflectAssemblyDemo
{
    class Program
    {
        static void Main()
        {
            int val;
            Assembly asm;
            try
            {
                asm = Assembly.LoadFrom("MyClasses.exe");
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                Console.ReadKey();
                return;
            }
            Type[] alltypes = asm.GetTypes();
            foreach (Type temp in alltypes)
                Console.WriteLine("Найдено: " + temp.Name);

            Console.WriteLine();

            Type t = alltypes[0];
            Console.WriteLine("Использовано: " + t.Name);

            ConstructorInfo[] ci = t.GetConstructors();

            Console.WriteLine("Доступные конструкторы: ");
            foreach (ConstructorInfo c in ci)
            {
                Console.Write(" " + t.Name + "(");

                ParameterInfo[] pi = c.GetParameters();
                for (int i = 0; i < pi.Length; i++)
                {
                    Console.Write(pi[i].ParameterType.Name + " " + pi[i].Name);
                    if (i + 1 < pi.Length) Console.Write(", ");
                }
                Console.WriteLine(")");
            }
            Console.WriteLine();

            int x;
            for (x = 0; x < ci.Length; x++)
            {
                ParameterInfo[] pi = ci[x].GetParameters();
                if (pi.Length == 2) break;
            }
            if (x == ci.Length)
            {
                Console.WriteLine("Подходящий конструктор не найден.");
                return;
            }
            else Console.WriteLine("Найден конструктор с двумя параметрами.\n");

            object[] consargs = new object[2];
            consargs[0] = 10;
            consargs[1] = 20;
            object reflectOb = ci[x].Invoke(consargs);

            Console.WriteLine("\nВызов методов для объекта reflectOb.");
            Console.WriteLine();
            MethodInfo[] mi = t.GetMethods();

            foreach (MethodInfo m in mi)
            {
                ParameterInfo[] pi = m.GetParameters();

                if (m.Name.CompareTo("Set") == 0 &&
                    pi[0].ParameterType == typeof(int))
                {
                    object[] args = new object[2];
                    args[0] = 9;
                    args[1] = 18;
                    m.Invoke(reflectOb, args);
                }
                else if (m.Name.CompareTo("Set") == 0 &&
                    pi[0].ParameterType == typeof(double))
                {
                    object[] args = new object[2];
                    args[0] = 1.12;
                    args[1] = 23.4;
                    m.Invoke(reflectOb, args);
                }
                else if (m.Name.CompareTo("Sum") == 0)
                {
                    val = (int)m.Invoke(reflectOb, null);
                    Console.WriteLine("Сумма равна " + val);
                }
                else if (m.Name.CompareTo("IsBetween") == 0)
                {
                    object[] args = new object[1];
                    args[0] = 14;
                    if ((bool)m.Invoke(reflectOb, args))
                        Console.WriteLine("Значение 14 находится между x и y");
                }
                else if (m.Name.CompareTo("Show") == 0)
                {
                    m.Invoke(reflectOb, null);
                }
            }

            Console.ReadKey();
        }
    }
}
