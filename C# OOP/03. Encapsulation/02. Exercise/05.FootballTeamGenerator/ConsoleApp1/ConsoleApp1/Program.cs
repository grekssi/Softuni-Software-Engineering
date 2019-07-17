using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading;

namespace ConsoleApp1
{
    public class Program
    {
        static void Main(string[] args)
        {
            var teams = new List<Team>();
            while (true)
            {
                try
                {
                    var command = Console.ReadLine().Split(';').ToArray();

                    if (command[0] == "END")
                    {
                        break;
                    }

                    if (command[0] == "Team")
                    {
                        string name = command[1];
                        Team team = new Team(name);
                        teams.Add(team);
                    }

                    if (command[0] == "Add")
                    {
                        string teamName = command[1];
                        if (teams.Select(x => x.Name).Contains(teamName))
                        {
                            string playerName = command[2];
                            int endurance = int.Parse(command[3]);
                            int sprint = int.Parse(command[4]);
                            int dribble = int.Parse(command[5]);
                            int passing = int.Parse(command[6]);
                            int shooting = int.Parse(command[7]);
                            Stats stats = new Stats(endurance, sprint, dribble, passing, shooting);
                            Player player = new Player(playerName, stats);
                            teams.Find(x => x.Name == teamName).Add(player);
                        }
                        else
                        {
                            Console.WriteLine($"Team {teamName} does not exist.");
                        }
                    }

                    if (command[0] == "Remove")
                    {
                        string teamName = command[1];
                        if (teams.Select(x => x.Name).Contains(teamName))
                        {
                            string playerName = command[2];
                            teams.Find(x => x.Name == teamName).Remove(playerName);
                        }
                        else
                        {
                            Console.WriteLine($"Team {teamName} does not exist.");
                        }
                    }

                    if (command[0] == "Rating")
                    {
                        string teamName = command[1];
                        if (teams.Select(x => x.Name).Contains(teamName))
                        {
                            Console.WriteLine(teams.Find(x => x.Name == teamName).Rating());
                        }
                        else
                        {
                            Console.WriteLine($"Team {teamName} does not exist.");
                        }
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
                
            }
        }
    }
}
