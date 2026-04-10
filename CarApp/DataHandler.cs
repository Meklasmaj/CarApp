namespace CarApp;

public class DataHandler
{
    private string _filePath;
    
    public DataHandler(string filePath)
    {
        _filePath = filePath;
    }

    public void SaveCarsToFile(List<Car> cars)
    {
        using (StreamWriter writer = new StreamWriter(_filePath))
        {
            foreach (Car car in cars)
            {
                writer.WriteLine(car.ToString());
            }
        }
    }

    public List<Car> LoadCarsFromFile()
    {
        List<Car> newCars = new List<Car>();
        using (StreamReader reader = new StreamReader(_filePath))
        {
            string line;
            while ((line = reader.ReadLine()) != null)
            {
                if (!string.IsNullOrEmpty(line))
                {
                    if (line[0] == 'E')
                    {
                        newCars.Add(ElectricCar.FromString(line));
                    }
                    else
                    {
                        newCars.Add(FuelCar.FromString(line));
                    }
                }
            }
        }
        return newCars;
    }
}