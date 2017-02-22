using UnityEngine;
using Zenject;
using ZenjectPrototype.Entities.Capabilities;
using ZenjectPrototype.Entities.Modifiers;
using ZenjectPrototype.UI;

public class EmitterItemInstaller : MonoInstaller<EmitterItemInstaller>
{
    public GameObject EmitterItemPrefab;

    public override void InstallBindings()
    {
        Container.BindFactory<WavelengthModifier, EmitterItem, EmitterItem.Factory>().FromPrefab(EmitterItemPrefab);
    }
}