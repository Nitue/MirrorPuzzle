using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UICanvas : MonoBehaviour {

    public GameManager GameManager;
    public Text PhotonCount;
    public string PhotonCountTextFormat = "Photons: {0}";

	// Use this for initialization
	void Start () {
        UpdatePhotonCount();
	}

    private void UpdatePhotonCount()
    {
        PhotonCount.text = string.Format(PhotonCountTextFormat, GameManager.PhotonCount);
    }

    public void EmitPhotons()
    {
        GameManager.EmitPhotons();
    }
}
