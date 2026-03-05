using System.Security.Cryptography;

namespace CarApp
{
    internal class Car
    {
        private string _brand;
        private string _model;
        private int _year;
        private char _gear;
        private int _odometer;
        public double KmPerLiter { get; private set; }
        public FuelType FuelType { get; private set; }
        private List<Trip> _trips = new List<Trip>();


        public Car(string brand, string model, int year, char gear, int odometer, FuelType fuelType, double kmPerLiter)
        {
            _brand = brand;
            _model = model;
            _year = year;
            _gear = gear;
            _odometer = odometer;
            FuelType = fuelType;
            KmPerLiter = kmPerLiter;
        }


        public void Drive(Trip trip)
        {
            if (true)
            {
                Console.Clear();
                Console.WriteLine(trip.GetTripDetails());
                _odometer += Convert.ToInt32(Math.Round(trip.Distance));
                Console.ReadLine();
            }
            else
            {
                Console.WriteLine("Motoren er ikke tændt, prøv igen senere eller tilkald vejhjælp");
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
    }
}