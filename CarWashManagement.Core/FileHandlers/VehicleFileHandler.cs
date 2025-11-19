using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarWashManagement.Core.FileHandlers
{
    // File handler class for managing vehicle data in vehicles.txt file.
    public class VehicleFileHandler : IFileHandler<Vehicle>
    {
        private readonly string filePath = FilePathManager.VehiclesFilePath;

        // Method to get all vehicles from the vehicles.txt file.
        public List<Vehicle> Load()
        {
            List<Vehicle> vehicles = new List<Vehicle>();

            // Check if the vehicles.txt file exists, if not, return an empty list.
            if (!File.Exists(filePath))
            {
                return vehicles;
            }

            string[] lines = File.ReadAllLines(filePath);

            foreach (string line in lines)
            {
                try
                {
                    string[] parts = line.Split('|');

                    if (parts.Length == 4)
                    {
                        Vehicle vehicle = new Vehicle
                        {
                            Type = parts[0],
                            BaseFee = decimal.Parse(parts[1]),
                            OwnerShare = decimal.Parse(parts[2]),
                            EmployeeShare = decimal.Parse(parts[3])
                        };
                        vehicles.Add(vehicle);
                    }
                } catch (Exception ex)
                {
                    Console.WriteLine($"Error parsing vehicle file line: {line}. Error: {ex.Message}");
                }
            }
            return vehicles;
        }

        // Method to save a list of vehicles to the vehicles.txt file.
        public void Save(List<Vehicle> vehicles)
        {
            List<string> lines = new List<string>();

            foreach (Vehicle vehicle in vehicles)
            {
                string line = String.Join("|",
                    vehicle.Type,
                    vehicle.BaseFee,
                    vehicle.OwnerShare,
                    vehicle.EmployeeShare);

                lines.Add(line);
            }

            File.WriteAllLines(filePath, lines);
        }
    }
}
