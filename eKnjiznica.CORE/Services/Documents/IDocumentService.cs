using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace eKnjiznica.CORE.Services.Documents
{
    public interface IDocumentService
    {
        Task<bool> SaveFile(HttpPostedFile  file, int bookId);
        string GetFileAbsolutePath(int id);
    }
}
