
public static class BinaryUtils
{
    public static void WriteToBinary(List<Product> products, string filePath)
    {
        try
        {
            FileStream fs = new FileStream(filePath, FileMode.Create);

            BinaryWriter bw = new BinaryWriter(fs);
            foreach (Product product in products)
            {
                bw.Write(product.Id);
                bw.Write(product.Name);
                bw.Write(product.Brand);
                bw.Write(product.Price);
                bw.Write(product.Description);
            }

            bw.Flush();
            bw.Close();
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.StackTrace);
        }
    }

    public static List<Product> ReadBinaryFile(string filePath)
    {
        List<Product> products = new List<Product>();
        try
        {
            FileStream fs = new FileStream(filePath, FileMode.Open);

            BinaryReader br = new BinaryReader(fs);
            while (br.BaseStream.Position < br.BaseStream.Length)
            {
                string id = br.ReadString();
                string productName = br.ReadString();
                string productBrand = br.ReadString();
                double productPrice = br.ReadDouble();
                string description = br.ReadString();
                products.Add(new Product(id, productName, productBrand, productPrice, description));
            }
            br.Close();
        }
        catch (Exception ex)
        {
            Console.WriteLine("Khong co file ");
        }
        return products;
    }
}
