namespace CarApp;

public class FuelCar : Car
{
    private FuelType _fuelType;

    public FuelCar(string brand, string model, int year, string licensePlate, int odometer, double usage,
        FuelType fuelType) : base(brand, model, year, licensePlate, odometer, usage)
    {
        _fuelType = fuelType;
    }
    public override FuelType GetFuelType()
    {
        return _fuelType;
    }
}