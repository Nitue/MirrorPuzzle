using System;
using Zenject;
using UnityEngine;

using Random = UnityEngine.Random;

namespace ZenjectPrototype.Managers
{
    public class Resource : IResource<int>
    {
        private int stock;

        public event EventHandler OnStockChanged;

        public int StockCap { get; private set; }
        public int Stock
        {
            get { return stock; }
            private set
            {
                if(value != stock)
                {
                    Debug.Log("Setting stock to: " + value);
                    stock = (value > StockCap) ? StockCap : (value < 0) ? 0 : value;
                    if (OnStockChanged != null) OnStockChanged.Invoke(this, new EventArgs());
                }
            }
        }

        public Resource()
        {
            this.stock = Random.Range(2, 10);
            this.StockCap = stock;
            Debug.Log("Resource created!");
        }

        public bool Spend(int amount)
        {
            int newValue = Stock - amount;
            if (Stock >= amount && newValue >= 0)
            {
                Debug.Log("Stock before spending: " + Stock);
                Stock = newValue;
                Debug.Log("Stock after: " + Stock);
                return true;
            }
            return false;
        }

        public int Restock(int amount)
        {
            int remain = (Stock + amount) - StockCap;
            Stock += amount;
            return (remain > 0) ? remain : 0;
        }
    }
}
