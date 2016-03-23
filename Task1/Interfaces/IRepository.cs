using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task1.Interfaces
{
    interface IRepository<T>
    {
        void Add(T item);
        void Add(IEnumerable<T> items);
        void Delete(T item);
        void Delete(IEnumerable<T> items);
        IEnumerable<T> TakeAll();
        T FindFirst(IEqualityComparer<T> comparer);
        IEnumerable<T> FindAll(IEqualityComparer<T> comparer);
        IEnumerable<T> Sort(IComparer<T> comparer);
    }
}
