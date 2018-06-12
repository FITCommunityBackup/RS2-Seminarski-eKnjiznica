using eKnjiznica.Commons.ViewModels.ClientBook;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eKnjiznica.CORE.Repository
{
    public interface IClientBooksRepo
    {
        List<ClientBookVM> GetClientBooks(string userId);
        List<ClientBookVM> GetClientBooks(string title, string author, string user);
    }
}
