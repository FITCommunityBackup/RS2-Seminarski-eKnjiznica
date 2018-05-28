using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Configuration;
using System.Web.Http;
using eKnjiznica.CORE.Services.Documents;

namespace eKnjiznica.API.Controllers
{
    [RoutePrefix("api/books/{id}/files")]
    public class BookFilesController : BaseController
    {

        private IDocumentService documentService;

        public BookFilesController(IDocumentService documentService)
        {
            this.documentService = documentService;
        }
        [HttpPost]
        [Route("")]
        public async Task<IHttpActionResult> MediaUpload(int id)
        {
            var httpRequest = HttpContext.Current.Request;
            foreach (string file in httpRequest.Files)
            {
                var postedFile = httpRequest.Files[file];
                var result = await documentService.SaveFile(postedFile, id);
                if(!result)
                    return BadRequest();
                
            }
            return Ok();
        }

    }
}
