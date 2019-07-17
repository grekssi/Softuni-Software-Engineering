using System.Collections.Generic;

namespace MilitaryElite2.Interfaces
{
    public interface IEngineer
    {
        IReadOnlyCollection<IRepair> Repairs { get; }
    }
}
