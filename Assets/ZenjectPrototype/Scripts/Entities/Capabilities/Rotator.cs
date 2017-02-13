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
        private Transform transform;
        private float step;

        [Inject]
        public Rotator(Transform transform, float step)
        {
            this.transform = transform;
            this.step = step;
        }

        public Vector3 Rotation
        {
            get
            {
                return transform.rotation.eulerAngles;
            }
            set
            {
                transform.rotation = Quaternion.Euler(ClosestStep(value.x, step), ClosestStep(value.y, step), ClosestStep(value.z, step));
            }
        }

        public void Rotate(Vector3 amount)
        {
            transform.Rotate(amount);
        }

        private float ClosestStep(float number, float interval)
        {
            return Mathf.Round(number / interval) * interval;
        }
    }
}
