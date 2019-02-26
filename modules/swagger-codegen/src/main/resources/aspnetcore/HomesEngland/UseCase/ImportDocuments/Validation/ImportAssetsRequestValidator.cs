using FluentValidation;
using HomesEngland.UseCase.ImportDocuments.Models;

namespace HomesEngland.UseCase.ImportDocuments.Validation
{
    public class ImportAssetsRequestValidator : AbstractValidator<ImportAssetsRequest>
    {
        public ImportAssetsRequestValidator()
        {
            RuleFor(r => r.AssetLines).NotNull().NotEmpty();
            RuleFor(r => r.Delimiter).NotNull().NotEmpty();
        }
    }
}
