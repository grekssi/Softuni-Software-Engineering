using System;
using System.Text;
using System.Xml;

namespace interfaces
{
    public class Circle : IDrawable
    {
        private int radius = 0;

        public Circle(int radius)
        {
            this.radius = radius;
        }

        public void Draw()
        {
            double rIn = radius - 0.5;
            double rOut = radius + 0.5;

            for (int x = radius; x >= -radius; --x)
            {
                for (double y = -radius; y < rOut; y += 0.5)
                {
                    double sum = x * x + y * y;
                    if (sum >= rIn * rIn && sum <= rOut * rOut)
                    {
                        Console.Write("*");
                    }
                    else
                    {
                        Console.Write(" ");
                    }
                }

                Console.WriteLine();
            }
        }
    }
}
