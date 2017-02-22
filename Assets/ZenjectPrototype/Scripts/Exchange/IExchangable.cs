using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ZenjectPrototype.Exchange
{
    public interface IExchangable
    {
        void To(int amount);
        void From(int amount);
    }
}
