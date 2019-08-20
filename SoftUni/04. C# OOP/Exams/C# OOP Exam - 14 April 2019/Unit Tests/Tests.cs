using System;

namespace Telecom.Tests
{
    using NUnit.Framework;

    [TestFixture]
    public class Tests
    {
        private Phone testPhone;
        private string testMake;
        private string testModel;
        
        [SetUp]
        public void SetUp()
        {
            testPhone = new Phone("Iphone", "6s");
        }

        [Test]
        public void Test_Constructor()
        {
            Assert.AreEqual("Iphone", testPhone.Make);
            Assert.AreEqual("6s", testPhone.Model);
            Assert.AreEqual(0, testPhone.Count);
        }

        [Test]
        public void Test_Make_Exception()
        {
            Assert.Throws<ArgumentException>(() => new Phone(null, "zen"));
        }

        [Test]
        public void Test_Model_Exception()
        {
            Assert.Throws<ArgumentException>(() => new Phone("Iphone", null));
        }

        [Test]
        public void Test_AddContact()
        {
            testPhone.AddContact("Bedo", "09283");
            testPhone.AddContact("Bedo2", "092823");
            Assert.AreEqual(2, testPhone.Count);
        }

        [Test]
        public void Test_AddContact_Exception()
        {
            testPhone.AddContact("Bedo", "09283");
            Assert.Throws<InvalidOperationException>(() => testPhone.AddContact("Bedo", "12345"));
        }

        [Test]
        public void Test_Call()
        {
            testPhone.AddContact("Bedo", "09283");
            Assert.AreEqual("Calling Bedo - 09283...", testPhone.Call("Bedo"));
        }

        [Test]
        public void Test_Call_Exception()
        {
            Assert.Throws<InvalidOperationException>(() => testPhone.Call("InvalidPerson"));
        }
    }
}