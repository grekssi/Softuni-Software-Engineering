using System;
using System.Linq;
using NUnit.Framework;

namespace Service.Tests
{
    public class DeviceTests
    {
        private Device testLaptop;
        private Device testPc;
        private Device testPhone;
        private Part testPcPart;
        private Part testLaptopPart;
        private Part testPhonePart;
        [SetUp]
        public void Setup()
        {
            this.testLaptop = new Laptop("Asus");
            this.testPc = new PC("Zen");
            this.testPhone = new Phone("Iphone");

            this.testLaptopPart = new LaptopPart("Motherboard", 50);
            this.testPcPart = new PCPart("CPU", 130);
            this.testPhonePart = new PhonePart("Camera", 30);
        }

        [Test]
        public void Test_Constructor()
        {
            Assert.NotNull(testLaptop.Parts);
            Assert.NotNull(testPc.Parts);
            Assert.NotNull(testPhone.Parts);

            Assert.AreEqual("Asus", testLaptop.Make);
            Assert.AreEqual("Zen", testPc.Make);
            Assert.AreEqual("Iphone", testPhone.Make);
        }

        [Test]
        public void Test_Constructor_Make_Null() //testWhiteSpace
        {
            Assert.Throws<ArgumentException>(() => this.testLaptop = new Laptop(null));
        }

        [Test]
        public void Test_Add_Part()
        {
            this.testPc.AddPart(testPcPart);
            var addedPart = testPc.Parts.FirstOrDefault(x => x.Name == testPcPart.Name);
            Assert.NotNull(addedPart);
            Assert.AreEqual(testPcPart.Name, addedPart.Name);
            Assert.That(testPc.Parts, Has.Member(testPcPart));
            Assert.AreEqual(1, testPc.Parts.Count);
        }

        [Test]
        public void Test_Add_Not_Correct_Part_For_Laptop_Exception()
        {
            Assert.Throws<InvalidOperationException>(() => this.testLaptop.AddPart(this.testPcPart));
        }

        [Test]
        public void Test_Add_Not_Correct_Part_For_PC_Exception()
        {
            Assert.Throws<InvalidOperationException>(() => this.testPc.AddPart(this.testPhonePart));
        }

        [Test]
        public void Test_Add_Not_Correct_Part_For_Phone_Exception()
        {
            Assert.Throws<InvalidOperationException>(() => this.testPhone.AddPart(this.testLaptopPart));
        }

        [Test]
        public void Test_Add_Part_Exception()
        {
            this.testPc.AddPart(testPcPart);
            Assert.Throws<InvalidOperationException>(() => this.testPc.AddPart(testPcPart));
        }

        [Test]
        public void Test_Remove_Part()
        {
            this.testPc.AddPart(new PCPart("HDD", 20));
            this.testPc.AddPart(new PCPart("CPU", 90));
            this.testPc.AddPart(new PCPart("GPU", 130));
            var partToRemove = testPc.Parts.FirstOrDefault(x => x.Name == "HDD");
            Assert.NotNull(partToRemove);
            this.testPc.RemovePart("HDD");
            Assert.AreEqual(2, this.testPc.Parts.Count);
        }

        [Test]
        public void Test_Remove_Part_Exception_Null()
        {
            Assert.Throws<ArgumentException>(() => this.testPc.RemovePart(null));
        }

        [Test]
        public void Test_Remove_Part_Exception_Empty()
        {
            Assert.Throws<ArgumentException>(() => this.testPc.RemovePart(string.Empty));
        }

        [Test]
        public void Test_Remove_Part_Exception_DoesNotExist()
        {
            Assert.Throws<InvalidOperationException>(() => this.testPc.RemovePart("InvalidPart123"));
        }

        [Test]
        public void Test_Repair_Part()
        {
            this.testPc.AddPart(new PCPart("HDD", 20, true));
            this.testPc.AddPart(new PCPart("CPU", 90, true));
            this.testPc.AddPart(new PCPart("GPU", 130, true));
            Assert.AreEqual(3, testPc.Parts.Count);

            var partToRepair = testPc.Parts.FirstOrDefault(x => x.Name == "HDD");
            Assert.NotNull(partToRepair);

            this.testPc.RepairPart("HDD");
            Assert.AreEqual(false, partToRepair.IsBroken); //check here if breaks
        }

        [Test]
        public void Test_Repair_Part_Exception_Null()
        {
            Assert.Throws<ArgumentException>(() => this.testPc.RepairPart(null));
        }

        [Test]
        public void Test_Repair_Part_Exception_Empty()
        {
            Assert.Throws<ArgumentException>(() => this.testPc.RepairPart(string.Empty));
        }

        [Test]
        public void Test_Repair_Part_Exception_Invalid_Part()
        {
            Assert.Throws<InvalidOperationException>(() => this.testPc.RepairPart("InvalidPart123"));
        }

        [Test]
        public void Test_Repair_Part_Exception_NotBrokenPart()
        {
            this.testPc.AddPart(new PCPart("HDD", 20, false));
            this.testPc.AddPart(new PCPart("CPU", 130, false));
            Assert.Throws<InvalidOperationException>(() => this.testPc.RepairPart("HDD"));
        }
    }
}
