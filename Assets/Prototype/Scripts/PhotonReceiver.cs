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
            var photon = contact.otherCollider.GetComponent<Photon>();
            if (photon != null && IsValidWavelength(photon.Wavelength))
            {
                Received++;
                photon.Kill();
            }
            else
            {
                Destroy(contact.otherCollider.gameObject);
            }
        }
    }

    private bool IsValidWavelength(float wavelength)
    {
        return (wavelength >= WavelengthMin && wavelength <= WavelengthMax);
    }

    public void Reset()
    {
        Received = 0;
    }
}
