using System;
using NUnit.Framework;

namespace Tests
{
    public class DatabaseTests
    {
        private Database.Database database;
        int[] nums = new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16 };
        [SetUp]
        public void Setup()
        {
            this.database = new Database.Database(nums);
        }

        [Test]
        public void Test_Constructor()
        {
            Assert.AreEqual(16, database.Count);
        }

        [Test]
        public void Test_Add_Exception()
        {
            Assert.Throws<InvalidOperationException>(() => database.Add(17));
        }

        [Test]
        public void Test_Add_Element()
        {
            int[] nums = new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
            this.database = new Database(nums);
            database.Add(11);
            Assert.AreEqual(11, this.database.Count);
        }

        [Test]
        public void Test_Remove_Exception()
        {
            this.database = new Database();
            Assert.Throws<InvalidOperationException>(() => database.Remove());
        }

        [Test]
        public void Test_Remove()
        {
            this.database = new Database(nums);
            database.Remove();
            Assert.AreEqual(15, database.Count);
        }

        [Test]
        public void Test_Fetch()
        {
            Assert.AreEqual(16, this.database.Fetch().Length);
        }
    }
}