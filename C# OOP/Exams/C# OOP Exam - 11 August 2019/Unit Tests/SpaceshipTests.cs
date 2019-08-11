namespace BlueOrigin.Tests
{
    using System;
    using NUnit.Framework;

    [TestFixture]
    public class SpaceshipTests
    {
        private Spaceship testSpaceship;
        private Astronaut testAstronaut;
        [SetUp]
        public void SetUp()
        {
            this.testAstronaut = new Astronaut("Elon", 90);
            this.testSpaceship = new Spaceship("Falcon", 10);
        }

        [Test]
        public void Test_Name()
        {
            var expectedName = "Falcon";
            Assert.AreEqual(expectedName, testSpaceship.Name);
        }

        [Test]
        public void Test_Name_Exception()
        {
            Assert.Throws<ArgumentNullException>(() => new Spaceship(null, 90));
        }

        [Test]
        public void Test_Capacity()
        {
            var expectedResult = 10;
            Assert.AreEqual(expectedResult, testSpaceship.Capacity);
        }
        [Test]
        public void Test_Capacity_Exception()
        {
            Assert.Throws<ArgumentException>(() => new Spaceship("Name", -1));
        }
        [Test]
        public void Test_Add_FullException()
        {
            testSpaceship = new Spaceship("Falcon", 0);
            Assert.Throws<InvalidOperationException>(() => testSpaceship.Add(testAstronaut));
        }

        [Test]
        public void Test_Add_Existing_Exception()
        {
            testSpaceship.Add(testAstronaut);
            Assert.Throws<InvalidOperationException>(() => testSpaceship.Add(testAstronaut));
        }

        [Test]
        public void Test_Add_Valid()
        {
            testSpaceship.Add(testAstronaut);
            var expectedResult = 1;
            Assert.AreEqual(expectedResult, testSpaceship.Count);
        }

        [Test]
        public void Test_Remove_True()
        {
            testSpaceship.Add(testAstronaut);
            var expectedResult = true;
            Assert.AreEqual(expectedResult, testSpaceship.Remove("Elon"));
        }

        [Test]
        public void Test_Remove_False()
        {
            var expectedResult = false;
            Assert.AreEqual(expectedResult, testSpaceship.Remove("Invalid"));
        }
        [Test]
        public void Test_Count()
        {
            var expectedResult = 0;
            Assert.AreEqual(expectedResult, testSpaceship.Count);
        }
    }
}