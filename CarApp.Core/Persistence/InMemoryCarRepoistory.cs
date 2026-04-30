using System;
using System.Collections.Generic;
using System.Text;
using CarApp.Core.Models;
namespace CarApp.Core.Persistence;

public class InMemoryCarRepoistory : ICarRepository
{
    private readonly List<Car> _cars = new List<Car>();

    // Get all cars from the repository
    public IEnumerable<Car> GetAll()
    {
        return _cars;
    }

    // Get a car by its license plate
    public Car GetByLicensePlate(string licensePlate)
    {
        return _cars.FirstOrDefault(car => car._licensePlate == licensePlate);
    }

    // Add a new car to the repository
    public void Add(Car car) { 
        if (GetByLicensePlate(car._licensePlate) != null)
        {
            throw new InvalidOperationException("A car with the same license plate already exists.");
        }
        _cars.Add(car);
    }

    // Update an existing car in the repository
    public void Update(Car car)
    {
        Car oldCar = GetByLicensePlate(car._licensePlate);
        if (oldCar == null)
        {
            throw new InvalidOperationException("Car not found in the repository.");
        }
        int index = _cars.IndexOf(oldCar);
        _cars[index] = car;
    }

    // Delete a car from the repository by its license plate
    public void Delete(string licensePlate)
    {
        Car car = GetByLicensePlate(licensePlate);
        if (car == null)
        {
            throw new InvalidOperationException("Car not found in the repository.");
        }
        _cars.Remove(car);

    }

}
