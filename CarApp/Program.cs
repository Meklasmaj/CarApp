namespace CarApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Car> _cars = new List<Car> { new Car("Mazda", "3", 2017, 'm', 180000, 'b', true, 19.7) };

            while (true)
            {
                Console.WriteLine("______________________________________");
                Console.WriteLine("|                                    |");
                Console.WriteLine("|                 MENU               |");
                Console.WriteLine("|____________________________________|\n");
                Console.WriteLine("1: Indtast biloplysninger (Anbefalet)");
                Console.WriteLine("2: Beregn pris på en køretur");
                Console.WriteLine("3: Er kilometertallet palindrom?");
                Console.WriteLine("4: Udskriv alle biloplysninger\n");
                Console.WriteLine("5: Luk Programmet\n");

                int answer = Convert.ToInt32(Console.ReadLine());

                switch (answer)
                {
                    case 1:
                        Console.Clear();
                        ReadCarDetails();
                        break;
                    case 2:
                        Console.WriteLine("Hvor langt skal du køre?");
                        double distance = Convert.ToDouble(Console.ReadLine());
                        _cars[0].Drive(distance);
                        Console.Clear();
                        break;
                    case 3:
                        Console.Clear();
                        if (_cars[0].IsPalindrome()){
                            Console.WriteLine("Den er palindrom");
                        } else Console.WriteLine("Den er ikke palindrom");
                            break;
                    case 4:
                        Console.Clear();
                        PrintAllTeamCars();
                        break;
                    case 5:
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
                char _fuelType;
                bool _isEngineOn;
                double _kmPerLiter;
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
                Console.WriteLine("Indtast brændstoftype b/d/e:");
                _fuelType = Console.ReadLine()[0];
                Console.WriteLine("Er bilen tændt?: y/n");
                char answer = Console.ReadLine()[0];
                if (answer == 'y')
                {
                    _isEngineOn = true;
                }
                else _isEngineOn = false;
                Console.WriteLine("Indtast Kilometer per liter:");
                _kmPerLiter = Convert.ToDouble(Console.ReadLine());

                _cars.Add(new Car(_brand, _model, _year, _gear, _odometer, _fuelType, _isEngineOn, _kmPerLiter));
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
                    _cars[i].GetCarDetails();
                }
            }
        }
    }
}