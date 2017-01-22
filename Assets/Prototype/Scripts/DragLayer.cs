using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragLayer : MonoBehaviour {

    public static Transform Transform;

	// Use this for initialization
	void Awake () {
        Transform = transform;
	}
}
