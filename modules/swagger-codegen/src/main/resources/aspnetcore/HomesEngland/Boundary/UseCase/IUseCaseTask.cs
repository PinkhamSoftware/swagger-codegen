using System.Threading.Tasks;

namespace HomesEngland.Boundary.UseCase
{
    public interface IUseCaseTask<in TRequest, TResponse>
    {
        Task<TResponse> ExecuteAsync(TRequest request);
    }
}
