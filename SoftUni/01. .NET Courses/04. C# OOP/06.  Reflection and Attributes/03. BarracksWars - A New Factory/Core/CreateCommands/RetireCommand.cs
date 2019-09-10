using System;
using System.Collections.Generic;
using System.Text;
using _03BarracksFactory.Contracts;
using _03BarracksFactory.Models.Units;
using P03_BarraksWars.Attributes;

namespace P03_BarraksWars.Core.CreateCommands
{
    public class RetireCommand : Command
    {
        [Inject]
        private IRepository repository;

        private string[] data;
        public RetireCommand(string[] data) : base(data)
        {
            this.data = data;
        }

        public override string Execute()
        {
            if (this.repository.RemoveUnit(data[1]))
            {
                return "UnitType retired!";
            }
            else
            {
                throw new ArgumentException("No such units in repository");
            }
        }
    }
}
