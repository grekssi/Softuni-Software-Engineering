using PlayersAndMonsters.Repositories.Contracts;

namespace PlayersAndMonsters.Models.Players.Contracts
{
    public class Advanced : Player
    {
        public Advanced(ICardRepository cardRepository, string username)
            : base(cardRepository, username, 250)
        {
        }
    }
}
