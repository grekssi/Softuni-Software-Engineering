using PlayersAndMonsters.Models.Cards.Contracts;

namespace PlayersAndMonsters.Core.Factories.Contracts
{
    public class CardFactory : ICardFactory
    {
        private ICard card;
        public ICard CreateCard(string type, string name)
        {
            switch (type)
            {
                case "Magic":
                    card = new MagicCard(name);
                    break;
                case "Trap":
                    card = new TrapCard(name);
                    break;
            }

            return card;
        }
    }
}
