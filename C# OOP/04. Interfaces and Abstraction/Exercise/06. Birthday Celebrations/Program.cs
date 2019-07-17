using System;
using System.Collections.Generic;
using System.Linq;

namespace BirthdayCelebration
{
    class Program
    {
        static List<IBirthable> birthed = new List<IBirthable>();
        static void Main(string[] args)
        {
            while (true)
            {
                var input = Console.ReadLine().Split(' ').ToArray();
                string prior = input[0];
                if (prior == "End")
                {
                    break;
                }

                switch (prior)
                {
                    case "Citizen":
                        CreateCitizen(input);
                        break;
                    case "Robot":
                        CreateRobot(input);
                        break;
                    case "Pet":
                        CreatePet(input);
                        break;
                }
            }

            string dateToSearch = Console.ReadLine();
            foreach (var item in birthed)
            {
                string year = item.BirthDate.ToString().Split('/')[2];
                if (year == dateToSearch)
                {
                    Console.WriteLine(item.BirthDate);
                }
            }
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
            string name = input[1];
            int age = int.Parse(input[2]);
            string id = input[3];
            string birthDate = input[4];

            Citizen citizen = new Citizen(id, birthDate, name, age);
            birthed.Add(citizen);
        }
    }
}
