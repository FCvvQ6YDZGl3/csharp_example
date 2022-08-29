using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project1.Chapter12
{
    struct Book
    {
        public string Author;
        public string Title;
        public int Copyright;

        public Book(string a, string t, int c)
        {
            Author = a;
            Title = t;
            Copyright = c;
        }

        public void show()
        {
            Console.WriteLine(Author + ", " +
                                Title + ", (c) " + Copyright);
        }
    }
    class StructDemo
    {
        public void run()
        {
            Book book1 = new Book("Герберт Шилдт",
                                "Полный справочник по C# 4.0",
                                2010);
            Book book2 = new Book();
            Book book3;

            book1.show();

            Console.WriteLine();

            if (book2.Title == null)
                Console.WriteLine("Член book2.Title пуст.");

            book2.Title = "О дивный новый мир";
            book2.Author = "Олдос Хаксли";
            book2.Copyright = 1932;


            book2.show();

            Console.WriteLine();

            //Console.WriteLine(book3.Title);

            book3.Title = "Красный шторм";

            Console.WriteLine(book3.Title);
        }
    }
}
