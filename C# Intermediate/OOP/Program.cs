

public class Program
{
    static void Main(string[] args)
    {
        Dog dog1 = new Dog(10, 0.2, true);
        Dog dog2 = new Dog(10, 0.2, true);

        Console.WriteLine(dog1.GetHashCode());
        Console.WriteLine(dog1.Equals(dog2));
        if (dog1.Equals(dog2))
        {
            Console.WriteLine("2 chu cho co can nang bang nhau");
        }

        Console.ReadKey();

      //MathUtils.Sum
    }
}
