using UnityEngine;

namespace Assets.Prototype.Scripts
{
    public class Wall : MonoBehaviour {


        void OnCollisionEnter(Collision collision)
        {
            foreach (ContactPoint contact in collision.contacts)
            {
                var photon = contact.otherCollider.gameObject.GetComponent<Photon>();
                if (photon != null) photon.Kill();
                else Destroy(contact.otherCollider.gameObject);
            }
        }
    }
}
