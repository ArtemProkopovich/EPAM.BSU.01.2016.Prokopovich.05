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
            ChangeRepository,
            Save,
            Exit
        }

        public static void ShowMenu()
        {
            for (int i = 0; i < 11; i++)
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

        public static void ChangeRepository()
        {
            Console.WriteLine("Выберите вид репозитория:");
            Console.WriteLine("1-бинарный файл.");
            Console.WriteLine("2-бинарный файл с сериализацией.");
            Console.WriteLine("3-XML файл.");
            string c = Console.ReadLine();
            switch (c)
            {
                case "2":
                    controller.ChangeRepostiory(Controller.RepType.BinarySerializable);
                    break;
                case "3":
                    controller.ChangeRepostiory(Controller.RepType.XML);
                    break;
                default:
                    controller.ChangeRepostiory(Controller.RepType.Binary);
                    break;

            }
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

        public static void Save()
        {
            controller.Save();
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
            ChangeRepository();
            while (command >= 0 && command < 10)
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
                    case Command.ChangeRepository:
                        ChangeRepository();
                        break;
                    case Command.Save:
                        Save();
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
