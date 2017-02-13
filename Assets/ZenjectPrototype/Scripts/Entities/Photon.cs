using System;
using UnityEngine;
using Zenject;
using ZenjectPrototype.Entities.Capabilities;

namespace ZenjectPrototype.Entities
{
    public class Photon : Entity, IKillable, IMovable, IRotatable
    {
        private IRotatable rotatable;
        private IMovable movement; // Changable movement logic

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

        public float Speed
        {
            get
            {
                return movement.Speed;
            }

            set
            {
                movement.Speed = value;
            }
        }

        [Inject]
        public void Construct(IMovable movement, IRotatable rotatable)
        {
            this.movement = movement;
            this.rotatable = rotatable;
        }

        public void Kill()
        {
            Destroy(gameObject);
        }

        public void Move(Vector3 direction)
        {
            movement.Move(direction); // Method delegation
        }

        public void Rotate(Vector3 amount)
        {
            rotatable.Rotate(amount);
        }

        public class Factory : Factory<Photon> { }
    }
}

