using System.Threading.Tasks;
using HomesEngland.UseCase.GetDocument;
using HomesEngland.UseCase.GetDocument.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebApi.Extensions;
using WebApi.Extensions.Requests;

namespace WebApi.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class DocumentController : ControllerBase
    {
        private readonly IGetDocumentUseCase _documentUseCase;

        public DocumentController(IGetDocumentUseCase useCase)
        {
            _documentUseCase = useCase;
        }

        [HttpGet("{id}")]
        [Produces("application/json", "text/csv")]
        [ProducesResponseType(typeof(ResponseData<GetDocumentResponse>), 200)]
        public async Task<IActionResult> Get([FromRoute] GetDocumentApiRequest request)
        {
            if (!request.IsValid())
            {
                return StatusCode(400);
            }

            GetDocumentRequest getDocumentRequest = new GetDocumentRequest
            {
                Id = request.Id.Value
            };

            return this.StandardiseResponse<GetDocumentResponse, DocumentOutputModel>(
                await _documentUseCase.ExecuteAsync(getDocumentRequest).ConfigureAwait(false));
        }
    }
}
