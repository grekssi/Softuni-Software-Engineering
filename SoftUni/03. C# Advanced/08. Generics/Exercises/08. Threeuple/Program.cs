using System;
using System.Dynamic;
using System.Runtime.InteropServices.ComTypes;
using System.Threading.Tasks.Sources;

namespace tuplegenerics
{
    class Program
    {
        static void Main(string[] args)
        {
            var firstLine = Console.ReadLine().Split(' ');
            string firstname = firstLine[0] + " " + firstLine[1];
            string city = firstLine[2];
            string town = firstLine[3];
            var firstTuple = new Tuple<string,string, string>(firstname, city, town);
            Console.WriteLine($"{firstTuple.item1} -> {firstTuple.item2} -> {firstTuple.item3}");

            var secondLine = Console.ReadLine().Split(' ');
            string name = secondLine[0];
            int liters = int.Parse(secondLine[1]);
            string drunk = secondLine[2];
            bool isdrunk = true;
            if (drunk == "drunk")
            {
                isdrunk = true;
            }
            else
            {
                isdrunk = false;
            }
            var secondTuple = new Tuple<string, int, bool>(name, liters, isdrunk);
            Console.WriteLine($"{secondTuple.item1} -> {secondTuple.item2} -> {secondTuple.item3}");

            var thirdline = Console.ReadLine().Split(' ');
            string namer = thirdline[0];
            double doubler = double.Parse(thirdline[1]);
            string bankName = thirdline[2];
            var thirdTuple = new Tuple<string, double, string>(namer, doubler, bankName);
            Console.WriteLine($"{thirdTuple.item1} -> {thirdTuple.item2} -> {thirdTuple.item3}");

        }
    }
}
