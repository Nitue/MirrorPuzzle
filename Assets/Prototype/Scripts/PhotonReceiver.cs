using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhotonReceiver : MonoBehaviour {

    public float Wavelength;
    public float WavelengthErrorMargin = 50f;

    public event EventHandler OnReceiveValid;
    public event EventHandler OnReceiveInvalid;

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
            if (photon != null)
            {
                if (IsValidWavelength(photon.Wavelength))
                {
                    Received++;
                    if (OnReceiveValid != null) OnReceiveValid(this, new EventArgs());
                }
                else
                {
                    if (OnReceiveInvalid != null) OnReceiveInvalid(this, new EventArgs());
                }
                photon.Kill();
            }
            else
            {
                Destroy(contact.otherCollider.gameObject);
                if (OnReceiveInvalid != null) OnReceiveInvalid(this, new EventArgs());
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
