using System;
using System.Linq;
using HomesEngland.UseCase.GenerateDocument.Models;
using HomesEngland.UseCase.Models;

namespace HomesEngland.UseCase.GenerateDocument
{
    public class InputParser: IInputParser<GenerateDocumentsRequest>
    {
        public GenerateDocumentsRequest Parse(string[] args)
        {
            int? records = null;
            if (args != null && args.Length >= 2)
            {
                if (args.ElementAt(0).Equals("--records", StringComparison.OrdinalIgnoreCase) )
                {
                    var recordInput = args.ElementAtOrDefault(1);
                    records = int.Parse(recordInput);
                }
            }
            var request = new GenerateDocumentsRequest
            {
                Records = records
            };
            return request;
        }
    }
}
