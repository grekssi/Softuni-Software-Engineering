using System;
using NUnit.Framework;

namespace TheRace.Tests
{
    public class RaceEntryTests
    {
        private RaceEntry raceEntry;
        private UnitMotorcycle testMotorcycle;
        private UnitRider testRider;
        [SetUp]
        public void Setup()
        {
            raceEntry = new RaceEntry();
            testMotorcycle = new UnitMotorcycle("Harley", 300, 700);
            testRider = new UnitRider("Greksi", testMotorcycle);
        }

        [Test]
        public void Test_Constructor()
        {
            RaceEntry newEntry = new RaceEntry();
            Assert.AreEqual(0, newEntry.Counter);
        }

        [Test]
        public void Test_AddRider_Exception_NullRider()
        {
            Assert.That(() => raceEntry.AddRider(null), Throws.InvalidOperationException);
        }

        [Test]
        public void Test_AddRider_Exception_Existing()
        {
            raceEntry.AddRider(testRider);
            Assert.That(() => raceEntry.AddRider(testRider), Throws.InvalidOperationException);
        }

        [Test]
        public void Test_AddRaider_Valid()
        {
            raceEntry.AddRider(testRider);
            Assert.AreEqual(1, raceEntry.Counter);
        }

        [Test]
        public void Test_Calculate_Exception()
        {
            raceEntry.AddRider(testRider);
            Assert.Throws<InvalidOperationException>(() => raceEntry.CalculateAverageHorsePower());
        }

        [Test]
        public void Test_Calculate_Valid()
        {
            UnitRider rider1 = new UnitRider("John", new UnitMotorcycle("Ford", 200, 400));
            UnitRider rider2 = new UnitRider("Michael", new UnitMotorcycle("Ducatti", 100, 400));
            UnitRider rider3 = new UnitRider("Pesho", new UnitMotorcycle("Kali", 300, 400));
            raceEntry.AddRider(rider1);
            raceEntry.AddRider(rider2);
            raceEntry.AddRider(rider3);
            Assert.AreEqual(200, raceEntry.CalculateAverageHorsePower());
        }
    }
}