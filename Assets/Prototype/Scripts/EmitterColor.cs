using UnityEngine;
using System.Collections;

public class EmitterColor : MonoBehaviour
{

    public PhotonEmitter PhotonEmitter;
    public MeshRenderer MeshRenderer;
    public Light Light;

    void Awake()
    {
        PhotonEmitter.PropertyChanged += PhotonEmitter_PropertyChanged;
    }

    private void PhotonEmitter_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
    {
        if (e.PropertyName == "Wavelength") SetColor(Util.GetColor(PhotonEmitter.Wavelength));
    }

    void Start()
    {
        SetColor(Util.GetColor(PhotonEmitter.Wavelength));
    }

    public void SetColor(Color color)
    {
        MeshRenderer.material.color = color;
        Light.color = color;
    }
}
