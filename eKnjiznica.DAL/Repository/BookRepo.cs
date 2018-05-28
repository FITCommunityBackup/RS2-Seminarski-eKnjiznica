using eKnjiznica.Commons.ViewModels.Books;
using eKnjiznica.CORE.Repository;
using eKnjiznica.DAL.EF;
using eKnjiznica.DAL.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eKnjiznica.DAL.Repository
{
    public class BookRepo : IBookRepo
    {
        private EF.EKnjiznicaDB context;

        public BookRepo(EKnjiznicaDB context)
        {
            this.context = context;
        }

        public void CreateBook(CreateBookVM model, string userId)
        {
            var book = new Book
            {
                Title = model.BookTitle,
                Description = model.BookDescription,
                UserId = userId,
                Autor = model.AuthorName,
                IsActive = true,
                ReleaseDate = model.ReleaseDate
            };

            ICollection<Category> categories = context.Categories.Where(x => model.CategoriesId.Contains(x.Id)).ToList();
            context.Books.Add(book);
            context.SaveChanges();
            foreach (var item in categories)
            {
                context.BookCategories.Add(new BookCategories
                {
                    UserId = userId,
                    CategoryId = item.Id,
                    Created = DateTime.UtcNow,
                    IsActive = true,
                    BookId = book.Id
                });
            }
            context.SaveChanges();

        }

        public BooksVM GetBookById(int bookId)
        {
            throw new NotImplementedException();
        }

        public List<BooksVM> GetBooks(string title, string authorName)
        {
            return context
                 .Books
                 .Where(x => string.IsNullOrEmpty(title) || x.Title.Contains(title))
                 .Where(x => string.IsNullOrEmpty(authorName) || x.Autor.Contains(authorName))
                 .Select(x => new BooksVM
                 {
                     Id = x.Id,
                     AuthorName = x.Autor,
                     BookTitle = x.Title,
                     Categories = x.Categories.Where(y=>y.IsActive).Select(y => new Commons.ViewModels.Category.CategoryVM {
                         Id = y.CategoryId,
                         CategoryName = y.Category.CategoryName,
                         IsActive = y.IsActive,
                     }).ToList(),
                     Description = x.Description,
                     IsActive = x.IsActive,
                     ReleaseDate = x.ReleaseDate

                 }).ToList();
        }

        public void SaveFilePath(BooksVM book, string relativePath)
        {
            var result =context.Books.FirstOrDefault(x => x.Id == book.Id);
            result.FileLocation = relativePath;
            context.SaveChanges();
        }

        public void UpdateBook(UpdateBookVM model, int id)
        {
            var book = context.Books.FirstOrDefault(x => x.Id == id);
            if (book == null)
                return;
            book.Title = model.BookTitle ?? book.Title;
            book.Description = model.BookDescription ?? book.Title;
            book.ReleaseDate = model.ReleaseDate ?? book.ReleaseDate;
            book.IsActive = model.IsActive;

            context.SaveChanges();

        }

        public void UpdateBookCategories(UpdateBookVM model, int id,string adminId)
        {
            var book = context.Books.FirstOrDefault(x => x.Id == id);
            if (book == null)
                return;

            var categories= context.BookCategories.Where(x => x.BookId == id).ToList();
            var userSelectedCategories = model.CategoriesId;

            //update old categories
            foreach (var item in categories)
            {
                if (userSelectedCategories.Any(x => x == item.CategoryId))
                {
                    userSelectedCategories.Remove(item.CategoryId);
                    item.IsActive = true;
                }
                else
                {
                    item.IsActive = false;
                }
            }
            //create new categories
            foreach (var item in userSelectedCategories)
            {
                context.BookCategories.Add(new Model.BookCategories
                {
                    BookId = id,
                    CategoryId = item,
                    Created = DateTime.UtcNow,
                    IsActive = true,
                    UserId = adminId
                });
            }

            context.SaveChanges();
        }
    }
}
