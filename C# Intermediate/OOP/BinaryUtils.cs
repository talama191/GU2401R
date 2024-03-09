
using static System.Net.Mime.MediaTypeNames;

public static class BinaryUtils
{
    public static void WriteToBinary(Student[] students, string filePath)
    {
        try
        {
            FileStream fs = new FileStream(filePath, FileMode.Create);

            BinaryWriter bw = new BinaryWriter(fs);
            foreach (Student student in students)
            {
                bw.Write(student.id);
                bw.Write(student.StudentName);
                bw.Write(student.Age);
            }

            bw.Flush();
            bw.Close();
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.StackTrace);
        }
    }

    public static void ReadBinaryFile(string filePath)
    {
        try
        {
            FileStream fs = new FileStream(filePath, FileMode.Open);

            BinaryReader br = new BinaryReader(fs);
            while (br.BaseStream.Position < br.BaseStream.Length)
            {
                int id = br.ReadInt32();
                string studentName = br.ReadString();
                int age = br.ReadInt32();
                Console.WriteLine($"id: {id}, name: {studentName}, age: {age}");
            }
            br.Close();
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.StackTrace);
        }
    }
}
