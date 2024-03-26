using System;
using System.Collections.Generic;

namespace apbd3
{
    public class ContainerShip
    {
        public List<Container> Containers { get; set; }
        public double MaxSpeed { get; set; }
        public int MaxContainers { get; set; }
        public double MaxWeight { get; set; }

        public ContainerShip(double maxSpeed, int maxContainers, double maxWeight)
        {
            Containers = new List<Container>();
            MaxSpeed = maxSpeed;
            MaxContainers = maxContainers;
            MaxWeight = maxWeight;
        }

        public void AddContainer(Container container)
        {
            if (Containers.Count >= MaxContainers)
            {
                throw new OverfillException("Cannot add more containers. The ship is at its maximum capacity.");
            }

            double currentWeight = 0;
            foreach (var c in Containers)
            {
                currentWeight += c.Weight;
            }

            if (currentWeight + container.Weight > MaxWeight)
            {
                throw new OverfillException("Cannot add this container. The ship would exceed its maximum weight capacity.");
            }

            Containers.Add(container);
        }
        public void ReplaceContainer(string serialNumber, Container newContainer)
        {
            var containerToReplace = Containers.Find(c => c.SerialNumber == serialNumber);

            if (containerToReplace == null)
            {
                throw new Exception($"No container found with serial number: {serialNumber}");
            }

            // Check if adding the new container would exceed the ship's weight capacity
            double currentWeight = 0;
            foreach (var c in Containers)
            {
                if (c != containerToReplace) // Don't include the weight of the container being replaced
                {
                    currentWeight += c.Weight;
                }
            }

            if (currentWeight + newContainer.Weight > MaxWeight)
            {
                throw new OverfillException("Cannot replace with this container. The ship would exceed its maximum weight capacity.");
            }

            // Replace the container
            Containers.Remove(containerToReplace);
            Containers.Add(newContainer);
        }

        public void UnloadContainer(string serialNumber)
        {
            var containerToUnload = Containers.Find(c => c.SerialNumber == serialNumber);

            if (containerToUnload == null)
            {
                throw new Exception($"No container found with serial number: {serialNumber}");
            }

            // Unload the container
            Containers.Remove(containerToUnload);
        }
    }
}