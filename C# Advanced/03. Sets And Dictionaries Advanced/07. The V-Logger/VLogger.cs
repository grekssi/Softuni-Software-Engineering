using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp218
{
    class Program
    {
        static void Main(string[] args)
        {
            var Vlogger = new Dictionary<string, int[]>();
            var vloggerFollowers = new Dictionary<string, HashSet<string>>();
            while (true)
            {
                string input = Console.ReadLine();
                if (input == "Statistics")
                {
                    string bestMan = string.Empty;
                    int mostFollowers = 0;
                    int lessFollowings = int.MaxValue;
                    foreach (var item in Vlogger)
                    {
                        if (item.Value[0] > mostFollowers)
                        {
                            mostFollowers = item.Value[0];
                            lessFollowings = item.Value[1];
                            bestMan = item.Key;
                        }

                        if (item.Value[0] == mostFollowers && item.Value[1] < lessFollowings)
                        {
                            mostFollowers = item.Value[0];
                            lessFollowings = item.Value[1];
                            bestMan = item.Key;
                        }
                    }
                    Console.WriteLine($"The V-Logger has a total of {Vlogger.Count} vloggers in its logs.");
                    Console.WriteLine($"1. {bestMan} : {mostFollowers} followers, {lessFollowings} following");
                    foreach (var item in vloggerFollowers[bestMan].OrderBy(x => x))
                    {
                        Console.WriteLine($"*  {item}");
                    }

                    Vlogger.Remove(bestMan);
                    int i = 2;
                    foreach (var item in Vlogger.OrderByDescending(x => x.Value[0]).ThenBy(x => x.Value[1]))
                    {
                        Console.WriteLine($"{i}. {item.Key} : {item.Value[0]} followers, {item.Value[1]} following");
                        i++;
                    }
                    break;
                }
                var command = input.Split(' ').ToArray();
                string vloggerNAme = command[0];
                string toDo = command[1];
                if (toDo == "joined")
                {
                    if (!Vlogger.ContainsKey(vloggerNAme))
                    {
                        Vlogger.Add(vloggerNAme, new int[2]);
                        vloggerFollowers.Add(vloggerNAme, new HashSet<string>());
                    }
                }

                if (toDo == "followed")
                {
                    string follower = command[2];
                    if (Vlogger.ContainsKey(vloggerNAme) && Vlogger.ContainsKey(follower) && vloggerNAme != follower
                        && !vloggerFollowers[follower].Contains(vloggerNAme))
                    {
                        Vlogger[vloggerNAme][1]++;
                        Vlogger[follower][0]++;
                        vloggerFollowers[follower].Add(vloggerNAme);
                    }
                }
            }
        }
    }
}
