using NUnit.Framework;

namespace Tests
{
    public class WarriorTests
    {
        private Warrior testWarrior;
        string testName = "Gosho";
        int testDamage = 35;
        int testHP = 50;
        [SetUp]
        public void Setup()
        {
            testWarrior = new Warrior(testName, testDamage, testHP);
        }

        [Test]
        public void Test_Constructor()
        {
            Assert.AreEqual("Gosho", this.testWarrior.Name);
            Assert.AreEqual(35, this.testWarrior.Damage);
            Assert.AreEqual(50, this.testWarrior.HP);
        }

        [Test]
        public void Test_Name_Null()
        {
            Assert.That(() => new Warrior(null, testDamage, testHP), Throws.ArgumentException);
        }

        [Test]
        public void Test_Damage_Exception_Zero()
        {
            Assert.That(() => new Warrior(testName, 0, testHP), Throws.ArgumentException);
        }

        [Test]
        public void Test_Damage_Exception_Negative()
        {
            Assert.That(() => new Warrior(testName, -1, testHP), Throws.ArgumentException);
        }

        [Test]
        public void Test_Hp_Exception_Negative()
        {
            Assert.That(() => new Warrior("Warrior1", 12, -1), Throws.ArgumentException);
        }

        [Test]
        public void Test_Attack_First_Exception()
        {
            Warrior warrior1 = new Warrior("Name1", 10, 30);
            Warrior warrior2 = new Warrior("Name2", 10, 40);
            Assert.Throws<InvalidOperationException>(() => warrior1.Attack(warrior2));
        }

        [Test]
        public void Test_Attack_Second_Exception()
        {
            Warrior warrior1 = new Warrior("Name1", 10, 40);
            Warrior warrior2 = new Warrior("Name2", 10, 30);
            Assert.Throws<InvalidOperationException>(() => warrior1.Attack(warrior2));
        }

        [Test]
        public void Test_Attack_Third_Exception()
        {
            Warrior warrior1 = new Warrior("Name1", 10, 40);
            Warrior warrior2 = new Warrior("Name2", 50, 50);
            Assert.Throws<InvalidOperationException>(() => warrior1.Attack(warrior2));
        }

        [Test]
        public void Test_Attack_This_HP()
        {
            Warrior warrior1 = new Warrior("Name1", 41, 35);
            Warrior warrior2 = new Warrior("Name2", 34, 40);
            warrior1.Attack(warrior2);
            Assert.AreEqual(1, warrior1.HP);
        }

        [Test]
        public void Test_Attack_If_Statment()
        {
            Warrior warrior1 = new Warrior("Name1", 41, 35);
            Warrior warrior2 = new Warrior("Name2", 34, 40);
            warrior1.Attack(warrior2);
            Assert.AreEqual(0, warrior2.HP);
        }

        [Test]
        public void Test_Attack_Else_Statment()
        {
            Warrior warrior1 = new Warrior("Name1", 39, 35);
            Warrior warrior2 = new Warrior("Name2", 34, 40);
            warrior1.Attack(warrior2);
            Assert.AreEqual(1, warrior2.HP);
        }
    }
}