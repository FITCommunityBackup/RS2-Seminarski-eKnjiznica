using eKnjiznica.Commons;
using eKnjiznica.Commons.ViewModels;
using eKnjiznica.Commons.ViewModels.Auctions;
using eKnjiznica.Commons.ViewModels.Books;
using eKnjiznica.Commons.ViewModels.Category;
using eKnjiznica.Commons.ViewModels.Clients;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace eKnjiznica.Commons.API
{
    public interface IApiClient
    {
        Task<HttpResponseMessage> LoginUser(LoginVM loginVM);
        Task<HttpResponseMessage> LoadAminAccounts(string usernameFilter);
        Task<HttpResponseMessage> CreateAdminAccount(AdminAddVM adminAdd);
        Task<HttpResponseMessage> UpdateAdminAccount(AdminUpdateVM adminUpdateVM);
        Task<HttpResponseMessage> GetAuditLogs();
        Task<HttpResponseMessage> GetCategories(string categoryNameFilter,bool includeInactiveCategories);
        Task<HttpResponseMessage> GetAuctions(DateTime dateFrom, DateTime dateTo,bool includeInactive);
        Task<HttpResponseMessage> LoadClientAccounts(string v, bool @checked);
        Task<HttpResponseMessage> GetPurchaces(string v1, string v2, string v3);
        Task<HttpResponseMessage> CreateCategory(CategoryAddVM model);
        Task<HttpResponseMessage> UpdateCategory(CategoryUpdateVm categoryUpdateVm, int id);
        Task<HttpResponseMessage> GetTransactions(string username, string adminUsername);
        Task<HttpResponseMessage> GetBooks(string bookTitle, string authorName);
        Task<HttpResponseMessage> GetBookOffers(string bookTitle, string authorName,bool includeInactive);
        Task<HttpResponseMessage> CreateBook(CreateBookVM createBookVM);
        Task<HttpResponseMessage> UpdateBook(UpdateBookVM updateBook, int bookId);
        Task<HttpResponseMessage> UploadFile(Stream file, string fileName, int bookId);
        Task<HttpResponseMessage> GetBookFile(int id);
        Task<HttpResponseMessage> UpdateExistingBookOffer(UpdateBookOfferVM bookOfferUpdate, int id);
        Task<HttpResponseMessage> GetTransaction(int transactionId);
        Task<HttpResponseMessage> CreateBookOffer(CreateBookOfferVM bookOfferCreate);
        Task<HttpResponseMessage> UpdateClientAccount(ClientUpdateVM clientUpdateVM, string id);
        Task<HttpResponseMessage> CreateClientAccount(ClientAddVM clientAddVM);
        Task<HttpResponseMessage> MakePayInRequest(decimal value, string id);
        Task<HttpResponseMessage> GetClientBooks(string clientId);
        Task<HttpResponseMessage> UpdateAuction(AuctionUpdateVM auctionUpdateVM, int id);
        Task<HttpResponseMessage> CreateAuction(AuctionCreateVM auctionCreateVM);
        Task<HttpResponseMessage> UploadBookPicture(byte[] uploadImage, string imageName, int id);

        
    }
}
