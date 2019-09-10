using System;
using System.Collections.Generic;
using System.Text;
using _03BarracksFactory.Contracts;
using P03_BarraksWars.Attributes;

namespace P03_BarraksWars.Core.CreateCommands
{
    public class AddCommand : Command
    {
        [Inject]
        private IRepository repository;

        [Inject]
        private IUnitFactory unitFactory;

        private string[] data;

        public AddCommand(string[] data) 
            : base(data)
        {
            this.data = data;
        }

        public override string Execute()
        {
            string unitType = data[1];
            IUnit unitToAdd = this.unitFactory.CreateUnit(unitType);
            this.repository.AddUnit(unitToAdd);
            string output = unitType + " added!";
            return output;
        }
    }

}
