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
        private int roundsMax;
        private int rounds;
        private bool isRoundGoing;

        public event EventHandler OnRoundStart;
        public event EventHandler OnRoundEnd;

        public bool IsRoundGoing
        {
            get { return isRoundGoing; }
        }

        public int Rounds
        {
            get { return rounds; }
        }

        [Inject]
        public LevelRoundManager(ICondition endCondition, int rounds)
        {
            this.endCondition = endCondition;
            this.roundsMax = rounds;
            this.rounds = rounds;
        }

        public void Initialize()
        {
            endCondition.OnConditionMet += EndCondition_OnConditionMet;
        }

        public void StartRound()
        {
            if(rounds > 0)
            {
                rounds--;
                isRoundGoing = true;
                if (OnRoundStart != null) OnRoundStart(this, new EventArgs());
            }
        }

        public void ResetRounds()
        {
            rounds = roundsMax;
        }

        private void EndCondition_OnConditionMet(object sender, EventArgs e)
        {
            isRoundGoing = false;
            if (OnRoundEnd != null) OnRoundEnd(this, new EventArgs());
        }
    }
}
