﻿using PlayersAndMonsters.Repositories.Contracts;

namespace PlayersAndMonsters.Models.Players.Contracts
{
    public class Beginner : Player
    {
        public Beginner(ICardRepository cardRepository, string username)
            : base(cardRepository, username, 50)
        {
        }
    }
}
