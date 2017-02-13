using UnityEngine;
using UnityEngine.EventSystems;

namespace Assets.Prototype.Scripts
{
    public class DropArea : MonoBehaviour, IDropHandler {

        public Transform Container;

        public delegate void DropEventHandler(GameObject gameObject);
        public event DropEventHandler OnDropped;

        public void OnDrop(PointerEventData eventData)
        {
            if (eventData.dragging)
            {
                eventData.pointerDrag.transform.SetParent(Container);
                if (OnDropped != null) OnDropped(eventData.pointerDrag);
            }
        }
    }
}
