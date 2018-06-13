using eKnjiznica.Commons.ViewModels.Books;
using eKnjiznica.CORE.Repository;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace eKnjiznica.CORE.Services.Documents
{
    public class DocumentService : IDocumentService
    {
        private IBookRepo bookRepo;
        IList<string> AllowedFileExtensions = new List<string> { ".pdf" };
        IList<string> AllowedImageExtensions = new List<string> { ".img",".jpg",".jpeg" };

        public DocumentService(IBookRepo bookRepo)
        {
            this.bookRepo = bookRepo;
        }

        public string GetRelativeDirectoryPath(BooksVM book)
        {
            return $"uploads/books/{book.BookTitle}_{book.AuthorName}/";
        }
        public string GetFullDirectoryPath(BooksVM book)
        {
            var path = HttpRuntime.AppDomainAppPath;
            return Path.Combine(path, GetRelativeDirectoryPath(book));
        }
        private bool IsValidFile(HttpPostedFile postedFile, IList<string> allowedExtensions)
        {
            if (postedFile == null || postedFile.ContentLength <= 0)
            {
                return false;
            }

            var ext = postedFile.FileName.Substring(postedFile.FileName.LastIndexOf('.'));
            var extension = ext.ToLower();

            int MaxContentLength = 1024 * 1024 * 100; //Size = 10 MB  
            if (!allowedExtensions.Contains(extension))
            {
                return false;
            }
            else if (postedFile.ContentLength > MaxContentLength)
            {
                return false;
            }


            return true;
        }

        public async Task<bool> SaveFile(HttpPostedFile postedFile, int bookId)
        {
            if (!IsValidFile(postedFile,AllowedFileExtensions))
                return false;

            var book = bookRepo.GetBookById(bookId);

            //create file and directory names
            //knjga.pdf
            var uploadedFileName = postedFile.FileName.Trim('\"');
            //c:/users/uploads
            var fullDirectoryPath = GetFullDirectoryPath(book);
            //c:/users/uploads/knjiga.pdf
            var fullFileName = Path.Combine(fullDirectoryPath, uploadedFileName);
            //~/uploads/knjiga.pdf
            var relativePath = Path.Combine(GetRelativeDirectoryPath(book) + uploadedFileName);

            Directory.CreateDirectory(fullDirectoryPath);

            await Task.Run(() =>
            {
                postedFile.SaveAs(fullFileName);
                bookRepo.SaveFilePath(book, relativePath, uploadedFileName);
            });
            return true;
        }
        public async Task<bool> SaveImageFile(HttpPostedFile postedFile, int bookId)
        {
            if (!IsValidFile(postedFile,AllowedImageExtensions))
                return false;

            var book = bookRepo.GetBookById(bookId);

            //create file and directory names
            //knjga.pdf
            var uploadedFileName = postedFile.FileName.Trim('\"');
            //c:/users/uploads
            var fullDirectoryPath = GetFullDirectoryPath(book);
            //c:/users/uploads/knjiga.pdf
            var fullFileName = Path.Combine(fullDirectoryPath, uploadedFileName);
            //~/uploads/knjiga.pdf
            var relativePath = Path.Combine(GetRelativeDirectoryPath(book) + uploadedFileName);

            Directory.CreateDirectory(fullDirectoryPath);

            await Task.Run(() =>
            {
                postedFile.SaveAs(fullFileName);
                bookRepo.SaveImageFilePath(book, relativePath, uploadedFileName);
            });
            return true;
        }

        public string GetFileAbsolutePath(int id)
        {
            var book = bookRepo.GetBookById(id);
            return AppDomain.CurrentDomain.BaseDirectory + "/" + book.FileLocation;
        }

        public string GetImageAbsolutePath(int id)
        {
            var book = bookRepo.GetBookById(id);
            return AppDomain.CurrentDomain.BaseDirectory + "/" + book.ImageLocation;
        }
    }
}
