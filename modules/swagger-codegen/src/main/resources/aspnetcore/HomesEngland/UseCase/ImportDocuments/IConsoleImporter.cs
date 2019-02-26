using System.Collections.Generic;
using System.Threading.Tasks;
using HomesEngland.UseCase.GetDocument.Models;

namespace HomesEngland.UseCase.ImportDocuments
{
    public interface IConsoleImporter
    {
        Task<IList<DocumentOutputModel>> ProcessAsync(string[] args);
    }
}
