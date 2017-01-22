using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using System.ComponentModel;

public class PhotonEmitter : MonoBehaviour, INotifyPropertyChanged {

    public GameObject PhotonPrefab;
    public float BaseWavelength;
    public float ForceMagnitude;
    public float MinWavelength = 400;
    public float MaxWavelength = 600;

    public ObservableList<Energy> EnergyBatches = new ObservableList<Energy>();

    [Header("Auto emit")]
    public bool EnableAutoEmitter;
    public float Rate;

    public delegate void PhotonEmittedEventHandler(PhotonEmittedEventArgs args);
    public event PhotonEmittedEventHandler OnPhotonEmitted;
    public event PropertyChangedEventHandler PropertyChanged;

    public float Wavelength
    {
        get { return BaseWavelength + EnergyBatches.Select(x => x.WavelengthChange).Sum(); }
    }

    private float autoEmitNextUpdate;

    void Awake()
    {
        EnergyBatches.OnAnyChange += EnergyBatches_OnAnyChange;
    }

    private void EnergyBatches_OnAnyChange(object sender, EventArgs e)
    {
        if (PropertyChanged != null) PropertyChanged(this, new PropertyChangedEventArgs("Wavelength"));
    }

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