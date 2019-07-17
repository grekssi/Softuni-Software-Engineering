using System;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace CollectionH
{
    class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                var input = Console.ReadLine().Split(' ').ToArray();
                string name = input[0];
                if (name == "End")
                {
                    break;
                }
                Citizen citizen = new Citizen(name);
                IPerson person = citizen;
                Console.WriteLine(person.GetName());
                IResident resident = citizen;
                Console.WriteLine(resident.GetName());
            }
        }
    }
}
