using System.Reflection;

namespace CarApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<String> brandList = ["Nissan", "Ford", "Ford", "Audi"];
            List<String> modelList = ["Qashqai", "DMax", "SMax", "A4"];
            List<String> fuelTypeList = ["diesel", "benzin", "benzin", "benzin"];
            List<int> yearList = [2014, 2015, 2014, 2001];
            List<int> odometerList = [150000, 166000, 260000, 440000];
            double benzinPrice = 13.39;
            double dieselPrice = 12.29;

            ReadCarDetails(brandList, modelList, yearList, odometerList);

            // Ending
            Console.Clear();

            PrintCarDetails(brandList, modelList, yearList, odometerList);

            Console.ReadLine();

            
        }
        static void ReadCarDetails(List<String> brands, List<String> models, List<int> years, List<int> odometers)
        {
            Console.Clear();
            Console.WriteLine("Indtast bilmærke:");
            brands.Add(Console.ReadLine());
            Console.WriteLine("Indtast bilmodel:");
            models.Add(Console.ReadLine());
            Console.WriteLine("Indtast bilens årgang:");
            years.Add(Convert.ToInt32(Console.ReadLine()));
            Console.WriteLine("Indtast bilens kilometer kørt:");
            odometers.Add(Convert.ToInt32(Console.ReadLine()));
        }

        void Drive(double distance, List<String> fuelTypes, List<int> odometers, double benzinPrice, double dieselPrice)
        {
            Console.WriteLine("Er bilen tændt? y/n:");
            char answer = Console.ReadLine().ToLower()[0];

            if (answer == 'y')
            {
                Console.WriteLine("Kører du på Benzin eller Diesel?:");
                string fuelType = Console.ReadLine().ToLower();
                fuelTypes.Add(fuelType);
                Console.WriteLine("Hvor langt kører den på literen?:");
                double kmPrL = Convert.ToDouble(Console.ReadLine());
                if (fuelType == "benzin")
                {
                    Console.WriteLine($"Du kører {fuelType.ToUpper()} og prisen pr/l er {benzinPrice}, det koster dig {CalculateTripPrice(distance, benzinPrice, kmPrL)}kr for at køre turen.");
                }
                else if (fuelType == "diesel")
                {
                    Console.WriteLine($"Du kører {fuelType.ToUpper()} og prisen pr/l er {dieselPrice}, det koster dig {CalculateTripPrice(distance, dieselPrice, kmPrL)}kr for at køre turen.");
                }
                else
                {
                    Console.WriteLine("El? Virkelig?");
                }
                Console.WriteLine($"Bilen er tændt og du kører en tur på {distance.ToString()}km");
                odometers[odometers.Count - 1] += Convert.ToInt32(Math.Round(distance));
            }
            else
            {
                Console.WriteLine("Motoren er ikke tændt, prøv igen senere eller tilkald vejhjælp");
            }

            Console.ReadLine();
        }

        static double CalculateTripPrice(double distance, double literPrice, double kmPrL)
        {
            double tripCost = 0;
            tripCost = distance / kmPrL * literPrice;
            return tripCost;
        }

        static bool IsPalindrome(int km)
        {
            string reverse = new string(km.ToString().Reverse().ToArray());
            if (km.ToString() == reverse)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        static void PrintCarDetails(List<String> brands, List<String> models, List<int> years, List<int> odometers)
        {
            string brandLabel = "Bilmærke".PadRight(12);
            string modelLabel = "Model".PadRight(12);
            string yearLabel = "Årgang".PadRight(12);
            string kmLabel = "Kilometertal";
            Console.WriteLine($"{brandLabel}|{modelLabel}|{yearLabel}|{kmLabel}");
            Console.WriteLine("---------------------------------------");
            string carInfo = String.Format("{0}|{1}|{2:F0}km", brands[brands.Count - 1].PadRight(12),
                models[models.Count - 1].PadRight(12), years[years.Count - 1].ToString().PadRight(12), odometers[odometers.Count - 1]);
            Console.WriteLine(carInfo);
        }
    }
}
