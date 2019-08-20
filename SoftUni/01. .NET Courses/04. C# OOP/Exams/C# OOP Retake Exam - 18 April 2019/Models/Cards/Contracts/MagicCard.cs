namespace PlayersAndMonsters.Models.Cards.Contracts
{
    public class MagicCard : Card
    {
        public MagicCard(string name) 
            : base(name, 5, 80)
        {
        }
    }
}
