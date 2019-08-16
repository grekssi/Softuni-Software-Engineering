using System;

namespace DefiningClasses
{
    class Program
    {
        static void Main(string[] args)
        {
            Person person = new Person(12);
            Console.WriteLine(person.Age);
            Console.WriteLine(person.Name);
        }
    }
}
