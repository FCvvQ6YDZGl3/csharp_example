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

            Console.WriteLine();

            Type t = alltypes[0];
            Console.WriteLine("Использовано: " + t.Name);

            ConstructorInfo[] ci = t.GetConstructors();

            ParameterInfo[] cpi = ci[0].GetParameters();
            object reflectOb;

            if (cpi.Length > 0)
            {
                object[] consargs = new object[cpi.Length];

                for (int n = 0; n < cpi.Length; n++)
                    consargs[n] = 10 + n * 20;

                reflectOb = ci[0].Invoke(consargs);
            }
            else
                reflectOb = ci[0].Invoke(null);

            Console.WriteLine("\nВызов методов для объекта reflectOb.");
            Console.WriteLine();

            MethodInfo[] mi = t.GetMethods(BindingFlags.DeclaredOnly |
                BindingFlags.Instance |
                BindingFlags.Public);

            foreach (MethodInfo m in mi)
            {
                Console.WriteLine("Вызов метода {0} ", m.Name);

                ParameterInfo[] pi = m.GetParameters();

                switch (pi.Length)
                {
                    case 0:
                        if (m.ReturnType == typeof(int))
                        {
                            val = (int)m.Invoke(reflectOb, null);
                            Console.WriteLine("Результат: " + val);
                        }
                        else if (m.ReturnType == typeof(void))
                        {
                            m.Invoke(reflectOb, null);
                        }
                        break;
                    case 1:
                        if (pi[0].ParameterType == typeof(int))
                        {
                            object[] args = new object[1];
                            args[0] = 14;
                            if ((bool)m.Invoke(reflectOb, args))
                                Console.WriteLine("Значение 14 находиться между x и y");
                            else
                                Console.WriteLine("Значение 14 не находиться между x и y");
                        }
                        break;
                    case 2:
                        if ((pi[0].ParameterType == typeof(int)) &&
                            (pi[1].ParameterType == typeof(int)))
                        {
                            object[] args = new object[2];
                            args[0] = 9;
                            args[1] = 18;
                            m.Invoke(reflectOb, args);
                        }
                        else if ((pi[0].ParameterType == typeof(double)) &&
                            (pi[1].ParameterType == typeof(double)))
                        {
                            object[] args = new object[2];
                            args[0] = 1.12;
                            args[1] = 23.4;
                            m.Invoke(reflectOb, args);
                        }
                        break;
                }
                Console.WriteLine();
            }

            Console.ReadKey();
        }
    }
}
