using DotNetCore.Validation;
using FluentValidation;

namespace DotNetCoreArchitecture.Model
{
    public class ValidatorBaseListCatogry<T> : Validator<T> where T : CatogryItemModel
    {
        public ValidatorBaseListCatogry()
        {
            RuleFor(x => x.Value).NotEmpty();
            RuleFor(x => x.Description).NotEmpty();
        }
    }

}
