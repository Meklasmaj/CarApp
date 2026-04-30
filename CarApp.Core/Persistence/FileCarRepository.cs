using System;
using System.Collections.Generic;
using System.Text;
using CarApp.Core.Models;
namespace CarApp.Core.Persistence;

public class FileCarRepository : ICarRepository
{

    public string FilePath { get; set; }

    public FileCarRepository(string filePath)
    {
        FilePath = filePath;
        if (!File.Exists(filePath))
        {
            File.Create(filePath).Close(); // Opret filen hvis den ikke findes
        }

    }

    public IEnumerable<Car> GetAll()
    {
        List<Car> cars = new List<Car>();

        // Læs alle linjer med StreamReader
        using (StreamReader reader = new StreamReader(FilePath))
        {
            string line;
            while ((line = reader.ReadLine()) != null)
            {
                if (string.IsNullOrWhiteSpace(line))
                    continue;
                
                string[] parts = line.Split('|');
                if (parts.Length > 0)
                {
                    if (parts[0] == "Benzin" || parts[0] == "Diesel")
                    {
                        // Opret en FuelCar med FuelCar.FromString(line)
                        cars.Add(FuelCar.FromString(line));
                    }
                    else if (parts[0] == "Electric")
                    {
                        // Opret en ElectricCar med ElectricCar.FromString(line)
                        cars.Add(ElectricCar.FromString(line));
                    }
                }
            }
            return cars;
        }

    }

    public Car GetByLicensePlate(string licensePlate)
    {
        // Brug GetAll() og find bilen med den givne nummerplade
        foreach (var car in GetAll())
        {
            if (car._licensePlate == licensePlate)
            {
                return car;
            }
        }
        return null;
    }

    public void Add(Car car)
    {
        List<Car> cars = GetAll().ToList();
        // Skriv car.ToString() som en ny linje med StreamWriter (append)
        using (StreamWriter writer = new StreamWriter(FilePath, true))
        {
            if (!cars.Any(c => c._licensePlate == car._licensePlate))
            {
                writer.WriteLine(car.ToString());
            }
        }
    }

    public void Update(Car car)
    {
        // Indlæs alle biler, find og erstat, skriv hele filen igen
        using(StreamWriter writer = new StreamWriter(FilePath, false)) // false for at overskrive
        {
            foreach (var existingCar in GetAll())
            {
                if (existingCar._licensePlate == car._licensePlate)
                {
                    writer.WriteLine(car.ToString()); // Skriv den opdaterede bil
                }
                else
                {
                    writer.WriteLine(existingCar.ToString()); // Skriv de andre biler uændret
                }
            }
        }
    }

    public void Delete(string licensePlate)
    {
        // Indlæs alle, fjern bilen, skriv hele filen igen
        using(StreamWriter writer = new StreamWriter(FilePath, false)) // false for at overskrive
        {
            foreach (var existingCar in GetAll())
            {
                if (existingCar._licensePlate != licensePlate)
                {
                    writer.WriteLine(existingCar.ToString()); // Skriv alle biler undtagen den der skal slettes
                }
            }
        }
    }


}
