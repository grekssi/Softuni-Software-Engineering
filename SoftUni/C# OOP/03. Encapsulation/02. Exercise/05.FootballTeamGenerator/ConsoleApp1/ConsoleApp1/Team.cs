using System;
using System.Collections.Generic;
using System.Linq;

namespace ConsoleApp1
{
    public class Team
    {
        private string name;
        public List<Player> Players { get; set; }

        public Team(string name)
        {
            this.name = name;
            this.Players = new List<Player>();
        }

        public string Name
        {
            get => this.name;
            private set => this.name = value;
        }

        public string Rating()
        {
            if (Players.Count == 0)
            {
                return "" + this.Name + " - " + "0";
            }
            var average = Players.Average(x => x.Stats.GetAgevare());
            return "" + this.Name + " - " + (int)(average / Players.Count);
        }

        public void Add(Player player)
        {
            this.Players.Add(player);
        }

        public void Remove(string name)
        {
            if (Players.Any(x => x.Name == name))
            {
                Players.Remove(Players.Find(x => x.Name == name));
            }
            else
            {
                throw new ArgumentException($"Player {name} is not in {this.Name} team.");
            }
        }
    }
}
