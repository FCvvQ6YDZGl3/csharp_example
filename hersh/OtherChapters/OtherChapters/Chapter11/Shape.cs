using System;
abstract class TwoDShape
{
    public double pri_Width;
    public double pri_Height;

    public double Width
    {
        get {return pri_Width; }
        set { pri_Width = value < 0 ? -value : value; }
    }

    public double Height
    {
        get { return pri_Height; }
        set { pri_Height = value < 0 ? -value : value; }
    }

    public void ShowDim()
    {
        Console.WriteLine("Ширина и высота равны {0} и {1}", Width, Height);
    }

    public TwoDShape()
    {
        Width = Height = 0.0;
        name = "null";
    }

    public TwoDShape(double w, double h, string n)
    {
        Width = w;
        Height = h;
        name = n;
    }
    
    public TwoDShape(double w, double h)
    {
        Width = w;
        Height = h;
    }

    public TwoDShape(double x, string n)
    {
        Width = Height = x;
        name = n;
    }

    public TwoDShape(TwoDShape ob)
    {
        Width = ob.Width;
        Height = ob.Height;
        name = ob.name;
    }

    public string name { get; set; }
    public abstract double Area();
}

class Triangle : TwoDShape
{
    public string Style;

    public Triangle()
    {
        Style = "null";
    }

    public Triangle(string s, double w, double h) : base(w, h, s)
    {
        Style = s;
    }

    public Triangle(double x) : base(x, "треугольник")
    {
        Style = "равнобедренный";
    }

    public Triangle(Triangle ob) : base(ob)
    {
        Style = ob.Style;
    }

    public override double Area()
    {
        return Width * Height / 2;
    }

    public void ShowStyle()
    {
        Console.WriteLine("Треугольник " + Style);
    }
}

class Shapes
{
    public void run()
    {
        ColorTriangle t1 = new ColorTriangle("синий", "прямоугольный", 8.0, 12.0);
        ColorTriangle t2 = new ColorTriangle("красный", "равнобедренный", 2.0, 2.0);

        Console.WriteLine("Сведения об объекте t1: ");
        t1.ShowStyle();
        t1.ShowDim();
        t1.ShowColor();
        Console.WriteLine("Площадь равна " + t1.Area());

        Console.WriteLine();

        Console.WriteLine("Сведения об объекте t2: ");
        t2.ShowStyle();
        t2.ShowDim();
        t2.ShowColor();
        Console.WriteLine("Площадь равна " + t2.Area());
    }
}

class DynShape
{
    public void run()
    {
        TwoDShape[] shapes = new TwoDShape[4];

        shapes[0] = new Triangle("прямоугольный", 8.0, 12.0);
        shapes[1] = new Rectangle(10);
        shapes[2] = new Rectangle(10, 4);
        shapes[3] = new Triangle(7.0);

        for (int i = 0; i < shapes.Length; i++)
        {
            Console.WriteLine("Объект - " + shapes[i].name);
            Console.WriteLine("Площадь равна " + shapes[i].Area());

            Console.WriteLine();
        }
    }
}

class Rectangle : TwoDShape
{
    public bool IsSquare()
    {
        if (Width == Height) return true;
        return false;
    }

    public override double Area()
    {
        return Width * Height;
    }

    public Rectangle(double w, double h) : base(w, h, "прямоугольник")
    {
    }
    public Rectangle(double x) : base(x, "прямоугольник")
    {
    }
}

class ColorTriangle : Triangle
{
    string color;

    public ColorTriangle(string c, string s, double w, double h) : base(s, w, h)
    {
        color = c;
    }

    public void ShowColor()
    {
        Console.WriteLine("Цвет " + color);
    }
}