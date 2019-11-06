using DotNetCore.Validation;
using FluentValidation;

namespace DotNetCoreArchitecture.Model
{
    public class CatogryAddValidator : CatogryBaseValidator<CatogryModel>
    {
        public CatogryAddValidator()
        {
            RuleFor(x => x.CatogryId).NotEmpty();
            RuleFor(x => x.Description).NotEmpty();
        }
    }
}
