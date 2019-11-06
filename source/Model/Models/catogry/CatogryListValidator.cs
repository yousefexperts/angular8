using DotNetCore.Validation;
using FluentValidation;

namespace DotNetCoreArchitecture.Model
{
    public class CatogryListValidator : ValidatorBaseListCatogry<CatogryItemModel>
    {
        public CatogryListValidator()
        {
            RuleFor(x => x.Value).NotEmpty();
            RuleFor(x => x.Description).NotEmpty();
        }
    }
}
