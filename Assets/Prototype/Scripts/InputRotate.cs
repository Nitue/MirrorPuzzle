using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputRotate : MonoBehaviour {

    public float RotationSpeed = 50f;
    public float RotationStep = 1f;
    public bool LockAxisX;
    public bool LockAxisY;
    public bool LockAxisZ;
    private bool rotateEnabled;
	
	// Update is called once per frame
	void Update () {
        if (rotateEnabled)
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if(Physics.Raycast(ray, out hit))
            {
                float x = (!LockAxisX) ? hit.point.x : transform.position.x;
                float y = (!LockAxisY) ? hit.point.y : transform.position.y;
                float z = (!LockAxisZ) ? hit.point.z : transform.position.z;
                transform.LookAt(new Vector3(x, y, z));
            }
        }
    }

    void OnMouseDown()
    {
        rotateEnabled = true;
    }

    void OnMouseUp()
    {
        rotateEnabled = false;
    }
}
