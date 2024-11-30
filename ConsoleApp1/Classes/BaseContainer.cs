public abstract class BaseContainer
{
    private static int uniqueIdCounter = 1;

    public string SerialNumber { get; private set; }
    public double MaxPayload { get; private set; }
    public double CargoMass { get; set; }
    public double TareWeight { get; private set; }
    public double Height { get; private set; }
    public double Depth { get; private set; }

    public BaseContainer(string type, double maxPayload, double tareWeight, double height, double depth)
    {
        SerialNumber = $"KON-{type}-{uniqueIdCounter++}";
        MaxPayload = maxPayload;
        TareWeight = tareWeight;
        Height = height;
        Depth = depth;
    }


    public virtual void LoadCargo(double mass)
    {
        if (CargoMass + mass > MaxPayload)
            throw new Exception("OverfillException: Exceeds maximum payload.");

        CargoMass += mass;
    }

    public virtual void EmptyCargo()
    {
        CargoMass = 0;
    }

    public override string ToString()
    {
        return $"{SerialNumber} - Mass: {CargoMass}/{MaxPayload}, Tare: {TareWeight}, Height: {Height}, Depth: {Depth}";
    }
}
