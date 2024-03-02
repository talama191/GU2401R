
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

    public override string? ToString()
    {
        return $"Chu cho nay co can nang {weight}kg, chieu cao {height}m";
    }

    public override bool Equals(object? obj)
    {
        Dog dog2 = obj as Dog;
        if (dog2 == null) return false;
        return this.weight == dog2.weight;
    }


}