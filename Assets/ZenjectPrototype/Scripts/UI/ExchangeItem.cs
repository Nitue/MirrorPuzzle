using UnityEngine;
using UnityEngine.UI;
using Zenject;
using ZenjectPrototype.Entities.Modifiers;
using ZenjectPrototype.Exchange;

namespace ZenjectPrototype.UI
{
    public class ExchangeItem : MonoBehaviour
    {
        [SerializeField]
        private Slider slider;
        private IExchangable exchangable;

        private float previousValue;
        public float PreviousValue
        {
            get { return previousValue; }
            set
            {
                if(value != previousValue)
                {
                    previousValue = value;
                }
            }
        }

        [Inject]
        public void Construct(IExchangable exchangable)
        {
            this.exchangable = exchangable;
        }

        protected void Awake()
        {
            previousValue = slider.value;
        }

        public void ChangeValue()
        {
            int change = Mathf.RoundToInt(slider.value - previousValue);
            
            if(change > 0)
            {
                exchangable.To(change);
            }
            else if(change < 0)
            {
                exchangable.From(Mathf.Abs(change));
            }

            previousValue = slider.value;
        }

        public class Factory : Factory<IExchangable, ExchangeItem> { }
    }
}
