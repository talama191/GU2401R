
public static class MangVaHam
{
    public static int DemSoLanSoChanXuatHienTrongChuoi(int[] arr)
    {
        int dem = 0;
        foreach (int i in arr)
        {
            if (i % 2 == 0)
            {
                dem++;
            }
        }
        return dem;
    }

    public static int TinhTong(int[] arr1)
    {
        int sum = 0;
        foreach (int i in arr1)
        {
            sum += i;
        }
        Console.WriteLine(sum);
        return sum;
    }

    public static void BaiTap2002()
    {
        int[,] arr = { { 1, 2 }, { 3, 4 }, { 3, 4 } };

        int sum = 0;
        int max = int.MinValue;
        for (int i = 0; i < arr.GetLength(0); i++)
        {
            for (int j = 0; j < arr.GetLength(1); j++)
            {
                sum += arr[i, j];
                if (arr[i, j] > max)
                {
                    max = arr[i, j];
                }
            }
        }
        Console.WriteLine(sum);
        Console.ReadKey();
    }

    public static void ThemPhanTuVaoMang()
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
        Console.ReadKey();
    }
}