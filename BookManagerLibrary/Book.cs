using System;
using System.Collections.Generic;
using System.Linq;

namespace BookManagerLibrary
{
    public class Book
    {
        public string Isbn { get; private set; }

        public string Title { get; internal set; }
        public string SubTitle { get; internal set; }
        public IEnumerable<string> Authores { get; internal set; } = new List<String>();
        public string Publisher { get; internal set; }
        public int Edition { get; internal set; }
        public int Year { get; internal set; }
        public EditionType Type { get; internal set; }

        internal Book(string isbn)
        {
            Isbn = isbn;
        }

        public Book (string isbn, string title, List<String> authores, string publisher)
        {
            Isbn = isbn;
            Title = title;
            Authores = authores;
            Publisher = publisher;
        }

        public override bool Equals(object obj)
        {
            return obj != null && Equals(obj as Book);
        }

        public bool Equals (Book book)
        {
            return book.Isbn.Equals(Isbn);
        }

        public override int GetHashCode()
        {
           return 31 * Isbn.GetHashCode();
        }

        public override string ToString()
        {
            return $"{Title} {SubTitle ?? string.Empty} {Authores.First()} {Publisher} {Edition} {Year} {Type}";
        }

        internal bool IsEditionOf(Book otherBook)
        {
            return Title.Equals(otherBook.Title)
                && (SubTitle?.Equals(otherBook.SubTitle) ?? otherBook.SubTitle == null)
                && Authores.SequenceEqual(otherBook.Authores)
                && Publisher.Equals(otherBook.Publisher);
        }
    }
}
