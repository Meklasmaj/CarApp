namespace CarApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Car> _cars = new List<Car> { new FuelCar("Mazda", "3", 2017, "CN45986", 180000, 19.7, FuelType.Benzin) };

            while (true)
            {
                Console.WriteLine("______________________________________");
                Console.WriteLine("|                                    |");
                Console.WriteLine("|                 MENU               |");
                Console.WriteLine("|____________________________________|\n");
                Console.WriteLine("1: Indtast biloplysninger (Anbefalet)");
                Console.WriteLine("2: Indtast ny køretur");
                Console.WriteLine("3: Beregn pris på køretur");
                Console.WriteLine("4: Er kilometertallet palindrom?");
                Console.WriteLine("5: Udskriv alle biloplysninger\n");
                Console.WriteLine("6: Luk Programmet\n");

                int answer = Convert.ToInt32(Console.ReadLine());

                switch (answer)
                {
                    case 1:
                        Console.Clear();
                        ReadCarDetails();
                        break;
                    case 2:
                        ReadTripDetails();
                        Console.Clear();
                        break;
                    case 3:
                        _cars[0].Drive(_cars[0].GetTrips()[0]);
                        Console.Clear();
                        break;
                    case 4:
                        Console.Clear();
                        if (_cars[0].IsPalindrome()){
                            Console.WriteLine("Den er palindrom");
                        } else Console.WriteLine("Den er ikke palindrom");
                            break;
                    case 5:
                        Console.Clear();
                        PrintAllTeamCars();
                        break;
                    case 6:
                        Environment.Exit(0);
                        break;
                }

                Console.WriteLine("\nTryk enter igen for at gå videre!\n");
                Console.ReadLine();
                Console.Clear();
            }

            void ReadCarDetails()
            {
                string _brand;
                string _model;
                int _year;
                char _gear;
                int _odometer;
                char fuelType;
                double _kmPerLiter;
                FuelType _fuelType;

                Console.Clear();
                Console.WriteLine("Indtast bilmærke:");
                _brand = Console.ReadLine();

                Console.WriteLine("Indtast bilmodel:");
                _model = Console.ReadLine();

                Console.WriteLine("Indtast bilens årgang:");
                _year = Convert.ToInt32(Console.ReadLine());

                Console.WriteLine("Indtast geartype m/a:");
                _gear = Console.ReadLine()[0];

                Console.WriteLine("Indtast bilens kilometer kørt:");
                _odometer = Convert.ToInt32(Console.ReadLine());

                Console.WriteLine("Indtast brændstoftype b/d/e/h:");
                fuelType = Console.ReadLine()[0];

                switch (fuelType)
                {
                    case 'b':
                        _fuelType = FuelType.Benzin;
                        break;
                    case 'd':
                        _fuelType = FuelType.Diesel;
                        break;
                    case 'e':
                        _fuelType = FuelType.Electric;
                        break;
                    case 'h':
                        _fuelType = FuelType.Hybrid;
                        break;
                    default:
                        _fuelType = FuelType.Benzin;
                        break;
                }
                Console.WriteLine("Indtast Kilometer per liter:");
                _kmPerLiter = Convert.ToDouble(Console.ReadLine());

                //_cars.Add(new Car(_brand, _model, _year, _gear, _odometer, _fuelType, _kmPerLiter));
            }

            void PrintAllTeamCars()
            {
                string brandLabel = "Bilmærke".PadRight(12);
                string modelLabel = "Model".PadRight(12);
                string yearLabel = "Årgang".PadRight(12);
                string kmLabel = "Kilometertal";
                Console.WriteLine($"{brandLabel}|{modelLabel}|{yearLabel}|{kmLabel}");
                Console.WriteLine("-----------------------------------------------------");
                for (int i = 0; i < _cars.Count; i++)
                {
                    Console.WriteLine(_cars[i].GetCarDetails());
                }
            }

            void ReadTripDetails()
            {
                Console.Clear();
                Console.WriteLine("Hvilken time startede turen?:");
                DateTime _startTime = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, Convert.ToInt32(Console.ReadLine()), 0, 0);

                Console.WriteLine("Hvilken time sluttede turen?:");
                DateTime _endTime = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, Convert.ToInt32(Console.ReadLine()), 0, 0);

                Console.WriteLine("Indtast tur nummer:");
                int _id = Convert.ToInt32(Console.ReadLine());

                Console.WriteLine("Indtast længden på turen i km:");
                double _distance = Convert.ToDouble(Console.ReadLine());

                Console.WriteLine("Hvilken nummer bil kørte du i:");
                int _carId = Convert.ToInt32(Console.ReadLine());
                _cars[_carId - 1].AddTrip(_startTime, _endTime, _id, _distance);
            }
        }
    }
}