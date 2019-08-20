using System;
using System.Linq;

namespace ParkingSystem.Tests
{
    using NUnit.Framework;

    public class SoftParkTest
    {
        private SoftPark softPark;
        private Car car;  
        [SetUp]
        public void Setup()
        {
            this.softPark = new SoftPark();
            this.car = new Car("Audi", "2323");
        }

        [Test]
        public void Test_Constructor()
        {
            SoftPark newPark = new SoftPark();
            Assert.NotNull(newPark.Parking);
            Assert.AreEqual(12, newPark.Parking.Count);
            Assert.AreEqual(null, newPark.Parking["A1"]);
            Assert.AreEqual("Audi", car.Make);
            Assert.AreEqual("2323", car.RegistrationNumber);
        }

        [Test]
        public void Test_ParkCar()
        {
            Assert.AreEqual($"Car:{car.RegistrationNumber} parked successfully!", softPark.ParkCar("A1", car));
        }

        [Test]
        public void Test_ParkCar_Exception_SpotDoesNotExist()
        {
            Assert.Throws<ArgumentException>(() => softPark.ParkCar("InvalidSpot", car));
        }

        [Test]
        public void Test_ParkCar_Exception_SpotTaken()
        {
            Car newCar = new Car("BMW", "91239");
            softPark.ParkCar("A1", car);
            Assert.Throws<ArgumentException>(() => softPark.ParkCar("A1", newCar));
        }

        [Test]
        public void Test_ParkCar_AlreadyParked()
        {
            softPark.ParkCar("A1", car);
            Assert.Throws<InvalidOperationException>(() => softPark.ParkCar("A2", car));
        }

        [Test]
        public void Test_RemoveCar()
        {
            softPark.ParkCar("A1", car);
            Assert.AreEqual($"Remove car:{car.RegistrationNumber} successfully!", this.softPark.RemoveCar("A1", car));
        }

        [Test]
        public void Test_RemoveCar_Exception_ParkingSpotDoesNotExist()
        {
            Assert.Throws<ArgumentException>(() => softPark.RemoveCar("InvalidSpot", car));
        }

        [Test]
        public void Test_RemoveCar_Exception_InvalidCar()
        {
            Car newCar = new Car("BMW", "91239");
            softPark.ParkCar("A1", car);
            Assert.Throws<ArgumentException>(() => softPark.RemoveCar("A1", newCar));
        }
    }
}