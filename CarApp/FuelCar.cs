using System.Xml.Linq;

namespace CarApp;

public class FuelCar : Car, ISellable, IInsurable
{
    private FuelType _fuelType;
    public double FuelLevel { get; private set; }
    public double Price { get; private set; }
    public string RegistrationNumber => _licensePlate;
    private bool Ignition;

    public FuelCar(string brand, string model, int year, string licensePlate, double capacity, double usage, double pris) : base(brand, model, year, licensePlate, 0, usage, capacity, false)
    {
        _fuelType = FuelType.Benzin;
        FuelLevel = capacity;
        Price = pris;
        Ignition = false;
    }

    public FuelCar(string brand, string model, int year, string licensePlate, int odometer, double usage, double capacity,
        bool ignition, FuelType fuelType, double price) : base(brand, model, year, licensePlate, odometer, usage, capacity, ignition)
    {
        _fuelType = fuelType;
        FuelLevel = capacity;
        Price = price;
        Ignition = ignition;
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
    public double GetInsuranceRate()
    {
        double insuranceRate = 0.06 ;
        if (_year < DateTime.Now.Year - 10)
        {
            insuranceRate *= 1.2; // Ældre biler har højere forsikringsrate
        }
        return insuranceRate;
    }
    public string GetInformation()
    {
        string Information = String.Format("{0}|{1}|{2}|{3}km|{4}|{5}|{6}", _brand.PadRight(12),
            _model.PadRight(12), _year.ToString().PadRight(12), _odometer.ToString().PadRight(12), Usage.ToString().PadRight(12), _fuelType.ToString().PadRight(12),Price.ToString().PadRight(12));
        return Information;
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

    public override string ToString()
    {
        return $"{_fuelType}|{_brand}|{_model}|{_year}|{_licensePlate}|{Usage}|{Capacity}|{Price}";
        // return $"{_fuelType},{_brand},{_model},{_year},{_licensePlate},{_odometer},{Usage},{Capacity},{Ignition},{Price}";
    }

    public static FuelCar FromString(string data)
    {
        string[] parts = data.Split('|');
        FuelType fuelType = (FuelType)Enum.Parse(typeof(FuelType), parts[0]);
        string brand = parts[1];
        string model = parts[2];
        int year = int.Parse(parts[3]);
        string licensePlate = parts[4];
        double capacity = double.Parse(parts[5]);
        double usage = double.Parse(parts[6]);
        double price = double.Parse(parts[7]);
        return new FuelCar(brand, model, year, licensePlate, capacity, usage, price);
        //int odometer = int.Parse(parts[5]);
        //double usage = double.Parse(parts[6]);
        //double capacity = double.Parse(parts[7]);
        //bool ignition = bool.Parse(parts[8]);
        //double price = double.Parse(parts[9]);
        //return new FuelCar(brand, model, year, licensePlate, odometer, usage, capacity, ignition, fuelType, price);
    }
}