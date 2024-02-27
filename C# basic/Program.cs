
public class Program
{
    static void Main(string[] args)
    {
        Account acc1 = new Account("Hong", 30, false);
        Console.WriteLine("Ten nguoi dung la: " + acc1.accountName + " Tuoi: " + acc1.age);
        Console.WriteLine($"Ten nguoi dung la: {acc1.accountName} Tuoi: {acc1.age}");
        Console.ReadKey();
    }
}
