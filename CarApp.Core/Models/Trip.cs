namespace CarApp.Core.Models;

public class Trip
{
    public DateTime Date { get; private set; }
    public DateTime Start {  get; private set; }
    public DateTime End { get; private set; }
    public int Id { get; private set; }
    public double Distance { get; private set; }
    public Car Car { get; private set; }

    public Trip(DateTime date, DateTime startTime, DateTime endTime, int id, double distance, Car car)
    {
        Date = date.Date;
        Start = startTime;
        End = endTime;
        Id = id;
        Distance = distance;
        Car = car;
    }

    public double CalculateEnergyUsage()
    {
        return Distance / Car.Usage;
    }

    public double CalculateTripPrice()
    {
        switch (Car.GetFuelType())
        {
            case FuelType.Benzin:
                return CalculateEnergyUsage() * 13.47;
            case FuelType.Diesel:
                return CalculateEnergyUsage() * 12.47;
            case FuelType.Electric:
                return CalculateEnergyUsage() * 4;
            case FuelType.Hybrid:
                return CalculateEnergyUsage() * 7.47;
            default:
                return CalculateEnergyUsage() * 13.47;
        } 
    }

    public TimeSpan CalculateDuration()
    {
        return End - Start;
    }

    public string GetTripDetails()
    {
        return $"Turen d. {Date}, med id: {Id}, som har en tid på {CalculateDuration().Hours.ToString()} timer. Turen var {Distance:F0}km lang, turen kostede {CalculateTripPrice().ToString("F2")}kr. EnergyLevel: {Car.GetEnergyLevel():F2} / {Car.Capacity}.";
    }
}
