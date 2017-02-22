using UnityEngine;

namespace ZenjectPrototype.Entities.AI
{
    public class PhotonAI : MonoBehaviour
    {
        [SerializeField]
        private Photon photon;

        protected void Update()
        {
            // Photon doesn't do anything else but move
            photon.Move();
        }
    }
}