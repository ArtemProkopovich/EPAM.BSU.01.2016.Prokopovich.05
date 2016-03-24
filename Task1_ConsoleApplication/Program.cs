using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task1;

namespace Task1_ConsoleApplication
{
    class Program
    {

        private static Controller controller = Controller.Instance;
        public enum Command
        {
            ShowMenu,
            ShowAllBooks,
            FindByAuthor,
            FindByName,
            SortByAuthor,
            SortByName,
            AddBook,
            DeleteBook,
            Exit
        }

        public static void ShowMenu()
        {
            for (int i = 0; i < 9; i++)
            {
                Console.WriteLine($"{i}) {((Command)i)}");
            }
        }

        public static void AddBook()
        {
            controller.Add(BookEnter());
        }

        public static void DeleteBook()
        {
            controller.Delete(BookEnter());
        }

        public static void ShowAllBooks()
        {
            ShowBooks(controller.TakeAll());
        }

        public static void FindByName()
        {
            Console.WriteLine("Введите название книги");
            ShowBooks(controller.FindAll(Console.ReadLine(), Controller.OpType.Name));
        }

        public static void FindByAuthor()
        {
            Console.WriteLine("Введите автора книги");
            ShowBooks(controller.FindAll(Console.ReadLine(), Controller.OpType.Author));
        }

        public static void SortByName()
        {
            ShowBooks(controller.Sort(Controller.OpType.Name));
        }

        public static void SortByAuthor()
        {
            ShowBooks(controller.Sort(Controller.OpType.Author));
        }

        public static void ShowBooks(IEnumerable<Book> list)
        {
            foreach (var book in list)
                Console.WriteLine(book);
        }

        public static Book BookEnter()
        {
            Book book = new Book();
            Console.WriteLine("Введите название книги");
            book.Name = Console.ReadLine();
            Console.WriteLine("Введите автора книги");
            book.Author = Console.ReadLine();
            Console.WriteLine("Введите количество страниц:");
            int number = 0;
            int.TryParse(Console.ReadLine(), out number);
            book.PageNumber = number;
            return book;
        }

        static void Main(string[] args)
        {
            int command = 0;
            while (command >= 0 && command < 8)
            {
                switch ((Command) command)
                {
                    case Command.ShowMenu:
                        ShowMenu();
                        break;
                    case Command.AddBook:
                        AddBook();
                        break;
                    case Command.DeleteBook:
                        DeleteBook();
                        break;
                    case Command.ShowAllBooks:
                        ShowAllBooks();
                        break;
                    case Command.FindByAuthor:
                        FindByAuthor();
                        break;
                    case Command.FindByName:
                        FindByName();
                        break;
                    case Command.SortByName:
                        SortByName();
                        break;
                    case Command.SortByAuthor:
                        SortByAuthor();
                        break;
                    case Command.Exit:
                        return;

                }
                Console.WriteLine("Введите номер команды");
                string strCommand = Console.ReadLine();
                if (!int.TryParse(strCommand, out command))
                    break;
            }
            Console.WriteLine("Press enter to exit...");
            Console.ReadLine();
        }
    }
}
