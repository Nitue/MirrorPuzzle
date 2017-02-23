using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ZenjectPrototype.Entities.Filters;
using ZenjectPrototype.Entities.Capabilities;
using Zenject;

namespace ZenjectPrototype.Entities
{
    public class PhotonReceiver : Entity, IReceiver<Photon>, IWave, ICollidable
    {
        public int Wavelength
        {
            get { return wave.Wavelength; }
            set { wave.Wavelength = value; }
        }

        public IEnumerable<Photon> ReceivedObjects
        {
            get { return receiver.ReceivedObjects; }
        }

        public bool HasReceivedAnything
        {
            get { return receiver.HasReceivedAnything; }
        }

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

        public event ReceivedEventHandler<Photon> OnReceived
        {
            add { receiver.OnReceived += value; }
            remove { receiver.OnReceived -= value; }
        }

        private IWave wave;
        private ICollidable collidable;
        private IReceiver<Photon> receiver;

        [Inject]
        public void Construct(IWave wave, ICollidable collidable, IReceiver<Photon> receiver)
        {
            this.wave = wave;
            this.collidable = collidable;
            this.receiver = receiver;
        }

        public bool IsCollision(Collision collision)
        {
            return collidable.IsCollision(collision);
        }

        public void Receive(Photon entity)
        {
            receiver.Receive(entity);
        }

        public void Release()
        {
            receiver.Release();
        }
    }
}
