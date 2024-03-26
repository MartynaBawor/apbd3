

using System;

public class GasContainer : Container
{
    public double Pressure { get; set; }
    
    public GasContainer(double cargoWeight, double height, double weight, double depth, double maxCargoWeight, double pressure) : base(cargoWeight, height, weight, depth, maxCargoWeight)
    {
        Pressure = pressure;
        SerialNumber = SerialGenerator.GenerateSerialNumber("G");
    }
    public override void Unload()
    {
        double remainingCargo = CargoWeight * 0.05;
        Console.WriteLine($"Unloading {CargoWeight - remainingCargo} from the container with serial number {SerialNumber}. Remaining cargo: {remainingCargo}");
        CargoWeight = remainingCargo;
    }
    public void NotifyHazard(string message)
    {
        Console.WriteLine(message);
    }
    public override void Load(double cargoWeight)
    {

        if (cargoWeight + CargoWeight > MaxCargoWeight)
        {
            throw new Exception("Cargo weight exceeds the maximum cargo weight of the container.");
        }

        base.Load(cargoWeight);
    }
    
    
    
    
}