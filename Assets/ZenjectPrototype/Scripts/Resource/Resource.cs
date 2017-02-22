using System;
using Zenject;

namespace ZenjectPrototype.ResourceSystem
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
                    stock = (value > StockCap) ? StockCap : (value < 0) ? 0 : value;
                    if (OnStockChanged != null) OnStockChanged.Invoke(this, new EventArgs());
                }
            }
        }

        [Inject]
        public Resource(int stock)
        {
            this.stock = stock;
            StockCap = stock;
        }

        public bool Spend(int amount)
        {
            int newValue = Stock - amount;
            if (Stock >= amount && newValue >= 0)
            {
                Stock = newValue;
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
