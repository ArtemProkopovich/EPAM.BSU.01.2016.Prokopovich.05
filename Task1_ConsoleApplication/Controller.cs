using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task1;

namespace Task1_ConsoleApplication
{
    public class Controller
    {
        public enum OpType
        {
            Name,
            Author,
            PageNumber
        }

        private Controller() { }
        public static Controller Instance { get; } = new Controller();

        public static BookService service = new BookService();

        public void Add(Book item)
        {
            service.Add(item);
        }

        public void Delete(Book item)
        {
            service.Delete(item);
        }

        public IEnumerable<Book> TakeAll()
        {
            return service.TakeAll();
        }

        public IEnumerable<Book> FindAll(string str, OpType type)
        {
            Predicate<Book> match = null;
            switch (type)
            {
                case OpType.Author:
                    match = e => e.Author.IndexOf(str, StringComparison.CurrentCulture) >= 0;
                    break;
                case OpType.Name:
                    match = e => e.Name.IndexOf(str, StringComparison.CurrentCulture) >= 0;
                    break;
                case OpType.PageNumber:
                    int number = 0;
                    int.TryParse(str, out number);
                    match = e => e.PageNumber > number;
                    break;
            }
            return service.FindAll(match);
        }

        public IEnumerable<Book> Sort(OpType type, bool increase = true)
        {
            Comparer<Book> comparer = null;
            switch (type)
            {
                case OpType.Author:
                    comparer = Comparer<Book>.Create((x, y) => x.Author.CompareTo(y.Author));
                    break;
                case OpType.Name:
                    comparer = Comparer<Book>.Create((x, y) => x.Name.CompareTo(y.Name));
                    break;
                case OpType.PageNumber:
                    comparer = Comparer<Book>.Create((x, y) => x.PageNumber.CompareTo(y.PageNumber));
                    break;
            }
            return service.Sort(comparer);
        }
    }
}
