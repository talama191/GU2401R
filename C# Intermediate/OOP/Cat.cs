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

    public override void Move()
    {
        Console.WriteLine("");
    }
}
