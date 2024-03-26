

using System;

public class RefrigeratedContainer : Container
    {
        public string ProductType { get; set; }
        public double Temperature { get; set; }

        public RefrigeratedContainer(double cargoWeight, double height, double weight, double depth, double maxCargoWeight, string productType, double temperature) : base(cargoWeight, height, weight, depth, maxCargoWeight)
        {
            ProductType = productType;
            Temperature = temperature;
            SerialNumber = SerialGenerator.GenerateSerialNumber("C");
        }

        public override void Load(double cargoWeight)
        {
            if (cargoWeight + CargoWeight > MaxCargoWeight)
            {
                throw new Exception("Cargo weight exceeds the maximum cargo weight of the container.");
            }

            CargoWeight += cargoWeight;
        }

        public override void Unload()
        {
            CargoWeight = 0;
        }
        // public void SetTemperature(string productType, double temperature)
        // {
        //
        //     if (temperature < (double)PossibleProducts
        //     {
        //         throw new Exception($"Temperature too low.");
        //     }
        //
        //     Temperature = temperature;
        // }
        //
        // {
        //     if (temperature < PossibleProducts[productType])
        //     {
        //         throw new Exception($"The temperature cannot be lower than the required temperature for the product type. Required: {GetRequiredTemperature(productType)}, provided: {temperature}");
        //     }
        //
        //     Temperature = temperature;
        // }
        // {
        //     if (temperature < (double)ProductType)
        //     {
        //         throw new Exception($"The temperature cannot be lower than the required temperature for the product type. Required: {(double)ProductType}, provided: {temperature}");
        //     }
        //
        //     Temperature = temperature;
        // }
    }

