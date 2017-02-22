using System.Linq;
using UnityEngine;
using Zenject;
using ZenjectPrototype.Entities;

namespace ZenjectPrototype.Exchange
{
    public class ExchangeInitializer : IInitializable
    {
        private ResourceWavelengthExchange.Factory factory;
        private EntityManager entityManager;
        private ExchangeManager exchangeManager;

        [Inject]
        public ExchangeInitializer(ResourceWavelengthExchange.Factory factory, EntityManager entityManager, ExchangeManager exchangeManager)
        {
            this.factory = factory;
            this.entityManager = entityManager;
            this.exchangeManager = exchangeManager;
        }

        public void Initialize()
        {
            foreach(var emitter in entityManager.GetAll().OfType<PhotonEmitter>())
            {
                exchangeManager.Add(factory.Create(emitter));
            }
        }
    }
}
