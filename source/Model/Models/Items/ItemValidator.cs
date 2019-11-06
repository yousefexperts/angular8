using DotNetCore.Validation;
using FluentValidation;

namespace DotNetCoreArchitecture.Model
{
    public class ItemValidator<T> : Validator<T> where T : ItemModel
    {
        public ItemValidator()
        {
            RuleFor(x => x.ItemName).NotEmpty();
            RuleFor(x => x.Description).NotEmpty();
            RuleFor(x => x.MaxNum).NotEmpty();
            RuleFor(x => x.MinNum).NotEmpty();
        }
    }
}
