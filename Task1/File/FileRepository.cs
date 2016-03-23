using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task1.Interfaces;

namespace Task1.File
{
    public class FileRepository : IRepository<Book>
    {
        private FileRepository() { }

        public static FileRepository Instance { get; } = new FileRepository();

        public void Add(IEnumerable<Book> items)
        {
            throw new NotImplementedException();
        }

        public void Add(Book item)
        {
            throw new NotImplementedException();
        }

        public void Delete(IEnumerable<Book> items)
        {
            throw new NotImplementedException();
        }

        public void Delete(Book item)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Book> FindAll(IEqualityComparer<Book> comparer)
        {
            throw new NotImplementedException();
        }

        public Book FindFirst(IEqualityComparer<Book> comparer)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Book> Sort(IComparer<Book> comparer)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Book> TakeAll()
        {
            throw new NotImplementedException();
        }
    }
}
