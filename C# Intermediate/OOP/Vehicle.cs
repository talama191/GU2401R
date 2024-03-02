//private > protected>public

public abstract class Vehicle
{
    protected int wheelCount;
    protected double weight;
    protected double speed;

    public int WheelCount => wheelCount;
    public double Weight => weight;
    public double Speed => speed;

    public abstract string GetInfo();
}

public class Car : Vehicle
{
    private int doorCount;

    public int DoorCount => doorCount;

    public Car()
    {
        wheelCount = 4;
        weight = 1000;
        speed = 100;
    }

    public override string GetInfo()
    {
        return $"Xe o to nay co can nang la {weight} , so cua la {doorCount}";
    }
}

public class Motorbike : Vehicle
{
    public Motorbike(int wheelCount)
    {
        this.wheelCount = wheelCount;
        weight = 300;
        speed = 70;
    }

    public override string GetInfo()
    {
        return $"Xe may nay co can nang la {weight}";
    }
}
