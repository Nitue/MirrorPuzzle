using UnityEngine;
using Zenject;
using ZenjectPrototype.GameState;
using ZenjectPrototype.Managers;

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
