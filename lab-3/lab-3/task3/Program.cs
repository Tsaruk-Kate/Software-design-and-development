using System;
using task3;

class Program
{
    static void Main(string[] args)
    {
        IRenderer rasterRenderer = new RasterRenderer();
        IRenderer vectorRenderer = new VectorRenderer();

        Shape circle = new Circle(rasterRenderer);
        Shape square = new Square(vectorRenderer);
        Shape triangle = new Triangle(rasterRenderer);

        circle.Draw();
        square.Draw();
        triangle.Draw();
    }
}