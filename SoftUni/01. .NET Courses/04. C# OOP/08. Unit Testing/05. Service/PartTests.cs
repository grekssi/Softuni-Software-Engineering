using System;
using NUnit.Framework;

namespace Tests
{
    public class PartTests
    {
        private Part phonepart;
        private Part pcpart;
        private Part laptoppart;
        [SetUp]
        public void Setup()
        {
            phonepart = new PhonePart("usb", 90);
            pcpart = new PCPart("disk", 90);
            laptoppart = new LaptopPart("Motherboard", 90);
        }

        [Test]
        public void Test_Constructor()
        {
          Part newphonepart = new PhonePart("usb", 90, true);
          Part newpcpart = new PCPart("disk", 90, true);
          Part newlaptoppart = new LaptopPart("Motherboard", 90, true);

          Assert.AreEqual("usb", newphonepart.Name);
          Assert.AreEqual(90 * 1.3m, newphonepart.Cost);
          Assert.AreEqual("disk", newpcpart.Name);
          Assert.AreEqual(90 * 1.2m, newpcpart.Cost);
          Assert.AreEqual("Motherboard", newlaptoppart.Name);
          Assert.AreEqual(90 * 1.5m, newlaptoppart.Cost);
          Assert.AreEqual(true, newphonepart.IsBroken);
          Assert.AreEqual(true, newlaptoppart.IsBroken);
          Assert.AreEqual(true, newpcpart.IsBroken);
        }

        [Test]
        public void Test_Name_Exception()
        {
            Assert.That(() => new PhonePart(null, 90), Throws.ArgumentException);
            Assert.That(() => new PCPart(null, 90), Throws.ArgumentException);
            Assert.That(() => new LaptopPart(null, 90), Throws.ArgumentException);
            Assert.That(() => new PhonePart(string.Empty, 90), Throws.ArgumentException);
            Assert.That(() => new PCPart(string.Empty, 90), Throws.ArgumentException);
            Assert.That(() => new LaptopPart(string.Empty, 90), Throws.ArgumentException);
        }

        [Test]
        public void Test_Cost_Exception()
        {
            Assert.That(() => new PhonePart("valid", 0), Throws.ArgumentException);
            Assert.That(() => new PCPart("valid2", -2), Throws.ArgumentException);
            Assert.That(() => new LaptopPart("valid3", -3), Throws.ArgumentException);
        }

        [Test]
        public void Test_IsBroken_True()
        {
            var newPhonePart = new PhonePart("valid", 2, true);
            Assert.AreEqual(true, newPhonePart.IsBroken);
        }

        [Test]
        public void Test_IsBroken_False()
        {
            var newPhonePart = new PhonePart("valid", 3, false);
            Assert.AreEqual(false, newPhonePart.IsBroken);
        }

        [Test]
        public void Test_Repair()
        {
            var newPhonePart = new PhonePart("valid", 2, true);
            newPhonePart.Repair();
            Assert.AreEqual(false, newPhonePart.IsBroken);
        }

        [Test]
        public void Test_Report()
        {
            var newPhonePart = new PhonePart("valid", 2, true);
            string report = $"{newPhonePart.Name} - {newPhonePart.Cost:f2}$" + Environment.NewLine +
                $"Broken: {newPhonePart.IsBroken}";
            Assert.AreEqual(report, newPhonePart.Report());
        }
    }
}