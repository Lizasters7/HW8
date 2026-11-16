using System;

abstract class Shape
{
    public abstract int GetArea();
}

class Rectangle : Shape
{
    public virtual int Width { get; set; }
    public virtual int Height { get; set; }

    public Rectangle(int width, int height)
    {
        Width = width;
        Height = height;
    }
    public override int GetArea() => Width * Height;
}

class Square : Shape
{
    public int Side { get; set; }

    public Square(int side)
    {
        Side = side;
    }

    public override int GetArea() => Side * Side;

    class Program
    {
        static void Main(string[] args)
        {
            Shape rect = new Rectangle(5, 10);
            Shape square = new Square(5);

            Console.WriteLine(rect.GetArea());   
            Console.WriteLine(square.GetArea()); 

            Console.ReadKey();
        }
    }
}