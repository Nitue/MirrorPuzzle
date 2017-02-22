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
            var killable = collision.collider.GetComponent<IKillable>();
            if (photonReceiver.IsCollision(collision))
            {
                photonReceiver.CountUp();
            }

            killable.Kill();
        }
    }
}
