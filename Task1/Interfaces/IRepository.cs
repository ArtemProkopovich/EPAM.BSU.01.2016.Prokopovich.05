using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task1.Interfaces
{
    interface IRepository<T>
    {
        void Load();
        void Save();
        void Add(T item);
        void Add(IEnumerable<T> items);
        void Delete(T item);
        void Delete(IEnumerable<T> items);
        IEnumerable<T> TakeAll();
        T FindFirst(Predicate<T> match);
        IEnumerable<T> FindAll(Predicate<T> match);
        IEnumerable<T> Sort(Comparison<T> comparison);
        IEnumerable<T> Sort(IComparer<T> comparer);
    }
}
