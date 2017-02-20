using System;
using System.Collections.Generic;
using System.Linq;
using Zenject;
using ZenjectPrototype.Entities;
using ZenjectPrototype.Entities.Capabilities;
using ZenjectPrototype.Managers;

namespace ZenjectPrototype.GameState
{
    public class EmitterTrigger : IInitializable
    {
        private IDataHolder<Entity> entities;
        private IRoundManager roundManager;

        [Inject]
        public EmitterTrigger(IDataHolder<Entity> entities, IRoundManager roundManager)
        {
            this.entities = entities;
            this.roundManager = roundManager;
        }

        public void Initialize()
        {
            roundManager.OnRoundStart += RoundManager_OnRoundStart;
        }

        private void RoundManager_OnRoundStart(object sender, EventArgs e)
        {
            TriggerEmitters(entities.GetAll().OfType<IEmitter>());
        }

        private void TriggerEmitters(IEnumerable<IEmitter> emitters)
        {
            foreach(var emitter in emitters.ToArray())
            {
                emitter.Emit();
            }
        }
    }
}
