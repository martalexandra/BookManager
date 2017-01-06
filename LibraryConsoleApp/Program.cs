using BookManagerLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookManagerConsoleApp
{
    class Program
    {
        private static readonly Library _library = new Library();
        static void Main(string[] args)
        {
            while (true)
            {
                var arguments = Console.ReadLine().Split(' ');
                switch (arguments[0])
                {
                    case "add":
                        Add(arguments);
                        break;
                    case "remove":
                        Remove(arguments);
                        break;
                    default:
                        List(arguments);
                        break;
                }
            }
        }

        private static void List(string[] args)
        {
            foreach (Book book in _library.Books.Values)
            {
                Console.WriteLine(book.ToString());
            }
        }

        private static void Add(string[] args)
        {
            _library.AddBook(new Book(args[1], args[2], new List<string> { args[3] }, args[4]));
        }

        private static void Remove(string[] args)
        {
            _library.RemoveBook(args[1]);
        }


    }
}
