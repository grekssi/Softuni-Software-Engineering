using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PokemonTrainer
{
    public class Trainer
    {
        private string name;
        private int numberOfBadges = 0;
        public List<Pokemon> pokemons;

        public List<Pokemon> Pokemons
        {
            get { return this.pokemons; }
        }

        public Trainer(string name)
        {
            this.name = name;
            this.numberOfBadges = 0;
            this.pokemons = new List<Pokemon>();
        }

        public string Name
        {
            get { return this.name; }
            set { this.name = value; }
        }

        public int NumberOfBadges
        {
            get { return this.numberOfBadges; }
            set { this.numberOfBadges++; }
        }


        public void RemoveDeadPokemons()
        {
            pokemons.RemoveAll(x => x.Health <= 0);
        }

        public void DecreaseHealth()
        {
            for (int i = 0; i < pokemons.Count; i++)
            {
                pokemons[i].Health -= 10;
            }
        }
    }
}
