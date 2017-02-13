using UnityEngine;
using UnityEngine.UI;

namespace Assets.Prototype.Scripts
{
    public class UIHUD : MonoBehaviour {

        public GameManager GameManager;
        public Text PhotonCount;
        public string PhotonCountTextFormat = "Photons: {0}";

        // Use this for initialization
        void Start () {
            GameManager.PropertyChanged += GameManager_PropertyChanged;

            UpdatePhotonCount();
        }

        private void GameManager_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            if (e.PropertyName == "PhotonCount") UpdatePhotonCount();
        }

        private void UpdatePhotonCount()
        {
            PhotonCount.text = string.Format(PhotonCountTextFormat, GameManager.PhotonCount);
        }

        public void EmitPhotons()
        {
            GameManager.EmitPhotons();
        }
    }
}
