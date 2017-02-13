using UnityEngine;

namespace Assets.Prototype.Scripts
{
    public class Mirror : MonoBehaviour {

        void OnCollisionEnter(Collision collision)
        {
            foreach(var contact in collision.contacts)
            {
                var photon = contact.otherCollider.gameObject.GetComponent<Photon>();
                if (photon != null)
                {
                    var velocity = photon.Velocity;
                    var reflect = Vector3.Reflect(velocity, contact.normal);
                    photon.Velocity = reflect;
                }
            }
        }
    }
}
