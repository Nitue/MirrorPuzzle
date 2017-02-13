using UnityEngine;

namespace Assets.Prototype.Scripts
{
    [ExecuteInEditMode]
    public class UIEmitterEnergyLauncher : MonoBehaviour {

        public PhotonEmitter Emitter;
        public UIEmitterEnergy UIEmitterEnergy;

        void Start()
        {
            UIEmitterEnergy = FindObjectOfType<UIEmitterEnergy>();
        }

        void OnMouseUpAsButton()
        {
            UIEmitterEnergy.Open(Emitter);
        }
    }
}
