using System;
using System.Collections.Generic;
using System.Linq;
using MilitaryElite2.Models;

namespace MilitaryElite2
{
    class Program
    {
        private static List<Soldier> soldiers = new List<Soldier>();
        static void Main(string[] args)
        {
            while (true)
            {
                try
                {
                    var input = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).ToArray();
                    string type = input[0];
                    if (type == "End")
                    {
                        foreach (var item in soldiers)
                        {
                            Console.WriteLine(item);
                        }

                        break;
                    }
                    switch (type)
                    {
                        case "Private":
                            CreatePrivate(input);
                            break;
                        case "LieutenantGeneral":
                            CreateLieutenant(input);
                            break;
                        case "Engineer":
                            CreateEngineer(input);
                            break;
                        case "Commando":
                            CreateCommando(input);
                            break;
                        case "Spy":
                            CreateSpy(input);
                            break;
                    }
                }
                catch (Exception)
                {
                }
            }
        }

        private static void CreateSpy(string[] input)
        {
            int id = int.Parse(input[1]);
            string firstName = input[2];
            string lastName = input[3];
            int codeNumber = int.Parse(input[4]);
            Spy spy = new Spy(id, firstName,lastName,codeNumber);
            soldiers.Add(spy);
        }

        private static void CreateCommando(string[] input)
        {
            int id = int.Parse(input[1]);
            string firstName = input[2];
            string lastName = input[3];
            decimal salary = decimal.Parse(input[4]);
            string corps = input[5];
            Commando commando = new Commando(id, firstName, lastName, salary, corps);
            soldiers.Add(commando);
            for (int i = 6; i < input.Length; i+=2)
            {
                string codeName = input[i];
                string state = input[i + 1];
                try
                {
                    Mission mission = new Mission(codeName, state);
                    commando.AddMission(mission);
                }
                catch (Exception)
                {
                }
            }
        }

        private static void CreateEngineer(string[] input)
        {
            int id = int.Parse(input[1]);
            string firstName = input[2];
            string lastName = input[3];
            decimal salary = decimal.Parse(input[4]);
            string corps = input[5];
            Engineer engineer = new Engineer(id, firstName,lastName,salary,corps);
            soldiers.Add(engineer);
            for (int i = 6; i < input.Length; i+=2)
            {
                string repairPart = input[i];
                int repairHours = int.Parse(input[i + 1]);
                Repair repair = new Repair(repairPart, repairHours);
                engineer.AddRepair(repair);
            }
        }

        private static void CreateLieutenant(string[] input)
        {
            int id = int.Parse(input[1]);
            string firstName = input[2];
            string lastName = input[3];
            decimal salary = decimal.Parse(input[4]);
            LieutenantGeneral general = new LieutenantGeneral(id, firstName, lastName, salary);
            soldiers.Add(general);
            for (int i = 5; i < input.Length; i++)
            {
                int privateId = int.Parse(input[i]);
                Private soldierToAdd = (Private) soldiers.FirstOrDefault(x => x.Id == privateId);
                general.AddPrivate(soldierToAdd);
            }
        }

        private static void CreatePrivate(string[] input)
        {
            int id = int.Parse(input[1]);
            string firstName = input[2];
            string lastName = input[3];
            decimal salary = decimal.Parse(input[4]);
            Private privateSoldier = new Private(id, firstName, lastName, salary);
            soldiers.Add(privateSoldier);
        }

    }
}
