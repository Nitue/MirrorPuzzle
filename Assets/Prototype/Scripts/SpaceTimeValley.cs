using System.Collections.Generic;
using UnityEngine;

namespace Assets.Prototype.Scripts
{
    public class SpaceTimeValley : MonoBehaviour {

        public float WavelengthChange;
        public float Magnitude;

        private List<Photon> photons = new List<Photon>();

        void OnTriggerEnter(Collider collider)
        {
            var photon = collider.gameObject.GetComponent<Photon>();
            if (photon != null)
            {
                photon.Wavelength += WavelengthChange;
                photons.Add(photon);
            }
        }

        void OnTriggerExit(Collider collider)
        {
            var photon = collider.gameObject.GetComponent<Photon>();
            if (photon != null)
            {
                photons.Remove(photon);
            }
        }

        void FixedUpdate()
        {
            foreach(var photon in photons)
            {
                photon.Velocity += (transform.position - photon.transform.position).normalized * Magnitude;
            }
        }
    }
}
