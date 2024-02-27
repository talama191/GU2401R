
public abstract class Animal
{
    protected double weight;
    protected double height;

    public double Weight => weight;
    public double Height => height;

    public Animal(double weight, double height)
    {
        this.weight = weight;
        this.height = height;
        Console.WriteLine("Khoi tao animal");
    }

    public abstract void MakeSound();
    public abstract void Move();
}