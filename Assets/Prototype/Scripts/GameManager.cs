using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class GameManager : MonoBehaviour {

    public int PhotonCount;
    public PhotonEmitter[] Emitters;
    public PhotonReceiver[] Receivers;

	// Use this for initialization
	void Awake () {
        RegisterPhotonEmitters();
        RegisterPhotonReceivers();
    }

    void Update()
    {
        if(PhotonCount == 0 && !IsAllPhotonsReceived())
        {
            Debug.Log("You lost!");
        }
        else if(IsAllPhotonsReceived())
        {
            Debug.Log("You win!");
        }
    }

    private void RegisterPhotonEmitters()
    {
        var objects = GameObject.FindGameObjectsWithTag("PhotonEmitter");
        var emitterList = new List<PhotonEmitter>();
        foreach(var go in objects)
        {
            var emitter = go.GetComponent<PhotonEmitter>();
            emitterList.Add(emitter);
        }
        Emitters = emitterList.ToArray();
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

    private bool IsAllPhotonsReceived()
    {
        foreach(var receiver in Receivers)
        {
            if (receiver.Received == 0) return false;
        }
        return true;
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
