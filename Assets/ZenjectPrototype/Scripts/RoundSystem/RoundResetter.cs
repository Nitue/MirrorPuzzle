using System;
using System.Linq;
using Zenject;
using ZenjectPrototype.Entities;
using ZenjectPrototype.Entities.Capabilities;

namespace ZenjectPrototype.RoundSystem
{
    public class RoundResetter : IInitializable
    {
        private IRoundManager roundManager;
        private IDataHolder<Entity> entities;

        [Inject]
        public RoundResetter(IRoundManager roundManager, IDataHolder<Entity> entities)
        {
            this.roundManager = roundManager;
            this.entities = entities;
        }

        public void Initialize()
        {
            roundManager.OnRoundEnd += RoundManager_OnRoundEnd;
        }

        private void RoundManager_OnRoundEnd(object sender, EventArgs e)
        {
            foreach (var receiver in entities.GetAll().OfType<IReceiver<Photon>>())
            {
                receiver.Release();
            }
        }
    }
}
