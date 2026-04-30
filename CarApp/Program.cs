using CarApp.Core.Models;
using CarApp.Core.Persistence;

namespace CarApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // ICarRepository repo = new InMemoryCarRepoistory();
            ICarRepository repo = new FileCarRepository("cars.txt");

            try
            {
                repo.Add(new FuelCar("Toyota", "Corolla", 2022, "AB12345", 50, 18, 45000));
                repo.Add(new ElectricCar("Tesla", "Model 3", 2023, "CD67890", 75, 6.5, 380000));
            } catch(Exception ex) {
                Console.WriteLine(ex.StackTrace);

            }
            // Hent alle og udskriv

            foreach (Car car in repo.GetAll())
                Console.WriteLine($"{car._brand} {car._model} — {car._licensePlate}");

            //// Hent en specifik bil
            //Car found = repo.GetByLicensePlate("AB12345");
            //Console.WriteLine(found != null ? $"Fundet: {found._brand}" : "Ikke fundet");

            //// Opdater en bil og verificer
            //repo.Update(new FuelCar("Suzuki", "Swift", 2019, "AB12345", 40, 21, 44000));
            //Car found2 = repo.GetByLicensePlate("AB12345");
            //Console.WriteLine(found2 != null ? $"Fundet: {found2._brand}" : "Ikke fundet");

            //repo.Update(new ElectricCar("Nissan", "Leaf", 2020, "XE60890", 40, 5.5, 100000));

            //// Slet en bil og verificer
            //repo.Delete("CD67890");
            //Console.WriteLine($"Antal biler: {repo.GetAll().Count()}"); // 1


            //DataHandler handler = new DataHandler("cars.txt");
            //List<Car> _cars = new List<Car>();

            ////Load File
            //if (File.Exists("cars.txt"))
            //{
            //    _cars = handler.LoadCarsFromFile();
            //}

            ////Work with data
            //_cars.Add(new FuelCar("Mazda", "3", 2017, "CN45986", 180000, 19.7, 50, true, FuelType.Benzin, 90000));
            //_cars.Add(new ElectricCar("Tesla", "3", 2017, "BP49999", 90000, 6, 65, true, FuelType.Electric, 190000));
            //foreach (Car car in _cars)
            //{
            //    Console.WriteLine(car.GetCarDetails());
            //}
            //Console.ReadLine();

            ////Save file
            //handler.SaveCarsToFile(_cars);


            //List<Car> _cars = new List<Car> { new FuelCar("Mazda", "3", 2017, "CN45986", 180000, 19.7, 50, true, FuelType.Benzin, 90000), new ElectricCar("Tesla", "3", 2017, "BP49999", 90000, 6, 65, true, FuelType.Electric, 190000) };
            // List<ISellable> _ForSale = new List<ISellable>();
            // List<IInsurable> _Insured = new List<IInsurable>();
            // FuelCar fc = new FuelCar("Mazda", "3", 2017, "CN45986", 180000, 19.7, 50, true, FuelType.Benzin, 90000);
            // ElectricCar ec = new ElectricCar("Tesla", "3", 2017, "BP49999", 90000, 6, 65, true, FuelType.Electric, 190000);
            // House h = new House("Strandvejen 42, 2900 Hellerup", 1965, 4200000, "1234-AB");
            //
            // _ForSale.Add(h);
            // _Insured.Add(h);
            // _ForSale.Add(fc);
            // _Insured.Add(fc);
            // _ForSale.Add(ec);
            // _Insured.Add(ec);
            // double total = 0;
            // foreach (IInsurable i in _Insured)
            // {
            //     
            //         Console.WriteLine($"Forsikringsrate for {i.RegistrationNumber}: {i.GetInsuranceRate():F2}%");
            //     
            // }
            // foreach (ISellable s in _ForSale)
            // {
            //     
            //         
            //         Console.WriteLine(s.GetInformation());
            //         total += s.Price;
            //         
            //     
            // }
            // Console.WriteLine($"Samlet Beholdningsværdi: {total:N0} Dkk");
            // while (true)
            // {
            //     Console.WriteLine("______________________________________");
            //     Console.WriteLine("|                                    |");
            //     Console.WriteLine("|                 MENU               |");
            //     Console.WriteLine("|____________________________________|\n");
            //     Console.WriteLine("1: Indtast biloplysninger (Anbefalet)");
            //     Console.WriteLine("2: Indtast ny køretur");
            //     Console.WriteLine("3: Beregn pris på køretur");
            //     Console.WriteLine("4: Er kilometertallet palindrom?");
            //     Console.WriteLine("5: Udskriv alle biloplysninger\n");
            //     Console.WriteLine("6: Luk Programmet\n");
            //
            //     int answer = Convert.ToInt32(Console.ReadLine());
            //
            //     switch (answer)
            //     {
            //         case 1:
            //             ReadCarDetails();
            //             break;
            //         case 2:
            //             ReadTripDetails();
            //             break;
            //         case 3:
            //             _cars[0].Drive(_cars[0].GetTrips()[0]);
            //             break;
            //         case 4:
            //             if (_cars[0].IsPalindrome()){
            //                 Console.WriteLine("Den er palindrom");
            //             } else Console.WriteLine("Den er ikke palindrom");
            //                 break;
            //         case 5:
            //             PrintAllTeamCars();
            //             break;
            //         case 6:
            //             _cars[0].ToggleEngine();
            //             break;
            //         case 7:
            //             Environment.Exit(0);
            //             break;
            //     }
            //
            //     Console.WriteLine("\nTryk enter igen for at gå videre!\n");
            //     Console.ReadLine();
        }

            // void ReadCarDetails()
            // {
            //     string _brand;
            //     string _model;
            //     int _year;
            //     char _gear;
            //     int _odometer;
            //     char fuelType;
            //     double usage;
            //     FuelType _fuelType;
            //     double capacity;
            //     string ignition;
            //
            //     Console.Clear();
            //     Console.WriteLine("Indtast bilmærke:");
            //     _brand = Console.ReadLine();
            //
            //     Console.WriteLine("Indtast bilmodel:");
            //     _model = Console.ReadLine();
            //
            //     Console.WriteLine("Indtast bilens årgang:");
            //     _year = Convert.ToInt32(Console.ReadLine());
            //
            //     Console.WriteLine("Indtast geartype m/a:");
            //     _gear = Console.ReadLine()[0];
            //
            //     Console.WriteLine("Indtast bilens kilometer kørt:");
            //     _odometer = Convert.ToInt32(Console.ReadLine());
            //
            //     Console.WriteLine("Indtast brændstoftype b/d/e/h:");
            //     fuelType = Console.ReadLine()[0];
            //
            //     switch (fuelType)
            //     {
            //         case 'b':
            //             _fuelType = FuelType.Benzin;
            //             break;
            //         case 'd':
            //             _fuelType = FuelType.Diesel;
            //             break;
            //         case 'e':
            //             _fuelType = FuelType.Electric;
            //             break;
            //         case 'h':
            //             _fuelType = FuelType.Hybrid;
            //             break;
            //         default:
            //             _fuelType = FuelType.Benzin;
            //             break;
            //     }
            //     Console.WriteLine("Indtast Kilometer per liter/kwH:");
            //     usage = Convert.ToDouble(Console.ReadLine());
            //
            //     Console.WriteLine("Indtast tank/batteri størrelse:");
            //     capacity = Convert.ToDouble(Console.ReadLine());
            //
            //     Console.WriteLine("Er bilen tændt (ja/nej)? ");
            //     ignition = Console.ReadLine().ToLower();
            //     bool IsEngineOn = false;
            //
            //     if (ignition == "ja")
            //     {
            //         IsEngineOn = true;
            //     }

                //_cars.Add(new Car(_brand, _model, _year, _gear, _odometer, _fuelType, _kmPerLiter));
            //}

            // void PrintAllTeamCars()
            // {
            //     string brandLabel = "Bilmærke".PadRight(12);
            //     string modelLabel = "Model".PadRight(12);
            //     string yearLabel = "Årgang".PadRight(12);
            //     string kmLabel = "Kilometertal";
            //     Console.WriteLine($"{brandLabel}|{modelLabel}|{yearLabel}|{kmLabel}");
            //     Console.WriteLine("-----------------------------------------------------");
            //     for (int i = 0; i < _cars.Count; i++)
            //     {
            //         Console.WriteLine(_cars[i].GetCarDetails());
            //     }
            // }
            //
            // void ReadTripDetails()
            // {
            //     Console.Clear();
            //     Console.WriteLine("Hvilken time startede turen?:");
            //     DateTime _startTime = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, Convert.ToInt32(Console.ReadLine()), 0, 0);
            //
            //     Console.WriteLine("Hvilken time sluttede turen?:");
            //     DateTime _endTime = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, Convert.ToInt32(Console.ReadLine()), 0, 0);
            //
            //     Console.WriteLine("Indtast tur nummer:");
            //     int _id = Convert.ToInt32(Console.ReadLine());
            //
            //     Console.WriteLine("Indtast længden på turen i km:");
            //     double _distance = Convert.ToDouble(Console.ReadLine());
            //
            //     Console.WriteLine("Hvilken nummer bil kørte du i:");
            //     int _carId = Convert.ToInt32(Console.ReadLine());
            //     _cars[_carId - 1].AddTrip(_startTime, _endTime, _id, _distance);
            // }
        }
    }
//}