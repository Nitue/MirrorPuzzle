using UnityEngine;

namespace Assets.Prototype.Scripts
{
    public class KillSwitch : MonoBehaviour
    {
        public Photon Photon;
        public float Duration = 1f;

        private float timer;

        void Start()
        {

        }

        void Update()
        {
            if (Photon.Velocity.magnitude == 0) timer += Time.deltaTime;
            if (timer >= Duration) Photon.Kill();
        }
    }
}
