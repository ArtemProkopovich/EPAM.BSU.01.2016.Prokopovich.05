using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task1.Interfaces;
using Task1.Exceptions;
using NLog;

namespace Task1.File
{
    public class FileRepository : IRepository<Book>
    {
        private Logger logger = LogManager.GetCurrentClassLogger();

        private FileRepository()
        {
        }

        private static IFile<Book> FileAccessInstance;
        private List<Book> innerList = new List<Book>();

        public static FileRepository GetInstance(string type)
        {
            FileAccessInstance = FileAccessFactory.GetFileAccessInstance(type);
            return new FileRepository();
        }

        public void Load()
        {
            try
            {
                innerList = FileAccessInstance.LoadAll().ToList();
            }
            catch (Exception ex)
            {
                logger.Error(ex);
                throw new RepositoryException("", ex);
            }
        }

        public void Save()
        {
            try
            {
                FileAccessInstance.SaveAll(innerList);
            }
            catch (Exception ex)
            {
                logger.Error(ex);
            }
        }

        public void Add(Book item)
        {
            logger.Debug(item);
            if (item == null)
            {
                throw new ArgumentNullException("", nameof(item));
            }
            if (innerList.FindIndex(e => e.Equals(item)) < 0)
                innerList.Add(item);
            else
                throw new AlreadyExistsException("", nameof(item));
        }

        public void Add(IEnumerable<Book> items)
        {
            logger.Debug(items);
            if (items == null)
                throw new ArgumentNullException("", nameof(items));
            foreach (var item in items)
                Add(item);
        }

        public void Delete(Book item)
        {
            logger.Debug(item);
            if (item == null)
                throw new ArgumentNullException("", nameof(item));
            if (!innerList.Remove(item))
            {
                throw new NotFoundException("", nameof(item));
            }
        }

        public void Delete(IEnumerable<Book> items)
        {
            if (items == null)
                throw new ArgumentNullException("", nameof(items));
            foreach (var item in items)
                Delete(item);
        }

        public IEnumerable<Book> TakeAll()
        {
            return innerList;
        }

        public Book FindFirst(Predicate<Book> match)
        {
            if (match == null)
                throw new ArgumentNullException("", nameof(match));
            return innerList.Find(match);
        }

        public IEnumerable<Book> FindAll(Predicate<Book> match)
        {
            if (match == null)
                throw new ArgumentNullException("", nameof(match));
            return innerList.FindAll(match);
        }

        public IEnumerable<Book> Sort(Comparison<Book> comparison)
        {
            if (comparison == null)
                throw new ArgumentNullException("", nameof(comparison));
            Book[] array = new Book[innerList.Count];
            innerList.CopyTo(array);
            Array.Sort(array, comparison);
            return array;
        }

        public IEnumerable<Book> Sort(IComparer<Book> comparer)
        {
            return Sort(comparer.Compare);
        }
    }
}
