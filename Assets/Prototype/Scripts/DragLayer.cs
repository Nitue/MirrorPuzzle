using UnityEngine;

namespace Assets.Prototype.Scripts
{
    public class DragLayer : MonoBehaviour {

        public static Transform Transform;

        // Use this for initialization
        void Awake () {
            Transform = transform;
        }
    }
}
