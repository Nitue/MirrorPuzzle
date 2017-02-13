using UnityEngine;

namespace Assets.Prototype.Scripts
{
    public class PhotonColor : MonoBehaviour {

        public Photon photon;

        // Use this for initialization
        void Awake () {
            photon.PropertyChanged += Photon_PropertyChanged;
        }

        private void Photon_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            if(e.PropertyName == "Wavelength")
            {
                var eventPhoton = (Photon)sender;
                SetColor(eventPhoton.Color);
            }
        }

        public void SetColor(Color color)
        {
            var mr = GetComponent<MeshRenderer>();
            mr.material.color = color;
        }
    }
}
