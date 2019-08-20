using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ConsoleApp198
{
    class Program
    {
        static void Main(string[] args)
        {
            int iterations = int.Parse(Console.ReadLine());
            int totalweight = 0;
            Regex reg = new Regex(@"^n:(?<=n:)(?<Name>.+);t:(?<Kind>.+);c--(?<Country>[A-Za-z\s]+)$");
            Regex letters = new Regex(@"[A-Za-z\s]+");
            Regex numbers = new Regex(@"[\d]");
            for (int i = 0; i < iterations; i++)
            {
                string command = Console.ReadLine();                
                var nameSbu = new StringBuilder();
                var kindSbu = new StringBuilder();
                var countrySbu = new StringBuilder();
                string nameMatch = reg.Match(command).Groups["Name"].Value.ToString();
                string kindMatch = reg.Match(command).Groups["Kind"].Value.ToString();
                string countryMatch = reg.Match(command).Groups["Country"].Value.ToString();
                
                if (!string.IsNullOrEmpty(nameMatch) && !string.IsNullOrEmpty(kindMatch)
                    && !string.IsNullOrEmpty(countryMatch))
                {
                    
                    var numbersMatch = numbers.Matches(command);
                    foreach (Match item in numbersMatch)
                    {
                        totalweight += int.Parse(item.ToString());

                    }

                    var name = letters.Matches(nameMatch);
                    foreach (Match item in name)
                    {
                        nameSbu.Append(item.ToString());
                    }
                    var kind = letters.Matches(kindMatch);
                    foreach (Match item in kind)
                    {
                        kindSbu.Append(item.ToString());
                    }
                    var country = letters.Matches(countryMatch);
                    foreach (Match item in country)
                    {
                        countrySbu.Append(item);
                    }
                   
                    Console.WriteLine($"{nameSbu.ToString()} is a {kindSbu.ToString()} from {countrySbu.ToString()}");
                    
                }
            }
            Console.WriteLine($"Total weight of animals: {totalweight}KG");
        }
    }
}
