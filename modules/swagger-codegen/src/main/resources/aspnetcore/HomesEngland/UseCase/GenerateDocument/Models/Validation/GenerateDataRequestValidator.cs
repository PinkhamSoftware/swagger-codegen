using FluentValidation;

namespace HomesEngland.UseCase.GenerateDocument.Models.Validation
{
    public class GenerateAssetsRequestValidator : AbstractValidator<GenerateDocumentsRequest>
    {
        public GenerateAssetsRequestValidator()
        {
            RuleFor(x => x).NotNull().WithMessage("Request must not be null");
            RuleFor(x => x.Records).NotNull().GreaterThan(0).WithMessage("Records must not be null and must be greater than 0.");
        }
    }
}
