using System;

namespace ConsoleApp1
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            string name = Console.ReadLine();
            int age = int.Parse(Console.ReadLine());

            Child child = new Child(age, name);
            Console.WriteLine(child);
        }
    }
}
