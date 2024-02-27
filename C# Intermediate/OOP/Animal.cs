
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
}

public class Cat : Animal
{
    bool canCatchMouse;

    public Cat(double weight, double height, bool canCatchMouse) : base(weight, height)
    {
        this.canCatchMouse = canCatchMouse;
        this.weight = 2;
    }

    public override void MakeSound()
    {
        Console.WriteLine("Meo meo");
    }
}

public class Dog : Animal
{
    bool coPhaiChoNghiepVu;

    public Dog(double weight, double height, bool coPhaiChoNghiepVu) : base(weight, height)
    {
        this.coPhaiChoNghiepVu = coPhaiChoNghiepVu;
    }

    public override void MakeSound()
    {
        Console.WriteLine("Gau gau");
    }
}