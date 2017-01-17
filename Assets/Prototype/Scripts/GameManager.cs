using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using UnityEngine;

[ExecuteInEditMode]
public class GameManager : MonoBehaviour, INotifyPropertyChanged {

    public PhotonEmitter[] Emitters;
    public PhotonReceiver[] Receivers;

    [SerializeField]
    private int photonCount;

    public event PropertyChangedEventHandler PropertyChanged;

    public ObservableList<Photon> Photons = new ObservableList<Photon>();

    public int PhotonCount
    {
        get { return photonCount; }
        set
        {
            if(photonCount != value)
            {
                photonCount = value;
                NotifyPropertyChange("PhotonCount");
            }
        }
    }

	// Use this for initialization
	void Awake () {
        RegisterPhotonEmitters();
        RegisterPhotonReceivers();
    }

    private void RegisterPhotonEmitters()
    {
        var objects = GameObject.FindGameObjectsWithTag("PhotonEmitter");
        var emitterList = new List<PhotonEmitter>();
        foreach(var go in objects)
        {
            var emitter = go.GetComponent<PhotonEmitter>();
            emitter.OnPhotonEmitted += Emitter_OnPhotonEmitted;
            emitterList.Add(emitter);
        }
        Emitters = emitterList.ToArray();
    }

    private void Emitter_OnPhotonEmitted(PhotonEmittedEventArgs args)
    {
        RegisterPhoton(args.Photon);
    }

    private void RegisterPhotonReceivers()
    {
        var objects = GameObject.FindGameObjectsWithTag("PhotonReceiver");
        var receiverList = new List<PhotonReceiver>();
        foreach (var go in objects)
        {
            var receiver = go.GetComponent<PhotonReceiver>();
            receiverList.Add(receiver);
        }
        Receivers = receiverList.ToArray();
    }

    private void RegisterPhoton(Photon photon)
    {
        Photons.Add(photon);
        photon.OnDeath += Photon_OnDeath;
    }

    private void Photon_OnDeath(object sender, System.EventArgs e)
    {
        Photons.Remove((Photon)sender);
    }

    public bool IsAllPhotonsReceived()
    {
        foreach(var receiver in Receivers)
        {
            if (receiver.Received == 0) return false;
        }
        return true;
    }

    private void NotifyPropertyChange(string propertyName)
    {
        if (PropertyChanged != null) PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
    }

    public void EmitPhotons()
    {
        if(PhotonCount > 0)
        {
            foreach (var emitter in Emitters)
            {
                emitter.Emit();
                PhotonCount--;
            }
        }
    }
}
