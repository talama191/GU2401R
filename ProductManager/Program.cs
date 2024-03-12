
public class Program
{
    static void Main(string[] args)
    {
        string saveFilePath = "E:\\Teaching\\Lop 2\\ProductManager\\products.txt";

        List<Product> products = BinaryUtils.ReadBinaryFile(saveFilePath);

        bool isProgramRunning = true;
        while (isProgramRunning)
        {
            PrintInfo();
            bool getInputFailed = true;
            int input = 1;
            while (getInputFailed)
            {
                try
                {
                    input = int.Parse(Console.ReadLine());
                    getInputFailed = false;
                }
                catch (Exception ex)
                {

                }
            }
            switch (input)
            {
                case 1:
                    Console.Clear();
                    DisplayProducts(products);
                    break;
                case 2:
                    Console.WriteLine("Chon ten san pham can tim");
                    string nameToFind = Console.ReadLine();
                    List<Product> results = FindProductByName(products, nameToFind);
                    if (results.Count == 0) Console.WriteLine("Khong tim thay san pham");
                    Console.Clear();
                    DisplayProducts(results);
                    break;
                case 3:
                    Console.WriteLine("Nhap thong tin san pham can them");
                    string productId = Console.ReadLine();
                    string productName = Console.ReadLine();
                    string brand = Console.ReadLine();
                    double price = 0;
                    try
                    {
                        price = int.Parse(Console.ReadLine());
                    }
                    catch (Exception ex)
                    {

                    }
                    string description = Console.ReadLine();
                    products.Add(new Product(productId, productName, brand, price, description));
                    BinaryUtils.WriteToBinary(products, saveFilePath);
                    break;
                case 0:
                    isProgramRunning = false;
                    break;
                default:
                    Console.Clear();
                    DisplayProducts(products);
                    break;
            }
            Console.ReadLine();
        }
    }

    private static void PrintInfo()
    {
        Console.WriteLine("Chuong trinh quan ly san pham");
        Console.WriteLine("1. Hien thi danh sach");
        Console.WriteLine("2. Tim kiem san pham");
        Console.WriteLine("3. Them san pham");
        Console.WriteLine("0. Thoat chuong trinh");
    }

    public static void DisplayProducts(List<Product> products)
    {
        Console.WriteLine("ID    Name    Brand   Price Description");
        foreach (Product product in products)
        {
            Console.WriteLine($"{product.Id.PadRight(3)}   {product.Name.PadRight(8)}  {product.Brand.PadRight(8)}   {product.Price.ToString().PadRight(6)}   {product.Description}");
        }
    }

    public static List<Product> FindProductByName(List<Product> products, string name)
    {
        List<Product> result = new List<Product>();
        foreach (Product product in products)
        {
            if (product.Name.ToUpper().Contains(name.ToUpper()))
            {
                result.Add(product);
            }
        }

        return result;
    }
}
