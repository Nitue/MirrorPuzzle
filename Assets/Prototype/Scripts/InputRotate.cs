using UnityEngine;

namespace Assets.Prototype.Scripts
{
    public class InputRotate : MonoBehaviour {

        public float RotationSpeed = 50f;
        public float RotationStep = 1f;
        public bool LockAxisX;
        public bool LockAxisY;
        public bool LockAxisZ;
        public float Step;
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
                    var rotation = transform.rotation.eulerAngles;
                    transform.rotation = Quaternion.Euler(ClosestNumber(rotation.x, Step), ClosestNumber(rotation.y, Step), ClosestNumber(rotation.z, Step));
                }
            }
        }

        private float ClosestNumber(float number, float interval)
        {
            return Mathf.Round(number / interval) * interval;
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
}
