﻿using eKnjiznica.Common.ViewModels.Books;
using eKnjiznica.Commons.ViewModels.Books;
using eKnjiznica.CORE.Repository;
using eKnjiznica.DAL.EF;
using eKnjiznica.DAL.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
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

        public BooksVM CreateBook(CreateBookVM model, string userId)
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

            return GetBookById(book.Id);

        }

        public BookOfferVM CreateBookOffer(CreateBookOfferVM model)
        {
            var bookOffer = new BookOffer
            {
                BookId = model.BookId,
                IsActive = true,
                OfferCreatedTime = DateTime.UtcNow,
                Price = model.Price
            };
            context.BookOffers.Add(bookOffer);
            context.SaveChanges();

            return GetBookOfferById(bookOffer.Id);
        }

        public BookOfferVM GetBookOfferById(int id,string userId=null)
        {
            return context.BookOffers
                .Where(x => x.Id == id)
                .Include(x => x.Book)
                .Include(x => x.Book.Categories)
                .Include(x => x.PurchasedBooks)
                .Select(bookOffermaper(userId))
                .FirstOrDefault();

        }

        public BooksVM GetBookById(int bookId)
        {
            return context
                  .Books
                  .Where(x => x.Id == bookId)
                  .Select(x => new BooksVM
                  {
                      Id = x.Id,
                      AuthorName = x.Autor,
                      BookTitle = x.Title,

                      Categories = x.Categories.Where(y => y.IsActive).Select(y => new Commons.ViewModels.Category.CategoryVM
                      {
                          Id = y.CategoryId,
                          CategoryName = y.Category.CategoryName,
                          IsActive = y.IsActive,
                      }).ToList(),
                      Description = x.Description,
                      IsActive = x.IsActive,
                      ReleaseDate = x.ReleaseDate,
                      FileLocation = x.FileLocation,
                      FileName = x.FileName,
                      ImageLocation = x.ImageLocation

                  }).FirstOrDefault();
        }

        public List<BookOfferVM> GetBookOffers(string title, string authorName, bool includeInactive)
        {
            return context.BookOffers
                 .Where(x => includeInactive || x.IsActive)
                 .Include(x => x.Book)
                 .Include(x => x.Book.Categories)
                 .Include(x => x.PurchasedBooks)
                  .Where(x => string.IsNullOrEmpty(title) || x.Book.Title.Contains(title))
                 .Where(x => string.IsNullOrEmpty(authorName) || x.Book.Autor.Contains(authorName))
                 .OrderBy(x => x.Book.Title)
                 .ThenByDescending(x => x.OfferCreatedTime)
                 .Select(bookOffermaper(null)).ToList();


        }

        private static System.Linq.Expressions.Expression<Func<BookOffer, BookOfferVM>> bookOffermaper(string userId)
        {
            return x => new BookOfferVM
            {
                Id = x.Id,
                AuthorName = x.Book.Autor,
                BookId = x.BookId,
                IsActive = x.IsActive,
                OfferCreatedDate = x.OfferCreatedTime,
                Price = x.Price,
                Title = x.Book.Title,
                BookReleaseDate = x.Book.ReleaseDate,
                Description = x.Book.Description,
                Categories = x.Book.Categories.Where(y => y.IsActive).Select(y => new Commons.ViewModels.Category.CategoryVM
                {
                    Id = y.CategoryId,
                    CategoryName = y.Category.CategoryName,
                    IsActive = y.IsActive,
                }).ToList(),
                ImageUrl = x.Book.ImageLocation,
                AverageRating=x.Book.BookRatings.Where(y=>y.IsActive).Average(y=>y.Rating),
                UserHasBook = userId == null ? false : x.PurchasedBooks.Any(y => y.UserId == userId),
                UserRating=userId==null || x.Book.BookRatings.Where(y=>y.IsActive && y.UserId==userId).Count()==0?
                0:x.Book.BookRatings.Where(y=>y.IsActive && y.UserId==userId).FirstOrDefault().Rating
            };
        }

        public List<BookOfferVM> GetBookOffersByCategory(int categoryId, string userId,string title=null)
        {
            return context.BookOffers
                     .Where(x => x.IsActive)
                     .Include(x => x.Book)
                     .Include(x => x.Book.Categories)
                     .Include(x => x.PurchasedBooks)
                     .Where(x=>string.IsNullOrEmpty(title) || x.Book.Title.Contains(title))
                     .Where(x => x.Book.Categories.Any(y => y.CategoryId == categoryId))
                     .OrderBy(x => x.Book.Title)
                     .ThenByDescending(x => x.OfferCreatedTime)
                     .Select(bookOffermaper(userId))
                     .ToList();
        }
        public List<BooksVM> GetBooks(string title, string authorName, bool includeInactive, int categoryId)
        {
            return context
                 .Books
                 .Where(x => x.IsActive || includeInactive)
                 .Where(x => string.IsNullOrEmpty(title) || x.Title.Contains(title))
                 .Where(x => string.IsNullOrEmpty(authorName) || x.Autor.Contains(authorName))
                 .Where(x => categoryId == 0 || x.Categories.Any(y => y.IsActive == true && y.CategoryId == categoryId))
                 .Select(x => new BooksVM
                 {
                     Id = x.Id,
                     AuthorName = x.Autor,
                     BookTitle = x.Title,
                     Categories = x.Categories.Where(y => y.IsActive).Select(y => new Commons.ViewModels.Category.CategoryVM
                     {
                         Id = y.CategoryId,
                         CategoryName = y.Category.CategoryName,
                         IsActive = y.IsActive,
                     }).ToList(),
                     Description = x.Description,
                     IsActive = x.IsActive,
                     ReleaseDate = x.ReleaseDate,
                     FileLocation = x.FileLocation,
                     FileName = x.FileName,
                     ImageLocation = x.ImageLocation
                 }).ToList();
        }

        public void SaveFilePath(BooksVM book, string relativePath, string fileName)
        {
            var result = context.Books.FirstOrDefault(x => x.Id == book.Id);
            result.FileLocation = relativePath;
            result.FileName = fileName;
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

        public void UpdateBookCategories(UpdateBookVM model, int id, string adminId)
        {
            var book = context.Books.FirstOrDefault(x => x.Id == id);
            if (book == null)
                return;

            var categories = context.BookCategories.Where(x => x.BookId == id).ToList();
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

        public void UpdateBookOffer(UpdateBookOfferVM model, int id)
        {
            var result = context.BookOffers.FirstOrDefault(x => x.Id == id);
            if (result == null)
                return;
            result.BookId = model.BookId;
            result.IsActive = model.IsActive;
            result.Price = model.Price;

            context.SaveChanges();
        }

        public void SaveImageFilePath(BooksVM book, string relativePath, string uploadedFileName)
        {
            var result = context.Books.FirstOrDefault(x => x.Id == book.Id);
            result.ImageLocation = relativePath;
            //result.ImageName = uploadedFileName;
            context.SaveChanges();
        }

        public BookOfferVM CreateAuctionBookOffer(CreateAuctionBookOfferVM vm)
        {
            var bookOffer = new BookOffer
            {
                BookId = vm.BookId,
                IsActive = false,
                OfferCreatedTime = DateTime.UtcNow,
                Price = vm.Price
            };
            context.BookOffers.Add(bookOffer);
            context.SaveChanges();
            return GetBookOfferById(bookOffer.Id);
        }


        public List<BookOfferVM> GetTopSellingBooksInCategories(List<int> categoryId, string userId)
        {
            var bookOffers = context.BookOffers
                        .Where(x => x.IsActive)
                .Include(x => x.Book.Categories)
                          .Where(x => !x.PurchasedBooks.Any(y => y.UserId == userId && y.BookOfferId == x.Id))
                          .Where(x => x.Book.Categories.Any(y => y.IsActive && categoryId.Contains(y.CategoryId)))
                          .Include(x => x.Book)
                          .Include(x => x.PurchasedBooks)
                          .OrderByDescending(x => x.PurchasedBooks.Count)
                          .Select(bookOffermaper(userId))
                          .ToList();
            return bookOffers;
        }

        public List<BookOfferVM> GetTopSellingBooks(List<int> alreadyAddedBooks, string userId, int neededBookNumber)
        {
            var bookOffers =
                context.BookOffers
                       .Where(x => x.IsActive)
                       .Where(x => !x.PurchasedBooks.Any(y => y.UserId == userId && y.BookOfferId == x.Id))
                       .Where(x => !alreadyAddedBooks.Contains(x.Id))
                       .Include(x => x.Book)
                       .Include(x => x.PurchasedBooks)
                       .Include(x => x.Book.Categories)
                       .OrderByDescending(x => x.PurchasedBooks.Count)
                       .Take(neededBookNumber - alreadyAddedBooks.Count())
                       .Select(bookOffermaper(userId))
                       .ToList();

            return bookOffers;
        }

        public List<BookOfferVM> GetTopSellingBooks(string userId = null)
        {

            var bookOffers =
                context.BookOffers
                       .Where(x => x.IsActive)
                       .Include(x => x.Book)
                       .Include(x => x.PurchasedBooks)
                       .Include(x => x.Book.Categories)
                       .OrderByDescending(x => x.PurchasedBooks.Count)
                       .Take(100)
                       .Select(bookOffermaper(userId))
                       .ToList();


            return bookOffers;
        }

        public List<BookOfferVM> GetUserRatedBooks(string userId)
        {

            return context.BookOffers
                .Where(x => x.IsActive)
                .Where(x => x.Book.BookRatings.Any(y => y.IsActive && y.UserId == userId))
                .Select(bookOffermaper(userId))
                .ToList();
        }

        public List<BookOfferVM> GetUserMissingBookOffers(string userId)
        {
            return context.BookOffers
               .Where(x => x.IsActive)
               .Where(x=>!x.PurchasedBooks.Any(y=>y.UserId==userId))
               .Select(bookOffermaper(userId))
               .ToList();
        }
    }
}
