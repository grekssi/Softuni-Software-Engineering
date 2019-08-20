using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.PortableExecutable;
using System.Security.Cryptography.X509Certificates;

namespace Collection
{
    public class Program
    {
        static void Main(string[] args)
        {
            var hashedPeople = new HashSet<Person>();
            var sortedPeople = new SortedSet<Person>();

            var inputLines = int.Parse(Console.ReadLine());

            for (int i = 0; i < inputLines; i++)

            {
                var info = Console.ReadLine().Split(' ').ToArray();
                string name = info[0];
                int age = int.Parse(info[1]);

                var person = new Person(name, age);
                 
                hashedPeople.Add(person);
                sortedPeople.Add(person);
            }

            Console.WriteLine(hashedPeople.Count);
            Console.WriteLine(sortedPeople.Count);

        }
    }
}
