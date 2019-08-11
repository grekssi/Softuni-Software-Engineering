using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using ViceCity.Models.Neghbourhoods.Contracts;
using ViceCity.Models.Players.Contracts;

namespace ViceCity.Models.Neghbourhoods.Models
{
    public class GangNeighborhood : INeighbourhood
    {
        public void Action(IPlayer mainPlayer, ICollection<IPlayer> civilPlayers)
        {
            foreach (var civilPlayer in civilPlayers.Where(x => x.IsAlive))
            {
                foreach (var gun in mainPlayer.GunRepository.Models.Where(x => x.CanFire))
                {
                    while (gun.CanFire && civilPlayer.IsAlive)
                    {
                        civilPlayer.TakeLifePoints(gun.Fire());
                    }
                }
            }

            foreach (var civilPlayer in civilPlayers.Where(x => x.IsAlive))
            {
                foreach (var gun in civilPlayer.GunRepository.Models.Where(x => x.CanFire))
                {
                    while (gun.CanFire && mainPlayer.IsAlive)
                    {
                        mainPlayer.TakeLifePoints(gun.Fire());
                    }

                    if (!mainPlayer.IsAlive)
                    {
                        return;
                    }
                }
            }
        }
    }
}
