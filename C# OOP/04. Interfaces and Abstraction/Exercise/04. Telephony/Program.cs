using System;
using System.Text.RegularExpressions;

namespace Telephony
{
    public class Program
    {
        static void Main(string[] args)
        {
            Regex site = new Regex(@"^([^\d]*)$");
            Regex phone = new Regex(@"[\d]+");

            var inputPhones = Console.ReadLine().Split(' ');
            SmartPhone iphone = new SmartPhone();
            foreach (var inputPhone in inputPhones)
            {
                if (phone.Match(inputPhone).Success)
                {
                    Console.WriteLine(iphone.Call(inputPhone));
                }
                else
                {
                    Console.WriteLine("Invalid number!");
                }
                
            }

            var inputSites = Console.ReadLine().Split(' ');
            foreach (var inputSite in inputSites)
            {
                if (site.Match(inputSite).Success)
                {
                    Console.WriteLine(iphone.Browse(inputSite));
                }
                else
                {
                    Console.WriteLine("Invalid URL!");
                }
            }
        }
    }
}
