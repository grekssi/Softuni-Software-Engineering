using System;
using NUnit.Framework;

namespace Service.Tests
{
    public class DeviceTests
    {
        private const string make = "Asus";
        private Laptop laptop;
        private PC pc;
        private Phone phone;

        [SetUp]
        public void Setup()
        {
           this.laptop = new Laptop(make);
           this.pc = new PC(make);
           this.phone = new Phone(make);
        }

        [Test]
        public void Test_Constructor()
        {
            Assert.AreEqual("Asus", laptop.Make);
            Assert.AreEqual("Asus", pc.Make);
            Assert.AreEqual("Asus", phone.Make);
            Assert.NotNull(laptop.Parts);
            Assert.NotNull(pc.Parts);
            Assert.NotNull(phone.Parts);
        }

        [Test]
        public void Test_Constructor_Exception()
        {
            Assert.Throws<ArgumentException>(() => new Phone(null));
            Assert.Throws<ArgumentException>(() => new PC(null));
            Assert.Throws<ArgumentException>(() => new Laptop(null));
            Assert.Throws<ArgumentException>(() => new Phone(string.Empty));
            Assert.Throws<ArgumentException>(() => new PC(string.Empty));
            Assert.Throws<ArgumentException>(() => new Laptop(string.Empty));
        }

        [Test]
        public void Test_Add_Exception()
        {
            Part phonepart = new PhonePart("usb", 90);
            Part pcpart = new PCPart("disk", 90);
            Part laptoppart = new LaptopPart("Motherboard", 90);

            laptop.AddPart(laptoppart);
            pc.AddPart(pcpart);
            phone.AddPart(phonepart);

            Assert.That(() => laptop.AddPart(laptoppart), Throws.InvalidOperationException);
            Assert.That(() => pc.AddPart(pcpart), Throws.InvalidOperationException);
            Assert.That(() => phone.AddPart(phonepart), Throws.InvalidOperationException);
        }

        [Test]
        public void Test_Add_Valid()
        {
            Part phonepart = new PhonePart("usb", 90);
            Part pcpart = new PCPart("disk", 90);
            Part laptoppart = new LaptopPart("Motherboard", 90);

            laptop.AddPart(laptoppart);
            pc.AddPart(pcpart);
            phone.AddPart(phonepart);

            Assert.AreEqual(1, phone.Parts.Count);
            Assert.AreEqual(1, laptop.Parts.Count);
            Assert.AreEqual(1, pc.Parts.Count);
        }

        [Test]
        public void Test_Remove_Exception()
        {
            Assert.That(() => pc.RemovePart(null), Throws.ArgumentException);
            Assert.That(() => laptop.RemovePart(null), Throws.ArgumentException);
            Assert.That(() => phone.RemovePart(null), Throws.ArgumentException);
        }

        [Test]
        public void Test_Remove_Exception_Empty()
        {
            Assert.That(() => pc.RemovePart(string.Empty), Throws.ArgumentException);
            Assert.That(() => laptop.RemovePart(string.Empty), Throws.ArgumentException);
            Assert.That(() => phone.RemovePart(string.Empty), Throws.ArgumentException);
        }

        [Test]
        public void Test_Remove_Second_Exception()
        {
            Assert.That(() => pc.RemovePart("InvalidPart"), Throws.InvalidOperationException);
            Assert.That(() => laptop.RemovePart("InvalidPart"), Throws.InvalidOperationException);
            Assert.That(() => phone.RemovePart("InvalidPart"), Throws.InvalidOperationException);
        }

        [Test]
        public void Test_Remove_Valid()
        {
            Part phonepart = new PhonePart("usb", 90);
            Part pcpart = new PCPart("disk", 90);
            Part laptoppart = new LaptopPart("Motherboard", 90);
            laptop.AddPart(laptoppart);
            pc.AddPart(pcpart);
            phone.AddPart(phonepart);

            laptop.RemovePart("Motherboard");
            pc.RemovePart("disk");
            phone.RemovePart("usb");
            Assert.AreEqual(0,phone.Parts.Count);
            Assert.AreEqual(0,pc.Parts.Count);
            Assert.AreEqual(0,laptop.Parts.Count);
        }

        [Test]
        public void Test_Repair_Exception()
        {
            Assert.That(() => laptop.RepairPart(null), Throws.ArgumentException);
            Assert.That(() => pc.RepairPart(null), Throws.ArgumentException);
            Assert.That(() => phone.RepairPart(null), Throws.ArgumentException);
        }

        [Test]
        public void Test_Repair_Exception_WhiteSpace()
        {
            Assert.That(() => laptop.RepairPart(string.Empty), Throws.ArgumentException);
            Assert.That(() => pc.RepairPart(string.Empty), Throws.ArgumentException);
            Assert.That(() => phone.RepairPart(string.Empty), Throws.ArgumentException);
        }

        [Test]
        public void Test_Repair_InvalidPart()
        {
            Assert.That(() => laptop.RepairPart("InvalidPart"), Throws.InvalidOperationException);
            Assert.That(() => pc.RepairPart("InvalidPart"), Throws.InvalidOperationException);
            Assert.That(() => phone.RepairPart("InvalidPart"), Throws.InvalidOperationException);
        }

        [Test]
        public void Test_Repair_Unbroken_Part()
        {
            Part phonepart = new PhonePart("usb", 90);
            Part pcpart = new PCPart("disk", 90);
            Part laptoppart = new LaptopPart("Motherboard", 90);
            laptop.AddPart(laptoppart);
            pc.AddPart(pcpart);
            phone.AddPart(phonepart);
            Assert.That(() => phone.RepairPart("usb"), Throws.InvalidOperationException);
            Assert.That(() => pc.RepairPart("disk"), Throws.InvalidOperationException);
            Assert.That(() => laptop.RepairPart("Motherboard"), Throws.InvalidOperationException);
        }

        [Test]
        public void Test_Repair_Valid()
        {
            Part phonepart = new PhonePart("usb", 90, true);
            Part pcpart = new PCPart("disk", 90, true);
            Part laptoppart = new LaptopPart("Motherboard", 90, true);

            laptop.AddPart(laptoppart);
            pc.AddPart(pcpart);
            phone.AddPart(phonepart);

            laptop.RepairPart("Motherboard");
            pc.RepairPart("disk");
            phone.RepairPart("usb");

            Assert.AreEqual(false, phonepart.IsBroken);
            Assert.AreEqual(false, pcpart.IsBroken);
            Assert.AreEqual(false, laptoppart.IsBroken);
        }
    }
}
