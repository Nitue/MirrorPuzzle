using UnityEngine;
using ZenjectPrototype.Entities.Capabilities;

namespace ZenjectPrototype.Entities.AI
{
    public class MirrorAI : MonoBehaviour
    {
        [SerializeField]
        private Mirror mirror;

        protected void OnCollisionEnter(Collision collision)
        {
            var movable = collision.collider.gameObject.GetComponent<IMovable>();
            if (movable != null)
            {
                mirror.Reflect(movable, collision.contacts[0].normal);
            }
        }
    }
}
