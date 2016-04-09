using System;
using System.Collections.Generic;

namespace Task1.Interfaces
{
    public interface IService<T>
    {
        void Add(T item);
        void Add(IEnumerable<T> items);
        void Delete(T item);
        void Delete(IEnumerable<T> items);
        IEnumerable<T> TakeAll();
        T FindFirst(Predicate<T> match);
        IEnumerable<T> FindAll(Predicate<T> match);
        IEnumerable<T> Sort(Comparison<T> comparer);
        IEnumerable<T> Sort(IComparer<T> comparer);
        void Load();
        void Save();
    }
}