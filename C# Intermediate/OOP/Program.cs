

using Part1;

public class Program
{
    static void Main(string[] args)
    {
        string filePath1 = "E:\\Teaching\\Lop 2\\C# Intermediate\\OOP\\example.txt";

        Student[] students = new Student[] {
            new Student(1,"anh",16),
            new Student(2,"van",17)
        };
        BinaryUtils.WriteToBinary(students, filePath1);
        BinaryUtils.ReadBinaryFile(filePath1);
        //BinaryUtils.WriteToBinary("anh", filePath1);
        //BinaryUtils.ReadBinaryFile(filePath1);
    }
}
