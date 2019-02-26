using System;
using System.Linq;
using HomesEngland.UseCase.ImportDocuments.Models;
using HomesEngland.UseCase.Models;

namespace HomesEngland.UseCase.ImportDocuments.Impl
{
    public class ImportAssetInputParser : IInputParser<ImportAssetConsoleInput>
    {
        public ImportAssetConsoleInput Parse(string[] args)
        {
            string delimiter = null;
            string path = null;
            if (args != null && args.Length == 4)
            {
                if (args.ElementAt(0).Equals("--file", StringComparison.OrdinalIgnoreCase))
                {
                    path = args.ElementAtOrDefault(1);
                }
                if (args.ElementAt(2).Equals("--delimiter", StringComparison.OrdinalIgnoreCase))
                {
                    delimiter = args.ElementAtOrDefault(3);
                }
            }
            var request = new ImportAssetConsoleInput
            {
                Delimiter = delimiter,
                FilePath = path
            };
            return request;
        }
    }
}
