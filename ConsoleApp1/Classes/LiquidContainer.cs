public class LiquidContainer : BaseContainer, IHazardNotifier
{

    public bool IsHazardous { get; private set; }

    public LiquidContainer(double maxPayload, double tareWeight, double height, double depth, bool isHazardous)
        : base("L", maxPayload, tareWeight, height, depth)
    {
        IsHazardous = isHazardous;
    }

    public void NotifyHazard(string message)
    {
        Console.WriteLine($"Hazard Alert: {message} in container {SerialNumber}");
    }

    public override void LoadCargo(double mass)
    {
        if (IsHazardous && CargoMass + mass > MaxPayload * 0.5)
            throw new OverfillException($"OverfillException: Cannot load {mass}kg into hazardous container {SerialNumber}. Max allowed is 50% of capacity.");
        if (!IsHazardous && CargoMass + mass > MaxPayload * 0.9)
            throw new OverfillException($"OverfillException: Cannot load {mass}kg into non-hazardous container {SerialNumber}. Max allowed is 90% of capacity.");
        base.LoadCargo(mass);
    }
}
