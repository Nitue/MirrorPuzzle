using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

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
