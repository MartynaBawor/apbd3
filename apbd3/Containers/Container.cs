

using System;

public class Container : IContainer
{
    public double CargoWeight { get; set; }
    public double Height { get; set; }
    public double Weight { get; set; }
    public double Depth { get; set; }
    public double MaxCargoWeight { get; set; }
    public string SerialNumber { get; set; }

    public Container(double cargoWeight, double height, double weight, double depth, double maxCargoWeight)
    {
        CargoWeight = cargoWeight;
        Height = height;
        Weight = weight;
        Depth = depth;
        MaxCargoWeight = maxCargoWeight;
    }

    public virtual void Unload()
    {
        throw new NotImplementedException();
    }

    public virtual void Load(double cargoWeight)
    {
        throw new NotImplementedException();
    }
}