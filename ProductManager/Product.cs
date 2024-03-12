
public class Product
{
    private string _id;
    private string _name;
    private string _brand;
    private double _price;
    private string _description;

    public string Id => _id;
    public string Name => _name;
    public string Brand => _brand;
    public double Price => _price;
    public string Description => _description;

    public Product(string id, string name, string brand, double price, string description)
    {
        _id = id;
        _name = name;
        _brand = brand;
        _price = price;
        _description = description;
    }
}
