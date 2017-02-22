using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using Zenject;
using ZenjectPrototype.Exchange;

namespace ZenjectPrototype.UI
{
    public class ExchangeItemLister : MonoBehaviour
    {
        [SerializeField]
        private Transform container;
        private IDataHolder<IExchangable> exchangables;
        private ExchangeItem.Factory factory;

        [Inject]
        public void Construct(ExchangeItem.Factory factory, IDataHolder<IExchangable> exchangables)
        {
            this.factory = factory;
            this.exchangables = exchangables;
        }

        protected void Awake()
        {
            exchangables.OnAdded += Exchangables_OnAdded;
        }

        private void Exchangables_OnAdded(object sender, AddedEventArgs<IExchangable> e)
        {
            var item = factory.Create(e.NewData);
            item.transform.SetParent(container);
        }
    }
}
