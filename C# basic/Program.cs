
public class Program
{
    static void Main(string[] args)
    {
        int[] arr = { 1, 2, 3 };
        int[,] arr2 = { { 2, 3 }, { 3, 4 }, { 3, 7 } };
        int[,,] arr2Chieu = {
                {  { 2, 3 },{ 2, 3 }},
                {  { 2, 3 },{ 2, 3 }},
                {  { 2, 3 },{ 2, 3 }}};
        // int[,] arr3 = new int[3, 2];
        int[,] arr3 = {
            { 2, 3, 4, 6 },
            { 3, 4, 6, 2 },
            { 3, 7, 10, 2 } ,
            { 3, 4, 6, 2 },
            { 3, 7, 4, 2 }
            };
        Console.WriteLine(arr3.GetLength(1));
        for (int i = 0; i < arr3.GetLength(0); i++)
        {

        }
    }

    public void ThemPhanTuVaoMang()
    {
        int[] ar1 = { 1, 2, 3, 4, 5, 0, 0, 0, 0, 0 };
        Console.WriteLine("Array");
        foreach (int i in ar1)
        {
            Console.Write(i + ",");
        }
        Console.WriteLine();

        Console.Write("Input the insert number: ");
        int insert = Int32.Parse(Console.ReadLine());

        Console.Write("Input the index of insertion: ");
        int index = Int32.Parse(Console.ReadLine());

        int[] ar2 = new int[10];
        for (int i = 0; i < ar1.Length; i++)
        {
            if (i == index)
            {
                ar2[i] = insert;
            }
            else
            {
                if (i > index)
                {
                    ar2[i] = ar1[i - 1];
                }
                else
                {
                    ar2[i] = ar1[i];
                }
            }
        }

        Console.WriteLine("New array");
        foreach (int i in ar2)
        {
            Console.Write(i + ",");
        }
        Console.WriteLine();
    }
}