using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using Microsoft.CSharp.RuntimeBinder;
using Microsoft.Extensions.DependencyModel.Resolution;
using NUnit.Framework;

namespace Tests
{
    public class CarTests
    {
        const string makeTest = "Ferrari";
        const string modelTest = "F150";
        const double fuelConsumptionTest = 12.5;
        const double fuelAmountTest = 50;
        const double fuelCapacity = 100;
        private Car car;

        [SetUp]
        public void Setup()
        {
            car = new Car("Ford", "Focus", 1.5, 40);
        }

        [Test]
        public void Test_Constructor()
        {
            Car car = new Car(makeTest, modelTest, fuelConsumptionTest, fuelCapacity);
            Assert.AreEqual(makeTest, car.Make);
            Assert.AreEqual(modelTest, car.Model);
            Assert.AreEqual(fuelConsumptionTest, car.FuelConsumption);
            Assert.AreEqual(fuelCapacity, car.FuelCapacity);
        }

        [Test]
        public void Test_Constructor_Empty_Make()
        {
            Assert.That(() => car = new Car(string.Empty, "Mustang", 20, 200), Throws.ArgumentException);
        }

        [Test]
        public void Test_Constructor_Null_Make()
        {
            Assert.That(() => car = new Car(null, "Mustang", 20, 200), Throws.ArgumentException);
        }

        [Test]
        public void Test_Constructor_Valid_Make()
        {
            Car newCar = new Car("Opel", "Corsa", 1.0, 20);
            Assert.AreEqual("Opel", newCar.Make);
        }

        [Test]
        public void Test_Constructor_Empty_Model()
        {
            Assert.That(() => new Car("Ford", string.Empty, 20, 200), Throws.ArgumentException);
        }

        [Test]
        public void Test_Constructor_Null_Model()
        {
            Assert.That(() => new Car("Ford", null, 20, 200), Throws.ArgumentException);
        }

        [Test]
        public void Test_Constructor_Valid_Model()
        {
            Car newCar = new Car("Opel", "Corsa", 1.0, 20);
            Assert.AreEqual("Corsa", newCar.Model);
        }

        [Test]
        public void Test_Constructor_Consumption_Negative()
        {
            Assert.That(() => new Car("Ford", "Mustang", -1, 200), Throws.ArgumentException);
        }

        [Test]
        public void Test_Constructor_Consumption_Zero()
        {
            Assert.That(() => new Car("Ford", "Mustang", 0, 200), Throws.ArgumentException);
        }

        [Test]
        public void Test_Constructor_Consumption_Valid()
        {
            Car newCar = new Car("Ford", "Mustang", 20, 200);
            Assert.AreEqual(20, newCar.FuelConsumption);
        }

        [Test]
        public void Test_Constructor_FuelCapacity_Negative()
        {
            Assert.That(() => new Car("Ford", "Mustang", 20, -1), Throws.ArgumentException);
        }

        [Test]
        public void Test_Constructor_FuelCapacity_Zero()
        {
            Assert.That(() => new Car("Ford", "Mustang", 20, 0), Throws.ArgumentException);
        }

        [Test]
        public void Test_Constructor_FuelCapacity_Valid()
        {
            Car car = new Car("Ford", "Mustang", 20, 200);
            Assert.AreEqual(200, car.FuelCapacity);
        }
        //Might need to test fuelAmount here before refueling
        [Test]
        public void Test_Refuel_Zero_Exception()
        {
            Assert.That(() => car.Refuel(0), Throws.ArgumentException);
        }

        [Test]
        public void Test_Refuel_Negative_Exception()
        {
            Assert.That(() => car.Refuel(-1), Throws.ArgumentException);
        }

        [Test] //may need test to validate overfueling
        public void Test_Refuel_Valid()
        {
            car.Refuel(10);
            Assert.AreEqual(10, car.FuelAmount);
        }

        [Test]
        public void Test_Drive_Exception_NoFuel()
        {
            Assert.That(() => car.Drive(10), Throws.InvalidOperationException);
        }

        [Test]
        public void Test_Drive_Valid()
        {
            car.Refuel(100);
            car.Drive(10);
            Assert.AreEqual(39.85, (double)car.FuelAmount);
        }

    }
}