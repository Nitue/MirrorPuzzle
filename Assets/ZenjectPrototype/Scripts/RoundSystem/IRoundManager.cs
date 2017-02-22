using System;
using ZenjectPrototype.ResourceSystem;

namespace ZenjectPrototype.RoundSystem
{
    public interface IRoundManager
    {
        bool IsRoundGoing { get; }
        IResource<int> Rounds { get; }
        void StartRound();
        event EventHandler OnRoundStart;
        event EventHandler OnRoundEnd;
    }
}
