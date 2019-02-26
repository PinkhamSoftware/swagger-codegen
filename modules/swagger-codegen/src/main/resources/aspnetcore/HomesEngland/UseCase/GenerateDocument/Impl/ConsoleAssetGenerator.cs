using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using HomesEngland.UseCase.GenerateDocument.Models;
using HomesEngland.UseCase.GetDocument.Models;
using HomesEngland.UseCase.Models;
using Microsoft.Extensions.Logging;

namespace HomesEngland.UseCase.GenerateDocument.Impl
{
    public class ConsoleAssetGenerator : IConsoleGenerator
    {
        private readonly IInputParser<GenerateDocumentsRequest> _inputParser;
        private readonly IGenerateDocumentsUseCase _generateDocumentUseCase;
        private readonly ILogger<ConsoleAssetGenerator> _logger;

        public ConsoleAssetGenerator(IInputParser<GenerateDocumentsRequest> inputParser, IGenerateDocumentsUseCase generateDocumentUseCase, ILogger<ConsoleAssetGenerator> logger)
        {
            _inputParser = inputParser;
            _generateDocumentUseCase = generateDocumentUseCase;
            _logger = logger;
        }

        public async Task<IList<DocumentOutputModel>> ProcessAsync(string[] args)
        {
            IList<DocumentOutputModel> output = null;
            PrintHelper();
            try
            {
                var request = ValidateInput(args);

                var cancellationTokenSource = new CancellationTokenSource();

                var generatedRecords = await _generateDocumentUseCase.ExecuteAsync(request, cancellationTokenSource.Token).ConfigureAwait(false);

                Console.WriteLine($"Generated: {generatedRecords.RecordsGenerated.Count} records");

                output = generatedRecords.RecordsGenerated;
            }
            catch (System.Exception ex)
            {
                _logger.Log(LogLevel.Error,ex, ex.Message);
            }

            return output;
        }

        private GenerateDocumentsRequest ValidateInput(string[] args)
        {
            if (args == null)
            {
                _logger.Log(LogLevel.Information, "Please enter input '--records {numberOfRecordsToGenerate}'");
                throw new ArgumentNullException(nameof(args));
            }

            GenerateDocumentsRequest request = _inputParser.Parse(args);
            
            if (!IsValidRequest(request))
            {
                throw new ArgumentException();
            }
            
            return request;
        }

        bool IsValidRequest(GenerateDocumentsRequest request)
        {
            if (request?.Records == null)
            {
                return false;  
            }

            return request.Records > 0;
        }
        private void PrintHelper()
        {
            _logger.Log(LogLevel.Information, "Welcome to the Asset Test Data Generator");
            _logger.Log(LogLevel.Information, "To generate assets please input:");
            _logger.Log(LogLevel.Information, "'--records {numberOfRecords}'");
        }
    }
}
