using System;
using System.Collections.Generic;
using System.Linq;
using Zenject;
using ZenjectPrototype.Entities;

namespace ZenjectPrototype.RoundSystem
{
    public class WinCondition : IInitializable, ICondition
    {
        private IDataHolder<Entity> entities;
        private IRoundManager roundManager;

        public event EventHandler OnConditionMet;

        [Inject]
        public WinCondition(IDataHolder<Entity> entities, IRoundManager roundManager)
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
            if(AreAllReceiversReady(entities.GetAll().OfType<PhotonReceiver>()))
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
