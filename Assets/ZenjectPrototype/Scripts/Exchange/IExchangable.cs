using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ZenjectPrototype.Exchange
{
    public interface IExchangable
    {
        bool Exchange(int amount);
    }
}
