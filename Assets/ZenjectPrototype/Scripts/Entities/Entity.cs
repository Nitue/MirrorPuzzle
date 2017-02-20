using UnityEngine;

namespace ZenjectPrototype.Entities
{
    /// <summary>
    /// Base class for Entities.
    /// </summary>
    public abstract class Entity : MonoBehaviour
    {
        public delegate void OnDestroyedEventHandler(Entity sender);
        public event OnDestroyedEventHandler OnDestroyed;

        public bool IsDestroyed { get; private set; }

        protected void OnDestroy()
        {
            IsDestroyed = true;
            if (OnDestroyed != null) OnDestroyed.Invoke(this);
        }
    }
}