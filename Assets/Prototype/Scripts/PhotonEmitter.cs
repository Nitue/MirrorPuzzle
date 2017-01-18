using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhotonEmitter : MonoBehaviour {

    public GameObject PhotonPrefab;
    public float Wavelength;
    public float ForceMagnitude;

    [Header("Auto emit")]
    public bool EnableAutoEmitter;
    public float Rate;

    public delegate void PhotonEmittedEventHandler(PhotonEmittedEventArgs args);
    public event PhotonEmittedEventHandler OnPhotonEmitted;

    private float autoEmitNextUpdate;

	// Use this for initialization
	void Start () {
        SetAutoEmitNextUpdate();
    }
	
	// Update is called once per frame
	void Update () {
		if(EnableAutoEmitter && Time.time >= autoEmitNextUpdate)
        {
            SetAutoEmitNextUpdate();
            Emit();
        }
	}

    private void SetAutoEmitNextUpdate()
    {
        autoEmitNextUpdate = Time.time + (1 / Rate);
    }

    public void Emit()
    {
        var photon_gameobject = Instantiate(PhotonPrefab, transform.position, transform.rotation) as GameObject;
        var direction = transform.forward;
        var photon = photon_gameobject.GetComponent<Photon>();
        photon.Velocity = new Vector3(direction.x, direction.y, direction.z) * ForceMagnitude;
        photon.GetComponent<Photon>().Wavelength = Wavelength;

        if (OnPhotonEmitted != null) OnPhotonEmitted(new PhotonEmittedEventArgs(photon));
    }
}

public class PhotonEmittedEventArgs
{
    public Photon Photon;
    
    public PhotonEmittedEventArgs(Photon photon)
    {
        Photon = photon;
    }
}