using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Security;
using System.Text;

namespace SpaceStationRecruitment
{
    class SpaceStation
    {
        private string name;
        private int capacity;
        private List<Astronaut> data;

        public SpaceStation(string name, int capacity)
        {
            this.Name = name;
            this.Capacity = capacity;
            this.data = new List<Astronaut>();
        }

        public string Name
        {
            get { return this.name; }
            set { this.name = value; }
        }

        public int Capacity
        {
            get { return this.capacity; }
            set { this.capacity = value; }
        }

        public void Add(Astronaut astronaut)
        {
            this.data.Add(astronaut);
        }

        public bool Remove(string name)
        {
            var toRemove = data.FirstOrDefault(x => x.Name == name);
            data.Remove(toRemove);
            if (toRemove != null)
            {
                return true;
            }
            else
            {
                return false;
            }
            
        }

        public Astronaut GetOldestAstronaut()
        {
            var toReturn = data.OrderByDescending(x => x.Age).FirstOrDefault();
            return toReturn;
        }

        public Astronaut GetAstronaut(string name)
        {
            var toReturn = data.FirstOrDefault(x => x.Name == name);
            return toReturn;
        }

        public int Count => this.data.Count();

        public string Report()
        {
            var sb = new StringBuilder();
            sb.AppendLine($"Astronauts working at Space Station {this.Name}:");
            sb.AppendLine(string.Join(Environment.NewLine, data));
            return sb.ToString().TrimEnd();
        }
    }
}
