
namespace Part1
{
    public interface IShape : IComparable<IShape>
    {
        public double GetArea();
        public double GetPerimeter();
    }

    public class Circle : IShape
    {
        private double radius;
        public double Area => GetArea();

        public Circle(double radius)
        {
            if (radius < 0) throw new Exception("Gia tri ban kinh khong duoc phep nho hon 0");
            this.radius = radius;
        }


        public double GetArea()
        {
            return radius * radius * Math.PI;
        }

        public double GetPerimeter()
        {
            return radius * 2 * Math.PI;
        }

        public int CompareTo(IShape? other)
        {
            double area = GetArea();
            if (area > other.GetArea()) return 1;
            if (area < other.GetArea()) return -1;
            return 0;
        }
    }

    public class Rectangle : IShape
    {
        private double width;
        private double height;

        public Rectangle(double width, double height)
        {
            this.width = width;
            this.height = height;
        }

        public int CompareTo(IShape? other)
        {
            double area = GetArea();
            if (area > other.GetArea()) return 1;
            if (area < other.GetArea()) return -1;
            return 0;
        }

        public double GetArea()
        {
            return width * height;
        }

        public double GetPerimeter()
        {
            return (width + height) * 2;
        }
    }
}
