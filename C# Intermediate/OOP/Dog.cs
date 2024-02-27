
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

    public override void Move()
    {
        Console.WriteLine("BBBB");
    }
}