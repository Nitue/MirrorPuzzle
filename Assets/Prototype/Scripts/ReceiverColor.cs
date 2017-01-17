using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReceiverColor : MonoBehaviour {

    public PhotonReceiver PhotonReceiver;
    public MeshRenderer MeshRenderer;

    void Start()
    {
        SetColor(Util.GetColor(PhotonReceiver.Wavelength));
    }

    public void SetColor(Color color)
    {
        MeshRenderer.material.color = color;
    }
}
