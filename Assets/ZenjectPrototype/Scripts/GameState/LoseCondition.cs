using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Zenject;
using ZenjectPrototype.Entities;
using ZenjectPrototype.Managers;

namespace ZenjectPrototype.GameState
{
    public class LoseCondition : IInitializable, ICondition
    {
        private IRoundManager roundManager;
        private IDataHolder<Entity> entities;

        public event EventHandler OnConditionMet;

        [Inject]
        public LoseCondition(IDataHolder<Entity> entities, IRoundManager roundManager)
        {
            this.entities = entities;
            this.roundManager = roundManager;
        }

        public void Initialize()
        {
            roundManager.OnRoundEnd += RoundManager_OnRoundEnd;
        }

        private void RoundManager_OnRoundEnd(object sender, EventArgs e)
        {
            if (!AreAllReceiversReady(entities.GetAll().OfType<PhotonReceiver>()) && roundManager.Rounds == 0)
            {
                if (OnConditionMet != null) OnConditionMet(this, new EventArgs());
            }
        }

        private bool AreAllReceiversReady(IEnumerable<PhotonReceiver> receivers)
        {
            return receivers.Count() == receivers.Where(x => x.Count > 0).Count();
        }
    }
}
