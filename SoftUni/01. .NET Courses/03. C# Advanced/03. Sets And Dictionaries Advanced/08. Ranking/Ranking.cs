using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace ConsoleApp216
{
    class Program
    {
        static void Main(string[] args)
        {
            var students = new Dictionary<string, Dictionary<string, int>>();
            var passwords = new Dictionary<string, string>();
            var points1 = new Dictionary<string, int>();
            while (true)
            {
                string input = Console.ReadLine();
                if (input == "end of contests")
                {
                    break;
                }
                var split = input.Split(':');
                string course = split[0];
                string password = split[1];
                passwords.Add(course, password);
            }
            while (true)
            {
                string command = Console.ReadLine();
                if (command == "end of submissions")
                {
                    int bestpoints = points1.Values.Max();
                    string bestName = string.Empty;
                    foreach (var item in points1)
                    {
                        if (item.Value == bestpoints)
                        {
                            bestName = item.Key;
                                break;
                        }
                    }
                    Console.WriteLine($"Best candidate is {bestName} with total {bestpoints} points.");
                    Console.WriteLine("Ranking: ");
                    foreach (var item in students.OrderBy(x => x.Key))
                    {
                        Console.WriteLine(item.Key);
                        foreach (var kvp in item.Value.OrderByDescending(x => x.Value))
                        {
                            Console.WriteLine($"#  {kvp.Key} -> {kvp.Value}");
                        }
                    }
                    break;
                }
                var split = command.Split(new string[] { "=>" }, StringSplitOptions.None);
                string courseName = split[0];
                string password = split[1];
                string name = split[2];
                int points = int.Parse(split[3]);
                if (passwords.ContainsKey(courseName) && passwords[courseName] == password)
                {
                    if (students.ContainsKey(name))
                    {
                        if (students[name].ContainsKey(courseName))
                        {
                            if (students[name][courseName] < points)
                            {
                                points1[name] += points - students[name][courseName];
                                students[name][courseName] = points;
                            }
                        }
                        else
                        {
                            points1[name] += points;
                            students[name].Add(courseName, points);
                        }
                    }
                    else
                    {
                        students.Add(name, new Dictionary<string, int>());
                        students[name].Add(courseName, points);
                        points1.Add(name, points);
                    }
                }
            }
        }
    }
}
