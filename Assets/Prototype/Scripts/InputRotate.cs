using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputRotate : MonoBehaviour {

    public float RotationSpeed = 50f;
    public bool LockAxisX;
    public bool LockAxisY;
    private bool rotateEnabled;
	
	// Update is called once per frame
	void Update () {
        if (rotateEnabled)
        {
            transform.Rotate(new Vector3((!LockAxisX) ? Input.GetAxis("Mouse Y") : 0f, (!LockAxisY) ? Input.GetAxis("Mouse X") : 0f, 0) * Time.deltaTime * RotationSpeed);
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
