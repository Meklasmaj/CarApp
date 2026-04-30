using System;
using System.Collections.Generic;
using System.Text;
using CarApp.Core.Models;
namespace CarApp.Core.Persistence;

public interface ICarRepository
{
    // Get all cars from the repository
    public IEnumerable<Car> GetAll();

    // Get a car by its license plate
    public Car GetByLicensePlate(string licensePlate);

    // Add a new car to the repository
    public void Add(Car car);

    // Update an existing car in the repository
    public void Update(Car car);

    // Delete a car from the repository by its license plate
    public void Delete(string licensePlate);

}
