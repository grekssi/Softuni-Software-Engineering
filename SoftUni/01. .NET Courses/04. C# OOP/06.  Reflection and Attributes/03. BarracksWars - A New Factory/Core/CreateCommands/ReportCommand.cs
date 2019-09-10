using System;
using System.Collections.Generic;
using System.Text;
using _03BarracksFactory.Contracts;
using P03_BarraksWars.Attributes;

namespace P03_BarraksWars.Core.CreateCommands
{
    public class ReportCommand : Command
    {
        [Inject]
        private IRepository repository;

        private string[] data;
        public ReportCommand(string[] data) : base(data)
        {
            this.data = data;
        }

        public override string Execute()
        {
            string output = this.repository.Statistics;
            return output;
        }
    }
}
