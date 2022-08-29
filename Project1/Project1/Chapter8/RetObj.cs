using System;

class Rect
{
    int width;
    int height;

    public Rect(int w, int h)
    {
        width = w;
        height = h;
    }

    public int Area()
    {
        return width * height;
    }

    public void Show()
    {
        Console.WriteLine(width + " " + height);
    }

    public Rect Enlarge(int factor)
    {
        return new Rect(width * factor, height * factor);
    }
}

class RetObj
{
    public void run()
    {
        Rect r1 = new Rect(4, 5);
        Console.Write("Размеры прямоугольника r1: ");
        r1.Show();
        Console.WriteLine("Площадь прямоугольника r1: {0}", r1.Area());
        Console.WriteLine();
        Rect r2 = r1.Enlarge(2);
        Console.Write("Размеры прямоугольгника r2: ");
        r2.Show();
        Console.WriteLine("Площадь прямоугольника r1: {0}", r2.Area());
    }
}