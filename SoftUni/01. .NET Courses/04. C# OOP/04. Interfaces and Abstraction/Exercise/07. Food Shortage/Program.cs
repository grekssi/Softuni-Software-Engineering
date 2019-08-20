using System;
using System.Collections.Generic;
using System.Linq;

namespace BirthdayCelebration
{
    class Program
    {
        static List<IBirthable> birthed = new List<IBirthable>();
        static List<IBuyer> buyers = new List<IBuyer>();
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            for (int i = 0; i < n; i++)
            {
                var input = Console.ReadLine().Split(' ').ToArray();
                if (input.Length == 4)
                {
                    CreateCitizen(input);
                }

                if (input.Length == 3)
                {
                    CreateRebel(input);
                }
            }

            while (true)
            {
                string command = Console.ReadLine();
                if (command == "End")
                {
                    Console.WriteLine(buyers.Select(x => x.Food).Sum());
                    break;
                }

                if (buyers.Select(x => x.Name).Contains(command))
                {
                    buyers.FirstOrDefault(x => x.Name == command).BuyFood();
                }
            }

        }

        private static void CreateRebel(string[] input)
        {
            string name = input[0];
            int age = int.Parse(input[1]);
            string band = input[2];
            Rebel rebel = new Rebel(name, age, band);
            buyers.Add(rebel);
        }

        private static void CreatePet(string[] input)
        {
            string name = input[1];
            string birthDate = input[2];

            Pet pet = new Pet(name, birthDate);
            birthed.Add(pet);
        }

        private static void CreateRobot(string[] input)
        {
            string name = input[1];
            string id = input[2];

            Robot robot = new Robot(id, name);
        }

        private static void CreateCitizen(string[] input)
        {
            string name = input[0];
            int age = int.Parse(input[1]);
            string id = input[2];
            string birthDate = input[3];

            Citizen citizen = new Citizen(id, birthDate, name, age);
            birthed.Add(citizen);
            buyers.Add(citizen);
        }
    }
}
