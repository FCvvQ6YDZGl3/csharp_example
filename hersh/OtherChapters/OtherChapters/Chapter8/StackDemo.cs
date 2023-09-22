using System;

class StackDemo
{
    public void run()
    {
        Stack stk1 = new Stack(10);
        Stack stk2 = new Stack(10);
        Stack stk3 = new Stack(10);
        char ch;
        int i;

        Console.WriteLine("Поместить символы A-J в стек stk1.");
        for (i = 0; !stk1.IsFull(); i++)
        {
            stk1.Push((char)('A' + i));
        }
        Console.WriteLine("Стек stk1 заполненю");

        Console.Write("Содержимое стека stk1: ");
        while (!stk1.IsEmpty())
        {
            ch = stk1.Pop();
            Console.WriteLine(ch);
        }

        Console.WriteLine();

        if (stk1.IsEmpty()) Console.WriteLine("Стек stk1 пуст.\n");

        Console.WriteLine("Вновь поместить символы A-J в стек stk1.");
        for (i = 0; !stk1.IsFull(); i++)
        {
            stk1.Push((char)('A' + i));
        }
        Console.WriteLine("А теперь извлечь символы из стека stk1\n" +
            "и поместить их в стек stk2.");
        while (!stk1.IsEmpty())
        {
            ch = stk1.Pop();
            stk2.Push(ch);
        }
        Console.Write("Содержимое стека stk2:\n");
        while (!stk2.IsEmpty())
        {
            ch = stk2.Pop();
            Console.WriteLine(ch);
        }

        Console.WriteLine("\n");

        Console.WriteLine("Поместить 5 символов в стек stk3.");
        for (i = 0; i<5; i++)
        {
            stk3.Push((char)('A' + i));
        }

        Console.WriteLine("Емкость стека stk3: " + stk3.Capacity());
        Console.WriteLine("Количество объектов в стеке stk3: " + stk3.GetNum());
    }
}