using PlayersAndMonsters.Models.Players.Contracts;
using PlayersAndMonsters.Repositories.Contracts;

namespace PlayersAndMonsters.Core.Factories.Contracts
{
    public class PlayerFactory : IPlayerFactory
    {
        private IPlayer player;
        public IPlayer CreatePlayer(string type, string username)
        {
            switch (type)
            {
                case "Beginner":
                    player = new Beginner(new CardRepository(), username);
                    break;
                case "Advanced":
                    player = new Advanced(new CardRepository(), username);
                    break;
            }

            return player;
        }
    }
}
