using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RectangleStruct
{
    public struct Rectangle
    {
        private double width;
        private double height;

        public double Width
        {
            get => width;
            set
            {
                Console.OutputEncoding = System.Text.Encoding.UTF8;
                if (value <= 0)
                    throw new ArgumentException("Ширина должна быть положительным числом");
                width = value;
            }
        }

        public double Height
        {
            get => height;
            set
            {
                Console.OutputEncoding = System.Text.Encoding.UTF8;
                if (value <= 0)
                    throw new ArgumentException("Высота должна быть положительным числом");
                height = value;
            }
        }

        public double Area => Width * Height;
        public double Perimeter => 2 * (Width + Height);

        public Rectangle(double width, double height) : this()
        {
            Width = width;
            Height = height;
        }

        public override string ToString() =>
            $"Прямоугольник шириной {Width:F4} см и высотой {Height:F4} см";

        public override bool Equals(object obj)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            if (!(obj is Rectangle))
                throw new ArgumentException("Объект для сравнения не является прямоугольником");

            Rectangle other = (Rectangle)obj;
            const double tolerance = 1e-13;
            return Math.Abs(Width - other.Width) < tolerance &&
                   Math.Abs(Height - other.Height) < tolerance;
        }

        public override int GetHashCode()
        {
            unchecked
            {
                int hash = 17;
                const int prime = 23;
                hash = hash * prime + Width.GetHashCode();
                hash = hash * prime + Height.GetHashCode();
                return hash;
            }
        }

        public static bool operator ==(Rectangle left, Rectangle right) => left.Equals(right);
        public static bool operator !=(Rectangle left, Rectangle right) => !left.Equals(right);

        public static Rectangle operator *(double factor, Rectangle rectangle)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            if (factor <= 0)
                throw new ArgumentException("Коэффициент должен быть положительным числом");

            return new Rectangle(rectangle.Width * factor, rectangle.Height * factor);
        }

        public static Rectangle operator *(Rectangle rectangle, double factor) => factor * rectangle;
    }
}