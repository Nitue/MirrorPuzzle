using UnityEngine;

namespace Assets.Prototype.Scripts
{
    public class ReceiverColor : MonoBehaviour {

        public PhotonReceiver PhotonReceiver;
        public MeshRenderer MeshRenderer;
        public Light Light;

        void Start()
        {
            SetColor(Util.GetColor(PhotonReceiver.Wavelength));
        }

        public void SetColor(Color color)
        {
            MeshRenderer.material.color = color;
            Light.color = color;
        }
    }
}
