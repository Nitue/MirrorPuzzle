using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mirror : MonoBehaviour {

    void OnCollisionEnter(Collision collision)
    {
        foreach(var contact in collision.contacts)
        {
            var velocity = contact.otherCollider.attachedRigidbody.velocity;
            Debug.Log("Normal: " + contact.normal);
            Debug.Log("Velocity: " + velocity);
            var reflect = Vector3.Reflect(velocity, contact.normal);
            Debug.Log("Velocity after: " + reflect);
            contact.otherCollider.attachedRigidbody.velocity = reflect;
        }
    }
}
