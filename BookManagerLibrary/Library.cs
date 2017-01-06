using System.Collections.Generic;

namespace BookManagerLibrary
{
    public class Library
    {
        public Dictionary<string, Book> Books { get; set; } = new Dictionary<string, Book>();
        public int NumberOfBooks { get; set; } = 0;

        public bool AddBook(Book book)
        {
            bool canBeAdded = !Books.ContainsKey(book.Isbn);
            if (canBeAdded) {
                Books.Add(book.Isbn, book);
            };
            return canBeAdded;
        }

        public bool RemoveBook(string isbn)
        {
            bool existed = Books.ContainsKey(isbn);
            if (existed)
            {
                Books.Remove(isbn);
            };
            return existed;
        }
    }
}
