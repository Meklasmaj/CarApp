using System.Reflection;

namespace CarApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<String> brandList = ["Nissan", "Ford", "Ford", "Audi"];
            List<String> modelList = ["Qashqai", "DMax", "SMax", "A4"];
            List<int> yearList = [2014, 2015, 2014, 2001];
            List<int> odometerList = [150000, 166000, 260000, 440000];

            ReadCarDetails();

            // Ending
            Console.Clear();

            PrintCarDetails();

            Console.ReadLine();

            void ReadCarDetails()
            {
                Console.Clear();
                Console.WriteLine("Indtast bilmærke:");
                brandList.Add(Console.ReadLine());
                Console.WriteLine("Indtast bilmodel:");
                modelList.Add(Console.ReadLine());
                Console.WriteLine("Indtast bilens årgang:");
                yearList.Add(Convert.ToInt32(Console.ReadLine()));
                Console.WriteLine("Indtast bilens kilometer kørt:");
                odometerList.Add(Convert.ToInt32(Console.ReadLine()));
            }

            static double CalculateTripPrice()
            {
                //if(fueltype == 'B')
                //{
                //    tripCost = distance / kmPrL * gasPrice;
                //}
                //else
                //{
                //    tripCost = distance / kmPrL * dieselPrice;
                //}
                double result = 0;
                return result;
            }

            void PrintCarDetails()
            {
                string brandLabel = "Bilmærke".PadRight(12);
                string modelLabel = "Model".PadRight(12);
                string yearLabel = "Årgang".PadRight(12);
                string kmLabel = "Kilometertal";
                Console.WriteLine($"{brandLabel}|{modelLabel}|{yearLabel}|{kmLabel}");
                Console.WriteLine("---------------------------------------");
                string carInfo = String.Format("{0}|{1}|{2:F0}km", brandList[brandList.Count -1].PadRight(12),
                    modelList[modelList.Count -1].PadRight(12), yearList[yearList.Count -1].ToString().PadRight(12), odometerList[odometerList.Count -1]);
                Console.WriteLine(carInfo);
            }
        }
    }
}
