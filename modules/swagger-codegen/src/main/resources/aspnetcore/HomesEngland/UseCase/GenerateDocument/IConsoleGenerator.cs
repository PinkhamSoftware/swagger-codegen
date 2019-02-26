using System.Collections.Generic;
using System.Threading.Tasks;
using HomesEngland.UseCase.GetDocument.Models;

namespace HomesEngland.UseCase.GenerateDocument
{
    public interface IConsoleGenerator
    {
        Task<IList<DocumentOutputModel>> ProcessAsync(string[] args);
    }
}
