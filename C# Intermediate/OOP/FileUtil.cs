

public static class FileUtil
{
    public static void CreateFile(string filePath)
    {
        File.Create(filePath);
    }

    public static void ReadFile(string filePath)
    {
        try
        {
            FileInfo file = new FileInfo(filePath);
            if (!file.Exists)
            {
                throw new FileNotFoundException();
            }

            StreamReader reader = new StreamReader(filePath);
            string line = "";

            while ((line = reader.ReadLine()) != null)
            {
                Console.WriteLine(line);
            }
            reader.Close();
        }
        catch (Exception e)
        {
            Console.WriteLine(e.StackTrace);
        }
    }

    public static void WriteFile(string filePath)
    {
        try
        {
            //Biến file thành đối tượng FileInfo
            //Kiểm tra file tồn tại không
            //Mở luồng ghi file StreamWriter
            //Cho người dùng nhập
            //Nếu người dùng không nhập gì thì ngắt chương trình
            FileInfo file = new FileInfo(filePath);
            StreamWriter writer = new StreamWriter(filePath);

            string line = Console.ReadLine();
            while (line != "")
            {
                writer.WriteLine(line);
                line = Console.ReadLine();
            }
            writer.Flush();
            writer.Close();
        }
        catch (Exception e)
        {
            Console.WriteLine(e.StackTrace);
        }
    }

    public static void ReadCSV(string filePath)
    {
        try
        {
            StreamReader reader = new StreamReader(filePath);

            string line;

            while ((line = reader.ReadLine()) != null)
            {
                string[] datas = line.Split(',');
                Console.WriteLine(datas[5].Replace("\"", ""));
            }
        }
        catch (Exception e)
        {
            Console.WriteLine(e.StackTrace);
        }
    }
}
