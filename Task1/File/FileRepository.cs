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
        private static Logger logger = LogManager.GetCurrentClassLogger();
        private FileRepository() { }
        private static readonly IFile<Book> FileAccessInstance = FileAccessFactory.FileAccessInstance;

        public static FileRepository Instance { get; } = new FileRepository();
    
        public void Add(IEnumerable<Book> items)
        {
            try
            {
                List<Book> fileItems = TakeAll().ToList();
                foreach (Book book in items)
                {
                    if (-1 != fileItems.FindIndex(e => e.Equals(book)))
                        throw new AlreadyExistsException("", nameof(book));
                }
                FileAccessInstance.AppendAll(items);
            }
            catch (AlreadyExistsException ex)
            {
                logger.Error(ex);
                throw ex;
            }
            catch (Exception ex)
            {
                logger.Error(ex);
                throw new RepositoryException("", ex);
            }
        }

        public void Add(Book item)
        {
            try
            {
                if (-1 != TakeAll().ToList().FindIndex(e => e.Equals(item)))
                    throw new AlreadyExistsException("", nameof(item));
                FileAccessInstance.Append(item);
            }
            catch (AlreadyExistsException ex)
            {
                logger.Error(ex);
                throw ex;
            }
            catch (Exception ex)
            {
                logger.Error(ex);
                throw new RepositoryException("", ex);
            }
        }

        public void Delete(IEnumerable<Book> items)
        {
            try
            {
                List<Book> fileItems = TakeAll().ToList();
                foreach (Book book in items)
                {
                    if (-1 == fileItems.FindIndex(e => e.Equals(book)))
                        throw new NotFoundException("", nameof(book));
                }
                foreach (Book book in items)
                {
                    fileItems.Remove(book);
                }
                FileAccessInstance.Write(fileItems);
            }
            catch (NotFoundException ex)
            {
                logger.Error(ex);
                throw ex;
            }
            catch (Exception ex)
            {
                logger.Error(ex);
                throw new RepositoryException("", ex);
            }
        }

        public void Delete(Book item)
        {
            try
            {
                List<Book> fileItems = TakeAll().ToList();
                if (-1 == fileItems.FindIndex(e => e.Equals(item)))
                    throw new NotFoundException("", nameof(item));
                fileItems.Remove(item);
                FileAccessInstance.Write(fileItems);
            }
            catch (NotFoundException ex)
            {
                logger.Error(ex);
                throw ex;
            }
            catch (Exception ex)
            {
                logger.Error(ex);
                throw new RepositoryException("", ex);
            }
        }

        public IEnumerable<Book> FindAll(Predicate<Book> match)
        {
            try
            {
                List<Book> fileItems = TakeAll().ToList();
                List<Book> result = fileItems.Where(item => match(item)).ToList();
                return result;
            }
            catch (Exception ex)
            {
                logger.Error(ex);
                throw new RepositoryException("", ex);
            }
        }

        public Book FindFirst(Predicate<Book> match)
        {
            try
            {
                List<Book> fileItems = TakeAll().ToList();
                Book result = fileItems.Find(match);
                return result;
            }
            catch (Exception ex)
            {
                logger.Error(ex);
                throw new RepositoryException("", ex);
            }
        }

        public IEnumerable<Book> Sort(IComparer<Book> comparer)
        {
            try
            {
                List<Book> fileItems = TakeAll().ToList();
                fileItems.Sort(comparer);
                return fileItems;
            }
            catch (Exception ex)
            {
                logger.Error(ex);
                throw new RepositoryException("", ex);
            }
        }

        public IEnumerable<Book> Sort(Comparison<Book> comparer)
        {
            try
            {
                List<Book> fileItems = TakeAll().ToList();
                fileItems.Sort(comparer);
                return fileItems;
            }
            catch (Exception ex)
            {
                logger.Error(ex);
                throw new RepositoryException("", ex);
            }
        }

        public IEnumerable<Book> TakeAll()
        {
            try
            {
                return FileAccessInstance.ReadAll();
            }
            catch (Exception ex)
            {
                logger.Error(ex);
                throw new RepositoryException("", ex);
            }
        }
    }
}
