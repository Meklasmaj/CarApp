using CarApp;

namespace CarUnitTest
{
    [TestClass]
    public class Test1
    {
        [TestMethod]
        public void GetTripsByDate_ReturnsMatchingTrips()
        {
            DateTime today = new DateTime(2026, 6, 1);
            Car car = new FuelCar("Audi", "A4", 2001, "CN45986", 490000, 14.3, FuelType.Benzin);
            Trip trip1 = new Trip(today.AddDays(1), today.AddHours(1), today.AddDays(1), 1, 70, car);
            Trip trip2 = new Trip(today.AddHours(1), today.AddHours(1), today.AddMinutes(1), 2, 70, car);
            Trip trip3 = new Trip(today.AddHours(1), today.AddHours(1), today.AddHours(1), 3, 70, car);


            car.Drive(trip1);
            car.Drive(trip2);
            car.Drive(trip3);

            // Act
            List<Trip> newTrips = car.GetTripsByDate(today);

            // Assert
            Assert.AreEqual(2, newTrips.Count);
        }

        [TestMethod]
        public void GetTripsByDate_ReturnsEmptyListOfTrips()
        {
            DateTime today = new DateTime(2026, 6, 1);
            Car car = new FuelCar("Audi", "A4", 2001, "CN45986", 490000, 14.3, FuelType.Benzin);
            Trip trip1 = new Trip(today.AddDays(1), today.AddDays(1), today.AddDays(1), 1, 70, car);
            Trip trip2 = new Trip(today.AddDays(1), today.AddDays(1), today.AddDays(1), 2, 70, car);
            Trip trip3 = new Trip(today.AddDays(1), today.AddDays(1), today.AddDays(1), 3, 70, car);


            car.Drive(trip1);
            car.Drive(trip2);
            car.Drive(trip3);

            // Act
            List<Trip> newTrips = car.GetTripsByDate(today);

            // Assert
            Assert.IsEmpty(newTrips);
        }

        [TestMethod]
        public void GetTripsInTimeInterval_ReturnsMatchingTrips()
        {
            DateTime today = new DateTime(2026, 6, 1, 10, 0, 0);
            Car car = new FuelCar("Audi", "A4", 2001, "CN45986", 490000, 14.3, FuelType.Benzin);
            Trip trip1 = new Trip(today, today.AddHours(6), today.AddDays(1), 1, 70, car);
            Trip trip2 = new Trip(today, today, today.AddDays(1), 2, 70, car);
            Trip trip3 = new Trip(today, today, today.AddDays(1), 3, 70, car);


            car.Drive(trip1);
            car.Drive(trip2);
            car.Drive(trip3);

            // Act
            List<Trip> newTrips = car.GetTripsInTimeInterval(today, today.AddHours(5));

            // Assert
            Assert.AreEqual(2, newTrips.Count);
        }

        [TestMethod]
        public void GetTripsInTimeInterval_ReturnsTripsWithEqualStartTime()
        {
            DateTime today = new DateTime(2026, 6, 1, 10, 0, 0);
            Car car = new FuelCar("Audi", "A4", 2001, "CN45986", 490000, 14.3, FuelType.Benzin);
            Trip trip1 = new Trip(today, today, today.AddDays(1), 1, 70, car);
            Trip trip2 = new Trip(today, today.AddHours(5), today.AddDays(1), 2, 70, car);

            car.Drive(trip1);
            car.Drive(trip2);

            // Act
            List<Trip> newTrips = car.GetTripsInTimeInterval(today, today.AddHours(5));

            // Assert
            Assert.AreEqual(2, newTrips.Count);
        }
    }
}
