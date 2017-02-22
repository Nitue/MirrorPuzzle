using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using Zenject;
using ZenjectPrototype.Managers;

namespace ZenjectPrototype.GameState
{
    public class LevelRoundManager : IInitializable, IRoundManager
    {
        private ICondition endCondition;
        private bool isRoundGoing;

        public event EventHandler OnRoundStart;
        public event EventHandler OnRoundEnd;

        public bool IsRoundGoing
        {
            get { return isRoundGoing; }
        }

        public IResource<int> Rounds { get; private set; }

        [Inject]
        public LevelRoundManager(ICondition endCondition, IResource<int> rounds)
        {
            this.endCondition = endCondition;
            this.Rounds = rounds;
        }

        public void Initialize()
        {
            endCondition.OnConditionMet += EndCondition_OnConditionMet;
        }

        public void StartRound()
        {
            if(Rounds.Spend(1))
            {
                isRoundGoing = true;
                if (OnRoundStart != null) OnRoundStart(this, new EventArgs());
            }
        }

        public void ResetRounds()
        {
            Rounds.Restock(Rounds.StockCap);
        }

        private void EndCondition_OnConditionMet(object sender, EventArgs e)
        {
            isRoundGoing = false;
            if (OnRoundEnd != null) OnRoundEnd(this, new EventArgs());
        }
    }
}
