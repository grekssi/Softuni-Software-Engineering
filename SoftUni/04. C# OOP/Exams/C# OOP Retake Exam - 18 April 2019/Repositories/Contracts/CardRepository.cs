using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.PortableExecutable;
using System.Text;
using PlayersAndMonsters.Models.Cards.Contracts;

namespace PlayersAndMonsters.Repositories.Contracts
{
    public class CardRepository : ICardRepository
    {
        public int Count { get; }

        private List<ICard> cards = new List<ICard>();
        public IReadOnlyCollection<ICard> Cards => this.cards.AsReadOnly();
        public void Add(ICard card)
        {
            if (card == null)
            {
                throw new ArgumentException("Card cannot be null!");
            }

            if (Cards.Any(x => x.Name == card.Name))
            {
                throw new ArgumentException($"Card {card.Name} already exists!");
            }

            cards.Add(card);
        }

        public bool Remove(ICard card)
        {
            if (card == null)
            {
                throw new ArgumentException("Card cannot be null!");
            }

            if (Cards.Any(x => x.Name == card.Name))
            {
                var toRemove = cards.FirstOrDefault(x => x.Name == card.Name);
                cards.Remove(toRemove);
                return true;
            }
            else
            {
                return false;
            }
        }

        public ICard Find(string name)
        {
            return this.Cards.FirstOrDefault(x => x.Name == name);
        }
    }
}
