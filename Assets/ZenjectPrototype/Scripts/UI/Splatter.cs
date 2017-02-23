using System;
using System.Linq;
using UnityEngine;
using Zenject;
using ZenjectPrototype.Entities.Capabilities;

namespace ZenjectPrototype.UI
{
    public class Splatter : MonoBehaviour
    {
        [SerializeField]
        private Splat ValidSplat;
        [SerializeField]
        private Splat InvalidSplat;
        [SerializeField]
        private Vector3 Offset;
        private ICollidable collidable;

        [Inject]
        public void Construct(ICollidable collidable)
        {
            this.collidable = collidable;
        }

        protected void Awake()
        {
            collidable.OnValidCollision += Collidable_OnValidCollision;
            collidable.OnInvalidCollision += Collidable_OnInvalidCollision;
        }

        private void Collidable_OnInvalidCollision(object sender, EventArgs e)
        {
            CreateSplat(InvalidSplat);
        }

        private void Collidable_OnValidCollision(object sender, EventArgs e)
        {
            CreateSplat(ValidSplat);
        }

        private void CreateSplat(Splat splat)
        {
            Instantiate(splat.gameObject, transform.position + Offset, splat.transform.rotation);
        }
    }
}
