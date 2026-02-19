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
            

            // Ending
            Console.Clear();

            

            Console.ReadLine();

            void ReadCarDetails()
            {
                Console.Clear();
                Console.WriteLine("Indtast bilmærke:");
                brandList.Append(Console.ReadLine());
                Console.WriteLine("Indtast bilmodel:");
                modelList.Append(Console.ReadLine());
                Console.WriteLine("Indtast bilens årgang:");
                yearList.Append(Convert.ToInt32(Console.ReadLine()));
                Console.WriteLine("Indtast bilens kilometer kørt:");
                odometerList.Append(Convert.ToInt32(Console.ReadLine()));
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
                string kmLabel = "Kilometertal";
                Console.WriteLine($"{brandLabel}|{modelLabel}|{kmLabel}");
                Console.WriteLine("---------------------------------------");
                string carInfo = String.Format("{0}|{1}|{2:F0}km", brandList[-1].PadRight(12), modelList[-1].PadRight(12), odometerList[-1]);
                Console.WriteLine(carInfo);
            }
        }
    }
}
