namespace CarApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            String brand = "";
            String model = "";
            int year = 0;
            char geartype = ' ';
            char fueltype = ' ';
            double kmPrL = 0;
            int kmNow = 0;
            double gasPrice = 13.49;
            double dieselPrice = 12.29;
            double distance = 0;
            double tripCost = 0;

            Console.WriteLine("Instast bilmærke:");
            brand = Console.ReadLine();

            Console.WriteLine("Instast bilmodel:");
            model = Console.ReadLine();

            Console.WriteLine("Instast årgang:");
            year = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Instast geartype, (A) for automatisk, (M) for manuel:");
            geartype = Console.ReadLine()[0];

            Console.WriteLine("Hvilken type brændstof kører bilen på? (B) Benzin / (D) Diesel");
            fueltype = Console.ReadLine()[0];

            Console.WriteLine("Hvor langt kører bilen på literen?");
            kmPrL = double.Parse(Console.ReadLine());

            Console.WriteLine("Hvor mange kilometer har bilen kørt nu?");
            kmNow = int.Parse(Console.ReadLine());

            Console.WriteLine("Hvor langt skal du køre?");
            distance = double.Parse(Console.ReadLine());

            if(fueltype == 'B')
            {
                tripCost = distance / kmPrL * gasPrice;
            }
            else
            {
                tripCost = distance / kmPrL * dieselPrice;
            }

            Console.WriteLine($"Turen på {distance}km, kommer til at koste {tripCost:F2}kr");
            Console.ReadLine();

            Math.Floor(distance);
            kmNow += Convert.ToInt32(distance);

            // Ending
            Console.Clear();

            Console.WriteLine($"{brand} {model} fra {year} har gear: {geartype}, den kører på {fueltype}, med {kmPrL} km/l og har nu kørt {kmNow}km");
            
            Console.ReadLine();
        }
    }
}
