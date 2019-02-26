using System.Collections.Generic;

namespace HomesEngland.UseCase.ImportDocuments
{
    public interface ITextSplitter
    {
        IList<string> SplitIntoLines(string text);
    }
}
