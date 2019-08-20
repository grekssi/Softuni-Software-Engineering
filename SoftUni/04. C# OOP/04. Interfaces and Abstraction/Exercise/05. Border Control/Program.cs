using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace BorderControlo
{
    public class Program
    {
        static void Main(string[] args)
        {
            var entered = new List<IEnter>();
            while (true)
            {
                var input = Console.ReadLine().Split(' ').ToArray();
                if (input[0] == "End")
                {
                    break;
                }
                if (input.Length == 3)
                {
                    string name = input[0];
                    int age = int.Parse(input[1]);
                    string id = input[2];
                    Citizen citizen = new Citizen(name, age, id);
                    entered.Add(citizen);
                }
                else if (input.Length == 2)
                {
                    string model = input[0];
                    string id = input[1];
                    Robot robot = new Robot(model, id);
                    entered.Add(robot);
                }
            }

            int invalidSeq = int.Parse(Console.ReadLine());

            foreach (var enter in entered.Where(x => x.Id.ToString().EndsWith(invalidSeq.ToString())))
            {
                Console.WriteLine(enter.Id);
            }
        }
    }
}
