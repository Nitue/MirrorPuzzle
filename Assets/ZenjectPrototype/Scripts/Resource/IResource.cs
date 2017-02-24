using System;

namespace ZenjectPrototype.ResourceSystem
{
    public interface IResource<T> where T : struct
    {
        event EventHandler OnStockChanged;
        T Stock { get; }
        T StockCap { get; }
        bool Spend(T amount);
        T Restock(T amount);
    }
}
