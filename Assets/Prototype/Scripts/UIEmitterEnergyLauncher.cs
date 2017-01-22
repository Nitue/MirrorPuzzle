using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class UIEmitterEnergyLauncher : MonoBehaviour {

    public PhotonEmitter Emitter;
    public UIEmitterEnergy UIEmitterEnergy;

    void Start()
    {
        UIEmitterEnergy = FindObjectOfType<UIEmitterEnergy>();
    }

	void OnMouseUpAsButton()
    {
        UIEmitterEnergy.Open(Emitter);
    }
}
