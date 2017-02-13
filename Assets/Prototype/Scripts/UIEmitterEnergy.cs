using UnityEngine;

namespace Assets.Prototype.Scripts
{
    public class UIEmitterEnergy : MonoBehaviour {

        [HideInInspector]
        public PhotonEmitter EmitterContext;
        public GameObject Container;
        public Transform EnergyContainer;
        public DropArea EmitterEnergyDropArea;
        public DropArea EnergyReserveDropArea;

        void Awake()
        {
            EmitterEnergyDropArea.OnDropped += EmitterEnergyDropArea_OnDropped;
            EnergyReserveDropArea.OnDropped += EnergyReserveDropArea_OnDropped;
        }

        private void EnergyReserveDropArea_OnDropped(GameObject gameObject)
        {
            if(EmitterContext != null)
            {
                var energy = gameObject.GetComponent<Energy>();
                if (energy != null && EmitterContext.EnergyBatches.Contains(energy))
                {
                    EmitterContext.EnergyBatches.Remove(energy);
                }
            }
        }

        private void EmitterEnergyDropArea_OnDropped(GameObject gameObject)
        {
            if(EmitterContext != null)
            {
                var energy = gameObject.GetComponent<Energy>();
                if (energy != null && !EmitterContext.EnergyBatches.Contains(energy))
                {
                    EmitterContext.EnergyBatches.Add(energy);
                }
            }
        }

        public Energy[] EnergyBatches
        {
            get { return EnergyContainer.GetComponentsInChildren<Energy>(true); }
        }

        public void Open(PhotonEmitter emitter)
        {
            EmitterContext = emitter;
            ShowContextEnergy();
            Container.SetActive(true);
        }

        public void Close()
        {
            EmitterContext = null;
            Container.SetActive(false);
        }

        private void ShowContextEnergy()
        {
            foreach(var energy in EnergyBatches)
            {
                if(EmitterContext.EnergyBatches.Contains(energy))
                {
                    energy.gameObject.SetActive(true);
                }
                else
                {
                    energy.gameObject.SetActive(false);
                }
            }
        }
    }
}
