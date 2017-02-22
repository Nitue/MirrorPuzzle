using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZenjectPrototype.Managers
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
