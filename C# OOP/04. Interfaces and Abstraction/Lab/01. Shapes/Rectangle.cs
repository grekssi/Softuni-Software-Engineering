using System;
using System.Collections.Generic;
using System.Text;

namespace interfaces
{
    public class Rectangle : IDrawable
    {
        private int height;
        private int width;

        public Rectangle(int height, int width)
        {
            this.height = height;
            this.width = width;
        }

        public void Draw()
        {
            DrawLine(width, '*', '*');
            for (int i = 0; i < height; i++)
            {
                DrawLine(width, '*', ' ');
            }
            DrawLine(width, '*', '*');
        }

        static void DrawLine(int width, char end, char mid)
        {
            Console.Write(end);
            for (int i = 0; i < width; i++)
            {
                Console.Write(mid);
            }
            Console.WriteLine(end);
        }
    }
}
