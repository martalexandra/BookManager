using NUnit.Framework;
using BookManagerLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTests
{
    [TestFixture]
    public class LibraryTests
    {
        [Test]
        public void InsertShould_InsertBookIfNotPresent()
        {
            Book book = new Book("1234");
            Library library = new Library();
            bool added = library.AddBook(book);
            Assert.That(added);
            Assert.That(library.Books.Count, Is.EqualTo(1));
            Assert.That(library.Books["1234"].Equals(book));
        }

        [Test]
        public void InsertShouldNot_InsertBookIfAlreadyPresent()
        {
            Book book = new Book("1234");
            Library library = new Library();
            library.Books.Add(book.Isbn, book);

            bool added = library.AddBook(book);
            Assert.That(!added);
            Assert.That(library.Books.Count, Is.EqualTo(1));
        }

        [Test]
        public void RemoveBookShould_NotThroughErrorIfBookNotPresent()
        {
            Library library = new Library();
            bool removed = library.RemoveBook("1234");
            Assert.That(!removed);
        }

        [Test]
        public void InsertShould_RemoveBookIfPresent()
        {
            Book book = new Book("1234");
            Library library = new Library();
            library.Books.Add(book.Isbn, book);

            bool removed = library.RemoveBook("1234");
            Assert.That(removed);
            Assert.That(library.Books.Count, Is.EqualTo(0));
        }
    }
}
