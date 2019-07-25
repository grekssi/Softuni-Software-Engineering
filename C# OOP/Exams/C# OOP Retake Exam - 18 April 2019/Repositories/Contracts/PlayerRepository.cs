using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using PlayersAndMonsters.Models.Players.Contracts;

namespace PlayersAndMonsters.Repositories.Contracts
{
    public class PlayerRepository : IPlayerRepository
    {
        private int count;

        public int Count
        {
            get => this.count;
            private set { this.count = value; }
        }
        private List<IPlayer> players = new List<IPlayer>();
        public IReadOnlyCollection<IPlayer> Players => this.players.AsReadOnly();
        public void Add(IPlayer player)
        {
            if (player == null)
            {
                throw new ArgumentException("Player cannot be null!");
            }

            if (this.Players.Any(x => x.Username == player.Username))
            {
                throw new ArgumentException($"Player {player.Username} already exists!");
            }

            this.players.Add(player);
        }

        public bool Remove(IPlayer player)
        {
            if (player == null)
            {
                throw new ArgumentException("Player cannot be null!");
            }

            if (Players.Select(x => x.Username).Contains(player.Username))
            {
                var toRemove = Players.FirstOrDefault(x => x.Username == player.Username);
                players.Remove(toRemove);
                return true;
            }
            else
            {
                return false;
            }
        }

        public IPlayer Find(string username)
        {
            return this.Players.FirstOrDefault(x => x.Username == username);
        }
    }
}
