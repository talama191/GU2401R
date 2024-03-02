
public abstract class Shape
{
    public abstract double GetArea();
    public abstract double GetPerimeter();
}

public class Circle : Shape
{
    public double radius;

    protected Circle(double radius)
    {
        this.radius = radius;
    }

    public override double GetArea()
    {
        return radius * 2 * Math.PI;
    }

    public override double GetPerimeter()
    {
        return radius * radius * Math.PI;
    }
}

public class Rectangle : Shape
{
    public double width;
    public double height;

    public Rectangle(double width, double height)
    {
        this.width = width;
        this.height = height;
    }

    public override double GetArea()
    {
        return width * height;
    }

    public override double GetPerimeter()
    {
        return (width + height) * 2;
    }
}