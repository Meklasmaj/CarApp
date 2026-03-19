using System.Xml.Linq;

namespace CarApp;

public class FuelCar : Car
{
    private FuelType _fuelType;
    public double FuelLevel { get; private set; }

    public FuelCar(string brand, string model, int year, string licensePlate, int odometer, double usage, double capacity,
        bool ignition, FuelType fuelType) : base(brand, model, year, licensePlate, odometer, usage, capacity, ignition)
    {
        _fuelType = fuelType;
        FuelLevel = capacity;
    }
    public override FuelType GetFuelType()
    {
        return _fuelType;
    }

    public override void UpdateEnergyLevel(double km)
    {
        FuelLevel -= km / Usage;
    }

    public override double GetEnergyLevel()
    {
        return FuelLevel;
    }

    public void Refuel(double liters)
    {
        if( FuelLevel + liters <= Capacity){
            FuelLevel += liters;
        }
        else
        {
            Console.WriteLine("Du har fyldt for meget brændstof på og nu har du ødelagt dine fine sko.");
            FuelLevel = Capacity;
        }
    }
}