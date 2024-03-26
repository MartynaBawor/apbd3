using System;
using apbd3;

LiquidContainer liquidContainer = new LiquidContainer(390, 20, 20, 20, 400, true);
RefrigeratedContainer refrigeratedContainer = new RefrigeratedContainer(200, 20, 20, 20, 400, "Fish", 2);
GasContainer gasContainer = new GasContainer(200, 20, 20, 20, 400, 2);
Console.WriteLine(liquidContainer.SerialNumber);
Console.WriteLine(refrigeratedContainer.SerialNumber);
Console.WriteLine(gasContainer.SerialNumber);
refrigeratedContainer.Load(30);
Console.WriteLine(refrigeratedContainer.CargoWeight);
ContainerShip containerShip = new ContainerShip(40, 20, 10000);
containerShip.AddContainer(liquidContainer);
containerShip.ReplaceContainer("KON-L-1", refrigeratedContainer);
Console.WriteLine(containerShip.Containers[0]);
containerShip.UnloadContainer("KON-C-1");