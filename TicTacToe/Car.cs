namespace TicTacToe
{
    public class Car
    {
        public string Name { get; private set; }
        public int WheelCount { get; private set; }
        public CarType CarType { get; private set; }

        public Car(string name, int wheelCount, CarType carType)
        {
            Name = name;
            WheelCount = wheelCount;
            CarType = carType;
        }
    }

    public enum CarType
    {
        Container,
        Truck,
        Bus
    }
}
