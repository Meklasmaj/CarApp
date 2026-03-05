namespace CarApp
{
    internal class Trip
    {
        public DateTime Date { get; private set; }
        public DateTime Start {  get; private set; }
        public DateTime End { get; private set; }
        public int Id { get; private set; }
        public double Distance { get; private set; }
        public Car Car { get; private set; }

        public Trip(DateTime date, DateTime startTime, DateTime endTime, int id, double distance, Car car)
        {
            Date = date;
            Start = startTime;
            End = endTime;
            Id = id;
            Distance = distance;
            Car = car;
        }

        public double CalculateFuelUsed()
        {
            return Distance / Car.KmPerLiter;
        }

        public double CalculateTripPrice()
        {
            switch (Car.FuelType)
            {
                case FuelType.Benzin:
                    return CalculateFuelUsed() * 13.47;
                case FuelType.Diesel:
                    return CalculateFuelUsed() * 12.47;
                case FuelType.Electric:
                    return CalculateFuelUsed() * 4;
                case FuelType.Hybrid:
                    return CalculateFuelUsed() * 7.47;
                default:
                    return CalculateFuelUsed() * 13.47;
            } 
        }

        public TimeSpan CalculateDuration()
        {
            return End - Start;
        }

        public string GetTripDetails()
        {
            return $"Turen d. {Date}, med id: {Id}, som har en tid på {CalculateDuration().Hours.ToString()} timer. Turen var {Distance:F0}km lang, turen kostede {CalculateTripPrice().ToString("F2")}kr.";
        }
    }
}
