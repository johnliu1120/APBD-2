public class ContainerShip
{
    public string Name { get; private set; }
    public double MaxSpeed { get; private set; } // in knots
    public int MaxContainerCount { get; private set; }
    public double MaxWeight { get; private set; } // in tons
    private List<BaseContainer> containers;

    public ContainerShip(string name, double maxSpeed, int maxContainerCount, double maxWeight)
    {
        Name = name;
        MaxSpeed = maxSpeed;
        MaxContainerCount = maxContainerCount;
        MaxWeight = maxWeight;
        containers = new List<BaseContainer>();
    }

    public void LoadContainer(BaseContainer container)
    {
        if (containers.Count >= MaxContainerCount)
            throw new InvalidOperationException($"Cannot load container. Ship '{Name}' has reached its maximum container capacity.");
        if (GetTotalWeight() + container.TareWeight + container.CargoMass > MaxWeight)
            throw new InvalidOperationException($"Cannot load container. Ship '{Name}' exceeds its maximum weight capacity.");
        containers.Add(container);
    }

    public void LoadContainers(List<BaseContainer> containerList)
    {
        foreach (var container in containerList)
        {
            LoadContainer(container);
        }
    }

    public void UnloadContainer(string serialNumber)
    {
        var container = containers.FirstOrDefault(c => c.SerialNumber == serialNumber);
        if (container == null)
            throw new InvalidOperationException($"Container with SerialNumber '{serialNumber}' not found on ship '{Name}'.");
        containers.Remove(container);
    }

    public void ReplaceContainer(string serialNumber, BaseContainer newContainer)
    {
        var index = containers.FindIndex(c => c.SerialNumber == serialNumber);
        if (index == -1)
            throw new InvalidOperationException($"Container with SerialNumber '{serialNumber}' not found on ship '{Name}'.");
        containers[index] = newContainer;
    }

    public void TransferContainer(ContainerShip targetShip, string serialNumber)
    {
        var container = containers.FirstOrDefault(c => c.SerialNumber == serialNumber);
        if (container == null)
            throw new InvalidOperationException($"Container with SerialNumber '{serialNumber}' not found on ship '{Name}'.");
        targetShip.LoadContainer(container);
        UnloadContainer(serialNumber);
    }

    public double GetTotalWeight()
    {
        return containers.Sum(c => c.TareWeight + c.CargoMass);
    }

    public void PrintContainerInfo(string serialNumber)
    {
        var container = containers.FirstOrDefault(c => c.SerialNumber == serialNumber);
        if (container == null)
            throw new InvalidOperationException($"Container with SerialNumber '{serialNumber}' not found on ship '{Name}'.");
        Console.WriteLine(container.ToString());
    }

    public void PrintShipInfo()
    {
        Console.WriteLine($"Ship: {Name}, Speed: {MaxSpeed} knots, Containers: {containers.Count}/{MaxContainerCount}, Weight: {GetTotalWeight()}/{MaxWeight}");
        foreach (var container in containers)
        {
            Console.WriteLine(container);
        }
    }
}
