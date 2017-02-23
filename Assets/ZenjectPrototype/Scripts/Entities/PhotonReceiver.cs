using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ZenjectPrototype.Entities.Filters;
using ZenjectPrototype.Entities.Capabilities;
using Zenject;

namespace ZenjectPrototype.Entities
{
    public class PhotonReceiver : Entity, ICounter, IWave, ICollidable
    {
        public int Count { get; private set; }

        public int Wavelength
        {
            get { return wave.Wavelength; }
            set { wave.Wavelength = value; }
        }

        public event CountUpEventHandler OnCountUp;
        public event EventHandler OnValidCollision
        {
            add { collidable.OnValidCollision += value; }
            remove { collidable.OnValidCollision -= value; }
        }
        public event EventHandler OnInvalidCollision
        {
            add { collidable.OnInvalidCollision += value; }
            remove { collidable.OnInvalidCollision -= value; }
        }

        public event WavelengthChangeEventHandler OnWavelengthChanged
        {
            add { wave.OnWavelengthChanged += value; }
            remove { wave.OnWavelengthChanged -= value; }
        }

        private IWave wave;
        private ICollidable collidable;

        [Inject]
        public void Construct(IWave wave, ICollidable collidable)
        {
            this.wave = wave;
            this.collidable = collidable;
        }

        public void CountUp()
        {
            Count++;
            if (OnCountUp != null) OnCountUp(this, new CountUpEventArgs());
        }

        public void Reset()
        {
            Count = 0;
        }

        public bool IsCollision(Collision collision)
        {
            return collidable.IsCollision(collision);
        }
    }
}
