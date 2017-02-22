using UnityEngine;
using Zenject;
using ZenjectPrototype.RoundSystem;

namespace ZenjectPrototype.UI
{
    public class PlayButton : MonoBehaviour
    {
        private IRoundManager roundManager;

        [Inject]
        public void Construct(IRoundManager roundManager)
        {
            this.roundManager = roundManager;
        }

        public void Play()
        {
            roundManager.StartRound();
        }
    }
}
