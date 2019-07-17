using System;
using System.Linq;

namespace DefiningClasses
{
    class Program
    {
        static void Main(string[] args)
        {
            Family family = new Family();
            int membersCount = int.Parse(Console.ReadLine());
            for (int i = 0; i < membersCount; i++)
            {
                var input = Console.ReadLine().Split().ToArray();
                string name = input[0];
                int age = int.Parse(input[1]);
                Person person = new Person(age, name);
                family.AddMembers(person);
            }

            Console.WriteLine(family.GetOldestMember().Name + " " + family.GetOldestMember().Age);
        }
    }
}
