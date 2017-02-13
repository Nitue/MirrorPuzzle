using UnityEngine;
using Zenject;
using ZenjectPrototype.Entities;

namespace ZenjectPrototype.AI
{
    public class PhotonAI : AI
    {
        [SerializeField]
        private Photon photon;

        protected override void Update()
        {
            // Photon doesn't do anything else but move forward
            // and doesn't care what happens on the way
            photon.Move(photon.transform.forward);
        }
    }
}