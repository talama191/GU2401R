
public class Vehicle
{
    protected int wheelCount;
    protected double weight;

    public int WheelCount => wheelCount;
    public double Weight => weight;
}

public class Car : Vehicle
{
    public Car()
    {
        wheelCount = 4;
        weight = 1000;
    }
}

public class Motorbike : Vehicle
{
    public Motorbike(int wheelCount)
    {
        this.wheelCount = wheelCount;
        weight = 300;
    }
}
