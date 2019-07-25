    using System;
using System.Collections.Generic;
    using System.Linq;
    using System.Runtime.Serialization;
    using System.Text;
    using PlayersAndMonsters.Models.Players.Contracts;

    namespace PlayersAndMonsters.Models.BattleFields.Contracts
{
    public class BattleField : IBattleField
    {
        public void Fight(IPlayer attackPlayer, IPlayer enemyPlayer)
        {
            if (attackPlayer.IsDead == true || enemyPlayer.IsDead == true)
            {
                throw new ArgumentException("Player is dead!");
            }

            if (attackPlayer.GetType().Name == "Beginner")
            {
                attackPlayer.Health += 40;
                foreach (var card in attackPlayer.CardRepository.Cards)
                {
                    card.DamagePoints += 30;
                }
            }

            if (enemyPlayer.GetType().Name == "Beginner")
            {
                enemyPlayer.Health += 40;
                foreach (var card in enemyPlayer.CardRepository.Cards)
                {
                    card.DamagePoints += 30;
                }
            }

            attackPlayer.Health += attackPlayer.CardRepository.Cards.Sum(c => c.HealthPoints);

            enemyPlayer.Health += enemyPlayer.CardRepository.Cards.Sum(c => c.HealthPoints);

            while (true)
            {
                int attackPlayerPoints = attackPlayer.CardRepository.Cards.Sum(x => x.DamagePoints);
                enemyPlayer.TakeDamage(attackPlayerPoints);
                if (enemyPlayer.Health == 0)
                {
                    break;
                }

                int enemyPlayerPoints = enemyPlayer.CardRepository.Cards.Sum(x => x.DamagePoints);
                attackPlayer.TakeDamage(enemyPlayerPoints);
                if (attackPlayer.Health == 0)
                {
                    break;
                }
            }
        }
    }
}
