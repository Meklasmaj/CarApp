using System.Security.Cryptography;

namespace CarApp
{
    public abstract class Car
    {
        private string _brand;
        private string _model;
        private int _year;
        private int _odometer;
        private string _licensePlate;
        public double Usage { get; private set; }
        private List<Trip> _trips = new List<Trip>();


        public Car(string brand, string model, int year, string licensePlate, int odometer, double usage)
        {
            _brand = brand;
            _model = model;
            _year = year;
            _licensePlate = licensePlate;
            _odometer = odometer;
            Usage = usage;
        }
        public List<Trip> GetTripsByDate(DateTime dato)
        {
            List<Trip> NewTrips = new List<Trip>();

            foreach (Trip trip in _trips)
            {
                if (trip.Date.Date == dato.Date)
                { 
                    NewTrips.Add(trip);
                }
            }
            return NewTrips;
        }

        public List<Trip> GetTripsInTimeInterval(DateTime start, DateTime end)
        {
            List<Trip> NewTrips = new List<Trip>();

            foreach (Trip trip in _trips)
            {
                if (trip.Start >= start && trip.Start <= end)
                { 
                    NewTrips.Add(trip);
                }
            }
            return NewTrips;
        }

        public void Drive(Trip trip)
        {
            if (true)
            {
                _trips.Add(trip);
                Console.WriteLine(trip.GetTripDetails());
                _odometer += Convert.ToInt32(Math.Round(trip.Distance));
            }
            else
            {
                Console.WriteLine("Motoren er ikke t�ndt, pr�v igen senere eller tilkald vejhj�lp");
            }
        }

        public bool IsPalindrome()
        {
            string reverse = "";

            for (int i = _odometer.ToString().Length; i != 0; i--)
            {
                reverse += _odometer.ToString()[i - 1];
            }

            if (_odometer.ToString() == reverse)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public string GetCarDetails()
        {
            string carInfo = String.Format("{0}|{1}|{2}|{3}km", _brand.PadRight(12),
                _model.PadRight(12), _year.ToString().PadRight(12), _odometer.ToString());
            return carInfo;
        }

        public void AddTrip(DateTime _startTime, DateTime _endTime, int _id, double _distance)
        {
            _trips.Add(new Trip(DateTime.Now, _startTime, _endTime, _id, _distance, this));
        }

        public List<Trip> GetTrips()
        {
            return _trips;
        }

        public abstract FuelType GetFuelType();
    }
}