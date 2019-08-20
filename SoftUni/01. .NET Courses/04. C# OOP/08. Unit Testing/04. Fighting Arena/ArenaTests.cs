using System.Linq;
using System.Net.Sockets;
using System.Runtime.InteropServices.ComTypes;
using NUnit.Framework;

namespace Tests
{
    public class ArenaTests
    {
        private Arena arena;
        [SetUp]
        public void Setup()
        {
            arena = new Arena();
        }

        [Test]
        public void Test_Constructor()
        {
            Arena arena = new Arena();
            Assert.IsNotNull(arena.Warriors);
        }

        [Test]
        public void Test_Count()
        {
            Arena arena = new Arena();
            Assert.AreEqual(0, arena.Count);
        }

        [Test]
        public void Test_Enroll_Exception()
        {
            Warrior warrior1 = new Warrior("Name1", 20, 30);
            Warrior warrior2 = new Warrior("Name1", 20, 30);
            this.arena.Enroll(warrior1);
            Assert.That(() => arena.Enroll(warrior2), Throws.InvalidOperationException);
            Assert.AreEqual(1, arena.Count);
        }

        [Test]
        public void Test_Enroll_Valid()
        {
            Warrior warrior1 = new Warrior("Name1", 20, 30);
            Warrior warrior2 = new Warrior("Name2", 20, 30);
            arena.Enroll(warrior1);
            arena.Enroll(warrior2);
            Assert.AreEqual(2, arena.Count);
        }

        [Test]
        public void Test_Fight_Exception_Null_FirstPlayer()
        {
            Warrior warrior1 = new Warrior("Name1", 20, 30);
            Warrior warrior2 = new Warrior("Name2", 20, 30);

            arena.Enroll(warrior1);
            arena.Enroll(warrior2);

            Assert.That(() => arena.Fight("InvalidName", "Name1"), Throws.InvalidOperationException); //may need second test
        }

        [Test]
        public void Test_Fight_Exception_Null_SecondPlayer()
        {
            Warrior warrior1 = new Warrior("Name1", 20, 30);
            Warrior warrior2 = new Warrior("Name2", 20, 30);

            arena.Enroll(warrior1);
            arena.Enroll(warrior2);

            Assert.That(() => arena.Fight("Name1", "InvalidName"), Throws.InvalidOperationException); //may need second test
        }

        [Test]
        public void Test_Fight_Valid_Third()
        {
            Warrior warrior1 = new Warrior("Name1", 5, 31);
            Warrior warrior2 = new Warrior("Name2", 20, 50);

            arena.Enroll(warrior1);
            arena.Enroll(warrior2);

            arena.Fight("Name1", "Name2");
            Assert.AreEqual(11, warrior1.HP);
            Assert.AreEqual(45, warrior2.HP);
        }
    }
}
