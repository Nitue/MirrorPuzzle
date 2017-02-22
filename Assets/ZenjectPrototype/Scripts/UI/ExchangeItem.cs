using UnityEngine;
using UnityEngine.UI;
using Zenject;
using ZenjectPrototype.Exchange;

namespace ZenjectPrototype.UI
{
    public class ExchangeItem : MonoBehaviour
    {
        [SerializeField]
        private Slider slider;
        [SerializeField]
        private int step;
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

        protected void Start()
        {
            previousValue = slider.value;
        }

        public void ChangeValue()
        {
            float stepValue = ClosestStep(slider.value, step);
            slider.value = stepValue;
            int change = Mathf.RoundToInt(stepValue - previousValue);
            if (exchangable.Exchange(change))
            {
                previousValue = slider.value;
            }
            else
            {
                slider.value = previousValue;
            }
        }

        private float ClosestStep(float number, float interval)
        {
            return Mathf.Round(number / interval) * interval;
        }

        public class Factory : Factory<IExchangable, ExchangeItem> { }
    }
}
