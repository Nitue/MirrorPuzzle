using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using Zenject;

namespace ZenjectPrototype.Entities.Capabilities
{
    public class Rotator : IRotatable
    {
        private Settings settings;       

        [Inject]
        public Rotator(Settings settings)
        {
            this.settings = settings;
        }

        public Vector3 Rotation
        {
            get
            {
                return settings.Transform.rotation.eulerAngles;
            }
            set
            {
                settings.Transform.rotation = Quaternion.Euler(LockAxises(ClosestStep(value, settings.Step)));
            }
        }

        public void Rotate(Vector3 eulerAngles)
        {
            Rotation += eulerAngles;
        }

        private float ClosestStep(float number, float interval)
        {
            return Mathf.Round(number / interval) * interval;
        }

        private Vector3 ClosestStep(Vector3 vector, float interval)
        {
            return new Vector3(ClosestStep(vector.x, interval), ClosestStep(vector.y, interval), ClosestStep(vector.z, interval));
        }

        private Vector3 LockAxises(Vector3 eulerAngles)
        {
            return new Vector3(
                (settings.LockX) ? settings.Transform.rotation.x : eulerAngles.x,
                (settings.LockY) ? settings.Transform.rotation.y : eulerAngles.y,
                (settings.LockZ) ? settings.Transform.rotation.z : eulerAngles.z
            );
        }

        public void LookAt(Vector3 position)
        {
            settings.Transform.LookAt(position); // set new rotation (no step correction or axis locking)
            Rotation = Rotation; // corrects the step and axis lock
        }

        [Serializable]
        public class Settings
        {
            public Transform Transform;
            public float Step;
            public bool LockX;
            public bool LockY;
            public bool LockZ;
        }
    }
}
