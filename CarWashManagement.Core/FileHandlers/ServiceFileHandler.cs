using CarWashManagement.Core.Enums;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarWashManagement.Core.FileHandlers
{
    // File handler class for managing service data in services.txt file.
    public class ServiceFileHandler : IFileHandler<Service>
    {
        private readonly string filePath = FilePathManager.ServicesFilePath;

        // Method to get all services from the services.txt file.
        public List<Service> Load()
        {
            List<Service> services = new List<Service>();
            
            if (!File.Exists(filePath))
            {
                return services;
            }

            string[] lines = File.ReadAllLines(filePath);
            
            foreach (string line in lines)
            {
                try
                {
                    string[] parts = line.Split('|');

                    if (parts.Length == 4)
                    {
                        Service service = new Service
                        {
                            Name = parts[0],
                            Fee = decimal.Parse(parts[1]),
                            // Convert string in file to Enum ServicePricingType.
                            PricingType = (ServicePricingType)Enum.Parse(typeof(ServicePricingType), parts[2]),
                            Multiplier = int.Parse(parts[3])
                        };
                        services.Add(service);
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error parsing service file line: {line}. Error: {ex.Message}");
                }
            }
            return services;
        }

        // Method to save a list of services to the services.txt file.
        public void Save(List<Service> services)
        {
            List<string> lines = new List<string>();

            foreach (Service service in services)
            {
                string line = string.Join("|",
                    service.Name,
                    service.Fee.ToString(),
                    service.PricingType.ToString(),
                    service.Multiplier.ToString()
                );
                lines.Add(line);
            }
            File.WriteAllLines(filePath, lines);
        }
    }
}
