using WebApi.Interface;

namespace WebApi.Extensions.Requests
{
    public class GetDocumentApiRequest:IApiRequest
    {
        public int? Id { get; set; }

        public bool IsValid()
        {
            return Id != null && !(Id <= 0);
        }
    }
}
