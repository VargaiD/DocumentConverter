using Autofac;
using DocumentConverter.API.Helpers;
using DocumentConverter.API.Models;
using DocumentConverter.Business.Modules;
using DocumentConverter.Data.Models;
using DocumentConverter.Shared.Exceptions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Text;

namespace DocumentConverter.API.Controllers
{
    [ApiController]
    [Route("document")]
    public class DocumentConverterController : Controller
    {
        // GET: DocumentConverterController
        [HttpGet]
        public ActionResult Get([FromQuery] DocumentLoadModel request)
        {
            try
            {
                var documentModule = DependencyHelper.Container.Resolve<IDocumentModule>();
                var file = documentModule.LoadFile(request.Location, request.LocationType, request.Format, DependencyHelper.Container);
                return File(Encoding.ASCII.GetBytes(file.Content), "text/plain");
            }
            catch (Exception ex)
            {
                return MakeResponseFromException(ex);
            }
        }

        // POST: DocumentConverterController/Create
        [HttpPost]
        public ActionResult Create([FromQuery] DocumentSaveModel request, [FromForm] IFormFile content)
        {
            try
            {
                var documentModule = DependencyHelper.Container.Resolve<IDocumentModule>();
                documentModule.SaveFile(new RawDocumentModel(ReadIncomingFile(content), request.SourceFormat), request.Location, request.LocationType, request.TargetFormat, DependencyHelper.Container);
                return StatusCode(200);
            }
            catch (Exception ex)
            {
                return MakeResponseFromException(ex);
            }
        }

        private string ReadIncomingFile(IFormFile file)
        {
            if (file.Length > 0)
            {
                var result = new StringBuilder();
                using (var reader = new StreamReader(file.OpenReadStream()))
                {
                    while (reader.Peek() >= 0)
                        result.AppendLine(reader.ReadLine());
                }
                return result.ToString();
            }
            throw new DocumentConverterValidationException("File you are trying to upload is empty!");
        }

        private ActionResult MakeResponseFromException(Exception ex)
        {
            if (ex is DocumentConverterValidationException or DocumentConverterValidationNullException)
            {
                return StatusCode(400, new { Message = ex.Message }); // all errors should be translated and stored as keys ideally
            }
            else
            {
                return StatusCode(500);
            }
        }
    }
}
