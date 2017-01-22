using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIEnergyReserve : MonoBehaviour {

    public GameManager GameManager;
    public Transform Container;

	// Use this for initialization
	void Awake () {
		foreach(var energy in GameManager.EnergyBatches)
        {
            Instantiate(energy.gameObject, Container);
        }
	}
}
