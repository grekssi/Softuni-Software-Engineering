using System.Transactions;

namespace Shapes
{
    public class Rectangle : Shape
    {
        public Rectangle(double height, double width)
        {
            this.Height = height;
            this.Width = width;
        }

        public double Height { get; set; }
        public double Width { get; set; }

        public override double CalculatePerimeter()
        {
            return 2 * Height + 2 * Width;
        }

        public override double CalculateArea()
        {
            return Height * Width;
        }

        public override string Draw()
        {
            return base.Draw() + " Rectangle";
        }
    }
}
