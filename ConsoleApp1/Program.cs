class Program
{
    static void Main(string[] args)
    {
        try
        {
            var ship1 = new ContainerShip("Poseidon", 20, 5, 500000);
            var ship2 = new ContainerShip("Hercules", 25, 3, 300000);

            var refrigeratedContainer = new RefrigeratedContainer(20000, 5000, 240, 120, "Bananas", -18, -15);
            var liquidContainer = new LiquidContainer(30000, 8000, 260, 140, true);
            var gasContainer = new GasContainer(15000, 4000, 220, 110, 5);

            refrigeratedContainer.LoadCargo(15000);
            liquidContainer.LoadCargo(10000);
            gasContainer.LoadCargo(7000);

            ship1.LoadContainer(refrigeratedContainer);
            ship1.LoadContainer(liquidContainer);

            ship1.PrintShipInfo();
            ship1.PrintContainerInfo(refrigeratedContainer.SerialNumber);

            ship1.UnloadContainer(liquidContainer.SerialNumber);
            ship1.PrintShipInfo();

            ship1.LoadContainer(liquidContainer);
            ship1.ReplaceContainer(liquidContainer.SerialNumber, gasContainer);
            ship1.PrintShipInfo();

            ship1.TransferContainer(ship2, gasContainer.SerialNumber);
            ship2.PrintShipInfo();
            ship1.PrintShipInfo();
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}
