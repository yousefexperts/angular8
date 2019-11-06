using DotNetCore.Validation;
using FluentValidation;

namespace DotNetCoreArchitecture.Model
{
    public class CatogryBaseValidator<T> : Validator<T> where T : CatogryModel
    {
        public CatogryBaseValidator()
        {
            RuleFor(x => x.CatogryId).NotEmpty();
            RuleFor(x => x.Description).NotEmpty();
        }
    }
}
