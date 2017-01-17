using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using UnityEngine;

/// <summary>
/// System.Collection.Generic.List type of list that can be observed for changes. Any added or removed items are triggers. Additionally changed items implementing INotifyPropertyChanged are also triggers.
/// </summary>
/// <typeparam name="T">Type of the items.</typeparam>
[Serializable]
public class ObservableList<T> : List<T>
{
    public delegate void ListItemAddedEventHandler(T[] addedItems);
    public delegate void ListItemRemovedEventHandler(T[] removedItems);

    /// <summary>
    /// Triggered when items are added to the list.
    /// </summary>
    public event ListItemAddedEventHandler OnItemAdded;
    /// <summary>
    /// Triggers when items are removed from the list.
    /// </summary>
    public event ListItemRemovedEventHandler OnItemRemoved;
    /// <summary>
    /// Triggers when any kind of change is made to the list.
    /// </summary>
    public event EventHandler OnAnyChange = delegate (object sender, EventArgs e) { }; // for some weird reason, System.EventHandler must be used otherwise subscribers are not detected as correct type
    
    public new T this[int index]
    {
        get
        {
            return base[index];
        }
        set
        {
            base[index] = value;
            ObserveForChanges(base[index]);
        }
    }

    public ObservableList() : base() { }

    public ObservableList(IEnumerable<T> collection) : base(collection)
    {
        ObserveAllForChanges();
    }

    /// <summary>
    /// Refreshes the observing of INotifyPropertyChanged items. This is kinda of temporary solution as I didn't find a way for the list start observing after a deserialization.
    /// </summary>
    public void Refresh()
    {
        ObserveAllForChanges();
    }

    private void NotifyItemAdded(T[] items)
    {
        NotifyAnyChange();
        if (OnItemAdded != null) OnItemAdded(items);
    }

    private void NotifyItemRemoved(T[] items)
    {
        NotifyAnyChange();
        if (OnItemRemoved != null) OnItemRemoved(items);
    }

    private void NotifyAnyChange()
    {
        if (OnAnyChange != null) OnAnyChange(this, new EventArgs());
    }

    private void ObserveAllForChanges()
    {
        foreach (T item in this)
        {
            ObserveForChanges(item);
        }
    }

    /// <summary>
    /// Checks if item can be observed for changes and starts observing if possible.
    /// </summary>
    private void ObserveForChanges(T item)
    {
        if(item is INotifyPropertyChanged)
        {
            var observable = ((INotifyPropertyChanged)item);
            observable.PropertyChanged -= Item_PropertyChanged; // try to remove duplicate
            observable.PropertyChanged += Item_PropertyChanged;
        }
    }

    private void Item_PropertyChanged(object sender, PropertyChangedEventArgs e)
    {
        NotifyAnyChange(); // when item in the list has changed, trigger OnChanged
    }

    public new void Add(T item)
    {
        base.Add(item);
        ObserveForChanges(item);
        NotifyItemAdded(new T[] { item });
    }

    public new void Insert(int index, T item)
    {
        base.Insert(index, item);
        ObserveForChanges(item);
        NotifyItemAdded(new T[] { item });
    }

    /*public new void AddRange(IEnumerable<T> collection)
    {
        base.AddRange(collection);
        NotifyItemAdded(collection);
    }*/

    /*public new void InsertRange(int index, IEnumerable<T> collection)
    {
        base.InsertRange(index, collection);
        NotifyItemAdded(collection);
    }*/

    public new void Remove(T item)
    {
        base.Remove(item);
        NotifyItemRemoved(new T[] { item });
    }

    public new void RemoveAt(int index)
    {
        T item = base[index];
        base.RemoveAt(index);
        NotifyItemRemoved(new T[] { item });
    }

    public new void RemoveAll(Predicate<T> match)
    {
        var items = FindAll(match);
        base.RemoveAll(match);
        NotifyItemRemoved(items.ToArray());
    }

    public new void RemoveRange(int index, int count)
    {
        var items = GetRange(index, count);
        base.RemoveRange(index, count);
        NotifyItemRemoved(items.ToArray());
    }

    public new void Clear()
    {
        var items = new T[Count];
        CopyTo(items);
        base.Clear();
        NotifyItemRemoved(items);
    }
}
