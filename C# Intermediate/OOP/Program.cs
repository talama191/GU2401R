

using Part1;

public class Program
{
    static void Main(string[] args)
    {
        IShape[] shapes = new IShape[]
        {
            new Circle(3),
            new Rectangle(3,4),
            new Rectangle(4,5),
            new Circle(5)
        };
        Array.Sort(shapes);
        for (int i = 0; i < shapes.Length; i++)
        {
            Console.WriteLine($"Dien tich la {shapes[i].GetArea()}, chu vi la {shapes[i].GetPerimeter()}");
        }
        Console.ReadKey();
    }

    public static void GetBound(IShape shape)
    {

    }

    public static void BaiTapTuan06()
    {
        Random rd = new Random();
        int[] arr = new int[100000];
        for (int i = 0; i < arr.Length; i++)
        {
            arr[i] = (int)rd.NextInt64(500);
        }

        StopWatch sw = new StopWatch();
        sw.Start();
        for (int i = 0; i < arr.Length - 1; i++)
        {
            int minIndex = i;
            int minCurrent = arr[i];
            for (int j = i + 1; j < arr.Length; j++)
            {
                if (minCurrent > arr[j])
                {
                    minCurrent = arr[j];
                    minIndex = j;
                }
            }
            int temp = arr[minIndex];
            arr[minIndex] = arr[i];
            arr[i] = temp;
        }
        sw.Stop();
        Console.WriteLine("Thoi gian chay: " + sw.GetElapsedTime());

        Console.ReadKey();
    }
}
