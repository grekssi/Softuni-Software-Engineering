using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ViceCity.Models.Guns.Contracts;
using ViceCity.Models.Guns.Models;
using ViceCity.Models.Neghbourhoods.Models;
using ViceCity.Models.Players.Contracts;
using ViceCity.Models.Players.Models;

namespace ViceCity.Core.Contracts
{
    public class Controller : IController
    {
        private IPlayer mainPlayer;
        private List<IPlayer> civilPlayers;
        private Queue<IGun> guns;
        GangNeighborhood gang = new GangNeighborhood();
        private int mainpointsoriginal;
        public Controller()
        {
            this.mainPlayer = new MainPlayer();
            this.civilPlayers = new List<IPlayer>();
            this.guns = new Queue<IGun>();
            mainpointsoriginal = mainPlayer.LifePoints;
        }
        public string AddPlayer(string name)
        {
            var player = new CivilPlayer(name);
            this.civilPlayers.Add(player);
            return $"Successfully added civil player: {name}!";
        }

        public string AddGun(string type, string name)
        {
            switch (type)
            {
                case "Pistol":
                    this.guns.Enqueue(new Pistol(name));
                    break;
                case "Rifle":
                    this.guns.Enqueue(new Rifle(name));
                    break;
                default:
                    return "Invalid gun type!";
            }

            return $"Successfully added {name} of type: {type}";
        }

        public string AddGunToPlayer(string name)
        {
            if (!guns.Any())
            {
                return "There are no guns in the queue!";
            }

            if (name == "Vercetti")
            {
                var gunmain = guns.Dequeue();
                mainPlayer.GunRepository.Add(gunmain);
                return $"Successfully added {gunmain.Name} to the Main Player: Tommy Vercetti";
            }

            if (civilPlayers.All(x => x.Name != name))
            {
                return $"Civil player with that name doesn't exists!";
            }

            var player = civilPlayers.FirstOrDefault(x => x.Name == name);
            var gun = guns.Dequeue();
            player.GunRepository.Add(gun);
            return $"Successfully added {gun.Name} to the Civil Player: {player.Name}";
        }

        public string Fight()
        {
            gang.Action(mainPlayer, civilPlayers);
            if (mainPlayer.LifePoints == mainpointsoriginal && !civilPlayers.Any(x => x.IsAlive == false))
            {
                return "Everything is okay!";
            }
            else
            {
                var sb = new StringBuilder();
                sb.AppendLine("A fight happened:");
                sb.AppendLine($"Tommy live points: {mainPlayer.LifePoints}!");
                sb.AppendLine($"Tommy has killed: {this.civilPlayers.Count(x => x.IsAlive == false)} players!");
                sb.AppendLine($"Left Civil Players: {this.civilPlayers.Count(x => x.IsAlive)}!");
                this.civilPlayers.RemoveAll(x => x.IsAlive == false);
                return sb.ToString().TrimEnd();
            }
        }
    }
}
