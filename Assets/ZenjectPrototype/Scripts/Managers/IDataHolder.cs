using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ZenjectPrototype.Managers
{
    public interface IDataHolder<T>
    {
        T Get(Func<T, bool> predicate);
        IEnumerable<T> GetAll(Func<T, bool> predicate);
        IEnumerable<T> GetAll();
        void Add(T data);
    }
}
