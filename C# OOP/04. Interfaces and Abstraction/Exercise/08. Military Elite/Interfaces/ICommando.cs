using System.Collections.Generic;

namespace MilitaryElite2.Interfaces
{
    public interface ICommando
    {
        IReadOnlyCollection<IMission> Missions { get; }
    }
}
