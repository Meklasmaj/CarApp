namespace CarApp
{
    internal class Fuel
    {
        public char _type { get; private set; }
        public double _price { get; set; }

        public Fuel(char type, double price)
        {
            _type = type;
            _price = price;
        }


    }
}