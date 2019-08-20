using System;
using System.Collections.Generic;
using System.Text;

namespace WildLife
{
    internal class Sounds
    {
        private Dictionary<string, string> sounds = new Dictionary<string, string>()
        {
            {"owl", "Hoot Hoot"},
            {"hen", "Cluck"},
            {"mouse", "Squeak"},
            {"dog", "Woof!"},
            {"cat", "Meow"},
            {"tiger", "ROAR!!!"}
        };

        public string ProduceSound(string animal)
        {
            if (sounds.ContainsKey(animal))
            {
                return sounds[animal];
            }
            else
            {
                throw new ArgumentException("Animal not found!");
            }
        }
    }
}
