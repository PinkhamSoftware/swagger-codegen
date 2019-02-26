using System.IO;
using System.Threading;
using System.Threading.Tasks;

namespace HomesEngland.UseCase.ImportDocuments.Impl
{
    public class TextFileReader : IFileReader<string>
    {
        public async Task<string> ReadAsync(string absoluteFilePath, CancellationToken cancellationToken)
        {
            var exists = File.Exists(absoluteFilePath);
            if(!exists)
                throw new FileNotFoundException(absoluteFilePath);
            var text = await File.ReadAllTextAsync(absoluteFilePath, cancellationToken).ConfigureAwait(false);
            return text;
        }
    }
}
