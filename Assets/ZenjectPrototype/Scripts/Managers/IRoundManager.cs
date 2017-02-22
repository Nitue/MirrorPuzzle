using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ZenjectPrototype.Managers
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
