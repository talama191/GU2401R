
public class Rectangle
{
    double width;
    double height;

    public Rectangle()
    {
    }

    public Rectangle(double width, double height)
    {
        this.width = width;
        this.height = height;
    }

    public Rectangle(double width)
    {
        this.width = width;
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
