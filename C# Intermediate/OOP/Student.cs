public class Student
{
    public int id { get; private set; }
    private string studentName;
    private int age;


    public string StudentName => studentName;
    public int Age
    {
        get => age;
        set
        {
            if (value >= 6 && value <= 18)
            {
                age = value;
            }
            else
            {
                Console.WriteLine("Tuoi khong hop le");
            }
        }
    }
    public string Info => age < 18 ? "La hoc sinh" : "La nguoi lon";

    public Student(string studentName, int age)
    {
        if (age < 0)
        {
            Console.WriteLine("Tuoi khong duoc phep <=6");
        }
        this.studentName = studentName;
        this.age = age;
    }

    public Student(int id, string studentName, int age)
    {
        this.id = id;
        this.studentName = studentName;
        this.age = age;
    }

    public void Print()
    {
        Console.WriteLine($"Ten: {this.studentName}, Tuoi: {this.age}");
    }
}
