namespace CarApp;

public class ElectricCar : Car, ISellable, IInsurable
{
    private FuelType _fuelType;
    private double BatteryLevel;
    public double Price { get; private set; }
    public string RegistrationNumber => _licensePlate;

    public ElectricCar(string brand, string model, int year, string licensePlate, int odometer, double usage, double capacity,
        bool ignition, FuelType fuelType, double price) : base(brand, model, year, licensePlate, odometer, usage, capacity, ignition)
    {
        _fuelType = fuelType;
        BatteryLevel = capacity;
        Price = price;
    }
    public override FuelType GetFuelType()
    {
        return _fuelType;
    }
    public double GetInsuranceRate()
    {
        double insuranceRate = 0.05 ;
        if (_year < DateTime.Now.Year - 10)
        {
            insuranceRate *= 1.2; // Ældre biler har højere forsikringsrate
        }
        return insuranceRate;
    }
    public string GetInformation()
    {
        string Information = String.Format("{0}|{1}|{2}|{3}km|{4}|{5}|{6}", _brand.PadRight(12),
            _model.PadRight(12), _year.ToString().PadRight(12), _odometer.ToString().PadRight(12), Usage.ToString().PadRight(12), _fuelType.ToString().PadRight(12), Price.ToString().PadRight(12));
        return Information;
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