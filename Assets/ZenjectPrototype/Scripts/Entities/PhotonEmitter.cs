using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;
using ZenjectPrototype.Entities.Capabilities;
using ZenjectPrototype.Entities.Spawners;
using ZenjectPrototype.Entities.Modifiers;

namespace ZenjectPrototype.Entities
{
    public class PhotonEmitter : Entity, IRotatable, IEmitter, IWave, IModifiable
    {
        private IRotatable rotatable;
        private ISpawner<Photon> spawner;
        private IWave wave;
        private IModifiable modifiable;

        public IEnumerable Modifiers
        {
            get { return modifiable.Modifiers; }
        }

        public Vector3 Rotation
        {
            get
            {
                return rotatable.Rotation;
            }
            set
            {
                rotatable.Rotation = value;
            }
        }

        public int Wavelength
        {
            get { return wave.Wavelength; }
            set { wave.Wavelength = value; }
        }

        public event WavelengthChangeEventHandler OnWavelengthChanged
        {
            add { wave.OnWavelengthChanged += value; }
            remove { wave.OnWavelengthChanged -= value; }
        }

        [Inject]
        public void Construct(IRotatable rotatable, ISpawner<Photon> spawner, IWave wave, IModifiable modifiable)
        {
            this.rotatable = rotatable;
            this.spawner = spawner;
            this.wave = wave;
            this.modifiable = modifiable;
        }

        public void Emit()
        {
            var photon = spawner.Spawn(transform.position);
            photon.Wavelength = Wavelength;
            photon.Rotation = Rotation;
            photon.Velocity = photon.transform.forward * 5f;
        }

        public void LookAt(Vector3 position)
        {
            rotatable.LookAt(position);
        }

        public void Register(Modifier modifier)
        {
            modifiable.Register(modifier);
        }

        public void Rotate(Vector3 amount)
        {
            rotatable.Rotate(amount);
        }

        private void OnMouseUpAsButton()
        {
            Emit();
        }
    }
}