using UnityEngine;

namespace Assets.Prototype.Scripts
{
    public class ReceiverSplatter : MonoBehaviour {

        public PhotonReceiver Receiver;
        public GameObject SplatValid;
        public GameObject SplatInvalid;
        public Vector3 SplatOffset;

        // Use this for initialization
        void Awake () {
            Receiver.OnReceiveValid += Receiver_OnReceiveValid;
            Receiver.OnReceiveInvalid += Receiver_OnReceiveInvalid;
        }

        private void Receiver_OnReceiveInvalid(object sender, System.EventArgs e)
        {
            CreateSplat(SplatInvalid);
        }

        private void Receiver_OnReceiveValid(object sender, System.EventArgs e)
        {
            CreateSplat(SplatValid);
        }

        private void CreateSplat(GameObject splatPrefab)
        {
            var splat = Instantiate(splatPrefab);
            splat.transform.position = Receiver.transform.position + SplatOffset;
        }
    }
}
