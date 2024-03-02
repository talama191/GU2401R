
public class Animal
{
    protected double weight;
    protected double height;

    public double Weight => weight;
    public double Height => height;

    public Animal(double weight, double height)
    {
        this.weight = weight;
        this.height = height;
    }

    public virtual void MakeSound()
    {
        Console.WriteLine("test");
    }

    public virtual void Move()
    {
        Console.WriteLine("test");
    }
}