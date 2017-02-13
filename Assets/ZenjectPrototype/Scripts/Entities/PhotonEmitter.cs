using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;
using ZenjectPrototype.Entities.Capabilities;
using ZenjectPrototype.Entities.Spawners;

namespace ZenjectPrototype.Entities
{
    public class PhotonEmitter : Entity, IRotatable, IEmitter
    {
        private IRotatable rotatable;
        private ISpawner<Photon> spawner;

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

        [Inject]
        public void Construct(IRotatable rotatable, ISpawner<Photon> spawner)
        {
            this.rotatable = rotatable;
            this.spawner = spawner;
        }

        public void Emit()
        {
            var photon = spawner.Spawn(transform.position);
            photon.Speed = 5f;
            photon.Rotation = Rotation;
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