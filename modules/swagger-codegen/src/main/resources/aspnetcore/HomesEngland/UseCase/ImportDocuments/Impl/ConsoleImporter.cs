using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using HomesEngland.UseCase.GetDocument.Models;
using HomesEngland.UseCase.ImportDocuments.Models;
using HomesEngland.UseCase.Models;
using Microsoft.Extensions.Logging;

namespace HomesEngland.UseCase.ImportDocuments.Impl
{
    public class ConsoleImporter : IConsoleImporter
    {
        private readonly IImportAssetsUseCase _importAssetsUseCase;
        private readonly IInputParser<ImportAssetConsoleInput> _inputParser;
        private readonly IFileReader<string> _fileReader;
        private readonly ITextSplitter _textSplitter;
        private readonly ILogger<IConsoleImporter> _logger;

        public ConsoleImporter(IImportAssetsUseCase importAssetsUseCase, IInputParser<ImportAssetConsoleInput> inputParser,IFileReader<string> fileReader, ITextSplitter textSplitter, ILogger<IConsoleImporter> logger)
        {
            _importAssetsUseCase = importAssetsUseCase;
            _inputParser = inputParser;
            _fileReader = fileReader;
            _textSplitter = textSplitter;
            _logger = logger;
        }

        public async Task<IList<DocumentOutputModel>> ProcessAsync(string[] args)
        {
            ValidateConsoleInput(args);
            var parsedInput = _inputParser.Parse(args);
            
            var cancellationTokenSource = new CancellationTokenSource();

            var text = await _fileReader.ReadAsync(parsedInput.FilePath, cancellationTokenSource.Token).ConfigureAwait(false);

            var csvLines = _textSplitter.SplitIntoLines(text);

            var importAssetsRequest = new ImportAssetsRequest
            {
                Delimiter = parsedInput.Delimiter,
                AssetLines = csvLines
            };

            var response = await _importAssetsUseCase.ExecuteAsync(importAssetsRequest, cancellationTokenSource.Token).ConfigureAwait(false);

            return response?.AssetsImported;
        }

        private void ValidateConsoleInput(string[] args)
        {
            if (args == null)
            {
                _logger.Log(LogLevel.Information, "Please enter input '--file {absolutePathToFile} --delimiter {delimiter}'");
                throw new ArgumentNullException(nameof(args));
            }
        }
    }
}
