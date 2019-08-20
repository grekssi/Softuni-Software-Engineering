using System;
using System.IO.Pipes;
using System.Linq;
using NUnit.Framework;

namespace Tests
{
    public class ExtendedDatabaseTests
    {
        private ExtendedDatabase extendedDatabase;
        private Person person;
        private static readonly Person testPerson = new Person(7, "Pesho");

        [SetUp]
        public void Setup()
        {
            this.person = new Person(1, "Gosho");
            this.extendedDatabase = new ExtendedDatabase(person);
        }

        [Test]
        public void Test_Constructor_Exception()
        {
            Person[] people = new Person[17];
            Assert.That(() => new ExtendedDatabase(people), Throws.ArgumentException);
        }

        [Test]
        public void Test_Constructor()
        {
            ExtendedDatabase newDatabase = new ExtendedDatabase(testPerson);
            Assert.AreEqual(1, newDatabase.Count);
        }

        [Test]
        public void Test_Add_Exception_Over16People()
        {
            Person[] persons = this.CreatePeople(16);
            ExtendedDatabase newDatabase = new ExtendedDatabase(persons);
            Assert.That(() => newDatabase.Add(testPerson), Throws.InvalidOperationException);
        }

        [Test]
        public void Test_Add_Exception_Username_Exists()
        {
            Person SameUsernamePerson = new Person(2, "Gosho");
            Assert.That(() => this.extendedDatabase.Add(SameUsernamePerson), Throws.InvalidOperationException);
        }

        [Test]
        public void Test_Add_Exception_Id_Exists()
        {
            Person SameIdPerson = new Person(1, "Pesho");
            Assert.That(() => this.extendedDatabase.Add(SameIdPerson), Throws.InvalidOperationException);
        }

        [Test]
        public void Test_Add_Method()
        {
            extendedDatabase.Add(testPerson);
            Assert.AreEqual(2, extendedDatabase.Count);
        }

        [Test]
        public void Test_Remove_Exception_ZeroCount()
        {
            ExtendedDatabase newDatabase = new ExtendedDatabase();
            Assert.That(() => newDatabase.Remove(), Throws.InvalidOperationException);
        }

        [Test]
        public void Test_Remove_Method()
        {
            int countShouldBe = this.extendedDatabase.Count - 1;
            this.extendedDatabase.Remove();
            int countIs = this.extendedDatabase.Count;
            Assert.AreEqual(countShouldBe, countIs);
        }

        [Test]
        public void Test_FindByUsername_NullOrEmpty_Exception()
        {
            Assert.That(() => this.extendedDatabase.FindByUsername(string.Empty), Throws.ArgumentNullException);
            Assert.That(() => this.extendedDatabase.FindByUsername(null), Throws.ArgumentNullException); //may need new test for that
        }

        [Test]
        public void Test_FindByUsername_DoesNotExist()
        {
            Assert.That(() => this.extendedDatabase.FindByUsername("FakeUSer"), Throws.InvalidOperationException);
        }

        [Test]
        public void Test_FindByUsername_Method()
        {
            this.extendedDatabase.Add(testPerson);
            Person expectedPerson = testPerson;
            Person realPerson = this.extendedDatabase.FindByUsername("Pesho");
            Assert.AreEqual(expectedPerson, realPerson);
        }

        [Test]
        public void Test_FindById_IdLessThanZero()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => extendedDatabase.FindById(-1));
        }

        [Test]
        public void Test_FindById_IdNotFound()
        {
            Assert.That(() => this.extendedDatabase.FindById(testPerson.Id), Throws.InvalidOperationException);
        }

        [Test]
        public void Test_FindByID_Method()
        {
            extendedDatabase.Add(testPerson);
            Person expectedPerson = testPerson;
            Person realPerson = extendedDatabase.FindById(testPerson.Id);
            Assert.AreEqual(expectedPerson, realPerson);
        }

        private Person[] CreatePeople(int countOfPeople)
        {
            Person[] people = new Person[countOfPeople];

            for (int i = 0; i < countOfPeople; i++)
            {
                long id = 2000 + i;
                string userName = "User" + (char)('a' + i);

                Person person = new Person(id, userName);
                people[i] = person;
            }

            return people;
        }

    }
}