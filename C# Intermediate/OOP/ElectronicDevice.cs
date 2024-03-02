
public abstract class ElectronicDevice
{
    protected string brand;

    public string Brand => brand;

    public abstract void Ringtone();
}

public class AndroidPhone : ElectronicDevice
{
    public AndroidPhone()
    {
        brand = "dfs";
    }

    public override void Ringtone()
    {

    }
}

public class Iphone : ElectronicDevice
{
    public override void Ringtone()
    {
        throw new NotImplementedException();
    }
}
