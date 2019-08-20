using System;
using System.Collections.Generic;
using System.Text;

namespace ViceCity.Models.Players.Models
{
    public class MainPlayer : Player
    {
        private const int InitialLifePoints = 100;
        private const string MainName = "Tommy Vercetti";

        public MainPlayer()
            : base(MainName, InitialLifePoints)
        {
        }
    }
}
