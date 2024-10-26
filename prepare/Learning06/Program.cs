using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        Square square = new Square("Red", 5);
        Rectangle rectangle = new Rectangle("Blue", 4, 6);
        Circle circle = new Circle("Green", 3);

        List<Shape> shapes = new List<Shape> { square, rectangle, circle };

        foreach (Shape shape in shapes)
        {
            Console.WriteLine($"Shape color: {shape.Color}");
            Console.WriteLine($"Shape area: {shape.GetArea()}");
            Console.WriteLine();
        }
    }
}
