

using System;

public class LiquidContainer : Container, IHazardNotifier
{
    public bool IsHazardous { get; set; }

    public LiquidContainer(double cargoWeight, double height, double weight, double depth, double maxCargoWeight, bool isHazardous) : base(cargoWeight, height, weight, depth, maxCargoWeight)
    {
        IsHazardous = isHazardous;
        SerialNumber = SerialGenerator.GenerateSerialNumber("L");
        double maxAllowedWeight = isHazardous ? maxCargoWeight * 0.5 : maxCargoWeight * 0.9;

        if (cargoWeight > maxAllowedWeight)
        {
            NotifyHazard($"Attempted to load {cargoWeight} into a container with serial number {SerialNumber}, which exceeds the maximum allowed weight of {maxAllowedWeight}.");
        }
    }
    
    
    
    public override void Load(double cargoWeight)
    {
        double maxAllowedWeight = IsHazardous ? MaxCargoWeight * 0.5 : MaxCargoWeight * 0.9;

        if (cargoWeight > maxAllowedWeight)
        {
            NotifyHazard($"Attempted to load {cargoWeight} into a container with serial number {SerialNumber}, which exceeds the maximum allowed weight of {maxAllowedWeight}.");
        }

        if (cargoWeight + CargoWeight > MaxCargoWeight)
        {
            throw new OverfillException("Too much weight.");
        }
        
        base.Load(cargoWeight);
    }
    public override void Unload()
    {
        Console.WriteLine($"Unloading {CargoWeight} from the container with serial number {SerialNumber}.");
        CargoWeight = 0;
    }

    public void NotifyHazard(string message)
    {
        Console.WriteLine(message);
    }
}