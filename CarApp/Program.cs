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

            Console.WriteLine("Instast bilmærke:");
            brand = Console.ReadLine();

            Console.WriteLine("Instast bilmodel:");
            model = Console.ReadLine();

            Console.WriteLine("Instast årgang:");
            year = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Instast geartype, (A) for automatisk, (M) for manuel:");
            geartype = Console.ReadLine()[0];

            Console.Clear();

            Console.WriteLine($"{brand} {model} fra {year} har gear: {geartype}");
            
            Console.ReadLine();
        }
    }
}
