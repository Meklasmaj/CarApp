namespace CarApp;

public class ElectricCar : Car
{
    private FuelType _fuelType;
    private double BatteryLevel;

    public ElectricCar(string brand, string model, int year, string licensePlate, int odometer, double usage, double capacity,
        bool ignition, FuelType fuelType) : base(brand, model, year, licensePlate, odometer, usage, capacity, ignition)
    {
        _fuelType = fuelType;
        BatteryLevel = capacity;
    }
    public override FuelType GetFuelType()
    {
        return _fuelType;
    }

    public override void UpdateEnergyLevel(double km)
    {
        BatteryLevel -= km / Usage;
    }

    public override double GetEnergyLevel()
    {
        return BatteryLevel;
    }

    public void Charge(double kwH)
    {
        BatteryLevel = Capacity;
    }
}