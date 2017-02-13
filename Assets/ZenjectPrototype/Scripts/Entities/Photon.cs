using System;
using UnityEngine;
using Zenject;
using ZenjectPrototype.Entities.Capabilities;

namespace ZenjectPrototype.Entities
{
    public class Photon : Entity, IKillable, IMovable
    {
        private IMovable movement; // Changable movement logic

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
        public void Construct(IMovable movement)
        {
            this.movement = movement;
        }

        public void Kill()
        {
            Destroy(gameObject);
        }

        public void Move(Vector3 direction)
        {
            movement.Move(direction); // Method delegation
        }

        public class Factory : Factory<Photon> { }
    }
}

