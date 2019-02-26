using System.Threading;
using System.Threading.Tasks;

namespace HomesEngland.UseCase.ImportDocuments
{
    public interface IFileReader<T>
    {
        Task<T> ReadAsync(string absoluteFilePath, CancellationToken cancellationToken);
    }
}
