namespace AreaLib
{
    public interface IFigure
    {
        double CalcArea();
    }

    public class Circle : IFigure
    {
        public double Radius { get; }
        public Circle(double radius)
        {
            if (radius <= 0)
                throw new ArgumentException("R must be > 0");

            Radius = radius;
        }
        public double CalcArea() => Math.PI * Radius * Radius;
    }

    public class Triangle : IFigure
    {
        public double A { get; }
        public double B { get; }
        public double C { get; }
        public Triangle(double a, double b, double c)
        {
            if (a <= 0 || b <= 0 || c <= 0)
                throw new ArgumentException("a, b, c must be > 0");

            if (a + b <= c || a + c <= b || b + c <= a)
                throw new ArgumentException("sum of 2 sides must be greater than 3rd side");

            A = a;
            B = b;
            C = c;
        }

        public double CalcArea()
        {
            double s = (A + B + C) / 2;
            return Math.Sqrt(s * (s - A) * (s - B) * (s - C));
        }

        public bool IsRightAngled()
        {
            double[] sides = { A, B, C };
            Array.Sort(sides);

            return Math.Abs(Math.Pow(sides[0], 2) + Math.Pow(sides[1], 2) - Math.Pow(sides[2], 2)) < 1e-10;
        }
    }

    public class Rectangle : IFigure
    {
        public double Height { get; }
        public double Width { get; }
        public Rectangle(double height, double width)
        {
            if (height <= 0 || width <= 0)
                throw new ArgumentException("Height and Width must be > 0");

            Height = height;
            Width = width;
        }
        public double CalcArea() => Height * Width;
    }

    public static class Area
    {
        public static double Calc(IFigure figure) => figure.CalcArea();
    }
}
