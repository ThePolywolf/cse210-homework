using System;

class Program
{
    static void Main(string[] args)
    {
        List<Shape> shapes = new List<Shape>(){
            new Square("Blue", 10),
            new Rectangle("Green", 5, 15),
            new Circle("Red", 8)
        };

        foreach (Shape shape in shapes){
            Console.WriteLine($"Color: {shape.GetColor()}, Area: {shape.Area()}");
        }
    }
}