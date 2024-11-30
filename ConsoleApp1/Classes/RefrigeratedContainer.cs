using System.ComponentModel;

public class RefrigeratedContainer : BaseContainer
{
    public string ProductType { get; private set; }
    public double ProductTemperature { get; private set; }
    public double Temperature { get; private set; }

    public RefrigeratedContainer(double maxPayload, double tareWeight, double height, double depth, string productType, double productTemperature, double temperature)
        : base("C", maxPayload, tareWeight, height, depth)
    {
        ProductType = productType;
        ProductTemperature = productTemperature;
        SetTemperature(temperature);
    }

    public void SetTemperature(double requiredTemperature)
    {
        if (requiredTemperature < ProductTemperature)
            throw new InvalidOperationException($"Temperature {requiredTemperature}°C is too low for the product '{ProductType}'. Minimum required is {ProductTemperature}°C.");
        Temperature = requiredTemperature;
    }
}
