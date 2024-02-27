

public class Program
{
    static void Main(string[] args)
    {
        Cat cat1 = new Cat(3, 0.1f, true);
        Dog dog1 = new Dog(10, 0.2f, false);

        Console.WriteLine($"Can nang meo la: {cat1.Weight}, Can nang cho la: {dog1.Weight}");
        cat1.MakeSound();
        dog1.MakeSound();

        Car car = new Car();
        Console.WriteLine($"So banh xe la {car.WheelCount}");
        Console.ReadKey();


    }
}
