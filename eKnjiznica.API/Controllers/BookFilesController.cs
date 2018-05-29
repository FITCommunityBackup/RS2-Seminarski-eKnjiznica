using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.IO;
using System.Web;
using eKnjiznica.CORE.Services.Documents;
using System.Net.Http.Headers;
using System;
using eKnjiznica.DAL.EF;

namespace eKnjiznica.API.Controllers
{
    [Authorize(Roles = EntityRoles.AdminRole)]
    [RoutePrefix("api/books/{id}/files")]
    public class BookFilesController : BaseController
    {

        private IDocumentService documentService;

        public BookFilesController(IDocumentService documentService)
        {
            this.documentService = documentService;
        }

        [HttpGet]
        [Route("")]
        public HttpResponseMessage GetFile(int id)
        {
            string path = documentService.GetFileAbsolutePath(id);
            HttpResponseMessage result = new HttpResponseMessage(HttpStatusCode.OK);
            var stream = new FileStream(path, FileMode.Open);
            result.Content = new StreamContent(stream);
            result.Content.Headers.ContentDisposition = new ContentDispositionHeaderValue("attachment");
            result.Content.Headers.ContentDisposition.FileName = Path.GetFileName(path);
            result.Content.Headers.ContentType = new MediaTypeHeaderValue("application/octet-stream");
            result.Content.Headers.ContentLength = stream.Length;
            return result;
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
                if (!result)
                    return BadRequest();

            }
            return Ok();
        }

    }
}
