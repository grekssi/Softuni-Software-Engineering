using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.PortableExecutable;

namespace DefiningClasses
{
    class Program
    {
        static void Main(string[] args)
        {
            var members = new List<Person>();
            int membersCount = int.Parse(Console.ReadLine());

            for (int i = 0; i < membersCount; i++)
            {
                var input = Console.ReadLine().Split().ToArray();
                string name = input[0];
                int age = int.Parse(input[1]);
                var newPerson = new Person(age, name);
                members.Add(newPerson);
            }

            foreach (var item in members.Where(x => x.Age > 30).OrderByDescending(x => x.Age))
            {
                Console.WriteLine($"{item.Name} - {item.Age}");
            }
            

        }
    }
}
