using System;

namespace interfaces
{
    class Program
    {
        static void Main(string[] args)
        {
            Circle circle = new Circle(4);
            circle.Draw();
            Rectangle rectangle = new Rectangle(4, 6);
            rectangle.Draw();
        }
    }
}
