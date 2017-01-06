using BookManagerLibrary;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTests
{
    [TestFixture]
    public class BookTests
    {
        Book modelBook = new Book("978-0-13-708107-3")
        {
            Title = "The Clean Coder",
            SubTitle = "A Code of Conduct for Professional Programmers",
            Authores = new HashSet<string> { "Robert C. Martin" },
            Edition = 1,
            Year = 2011,
            Publisher = "Prenctice Hall",
            Type = EditionType.Paperback
        };

        [Test]
        public void ShouldBeEqual()
        {
            Book equalBook = new Book("978-0-13-708107-3");
            Assert.That(equalBook, Is.EqualTo(modelBook));
        }

        [Test]
        public void ShouldNotBeEqual()
        {
            Book differentBook = new Book("1234")
            {
                Title = "The Clean Coder",
                SubTitle = "A Code of Conduct for Professional Programmers",
                Authores = new HashSet<string> { "Robert C. Martin" },
                Edition = 1,
                Year = 2011,
                Publisher = "Prenctice Hall",
                Type = EditionType.Paperback
            };
            Assert.That(differentBook, Is.Not.EqualTo(modelBook));
        }

        [TestCase(2011, 1, EditionType.Paperback)]
        [TestCase(2012, 1, EditionType.Paperback)]
        [TestCase(2011, 2, EditionType.Paperback)]
        [TestCase(2011, 1, EditionType.Hardcover)]
        public void IsEditionOf_IsTrue_IfOnlyTypeEditionOrYearAreDifferent(int edition, int year, EditionType type)
        {
            Book anotherEditionOfBook = new Book("1234")
            {
                Title = "The Clean Coder",
                SubTitle = "A Code of Conduct for Professional Programmers",
                Authores = new HashSet<string> { "Robert C. Martin" },
                Edition = edition,
                Year = year,
                Publisher = "Prenctice Hall",
                Type = type
            };
            Assert.That(anotherEditionOfBook, Is.Not.EqualTo(modelBook));
            Assert.That(anotherEditionOfBook.IsEditionOf(modelBook), Is.True);
            Assert.That(modelBook.IsEditionOf(anotherEditionOfBook), Is.True);
        }

        
        [Test]
        public void IsEditionOf_IsTrue_WhenSubtitleNotSetForBoth()
        {
            Book book = new Book("1234")
            {
                Title = "The Clean Coder",
                SubTitle = null,
                Authores = new HashSet<string> { "Robert C. Martin" },
                Edition = 1,
                Year = 2015,
                Publisher = "Prenctice Hall",
                Type = EditionType.Paperback
            };
            Book anotherEditionOfBook = new Book("5678")
            {
                Title = "The Clean Coder",
                SubTitle = null,
                Authores = new HashSet<string> { "Robert C. Martin" },
                Edition = 2,
                Year = 2015,
                Publisher = "Prenctice Hall",
                Type = EditionType.Paperback
            };
            Assert.That(anotherEditionOfBook, Is.Not.EqualTo(book));
            Assert.That(anotherEditionOfBook.IsEditionOf(book), Is.True);
            Assert.That(book.IsEditionOf(anotherEditionOfBook), Is.True);
        }

        [TestCase("A Title", "A Code of Conduct for Professional Programmers", "Robert C. Martin", "Prenctice Hall")]
        [TestCase("The Clean Coder", "A Subtitle", "Robert C. Martin", "Prenctice Hall")]
        [TestCase("The Clean Coder", "A Code of Conduct for Professional Programmers", "An Author", "Prenctice Hall")]
        [TestCase("The Clean Coder", "A Code of Conduct for Professional Programmers", "Robert C. Martin", "A Publisher")]
        [TestCase("The Clean Coder", null, "Robert C. Martin", "A Publisher")]
        public void IsEditionOf_IsFalse_IfTitleSubtitleAuthoresOrPublisherAreDifferent(string title, string subtitle, string author, string publisher)
        {
            //Publisher???
            Book anotherBook = new Book("1234")
            {
                Title = title,
                SubTitle = subtitle,
                Authores = new HashSet<string> { author },
                Edition = 1,
                Year = 2011,
                Publisher = publisher,
                Type = EditionType.Paperback
            };
            Assert.That(anotherBook, Is.Not.EqualTo(modelBook));
            Assert.That(anotherBook.IsEditionOf(modelBook), Is.False);
            Assert.That(modelBook.IsEditionOf(anotherBook), Is.False);
        }
    }
}