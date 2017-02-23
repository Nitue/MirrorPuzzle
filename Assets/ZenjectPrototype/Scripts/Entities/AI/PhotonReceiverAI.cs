using UnityEngine;
using ZenjectPrototype.Entities.Capabilities;

namespace ZenjectPrototype.Entities.AI
{
    public class PhotonReceiverAI : MonoBehaviour
    {
        [SerializeField]
        private PhotonReceiver photonReceiver;

        protected void OnCollisionEnter(Collision collision)
        {
            var photon = collision.collider.GetComponent<Photon>();
            if (photonReceiver.IsCollision(collision))
            {
                photonReceiver.Receive(photon);
            }
            else
            {
                photon.Kill();
            }
        }
    }
}
