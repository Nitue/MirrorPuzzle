using System;
using System.Collections.Generic;

namespace ZenjectPrototype
{
    public delegate void AddedEventHandler<T>(object sender, AddedEventArgs<T> e);

    public class AddedEventArgs<T>
    {
        public readonly T NewData;

        public AddedEventArgs(T data)
        {
            NewData = data;
        }
    }

    public interface IDataHolder<T>
    {
        T Get(Func<T, bool> predicate);
        IEnumerable<T> GetAll(Func<T, bool> predicate);
        IEnumerable<T> GetAll();
        void Add(T data);

        event AddedEventHandler<T> OnAdded;
    }
}
