using System;
using System.Collections.Generic;
using System.IO.Enumeration;
using System.Linq;
using System.Text;
using PlayersAndMonsters.Common;
using PlayersAndMonsters.Core.Contracts;
using PlayersAndMonsters.Core.Factories.Contracts;
using PlayersAndMonsters.Models.BattleFields.Contracts;
using PlayersAndMonsters.Models.Cards.Contracts;
using PlayersAndMonsters.Models.Players.Contracts;
using PlayersAndMonsters.Repositories.Contracts;

namespace PlayersAndMonsters.Core
{
    public class ManagerController : IManagerController
    {
        private readonly CardRepository cardRepository;
        private readonly PlayerRepository playerRepository;
        private readonly CardFactory cardFactory;
        private readonly PlayerFactory playerFactory;
        private readonly BattleField battleField;

        public ManagerController()
        {
            this.cardRepository = new CardRepository();
            this.playerRepository = new PlayerRepository();
            this.cardFactory = new CardFactory();
            this.playerFactory = new PlayerFactory();
            this.battleField = new BattleField();
        }

        public string AddPlayer(string type, string username)
        {
            IPlayer player = this.playerFactory.CreatePlayer(type, username);
            this.playerRepository.Add(player);
            return string.Format(ConstantMessages.SuccessfullyAddedPlayer, type, username);
        }

        public string AddCard(string type, string name)
        {
            ICard card = this.cardFactory.CreateCard(type, name);
            this.cardRepository.Add(card);
            return string.Format(ConstantMessages.SuccessfullyAddedCard, type, name);
        }

        public string AddPlayerCard(string username, string cardName)
        {
            playerRepository.Find(username).CardRepository.Add(this.cardRepository.Find(cardName));
            return string.Format(ConstantMessages.SuccessfullyAddedPlayerWithCards, cardName, username);
        }

        public string Fight(string attackUser, string enemyUser)
        {
            IPlayer attackPlayer = playerRepository.Find(attackUser);
            IPlayer enemyPlayer = playerRepository.Find(enemyUser);
            this.battleField.Fight(attackPlayer, enemyPlayer);
            return string.Format(ConstantMessages.FightInfo, attackPlayer.Health, enemyPlayer.Health);
        }

        public string Report()
        {
            var sb = new StringBuilder();
            foreach (var player in playerRepository.Players)
            {
                sb.AppendLine(string.Format(ConstantMessages.PlayerReportInfo, player.Username, player.Health, player.CardRepository.Cards.Count));
                foreach (var card in player.CardRepository.Cards)
                {
                    sb.AppendLine(string.Format(ConstantMessages.CardReportInfo, card.Name, card.DamagePoints));
                }
                sb.AppendLine(string.Format(ConstantMessages.DefaultReportSeparator));
            }
            return sb.ToString().TrimEnd();
        }
    }
}
