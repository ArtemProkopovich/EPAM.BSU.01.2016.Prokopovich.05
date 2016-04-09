using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task1.Interfaces;
using Task1.Exceptions;
using Task1.File;

namespace Task1
{
    public class BookService : IService<Book>
    {
        private readonly IRepository<Book> repository;

        public BookService(string rep_type)
        {
            repository = RepositoryFactory.FactoryInstance.GetFileRepository(rep_type);
            Load();
        }

        public void Load()
        {
            repository.Load();
        }

        public void Save()
        {
            repository.Save();
        }

        public void Add(Book book)
        {
            if (book == null)
                throw new ArgumentNullException(nameof(book));
            repository.Add(book);
        }

        public void Add(IEnumerable<Book> books)
        {
            if (books == null)
                throw new ArgumentNullException(nameof(books));
            repository.Add(books);
        }

        public void Delete(Book book)
        {
            if (book == null)
                throw new ArgumentNullException(nameof(book));
            repository.Delete(book);
        }

        public void Delete(IEnumerable<Book> books)
        {
            if (books == null)
                throw new ArgumentNullException(nameof(books));
            repository.Delete(books);
        }

        public IEnumerable<Book> TakeAll()
        {
            return repository.TakeAll();
        }

        public IEnumerable<Book> FindAll(Predicate<Book> match)
        {
            if (match == null)
                throw new ArgumentNullException(nameof(match));
            return repository.FindAll(match);
        }

        public IEnumerable<Book> Sort(Comparison<Book> comparer)
        {
            if (comparer == null)
                throw new ArgumentNullException(nameof(comparer));
            return repository.Sort(comparer);
        }

        public IEnumerable<Book> Sort(IComparer<Book> comparer)
        {
            if (comparer == null)
                throw new ArgumentNullException(nameof(comparer));
            return repository.Sort(comparer);
        }

        public Book FindFirst(Predicate<Book> match)
        {
            if (match == null)
                throw new ArgumentNullException(nameof(match));
            return repository.FindFirst(match);
        }
    }
}
