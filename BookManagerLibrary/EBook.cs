using System;
using System.Collections.Generic;

namespace BookManagerLibrary
{
    public class EBook : Book
    {
        // Additional eBook properties
        public string FileFormat { get; set; } // e.g., EPUB, PDF, MOBI
        public double FileSizeInMB { get; set; } // Size of the file in megabytes
        public string DownloadURL { get; set; } // URL to download the eBook
        public bool IsDRMProtected { get; set; } // Flag to indicate DRM protection

        // Constructor that includes new properties
        public EBook(
            string isbn,
            string title,
            List<string> authores,
            string publisher,
            string fileFormat,
            double fileSizeInMB,
            string downloadURL,
            bool isDRMProtected
        ) : base(isbn, title, authores, publisher)
        {
            FileFormat = fileFormat ?? throw new ArgumentNullException(nameof(fileFormat));
            FileSizeInMB = fileSizeInMB;
            DownloadURL = downloadURL ?? throw new ArgumentNullException(nameof(downloadURL));
            IsDRMProtected = isDRMProtected;
        }

        // Override ToString to print the information for EBook
        public override string ToString()
        {
            return base.ToString() + $" | Format: {FileFormat} | Size: {FileSizeInMB} MB | DRM: {IsDRMProtected}";
        }

        // Override Equals to include eBook-specific properties in comparisons
        public override bool Equals(object obj)
        {
            if (base.Equals(obj) && obj is EBook otherEBook)
            {
                return FileFormat == otherEBook.FileFormat &&
                       FileSizeInMB == otherEBook.FileSizeInMB &&
                       DownloadURL == otherEBook.DownloadURL &&
                       IsDRMProtected == otherEBook.IsDRMProtected;
            }
            return false;
        }

        // Override GetHashCode to include eBook-specific properties
        public override int GetHashCode()
        {
            return HashCode.Combine(base.GetHashCode(), FileFormat, FileSizeInMB, DownloadURL, IsDRMProtected);
        }
    }
}
