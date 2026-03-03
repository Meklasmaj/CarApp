namespace CarApp
{
    internal class Car
    {
        public List<Fuel> fuels = new List<Fuel> { new Fuel('b', 13.47), new Fuel('d', 12.47), new Fuel('e', 3) };

        private string _brand;
        private string _model;
        private int _year;
        private char _gear;
        private int _odometer;
        private char _fuelType;
        private bool _isEngineOn;
        private double _kmPerLiter;
        private double _literPrice;

        public Car(string brand, string model, int year, char gear, int odometer, char fuelType, bool isEngineOn, double kmPerLiter)
        {
            _brand = brand;
            _model = model;
            _year = year;
            _gear = gear;
            _odometer = odometer;
            _fuelType = fuelType;
            _isEngineOn = isEngineOn;
            _kmPerLiter = kmPerLiter;
            _literPrice = fuels.Find(f => f._type == _fuelType)._price;
        }


        public void Drive(double distance)
        {
            if (_isEngineOn)
            {
                Console.WriteLine($"Du kører {_fuelType.ToString().ToUpper()} og prisen pr/l er {_literPrice.ToString()}, det koster dig {CalculateTripPrice(distance):F0}kr for at køre turen.");
                Console.WriteLine($"Bilen er tændt og du kører en tur på {distance.ToString()}km");
                _odometer += Convert.ToInt32(Math.Round(distance));
            }
            else
            {
                Console.WriteLine("Motoren er ikke tændt, prøv igen senere eller tilkald vejhjælp");
            }
        }

        public double CalculateTripPrice(double distance)
        {
            double tripCost = 0;
            tripCost = distance / _kmPerLiter * _literPrice;
            return tripCost;
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

        public void GetCarDetails()
        {
            string carInfo = String.Format("{0}|{1}|{2:F0}km", _brand.PadRight(12),
                _model.PadRight(12), _year.ToString().PadRight(12), _odometer.ToString());
            Console.WriteLine(carInfo);
        }
    }
}