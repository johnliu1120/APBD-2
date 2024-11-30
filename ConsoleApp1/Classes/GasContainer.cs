public class GasContainer : BaseContainer, IHazardNotifier
{
    public double Pressure { get; private set; }

    public GasContainer(double maxPayload, double tareWeight, double height, double depth, double pressure)
        : base("G", maxPayload, tareWeight, height, depth)
    {
        Pressure = pressure;
    }

    public void NotifyHazard(string message)
    {
        Console.WriteLine($"Hazard Alert: {message} in container {SerialNumber}");
    }

    public override void EmptyCargo()
    {
        CargoMass *= 0.05;
    }
}
