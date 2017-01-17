using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhotonReceiver : MonoBehaviour {

    public float Wavelength;
    public float WavelengthErrorMargin = 50f;

    public int Received { get; private set; }
    public float WavelengthMin
    {
        get { return Wavelength - WavelengthErrorMargin; }
    }
    public float WavelengthMax
    {
        get { return Wavelength + WavelengthErrorMargin; }
    }

    void OnCollisionEnter(Collision collision)
    {
        foreach (ContactPoint contact in collision.contacts)
        {
            if (IsValidCollision(contact))
            {
                Received++;
                Debug.Log("Received correct photon!");
            }
            else
            {
                Debug.Log("Received invalid photon!");
            }
            Destroy(contact.otherCollider.gameObject);
        }
    }

    private bool IsValidCollision(ContactPoint contact)
    {
        var photon = contact.otherCollider.GetComponent<Photon>();
        return (photon != null && IsValidWavelength(photon.Wavelength));
    }

    private bool IsValidWavelength(float wavelength)
    {
        return (wavelength >= WavelengthMin && wavelength <= WavelengthMax);
    }
}
